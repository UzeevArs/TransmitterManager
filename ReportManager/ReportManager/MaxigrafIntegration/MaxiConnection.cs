using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using static ReportManager.MaxigrafIntegration.ClientPipeSettings;

namespace ReportManager.MaxigrafIntegration
{
    internal class MaxiConnection : IDisposable
    {
        public event ConnectionHandler ConnectionEventHandler;
        public event ReadHandler WriteEventHandler;
        public event WriteHandler ReadEventHandler;

        private readonly ClientPipeStreamFacade _clientPipe;
        private readonly ServerPipeStreamFacade _serverPipe;

        private readonly Thread _serverThread;

        public bool Alive { get { return _serverPipe.Alive; } }

        public MaxiConnection()
        {
            _serverThread = new Thread(ReadServerPipe);
            _clientPipe = new ClientPipeStreamFacade(Name);
            _serverPipe = new ServerPipeStreamFacade(ServerPipeSettings.Name);
        }

        public async Task<bool> ConnectAsync()
        {
            return await Task.Run(() =>
            {
                try
                {
                    WrapConnectionError(_clientPipe.Connect(),
                                        s => s != ConnectStatus.SuccessConnected,
                                        "Error in client pipe connection");

                    var readStatus = _clientPipe.Read();
                    WrapConnectionError(readStatus,
                                        s => s.Item1 != Status.Success,
                                        "Error in reading request \'Hello\' command from client pipe");

                    var command = Converter.ToAsciiString(readStatus.Item2);
                    WrapConnectionError(command,
                                        s => s != HelloRequest,
                                        "Error in parsing request \'Hello\' command from client pipe");

                    WrapConnectionError(_clientPipe.Send(Converter.ToAsciiBytes(HelloResponse)),
                                        s => s != Status.Success,
                                        "Error in sending response \'Hello\' command to client pipe");

                    WrapConnectionError(_serverPipe.StartListening(),
                                        s => s != ConnectStatus.SuccessConnected,
                                        "Error in accepting server pipe");

                    ConnectionSuccess();
                    return true;
                }
                catch (Exception ex)
                {
                    ConnectionError(ex.Message);
                    return false;
                }
            });
        }

        public async Task<bool> SendTextScriptAsync(string path)
        {
            return await Task.Run(() =>
            {
                try
                {
                    WrapWriteError(_serverPipe.Send(Converter.ToAsciiBytes(CommandsList[Commands.TxtFileStart])),
                                   status => status != Status.Success,
                                   "Error in sending text script initial command");

                    using (var stream = new StreamReader(path))
                        while (!stream.EndOfStream)
                            _serverPipe.Send(Converter.ToAsciiBytes(new StringBuilder()
                                .Append(stream.ReadLine())
                                .Append("*?")
                                .ToString()));

                    WrapWriteError(_serverPipe.Send(Converter.ToAsciiBytes(CommandsList[Commands.EndFile])),
                                   status => status != Status.Success,
                                   "Error in sending text script end file command");

                    var readStatus = _serverPipe.Read();
                    WrapReadError(readStatus,
                                  t => t.Item1 != Status.Success,
                                  "Error in reading status from client pipe");

                    WrapReadError(TryParseCommand(Converter.ToAsciiString(readStatus.Item2)),
                                  t => t != Commands.TxtSuccess,
                                  $"Error: {Converter.ToAsciiString(readStatus.Item2)}");

                    ReadSuccess();
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> SendLeScriptAsync(string path)
        {
            return await Task.Run(() =>
            {
                try
                {
                    WrapWriteError(_serverPipe.Send(Converter.ToAsciiBytes(CommandsList[Commands.LeFileStart])),
                                   status => status != Status.Success,
                                   "Error in sending le script initial command");
                    WriteMessage($"[Дата: {DateTime.Now}]. Отправлена команда {CommandsList[Commands.LeFileStart]}");

                    WriteMessage($"[Дата: {DateTime.Now}]. Открытие файла {path}. Существует ли файл: {File.Exists(path)}");
                    ulong counter = 0; 
                    using (var binaryStream = new BinaryReader(File.OpenRead(path)))
                        while (binaryStream.BaseStream.Position != binaryStream.BaseStream.Length)
                        {
                            _serverPipe.Send(binaryStream.ReadBytes(256));
                            counter++;
                            if (counter % 1000 == 0)
                                WriteMessage($"[Дата: {DateTime.Now}, {counter} итерация]. Отправлены 256 байт");
                        }
                    WriteMessage($"[Дата: {DateTime.Now}]. Общее количество итераций: {counter}");

                    WrapWriteError(_serverPipe.Send(Converter.ToAsciiBytes(CommandsList[Commands.EndFile])),
                                   status => status != Status.Success,
                                   "Error in sending le script end command");
                    WriteMessage($"[Дата: {DateTime.Now}]. Отправлена команда: {CommandsList[Commands.EndFile]}");


                    WriteMessage($"[Дата: {DateTime.Now}]. Ожидание ответа о статусе операции");
                    var readStatus = _serverPipe.Read();
                    WrapReadError(readStatus,
                                  t => t.Item1 != Status.Success,
                                  "Error in reading status from client pipe");

                    WriteMessage($"[Дата: {DateTime.Now}]. Статус: {Converter.ToAsciiString(readStatus.bytes)}");
                    WrapReadError(TryParseCommand(Converter.ToAsciiString(readStatus.bytes)),
                                  t => t != Commands.LeSuccess,
                                  $"Error: {Converter.ToAsciiString(readStatus.bytes)}");

                    ReadSuccess();
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> ShowCrossJoystickAsync()
        {
            return await Task.Run(() =>
            {
                try
                {
                    WrapWriteError(_serverPipe.Send(Converter.ToAsciiBytes(CommandsList[Commands.ShowCrossJoystick])),
                                   status => status != Status.Success,
                                   "Error in sending show cross joystick initial command");
                    WriteSuccess();
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> ShowRectJoystickAsync()
        {
            return await Task.Run(() =>
            {
                try
                {
                    WrapWriteError(_serverPipe.Send(Converter.ToAsciiBytes(CommandsList[Commands.ShowRectJoystick])),
                                   status => status != Status.Success,
                                   "Error in sending show rect joystick initial command");
                    WriteSuccess();
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> SetNewValueAsync(string path, string value)
        {
            return await Task.Run(() =>
            {
                try
                {
                    WrapWriteError(_serverPipe.Send(Converter.ToAsciiBytes(CommandsList[Commands.SetValue])),
                                   status => status != Status.Success,
                                   "Error in sending set new value command");

                    WrapWriteError(_serverPipe.Send(Converter.ToAsciiBytes($"{path}={value}")),
                                   status => status != Status.Success,
                                   $"Error in sending: {path}={value}");

                    var readStatus = _serverPipe.Read();
                    WrapReadError(readStatus,
                                  t => int.Parse(Converter.ToAsciiString(t.Item2)) != 0,
                                  $"Error in status from client pipe ({Converter.ToAsciiString(readStatus.Item2)})");

                    ReadSuccess();
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> StartMarkingAsync()
        {
            return await Task.Run(() =>
            {
                try
                {
                    WrapWriteError(_serverPipe.Send(Converter.ToAsciiBytes(CommandsList[Commands.StartMarking])),
                                   status => status != Status.Success,
                                   "Error in sending start marking initial command");
                    WriteSuccess();
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> StopMarkingAsync()
        {
            return await Task.Run(() =>
            {
                try
                {
                    WrapWriteError(_serverPipe.Send(Converter.ToAsciiBytes(CommandsList[Commands.StopMarking])),
                                   status => status != Status.Success,
                                   "Error in sending stop marking initial command");
                    WriteSuccess();
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public void StartReadServerPipe()
        {
            _serverThread.Start();
        }

        private void ReadServerPipe()
        {
            try
            {
                while (true)
                {
                    var data = _clientPipe.Read();
                    WrapReadError(data,
                                  t => t.Item1 != Status.Success,
                                  "Server pipe message reading error");
                    ReadSuccess(Converter.ToAsciiString(data.Item2));
                }
            }
            catch { }
        }

        public void Dispose()
        {
            try
            {
                _serverThread.Abort();
                _serverPipe.Send(Converter.ToAsciiBytes(CommandsList[Commands.Exit]));
                _clientPipe.Read();

                _clientPipe.Dispose();
                _serverPipe.Dispose();
            }
            catch { }
        }


        private void WrapReadError<T>(T result, Func<T, bool> compareFunctor, string message)
        {
            if (compareFunctor(result))
            {
                ReadError(message);
                throw new Exception(message);
            }
        }

        private void ReadError(string message)
        {
            ReadEventHandler?.Invoke(this, (Status.Error, message));
        }

        private void ReadSuccess(string message = "")
        {
            ReadEventHandler?.Invoke(this, (Status.Success, message));
        }


        private void WrapWriteError<T>(T result, Func<T, bool> compareFunctor, string message)
        {
            if (compareFunctor(result))
            {
                WriteError(message);
                throw new Exception(message);
            }
        }

        private void WriteError(string message)
        {
            WriteEventHandler?.Invoke(this, (Status.Error, message));
        }

        private void WriteMessage(string message)
        {
            WriteEventHandler?.Invoke(this, (Status.Message, message));
        }

        private void WriteSuccess(string message = "")
        {
            WriteEventHandler?.Invoke(this, (Status.Success, message));
        }


        private void WrapConnectionError<T>(T result, Func<T, bool> compareFunctor, string message)
        {
            if (compareFunctor(result))
            {
                ConnectionError(message);
                throw new Exception(message);
            }
        }

        private void ConnectionError(string message)
        {
            ConnectionEventHandler?.Invoke(this, (ConnectStatus.ConnectError, message));
        }

        private void ConnectionSuccess(string message = "")
        {
            ConnectionEventHandler?.Invoke(this, (ConnectStatus.SuccessConnected, message));
        }


        public delegate void ConnectionHandler(object sender, (ConnectStatus status, string message) status);

        public delegate void ReadHandler(object sender, (Status status, string message) status);

        public delegate void WriteHandler(object sender, (Status status, string message) status);
    }
}

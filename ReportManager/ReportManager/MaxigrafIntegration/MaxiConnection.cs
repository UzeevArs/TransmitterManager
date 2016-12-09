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
                                        s => s.Item1 != ReadWriteStatus.Success,
                                        "Error in reading request \'Hello\' command from client pipe");

                    var command = Converter.ToAsciiString(readStatus.Item2);
                    WrapConnectionError(command,
                                        s => s != HelloRequest,
                                        "Error in parsing request \'Hello\' command from client pipe");

                    WrapConnectionError(_clientPipe.Send(Converter.ToAsciiBytes(HelloResponse)),
                                        s => s != ReadWriteStatus.Success,
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
                        status => status != ReadWriteStatus.Success,
                        "Error in sending text script initial command");

                    using (var stream = new StreamReader(path))
                        while (!stream.EndOfStream)
                            _serverPipe.Send(Converter.ToAsciiBytes(new StringBuilder()
                                .Append(stream.ReadLine())
                                .Append("*?")
                                .ToString()));

                    WrapWriteError(_serverPipe.Send(Converter.ToAsciiBytes(CommandsList[Commands.EndFile])),
                        status => status != ReadWriteStatus.Success,
                        "Error in sending text script end file command");

                    var readStatus = _serverPipe.Read();
                    WrapReadError(readStatus,
                        t => t.Item1 != ReadWriteStatus.Success,
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
                        status => status != ReadWriteStatus.Success,
                        "Error in sending le script initial command");

                    using (var binaryStream = new BinaryReader(File.OpenRead(path)))
                        while (binaryStream.BaseStream.Position != binaryStream.BaseStream.Length)
                            _serverPipe.Send(binaryStream.ReadBytes(256));

                    WrapWriteError(_serverPipe.Send(Converter.ToAsciiBytes(CommandsList[Commands.EndFile])),
                        status => status != ReadWriteStatus.Success,
                        "Error in sending le script end command");


                    var readStatus = _serverPipe.Read();
                    WrapReadError(readStatus,
                        t => t.Item1 != ReadWriteStatus.Success,
                        "Error in reading status from client pipe");

                    WrapReadError(TryParseCommand(Converter.ToAsciiString(readStatus.Item2)),
                        t => t != Commands.LeSuccess,
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

        public async Task<bool> ShowCrossJoystickAsync()
        {
            return await Task.Run(() =>
            {
                try
                {
                    WrapWriteError(_serverPipe.Send(Converter.ToAsciiBytes(CommandsList[Commands.ShowCrossJoystick])),
                        status => status != ReadWriteStatus.Success,
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
                                    status => status != ReadWriteStatus.Success,
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
                                   status => status != ReadWriteStatus.Success,
                                   "Error in sending set new value command");

                    WrapWriteError(_serverPipe.Send(Converter.ToAsciiBytes($"{path}={value}")),
                                   status => status != ReadWriteStatus.Success,
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
                                    status => status != ReadWriteStatus.Success,
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
                                    status => status != ReadWriteStatus.Success,
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
                                  t => t.Item1 != ReadWriteStatus.Success,
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
            ReadEventHandler?.Invoke(this,
                new Tuple<ReadWriteStatus, string>(ReadWriteStatus.Error, message));
        }

        private void ReadSuccess(string message = "")
        {
            ReadEventHandler?.Invoke(this,
                new Tuple<ReadWriteStatus, string>(ReadWriteStatus.Success, message));
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
            WriteEventHandler?.Invoke(this,
                new Tuple<ReadWriteStatus, string>(ReadWriteStatus.Error, message));
        }

        private void WriteSuccess(string message = "")
        {
            WriteEventHandler?.Invoke(this,
                new Tuple<ReadWriteStatus, string>(ReadWriteStatus.Success, message));
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
            ConnectionEventHandler?.Invoke(this,
                new Tuple<ConnectStatus, string>(ConnectStatus.ConnectError, message));
        }

        private void ConnectionSuccess(string message = "")
        {
            ConnectionEventHandler?.Invoke(this,
                new Tuple<ConnectStatus, string>(ConnectStatus.SuccessConnected, message));
        }


        public delegate void ConnectionHandler(object sender, Tuple<ConnectStatus, string> status);

        public delegate void ReadHandler(object sender, Tuple<ReadWriteStatus, string> status);

        public delegate void WriteHandler(object sender, Tuple<ReadWriteStatus, string> status);
    }
}

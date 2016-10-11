using System;
using System.IO;
using System.Threading;

namespace ReportManager.MaxigrafIntegration
{
    public class MaxiConnection : IDisposable
    {
        public event ConnectionHandler ConnectionEventHandler;
        public event ReadHandler WriteEventHandler;
        public event WriteHandler ReadEventHandler;

        private ClientPipeStream _clientPipe;
        private ServerPipeStream _serverPipe;

        public MaxiConnection()
        {
            _clientPipe = new ClientPipeStream(ClientPipeSettings.Name);
            _serverPipe = new ServerPipeStream(ServerPipeSettings.Name);
        }

        public void Connect()
        {
            new Thread(delegate()
            {
                try
                {
                    var connectStatus = _clientPipe.Connect();
                    if (connectStatus != ConnectStatus.SuccessConnected)
                    {
                        ConnectionEventHandler?.Invoke(this,
                            new Tuple<ConnectStatus, string>(ConnectStatus.ConnectError,
                                "Error in client pipe connection"));
                        return;
                    }

                    var readStatus = _clientPipe.Read();
                    if (readStatus.Item1 != ReadWriteStatus.Success)
                    {
                        ConnectionEventHandler?.Invoke(this,
                            new Tuple<ConnectStatus, string>(ConnectStatus.ConnectError,
                                "Error in reading request \'Hello\' command " +
                                "from client pipe"));
                        return;
                    }
                    var command = Converter.ToAsciiString(readStatus.Item2);
                    if (ClientPipeSettings.HelloRequest != command)
                    {
                        ConnectionEventHandler?.Invoke(this,
                            new Tuple<ConnectStatus, string>(ConnectStatus.ConnectError,
                                "Error in parsing request \'Hello\' command " +
                                "from client pipe"));
                        return;
                    }

                    var writeStatus = _clientPipe.Send(Converter.ToAsciiBytes(ClientPipeSettings.HelloResponse));
                    if (writeStatus != ReadWriteStatus.Success)
                    {
                        ConnectionEventHandler?.Invoke(this,
                            new Tuple<ConnectStatus, string>(ConnectStatus.ConnectError,
                                "Error in sending response \'Hello\' command " +
                                "to client pipe"));
                        return;
                    }
                    var listenStatus = _serverPipe.StartListening();
                    if (listenStatus != ConnectStatus.SuccessConnected)
                    {
                        ConnectionEventHandler?.Invoke(this,
                            new Tuple<ConnectStatus, string>(ConnectStatus.ConnectError,
                                "Error in accepting server pipe"));
                        return;
                    }

                    ConnectionEventHandler?.Invoke(this,
                        new Tuple<ConnectStatus, string>(ConnectStatus.SuccessConnected, ""));
                }
                catch (Exception ex)
                {
                    ConnectionEventHandler?.Invoke(this, new Tuple<ConnectStatus, string>(ConnectStatus.ConnectError,
                        ex.Message));
                }

            }).Start();
        }

        public void SendScript()
        {
            new Thread(delegate()
            {
                try
                {
                    var startStatus = _serverPipe.Send(
                                        Converter.ToAsciiBytes(
                                            ClientPipeSettings.CommandsList[ClientPipeSettings.Commands.TxtFileStart]));

                    using (var stream = new StreamReader("test.txt"))
                    {
                        while (!stream.EndOfStream)
                        {
                            var streamWriteStatus = _serverPipe.Send(
                                                        Converter.ToAsciiBytes(stream.ReadLine() + "*?"));
                        }
                    }

                    var endStatus = _serverPipe.Send(
                                        Converter.ToAsciiBytes(
                                            ClientPipeSettings.CommandsList[ClientPipeSettings.Commands.EndFile]));

                    var readStatus = _serverPipe.Read();
                    if (readStatus.Item1 != ReadWriteStatus.Success)
                    {
                        ConnectionEventHandler?.Invoke(this, new Tuple<ConnectStatus, string>(ConnectStatus.ConnectError,
                                                                                              "Error in reading status " +
                                                                                              "from client pipe"));
                        return;
                    }
                    if (ClientPipeSettings.TryParseCommand(Converter.ToAsciiString(readStatus.Item2))
                            == ClientPipeSettings.Commands.TxtSuccess)
                    {
                        ConnectionEventHandler?.Invoke(this, new Tuple<ConnectStatus, string>(ConnectStatus.SuccessConnected,
                                                                                              ""));
                    }
                    else
                    {
                        ConnectionEventHandler?.Invoke(this, new Tuple<ConnectStatus, string>(ConnectStatus.ConnectError,
                                                                                              $"Error: {Converter.ToAsciiString(readStatus.Item2)}"));
                    }
                }
                catch (Exception ex)
                {
                    ConnectionEventHandler?.Invoke(this, new Tuple<ConnectStatus, string>(ConnectStatus.ConnectError,
                                                                                          ex.Message));
                }
            }).Start();
        }

        public void ShowCrossJoystick()
        {
            new Thread(delegate()
            {
                try
                {
                    var status = _serverPipe.Send(
                                    Converter.ToAsciiBytes(
                                        ClientPipeSettings.CommandsList[ClientPipeSettings.Commands.ShowCrossJoystick]));
                    if (status != ReadWriteStatus.Success)
                    {
                        WriteEventHandler?.Invoke(this, new Tuple<ReadWriteStatus, string>(ReadWriteStatus.Error, 
                                                                                           "ReadWriteStatus not success"));
                        return;
                    }
                    WriteEventHandler?.Invoke(this, new Tuple<ReadWriteStatus, string>(ReadWriteStatus.Success, 
                                                                                       ""));
                }
                catch (Exception ex)
                {
                    WriteEventHandler?.Invoke(this, new Tuple<ReadWriteStatus, string>(ReadWriteStatus.Error, ex.Message));
                }

            }).Start();
        }

        public void ShowRectJoystick()
        {
            new Thread(delegate ()
            {
                try
                {
                    var status = _serverPipe.Send(
                                    Converter.ToAsciiBytes(
                                        ClientPipeSettings.CommandsList[ClientPipeSettings.Commands.ShowRectJoystick]));
                    if (status != ReadWriteStatus.Success)
                    {
                        WriteEventHandler?.Invoke(this, new Tuple<ReadWriteStatus, string>(ReadWriteStatus.Error,
                                                                                           "ReadWriteStatus not success"));
                        return;
                    }
                    WriteEventHandler?.Invoke(this, new Tuple<ReadWriteStatus, string>(ReadWriteStatus.Success,
                                                                                       ""));
                }
                catch (Exception ex)
                {
                    WriteEventHandler?.Invoke(this, new Tuple<ReadWriteStatus, string>(ReadWriteStatus.Error, ex.Message));
                }

            }).Start();
        }

        public void StartMarking()
        {
            new Thread(delegate ()
            {
                try
                {
                    var status = _serverPipe.Send(
                                    Converter.ToAsciiBytes(
                                        ClientPipeSettings.CommandsList[ClientPipeSettings.Commands.StartMarking]));
                    if (status != ReadWriteStatus.Success)
                    {
                        WriteEventHandler?.Invoke(this, new Tuple<ReadWriteStatus, string>(ReadWriteStatus.Error,
                                                                                           "ReadWriteStatus not success"));
                        return;
                    }
                    WriteEventHandler?.Invoke(this, new Tuple<ReadWriteStatus, string>(ReadWriteStatus.Success,
                                                                                       ""));
                }
                catch (Exception ex)
                {
                    WriteEventHandler?.Invoke(this, new Tuple<ReadWriteStatus, string>(ReadWriteStatus.Error, ex.Message));
                }

            }).Start();
        }

        public void StopMarking()
        {
            new Thread(delegate ()
            {
                try
                {
                    var status = _serverPipe.Send(
                                    Converter.ToAsciiBytes(
                                        ClientPipeSettings.CommandsList[ClientPipeSettings.Commands.StopMarking]));
                    if (status != ReadWriteStatus.Success)
                    {
                        WriteEventHandler?.Invoke(this, new Tuple<ReadWriteStatus, string>(ReadWriteStatus.Error,
                                                                                           "ReadWriteStatus not success"));
                        return;
                    }
                    WriteEventHandler?.Invoke(this, new Tuple<ReadWriteStatus, string>(ReadWriteStatus.Success,
                                                                                       ""));
                }
                catch (Exception ex)
                {
                    WriteEventHandler?.Invoke(this, new Tuple<ReadWriteStatus, string>(ReadWriteStatus.Error, ex.Message));
                }

            }).Start();
        }

        public void ReadServerPipe()
        {
            new Thread(delegate()
            {
                try
                {
                    var data = _clientPipe.Read();
                    if (data.Item1 != ReadWriteStatus.Success)
                    {
                        ReadEventHandler?.Invoke(this, new Tuple<ReadWriteStatus, string>(ReadWriteStatus.Error, 
                                                                                          "ReadWriteStatus not success"));
                        return;
                    }
                    ReadEventHandler?.Invoke(this, new Tuple<ReadWriteStatus, string>(ReadWriteStatus.Success,
                                                                                      Converter.ToAsciiString(data.Item2)));
                }
                catch (Exception ex)
                {
                    ReadEventHandler?.Invoke(this, new Tuple<ReadWriteStatus, string>(ReadWriteStatus.Error, ex.Message));
                }

            }).Start();
        }

        public void Dispose()
        {
            new Thread(delegate()
            {
                try
                {
                    _serverPipe.Send(
                        Converter.ToAsciiBytes(
                            ClientPipeSettings.CommandsList[ClientPipeSettings.Commands.Exit]));
                    _clientPipe.Read();

                    _clientPipe.Dispose();
                    _serverPipe.Dispose();
                }
                catch { }

            }).Start();
        }

        public delegate void ConnectionHandler(object sender, Tuple<ConnectStatus, string> status);

        public delegate void ReadHandler(object sender, Tuple<ReadWriteStatus, string> status);

        public delegate void WriteHandler(object sender, Tuple<ReadWriteStatus, string> status);
    }
}

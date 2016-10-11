using System;
using System.IO.Pipes;

namespace ReportManager.MaxigrafIntegration
{
    public class ClientPipeStream : IDisposable
    {
        private readonly NamedPipeClientStream ClientStream;

        public ClientPipeStream(string name)
        {
            ClientStream = new NamedPipeClientStream(".", name, PipeDirection.InOut);
        }

        public ConnectStatus Connect()
        {
            try
            {
                ClientStream.Connect(10);
                return ConnectStatus.SuccessConnected;
            }
            catch
            {
                return ConnectStatus.ConnectError;
            }
        }

        public void Dispose()
        {
            ClientStream?.Dispose();
        }

        public ReadWriteStatus Send(byte[] data)
        {
            var writedBytes = 0;
            while (true)
            {
                if (writedBytes >= data.Length)
                    break;

                try
                {
                    ClientStream.Write(data, writedBytes, 256);
                }
                catch
                {
                    return ReadWriteStatus.Error;
                }

                writedBytes += 256;
            }
            return ReadWriteStatus.Success;
        }

        public Tuple<ReadWriteStatus, byte[]> Read()
        {
            try
            {
                var rawBytes = new byte[256];
                var readedBytes = ClientStream.Read(rawBytes, 0, 256);

                if (readedBytes > 0)
                {
                    var bundleBytes = new byte[readedBytes];
                    for (var i = 0; i < readedBytes; ++i)
                        bundleBytes[i] = rawBytes[i];
                    return new Tuple<ReadWriteStatus, byte[]>(ReadWriteStatus.Success, bundleBytes);
                }
            }
            catch { }

            return new Tuple<ReadWriteStatus, byte[]>(ReadWriteStatus.Error, new byte[0]);
        }
    }

    public class ServerPipeStream : IDisposable
    {
        private readonly NamedPipeServerStream ServerStream;

        public ServerPipeStream(string name)
        {
            ServerStream = new NamedPipeServerStream(name, PipeDirection.InOut, 1);
        }

        public ConnectStatus StartListening()
        {
            try
            {
                ServerStream.WaitForConnection();
                return ConnectStatus.SuccessConnected;
            }
            catch (Exception)
            {
                return ConnectStatus.ConnectError;
            }
        }

        public void Dispose()
        {
            ServerStream?.Dispose();
        }

        public ReadWriteStatus Send(byte[] data)
        {
            var writedBytes = 0;
            while (true)
            {
                if (writedBytes >= data.Length)
                    break;

                try
                {
                    ServerStream.Write(data, writedBytes, 256);
                }
                catch
                {
                    return ReadWriteStatus.Error;
                }

                writedBytes += 256;
            }
            return ReadWriteStatus.Success;
        }

        public Tuple<ReadWriteStatus, byte[]> Read()
        {
            try
            {
                var rawBytes = new byte[256];
                var readedBytes = ServerStream.Read(rawBytes, 0, 256);

                if (readedBytes > 0)
                {
                    var bundleBytes = new byte[readedBytes];
                    for (var i = 0; i < readedBytes; ++i)
                        bundleBytes[i] = rawBytes[i];
                    return new Tuple<ReadWriteStatus, byte[]>(ReadWriteStatus.Success, bundleBytes);
                }
            }
            catch { }

            return new Tuple<ReadWriteStatus, byte[]>(ReadWriteStatus.Error, new byte[0]);
        }
    }

    public enum ConnectStatus
    {
        SuccessConnected, ConnectError
    }

    public enum ReadWriteStatus
    {
        Success, Error
    }
}

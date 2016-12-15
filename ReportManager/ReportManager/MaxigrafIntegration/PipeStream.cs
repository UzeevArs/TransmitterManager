using System;
using System.IO.Pipes;
using System.Threading.Tasks;

namespace ReportManager.MaxigrafIntegration
{
    internal class ClientPipeStreamFacade : IDisposable
    {
        private readonly NamedPipeClientStream _clientStream;

        public ClientPipeStreamFacade(string name)
        {
            _clientStream = new NamedPipeClientStream(".", name, PipeDirection.InOut);
        }

        public ConnectStatus Connect()
        {
            try
            {
                _clientStream.Connect(10);
                return ConnectStatus.SuccessConnected;
            }
            catch
            {
                return ConnectStatus.ConnectError;
            }
        }

        public async Task<ConnectStatus> ConnectAsync()
        {
            try
            {
                await _clientStream.ConnectAsync(10);
                return ConnectStatus.SuccessConnected;
            }
            catch
            {
                return ConnectStatus.ConnectError;
            }
        }

        public void Dispose()
        {
            _clientStream?.Dispose();
        }

        public async Task<Status> SendAsync(byte[] data)
        {
            var writedBytes = 0;
            while (true)
            {
                if (writedBytes >= data.Length)
                    break;

                try
                {
                    await _clientStream.WriteAsync(data, writedBytes, 256);
                }
                catch
                {
                    return Status.Error;
                }

                writedBytes += 256;
            }
            return Status.Success;
        }

        public Status Send(byte[] data)
        {
            var writedBytes = 0;
            while (true)
            {
                if (writedBytes >= data.Length)
                    break;

                try
                {
                    _clientStream.Write(data, writedBytes, 256);
                }
                catch
                {
                    return Status.Error;
                }

                writedBytes += 256;
            }
            return Status.Success;
        }

        public async Task<Tuple<Status, byte[]>> ReadAsync()
        {
            try
            {
                var rawBytes = new byte[256];
                var readedBytes = await _clientStream.ReadAsync(rawBytes, 0, 256);

                if (readedBytes > 0)
                {
                    var bundleBytes = new byte[readedBytes];
                    for (var i = 0; i < readedBytes; ++i)
                        bundleBytes[i] = rawBytes[i];
                    return new Tuple<Status, byte[]>(Status.Success, bundleBytes);
                }
            }
            catch { }

            return new Tuple<Status, byte[]>(Status.Error, new byte[0]);
        }

        public Tuple<Status, byte[]> Read()
        {
            try
            {
                var rawBytes = new byte[256];
                var readedBytes = _clientStream.Read(rawBytes, 0, 256);

                if (readedBytes > 0)
                {
                    var bundleBytes = new byte[readedBytes];
                    for (var i = 0; i < readedBytes; ++i)
                        bundleBytes[i] = rawBytes[i];
                    return new Tuple<Status, byte[]>(Status.Success, bundleBytes);
                }
            }
            catch { }

            return new Tuple<Status, byte[]>(Status.Error, new byte[0]);
        }
    }

    internal class ServerPipeStreamFacade : IDisposable
    {
        private readonly NamedPipeServerStream _serverStream;

        public bool Alive { get { return (bool)_serverStream?.IsConnected; } }

        public ServerPipeStreamFacade(string name)
        {
            _serverStream = new NamedPipeServerStream(name, PipeDirection.InOut, 1);
        }

        public ConnectStatus StartListening()
        {
            try
            {
                _serverStream.WaitForConnection();
                return ConnectStatus.SuccessConnected;
            }
            catch (Exception)
            {
                return ConnectStatus.ConnectError;
            }
        }

        public async Task<ConnectStatus> StartListeningAsync()
        {
            try
            {
                await _serverStream.WaitForConnectionAsync();
                return ConnectStatus.SuccessConnected;
            }
            catch (Exception)
            {
                return ConnectStatus.ConnectError;
            }
        }

        public void Dispose()
        {
            _serverStream?.Dispose();
        }

        public async Task<Status> SendAsync(byte[] data)
        {
            var writedBytes = 0;
            data = Check256Bytes(data);

            while (true)
            {
                if (writedBytes >= data.Length)
                    break;

                try
                {
                    await _serverStream.WriteAsync(data, writedBytes, 256);
                }
                catch
                {
                    return Status.Error;
                }

                writedBytes += 256;
            }
            return Status.Success;
        }

        public Status Send(byte[] data)
        {
            var writedBytes = 0;
            data = Check256Bytes(data);

            while (true)
            {
                if (writedBytes >= data.Length)
                    break;

                try
                {
                    _serverStream.Write(data, writedBytes, 256);
                }
                catch
                {
                    return Status.Error;
                }

                writedBytes += 256;
            }
            return Status.Success;
        }

        public async Task<(Status status, byte[] bytes)> ReadAsync()
        {
            try
            {
                var rawBytes = new byte[256];
                var readedBytes = await _serverStream.ReadAsync(rawBytes, 0, 256);

                if (readedBytes > 0)
                {
                    var bundleBytes = new byte[readedBytes];
                    for (var i = 0; i < readedBytes; ++i)
                        bundleBytes[i] = rawBytes[i];
                    return (Status.Success, bundleBytes);
                }
            }
            catch { }

            return (Status.Error, new byte[0]);
        }

        public (Status status, byte[] bytes) Read()
        {
            try
            {
                var rawBytes = new byte[256];
                var readedBytes = _serverStream.Read(rawBytes, 0, 256);

                if (readedBytes > 0)
                {
                    var bundleBytes = new byte[readedBytes];
                    for (var i = 0; i < readedBytes; ++i)
                        bundleBytes[i] = rawBytes[i];
                    return (Status.Success, bundleBytes);
                }
            }
            catch { }

            return (Status.Error, new byte[0]);
        }

        private byte[] Check256Bytes(byte[] bytes)
        {
            if (bytes.Length >= 256) return bytes;

            var newbytes = new byte[256];
            for (var i = 0; i < bytes.Length; ++i)
            {
                newbytes[i] = bytes[i];
            }
            return newbytes;
        }
    }

    internal enum ConnectStatus
    {
        SuccessConnected, ConnectError
    }

    internal enum Status
    {
        Success, Error, Message
    }
}

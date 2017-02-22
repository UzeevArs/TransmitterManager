using Modbus.Device;
using Stateless;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReportManager.TemperatureLogger.Modbus
{
    internal class PortSettings
    {
        public string Name { get; set; }
        public int BaudRate { get; set; }
        public int DataBits { get; set; }
        public Parity Parity { get; set; }
        public StopBits StopBits { get; set; }
    }

    internal class ModbusSettings
    {
        public byte SlaveAdress { get; set; }
        public ushort StartAdress { get; set; }
        public ushort NumberOfPoints { get; set; }
    }

    internal struct ReadPacket<T> where T: struct
    {
        public T Value { get; set; }
        public DateTime Time { get; set; }
    }

    internal class TemperatureDevice : IDisposable
    {
        public enum TemperatureDeviceState
        {
            CheckConnection,
            FindPortName,
            Read,
            StopRead,
            Idle
        }

        private enum TemperatureDeviceEdge
        {
            ConnectionValid, ConnectionInvalid,
            PortNameFounded, PortNameNotFounded,
            ReadSuccess, ReadError,
            ReadStop, ReadStart,
            ToIdle
        }

        public event EventHandler<ReadPacket<float>> OnTemperatureRead;
        public event EventHandler<ReadPacket<float>> OnHumidityRead;
        public event EventHandler<ReadPacket<float>> OnPressureRead;
        public event EventHandler<TemperatureDeviceState> OnChangeState;

        public TemperatureDevice()
        {
            IsReading = true;

            ModbusDeviceStates = new StateMachine<TemperatureDeviceState, TemperatureDeviceEdge>(TemperatureDeviceState.Idle);
            ModbusDeviceStates.Configure(TemperatureDeviceState.CheckConnection)
                      .OnEntry(() => Task.Run(() => OnChangeState?.Invoke(this, TemperatureDeviceState.CheckConnection)))
                      .OnEntry(Connect)
                      .Permit(TemperatureDeviceEdge.ConnectionInvalid,  TemperatureDeviceState.FindPortName)
                      .Permit(TemperatureDeviceEdge.ReadStart,          TemperatureDeviceState.FindPortName)
                      .Permit(TemperatureDeviceEdge.ConnectionValid,    TemperatureDeviceState.Read)
                      .Permit(TemperatureDeviceEdge.ReadStop,           TemperatureDeviceState.StopRead)
                      .Permit(TemperatureDeviceEdge.ToIdle,             TemperatureDeviceState.Idle);
            ModbusDeviceStates.Configure(TemperatureDeviceState.FindPortName)
                      .OnEntry(() => Task.Run(() => OnChangeState?.Invoke(this, TemperatureDeviceState.FindPortName)))
                      .OnEntry(async () => await FindPortNameAsync())
                      .PermitReentry(TemperatureDeviceEdge.PortNameNotFounded)
                      .Permit(TemperatureDeviceEdge.PortNameFounded,   TemperatureDeviceState.CheckConnection)
                      .Permit(TemperatureDeviceEdge.ReadStop,          TemperatureDeviceState.StopRead)
                      .Permit(TemperatureDeviceEdge.ToIdle,            TemperatureDeviceState.Idle);
            ModbusDeviceStates.Configure(TemperatureDeviceState.Read)
                      .OnEntry(() => Task.Run(() => OnChangeState?.Invoke(this, TemperatureDeviceState.Read)))
                      .OnEntry(async () => await ReadAsync())
                      .PermitReentry(TemperatureDeviceEdge.ReadSuccess)
                      .Permit(TemperatureDeviceEdge.ReadError,         TemperatureDeviceState.CheckConnection)
                      .Permit(TemperatureDeviceEdge.ReadStop,          TemperatureDeviceState.StopRead)
                      .Permit(TemperatureDeviceEdge.ToIdle,            TemperatureDeviceState.Idle);
            ModbusDeviceStates.Configure(TemperatureDeviceState.StopRead)
                      .OnEntry(() => Task.Run(() => OnChangeState?.Invoke(this, TemperatureDeviceState.StopRead)))
                      .Permit(TemperatureDeviceEdge.ReadStart,         TemperatureDeviceState.Read)
                      .Permit(TemperatureDeviceEdge.ToIdle,            TemperatureDeviceState.Idle);
            ModbusDeviceStates.Configure(TemperatureDeviceState.Idle)
                      .OnEntry(() => Task.Run(() => OnChangeState?.Invoke(this, TemperatureDeviceState.Idle)))
                      .Permit(TemperatureDeviceEdge.ReadStart,         TemperatureDeviceState.Read)
                      .PermitReentry(TemperatureDeviceEdge.ToIdle);
        }

        public bool StartRead()
        {
            if (!ModbusDeviceStates.CanFire(TemperatureDeviceEdge.ReadStart)) return false;

            IsReading = true;
            ModbusDeviceStates.Fire(TemperatureDeviceEdge.ReadStart);
            return true;
        }

        public bool Alive()
        {
            return ModbusDeviceStates.State == TemperatureDeviceState.Read;
        }

        public bool StopRead()
        {
            if (!ModbusDeviceStates.CanFire(TemperatureDeviceEdge.ReadStop)) return false;

            IsReading = false;
            ModbusDeviceStates.Fire(TemperatureDeviceEdge.ReadStop);
            return true;
        }

        public void ToIdle()
        {
            ModbusDeviceStates.Fire(TemperatureDeviceEdge.ToIdle);
        }

        private void Connect()
        {
            try
            {
                Serial?.Close();
                Thread.Sleep(50);

                Serial = new SerialPort(PortName)
                {
                    BaudRate = 9600,
                    DataBits = 8,
                    Parity = Parity.None,
                    StopBits = StopBits.One
                };
                Serial.Open();

                Modbus = ModbusSerialMaster.CreateRtu(Serial);
                Modbus.Transport.Retries = 2;
                Modbus.Transport.ReadTimeout = 100;
                Modbus.ReadInputRegisters(1, 0, 4);

                ModbusDeviceStates.Fire(TemperatureDeviceEdge.ConnectionValid);
            }
            catch
            {
                Serial?.Close();
                Thread.Sleep(50);
                ModbusDeviceStates.Fire(TemperatureDeviceEdge.ConnectionInvalid);
            }
        }

        private async Task FindPortNameAsync()
        {
            PortName = string.Empty;
            PortName = await ModbusDetector.DetectAsync(new ModbusSettings { NumberOfPoints = 4,
                                                                             SlaveAdress = 1,
                                                                             StartAdress = 0 });
            if (PortName == string.Empty)
                ModbusDeviceStates.Fire(TemperatureDeviceEdge.PortNameNotFounded);
            else
                ModbusDeviceStates.Fire(TemperatureDeviceEdge.PortNameFounded);
        }

        private async Task ReadAsync()
        {
            try
            {
                ushort[] data = await Modbus.ReadInputRegistersAsync(1, 0, 6);
                var temperature = BitConverter.ToSingle(BitConverter.GetBytes(data[0])
                                                                    .Concat(BitConverter.GetBytes(data[1]))
                                                                    .ToArray(), 0);
                var humidity = BitConverter.ToSingle(BitConverter.GetBytes(data[2])
                                                                 .Concat(BitConverter.GetBytes(data[3]))
                                                                 .ToArray(), 0);
                var pressure = BitConverter.ToSingle(BitConverter.GetBytes(data[4])
                                                                 .Concat(BitConverter.GetBytes(data[5]))
                                                                 .ToArray(), 0);
                await Task.Run(() =>
                {
                    OnTemperatureRead?.Invoke(this, new ReadPacket<float> { Value = temperature, Time = DateTime.Now });
                    OnHumidityRead?.Invoke(this, new ReadPacket<float> { Value = humidity, Time = DateTime.Now });
                    OnPressureRead?.Invoke(this, new ReadPacket<float> { Value = (pressure * 133.322f) / 1000.0f, Time = DateTime.Now });
                });

                if (IsReading && ModbusDeviceStates.CanFire(TemperatureDeviceEdge.ReadSuccess))
                    ModbusDeviceStates.Fire(TemperatureDeviceEdge.ReadSuccess);

                await Task.Run(() => Thread.Sleep(1000));
                
            }
            catch
            {
                if (ModbusDeviceStates.CanFire(TemperatureDeviceEdge.ReadError))
                    ModbusDeviceStates.Fire(TemperatureDeviceEdge.ReadError);
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; 

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Modbus.Dispose();
                    if (Serial.IsOpen) Serial.Dispose();
                }
                Modbus = null;
                Serial = null;
                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        // ~TemperatureDevice() {
        //   // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
        //   Dispose(false);
        // }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            // GC.SuppressFinalize(this);
        }
        #endregion

        private StateMachine<TemperatureDeviceState, TemperatureDeviceEdge> ModbusDeviceStates { get; set; }
        private SerialPort Serial { get; set; }
        private ModbusSerialMaster Modbus { get; set; }

        private string PortName { get; set; }
        private bool IsReading { get; set; }
    }
}

using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using Modbus.Device;
using System;

namespace ReportManager.TemperatureLogger.Modbus
{
    static internal class ModbusDetector
    {
        public static async Task<string> DetectAsync(ModbusSettings settings)
        {
            return await Task.Run(() =>
            {
                return SerialPort.GetPortNames()
                    .Select(name =>
                    {
                        using (var serial = new SerialPort(name)
                        {
                            BaudRate = 9600,
                            DataBits = 8,
                            Parity = Parity.None,
                            StopBits = StopBits.One,
                            ReadTimeout = 100,
                            WriteTimeout = 100
                        })
                        {
                            try
                            {
                                serial.Open();
                                if (!serial.IsOpen) return (false, name);

                                var master = ModbusSerialMaster.CreateRtu(serial);
                                master.Transport.Retries = 1;
                                master.Transport.ReadTimeout = 100;
                                master.Transport.WaitToRetryMilliseconds = 10;
                                master.Transport.WriteTimeout = 100;

                                var result = master.ReadInputRegisters(settings.SlaveAdress,
                                                                       settings.StartAdress,
                                                                       settings.NumberOfPoints);
                                return (true, name);
                            }
                            catch
                            {
                                return (false, name);
                            }
                        }
                    })
                    .Aggregate("", (final, status) =>
                    {
                        if (status.Item1) final = status.Item2;
                        return final;
                    });
            });
            
        }
    }
}

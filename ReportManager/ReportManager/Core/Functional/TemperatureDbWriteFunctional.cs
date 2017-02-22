using ReportManager.Data.SAP.ConcreteAdapters;
using ReportManager.Data.DataModel;
using ReportManager.TemperatureLogger.Modbus;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReportManager.Core.Functional
{
    internal class TemperatureDbWriteFunctional : Functional
    {
        public event EventHandler OnInsert;
        public override event EventHandler<bool> StatusChanged;

        private ConcurrentStack<float> TemperatureStack { get; set; } = new ConcurrentStack<float>();
        private ConcurrentStack<float> HumidityStack { get; set; } = new ConcurrentStack<float>();
        private ConcurrentStack<float> PressureStack { get; set; } = new ConcurrentStack<float>();

        private Thread CurrentThread { get; set; }

        public TemperatureDevice Device { get { return ReportManagerContext.GetInstance().Device; } }

        public override bool? IsRunning { get { return CurrentThread?.IsAlive; } }

        public TemperatureDbWriteFunctional()
        {
            Name = "Запись данных в БД с температурного датчика";
            Device.OnPressureRead += Device_OnPressureRead;
            Device.OnHumidityRead += Device_OnHumidityRead; ;
            Device.OnTemperatureRead += Device_OnTemperatureRead;
        }

        private void Device_OnTemperatureRead(object sender, ReadPacket<float> e)
        {
            if (TemperatureStack.Count > 100) TemperatureStack.Clear();
            TemperatureStack.Push(e.Value);
        }

        private void Device_OnHumidityRead(object sender, ReadPacket<float> e)
        {
            if (HumidityStack.Count > 100) HumidityStack.Clear();
            HumidityStack.Push(e.Value);
        }

        private void Device_OnPressureRead(object sender, ReadPacket<float> e)
        {
            if (PressureStack.Count > 100) PressureStack.Clear();
            PressureStack.Push(e.Value);
        }

        public override void Start()
        {
            Device.StartRead();
            CurrentThread = new Thread(WriteToDb);
            CurrentThread.Start();
            StatusChanged?.Invoke(this, true);
        }

        private void WriteToDb()
        {
            while (true)
            {
                try
                {
                    while (DateTime.Now.Second != 0)
                        Thread.Sleep(TimeSpan.FromMilliseconds(400));

                    new TemperatureFrameDatabaseAdapter().Insert(GetFromQueues());
                    OnInsert?.Invoke(this, EventArgs.Empty);
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
                catch (ThreadAbortException)
                {
                    break;
                }
            }
        }

        public override void Stop()
        {
            CurrentThread?.Abort();
            Device.StopRead();
            StatusChanged?.Invoke(this, false);
        }

        IEnumerable<TemperatureFrame> GetFromQueues()
        {
            TemperatureFrame frame = new TemperatureFrame();
            frame.Time = DateTime.Now;

            if (!Device.Alive()) yield break;

            float value = 0.0f;
            while (!TemperatureStack.TryPop(out value)) { Thread.Yield(); }
            frame.Temperature = value;

            while (!HumidityStack.TryPop(out value)) { Thread.Yield(); }
            frame.Humidity = value;

            while (!PressureStack.TryPop(out value)) { Thread.Yield(); }
            frame.Pressure = value;

            yield return frame;
        }
    }
}

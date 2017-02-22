using ReportManager.TemperatureLogger.Modbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Core.Functional
{
    internal class TempteratureDeviceFunctional : Functional
    {
        public override bool? IsRunning => Device.Alive();

        public override event EventHandler<bool> StatusChanged;

        public TemperatureDevice Device { get { return ReportManagerContext.GetInstance().Device; } }

        public TempteratureDeviceFunctional()
        {
            Name = "Температурный датчик";
            Device.OnChangeState += Device_OnChangeState;
        }

        private void Device_OnChangeState(object sender, TemperatureDevice.TemperatureDeviceState e)
        {
            if (e == TemperatureDevice.TemperatureDeviceState.Read)
                StatusChanged?.Invoke(this, true);
            else if (e == TemperatureDevice.TemperatureDeviceState.Idle)
                StatusChanged?.Invoke(this, false);
        }

        public async override void Start()
        {
            await Task.Run(() => Device.StartRead());
        }

        public async override void Stop()
        {
            await Task.Run(() => Device.ToIdle());
        }
    }
}

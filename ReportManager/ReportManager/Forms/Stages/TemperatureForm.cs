using DevExpress.XtraEditors;
using ReportManager.Core;
using ReportManager.Data.Extensions;
using ReportManager.Data.SAP.ConcreteAdapters;
using ReportManager.Core.Functional;
using DevExpress.XtraCharts;

namespace ReportManager.Forms.Stages
{
    public partial class TemperatureForm : XtraForm
    {
        public TemperatureForm()
        {
            InitializeComponent();

            TFunctionalGridSubscribe();
            TFunctionalChartSubscribe();
            TFunctionalGaugesSubscribe();

            var functional = ReportManagerContext.GetInstance()
                                                 .Functionals
                                                 .Find(func => func.GetType() == typeof(TempteratureDeviceFunctional));
            if (functional == null) Close();
            functional.Start();
        }

        private void TFunctionalGaugesSubscribe()
        {
            ReportManagerContext.GetInstance().Device.OnTemperatureRead += Device_OnTemperatureRead;
            ReportManagerContext.GetInstance().Device.OnHumidityRead += Device_OnHumidityRead;
            ReportManagerContext.GetInstance().Device.OnPressureRead += Device_OnPressureRead;
        }

        private void Device_OnPressureRead(object sender, TemperatureLogger.Modbus.ReadPacket<float> e)
        {
            this.SafeInvoke(() => gaugePressure.Text = e.Value.ToString("F"));
        }

        private void Device_OnHumidityRead(object sender, TemperatureLogger.Modbus.ReadPacket<float> e)
        {
            this.SafeInvoke(() => gaugeHumidity.Text = e.Value.ToString("F"));
        }

        private void Device_OnTemperatureRead(object sender, TemperatureLogger.Modbus.ReadPacket<float> e)
        {
            this.SafeInvoke(() => gaugeTemperature.Text = e.Value.ToString("F"));
        }

        private void TFunctionalChartSubscribe()
        {
            this.SafeInvoke(() =>
            {
                var data = new TemperatureFrameDatabaseAdapter().Select();
                foreach (Series s in chartTemp.Series)
                    s.DataSource = data;
            });

            var functional = ReportManagerContext.GetInstance()
                                                 .Functionals
                                                 .Find(func => func.GetType() == typeof(TemperatureDbWriteFunctional));
            if (functional != null)
                (functional as TemperatureDbWriteFunctional).OnInsert += (sender, args)
                    => this.SafeInvoke(()
                    =>
                    {
                        var data = new TemperatureFrameDatabaseAdapter().Select();
                        foreach (Series s in chartTemp.Series)
                            s.DataSource = data;
                    });
        }

        private void TFunctionalGridSubscribe()
        {
            this.SafeInvoke(() => grdTemp.DataSource = new TemperatureFrameDatabaseAdapter().Select());

            var functional = ReportManagerContext.GetInstance()
                                                 .Functionals
                                                 .Find(func => func.GetType() == typeof(TemperatureDbWriteFunctional));
            if (functional != null)
                (functional as TemperatureDbWriteFunctional).OnInsert += (sender, args)
                    => this.SafeInvoke(()
                    => grdTemp.DataSource = new TemperatureFrameDatabaseAdapter().Select());
        }

        private void TemperatureForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            ReportManagerContext.GetInstance().Device.OnTemperatureRead -= Device_OnTemperatureRead;
            ReportManagerContext.GetInstance().Device.OnHumidityRead -= Device_OnHumidityRead;
            ReportManagerContext.GetInstance().Device.OnPressureRead -= Device_OnPressureRead;
        }
    }
}

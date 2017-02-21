using DevExpress.XtraEditors;
using ReportManager.Core;
using ReportManager.TemperatureLogger.Modbus;
using System;
using System.Threading;
using System.Windows.Forms;
using ReportManager.Data.Extensions;
using ReportManager.Data.Database.ConcreteAdapters;
using ReportManager.Core.Functional;
using DevExpress.XtraCharts;

namespace ReportManager.Forms.Stages
{
    public partial class TemperatureForm : XtraForm
    {
        private TemperatureDevice Device { get { return ReportManagerContext.GetInstance().Device; } }

        public TemperatureForm()
        {
            InitializeComponent();

            TFunctionalGridSubscribe();
            TFunctionalChartSubscribe();
            TFunctionalGaugesSubscribe();

            Device.StartRead();
        }

        private void TFunctionalGaugesSubscribe()
        {
            ReportManagerContext.GetInstance().Device.OnTemperatureRead += (sender, data)
                => this.SafeInvoke(() 
                => gaugeTemperature.Text = data.Value.ToString("F"));
            ReportManagerContext.GetInstance().Device.OnHumidityRead += (sender, data)
                => this.SafeInvoke(()
                => gaugeHumidity.Text = data.Value.ToString("F"));
            ReportManagerContext.GetInstance().Device.OnPressureRead += (sender, data)
                => this.SafeInvoke(()
                => gaugePressure.Text = data.Value.ToString("F"));
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
    }
}

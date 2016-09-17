using DevExpress.LookAndFeel;
using DevExpress.XtraReports.UI;
using ReportManager.DataModel;
using ReportManager.Reports;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using System.Reflection;
using System.Linq;

namespace ReportManager
{
    public partial class ReportForm : Form
    {
        private LinkedList<ReportTypeWrapper> reportTypes;

        public ReportForm()
        {
            InitializeComponent();
            reportTypes = new LinkedList<ReportTypeWrapper>();
            LoadReports();
        }
        private void LoadReports()
        {
            Assembly mscorlib = typeof(ISavingReport).Assembly;
            foreach (Type type in mscorlib.GetTypes())
            {
                if (type.GetInterfaces().
                    FirstOrDefault(typeInst => typeInst == typeof(ISavingReport)) != null)
                {
                    reportTypes.AddLast(new ReportTypeWrapper { ReportType = type });
                    cbReports.Properties.Items.Add(reportTypes.Last.Value);
                }
            }
            cbReports.SelectedIndex = 0;
        }
        private XtraReport CreateReportInstance()
        {
            XtraReport report = (XtraReport)
                Activator.CreateInstance((cbReports.SelectedItem as ReportTypeWrapper).ReportType);

            if (!(report is ISavingReport))
            {
                MessageBox.Show("Забыл унаследоваться от интерфейс ISavingReport");
                return null;
            };

            if ((report as ISavingReport).IsExistTemplateFile())
            {
                report.LoadLayout((report as ISavingReport).GetTemplateFileName());
            }


            //new List<InputData> { ReportManagerContext.GetInstance().CurrentDeviceModel.InputData[0] };

            //new DeviceModel().InputData
            //{

            //ReportManagerContext.GetInstance().CurrentDeviceModel.InputData[0]                   
            //    }

            report.DataSource = 
                new List<AggregatedFieldsModel> {new AggregatedFieldsModel(

                    ReportManagerContext.GetInstance().CurrentDeviceModel.SerialNumber[0],
                    ReportManagerContext.GetInstance().CurrentDeviceModel.InputData[0],
                    ReportManagerContext.GetInstance().CurrentDeviceModel.CalibrationResults[0],
                    ReportManagerContext.GetInstance().CurrentDeviceModel.DeviceTestResults[0])
            };

            return report;
        }

        private void btnOpenPreview_Click(object sender, System.EventArgs e)
        {
            var report = CreateReportInstance();
            if (report == null) return;

            using (ReportPrintTool printTool = new ReportPrintTool(report))
            {
                printTool.ShowRibbonPreviewDialog(UserLookAndFeel.Default);
            }
        }
        private void btnOpenEditor_Click(object sender, EventArgs e)
        {
            var report = CreateReportInstance();
            if (report == null) return;

            using (ReportDesignTool designerTool = new ReportDesignTool(report))
            {
                designerTool.ShowRibbonDesignerDialog(UserLookAndFeel.Default);
            }
        }
    }

    class ReportTypeWrapper
    {
        public Type ReportType { get; set; }
        public override string ToString()
        {
            return ReportType != null ? ReportType.Name : "";
        }
    }
}


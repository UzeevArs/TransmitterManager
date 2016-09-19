using DevExpress.LookAndFeel;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using ReportManager.Database;
using ReportManager.DataModel;
using ReportManager.Reports;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ReportManager.Forms
{
    public partial class SerialNumberGenerateForm : Form
    {
        public SerialNumberGenerateForm()
        {
            InitializeComponent();
            nifudaDataTableAdapter1.Fill(nifudaDataSet1.NifudaDataTable);
            nifudaDataTableAdapter1.Connection.ConnectionString = ConnectionStringContainer.GetInstance().ConnStrNifuda;
        }

        private void grdEmptySerial_DoubleClick(object sender, EventArgs e)
        {
            var rows = (grdEmptySerial.MainView as GridView).GetSelectedRows();
            if (rows.Length > 0)
            {
                //var serial = SerialGenerator.Generate(nifudaDataSet1.NifudaDataTable[rows[0]]);

                nifudaDataTableAdapter1.UpdateQuery("Generated", nifudaDataSet1.NifudaDataTable[rows[0]].SERIAL_NO);
                var device = GetDeviceBySerialNifuda(nifudaDataSet1.NifudaDataTable[rows[0]].SERIAL_NO);
                var report = CreateReportInstance(device);
                using (ReportPrintTool printTool = new ReportPrintTool(report))
                {
                    printTool.ShowRibbonPreviewDialog(UserLookAndFeel.Default);
                }
             }

        }

        private DeviceModel GetDeviceBySerialNifuda(string serial)
        {
            return DataModelCreator.GetDeviceBySerial(new DataModel.SerialNumber { Serial = serial });
        }

        private TransportListReport CreateReportInstance(DeviceModel device)
        {
            TransportListReport report = new TransportListReport();

            if ((report as ISavingReport).IsExistTemplateFile())
            {
                report.LoadLayout((report as ISavingReport).GetTemplateFileName());
            }

            report.DataSource =
                new List<InputData> { device.InputData[0] };

            return report;
        }
    }
}

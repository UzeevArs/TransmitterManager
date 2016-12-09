using System;
using System.Collections.Generic;
using System.IO;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using ReportManager.Core.Utility;
using ReportManager.Data.DataModel;
using ReportManager.Data.Settings;
using ReportManager.Reports;
using ReportManager.Core;
using ReportManager.Data.Extensions;

namespace ReportManager.Forms.Stages
{
    public partial class TransportListGenerateStageForm : XtraForm
    {
        public TransportListGenerateStageForm()
        {
            InitializeComponent();
            nifudaDataTableAdapter1.Fill(nifudaDataSet1.NifudaDataTable);
            nifudaDataTableAdapter1.Connection.ConnectionString = SettingsContext.GlobalSettings.NifudaConnectionString;
        }

        private TransportListReport CreateReportInstance(InputData input)
        {
            TransportListReport report = new TransportListReport();

            if ((report as ISavingReport).IsExistTemplateFile())
            {
                report.LoadLayout((report as ISavingReport).GetTemplateFileName());
            }

            report.DataSource = new List<object> { input }
                            .PropertiesToDict()
                            .ToExpando()
                            .ToDynamicArray()
                            .ToDataTable();

            report.PrintingSystem.PrintProgress += Report_PrintProgress;

            return report;
        }

        private void Report_PrintProgress(object sender, PrintProgressEventArgs e)
        {
            var (status, extra) = FolderUtility.CheckAndCreateCurrentPath("Transport List");
            if (status == FolderUtilityStatus.Success)
            {
                var path = $"{extra}" +
                           $"TransportList_{ReportManagerContext.GetInstance().CurrentInput.SERIAL_NO}.pdf";
                if (!Directory.Exists(path))
                    (sender as TransportListReport)?.ExportToPdf(path);
            }
            else if (status == FolderUtilityStatus.Error)
            {
                XtraMessageBox.Show($"Не удалось сохранить отчет\n{extra}");
            }
        }

        private void TransportListGenerateStageForm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            ReportManagerContext.GetInstance().InputDataCreatedStatus -= OnDeviceModelCreatedStatus;
        }

        private void ShowReport(InputData input)
        {
            if (input == null) return;

            var report = CreateReportInstance(input);
            using (ReportPrintTool printTool = new ReportPrintTool(report))
            {
                printTool.ShowRibbonPreviewDialog(UserLookAndFeel.Default);
            }
        }

        private void OnDeviceModelCreatedStatus(object sender, (DeviceModelStatus, InputData) data)
        {
            var (status, input) = data;

            if (status == DeviceModelStatus.CreatedSuccess)
            {
                ShowReport(input);
            }
            else if(data.Item1 == DeviceModelStatus.CreatedError)
            {
                Close();
            }
        }

        private void TransportListGenerateStageForm_Shown(object sender, EventArgs e)
        {
            ReportManagerContext.GetInstance().InputDataCreatedStatus += OnDeviceModelCreatedStatus;
            ShowReport(ReportManagerContext.GetInstance().CurrentInput);
        }
    }
}

using System;
using System.Collections.Generic;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using ReportManager.Core.Utility;
using ReportManager.Data.DataModel;
using ReportManager.Data.Settings;
using ReportManager.Reports;
using ReportManager.Core;

namespace ReportManager.Forms.Stages
{
    public partial class TransportListGenerateStageForm : XtraForm
    {
        

       
        public TransportListGenerateStageForm()
        {
            var dateTime = DateTime.Now.Date;
            InitializeComponent();
            nifudaDataTableAdapter1.Fill(nifudaDataSet1.NifudaDataTable);
            nifudaDataTableAdapter1.Connection.ConnectionString = SettingsContext.GlobalSettings.NifudaConnectionString;
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



            report.PrintingSystem.EndPrint+= Report_AfterPrint;

//            AfterPrint

            return report;
        }




        private void Report_AfterPrint(object sender, EventArgs e)
        {
            var folderData = FolderUtility.CheckAndCreateCurrentPath();
            if (folderData.Item1 == FolderUtilityStatus.Success)
            {
                (sender as TransportListReport)?.ExportToPdf($"{folderData.Item2}" +
                    $"{ReportManagerContext.GetInstance().CurrentDeviceModel.SerialNumber[0].Serial}.pdf");
            }
            else if (folderData.Item1 == FolderUtilityStatus.Error)
            {
                XtraMessageBox.Show($"Не удалось сохранить отчет\n{folderData.Item2}");
            }
        }

        private void TransportListGenerateStageForm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            ReportManagerContext.GetInstance().DeviceModelCreatedStatus -= OnDeviceModelCreatedStatus;
        }

        private void ShowReport(DeviceModel model)
        {
            if (model == null) return;

            var report = CreateReportInstance(model);
            using (ReportPrintTool printTool = new ReportPrintTool(report))
            {
                printTool.ShowRibbonPreviewDialog(UserLookAndFeel.Default);
            }
        }
        private void OnDeviceModelCreatedStatus(object sender, Tuple<DeviceModelStatus, DeviceModel> data)
        {
            if ( data.Item1 == DeviceModelStatus.CreatedSuccess)
            {
                ShowReport(data.Item2);
            }
            else if(data.Item1 == DeviceModelStatus.CreatedError)
            {
                Close();
            }
        
        }
        private void TransportListGenerateStageForm_Shown(object sender, EventArgs e)
        {
            ReportManagerContext.GetInstance().DeviceModelCreatedStatus += OnDeviceModelCreatedStatus;
            ShowReport(ReportManagerContext.GetInstance().CurrentDeviceModel);
        }


    }
}

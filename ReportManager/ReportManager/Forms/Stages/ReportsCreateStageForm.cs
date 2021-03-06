﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using ReportManager.Core;
using ReportManager.Data.DataModel;
using ReportManager.Reports;
using ReportManager.Data.Extensions;
using ReportManager.Data.SAP.ConcreteAdapters;
using System.IO;
using DevExpress.XtraPrinting;
using ReportManager.Core.Utility;

namespace ReportManager.Forms.Stages
{
    public partial class ReportForm : XtraForm
    {
        private readonly LinkedList<ReportTypeWrapper> _reportTypes;

        public ReportForm()
        {
            InitializeComponent();
            _reportTypes = new LinkedList<ReportTypeWrapper>();
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
                    _reportTypes.AddLast(new ReportTypeWrapper { ReportType = type });
                    cbReports.Properties.Items.Add(_reportTypes.Last.Value);
                }
            }
            cbReports.SelectedIndex = 0;
        }

        private XtraReport CreateReportInstance()
        {

            var report = (XtraReport)
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

            var input = ReportManagerContext.GetInstance().CurrentInput;
            report.DataSource = new List<object> { input,
                                                   (new DeviceTestResultsDatabaseAdapter()).SelectBySerial(input.SERIAL_NO).FirstOrDefault() ?? new DeviceTestResults(),
                                                   (new CalibrationResultsDatabaseAdapter()).SelectBySerial(input.SERIAL_NO).FirstOrDefault() ?? new CalibrationResults() }
                                .PropertiesToDict()
                                .ToExpando()
                                .ToDynamicArray()
                                .ToDataTable();

            report.PrintingSystem.PrintProgress += Report_PrintProgreses;

            return report;
        }

        private void BtnOpenPreview_Click(object sender, System.EventArgs e)
        {
            var report = CreateReportInstance();
            if (report == null) return;

            using (ReportPrintTool printTool = new ReportPrintTool(report))
            {
                printTool.ShowRibbonPreviewDialog(UserLookAndFeel.Default);
            }
        }
        private void BtnOpenEditor_Click(object sender, EventArgs e)
        {
            var report = CreateReportInstance();
            if (report == null) return;

            using (ReportDesignTool designerTool = new ReportDesignTool(report))
            {
                designerTool.ShowRibbonDesignerDialog(UserLookAndFeel.Default);
            }
        }

        private void Report_PrintProgreses(object sender, PrintProgressEventArgs e)
        {
            var report = CreateReportInstance();
            var name = CreateReportInstance().Report.Band.ToString();
            if (name == "Сертификат")
            {
                var (status, extra) = FolderUtility.CheckAndCreateCurrentPath("Certificate");
                if (status == FolderUtilityStatus.Success)
                {
                    var path = $"{extra}" +
                               $"Certificate_{ReportManagerContext.GetInstance().CurrentInput.SERIAL_NO}.pdf";
                    if (!Directory.Exists(path))
                       (report as CertificateReport)?.ExportToPdf(path);
                }
                else if (status == FolderUtilityStatus.Error)
                {
                    XtraMessageBox.Show($"Не удалось сохранить отчет\n{extra}");
                }
            }
            

        }
    }
    internal class ReportTypeWrapper
    {
        public Type ReportType { get; set; }
        public override string ToString()
        {
            return ReportType != null ? ReportType.Name : "";
        }
    }

        

}


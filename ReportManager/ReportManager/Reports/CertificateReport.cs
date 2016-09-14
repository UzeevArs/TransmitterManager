using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.IO;

namespace ReportManager.Reports
{
    public partial class CertificateReport : DevExpress.XtraReports.UI.XtraReport, ISavingReport
    {
        public CertificateReport()
        {
            InitializeComponent();
            Name = "CertificateReportTemplate";
            Tag = "CertificateReportTemplate.repx";
        }

        public string GetTemplateFileName()
        {
            return (string)Tag;
        }

        public bool IsExistTemplateFile()
        {
            try
            {
                using (FileStream stream = new FileStream(GetTemplateFileName(), FileMode.Open))
                {
                }

                return true;
            }
            catch (FileNotFoundException)
            {
                return false;
            }
        }
    }
    //public partial class CertificateReport : DevExpress.XtraReports.UI.XtraReport
    //{
    //    public CertificateReport()
    //    {
    //        InitializeComponent();
    //    }

    //}
}

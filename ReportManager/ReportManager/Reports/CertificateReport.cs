using System.IO;
using DevExpress.XtraReports.UI;
using ReportManager.Data.Settings;

namespace ReportManager.Reports
{
    internal partial class CertificateReport : XtraReport, ISavingReport
    {
        public CertificateReport()
        {
            InitializeComponent();
            Name = "CertificateReportTemplate";
            Tag = "CertificateReportTemplate.repx";
        }

        public string GetTemplateFileName()
        {
            return (string) Tag;
        }

        public bool IsExistTemplateFile()
        {
            try
            {
                using (var stream = new FileStream(GetTemplateFileName(), FileMode.Open))
                {
                }

                return true;
            }
            catch (FileNotFoundException)
            {
                return false;
            }
        }

        public override string ToString()
        {
            return "Сертификат";
        }
    }

}

using System;
using System.IO;

namespace ReportManager.Reports
{
    public partial class TransportListReport : DevExpress.XtraReports.UI.XtraReport, ISavingReport
    {
        public TransportListReport()
        {
            InitializeComponent();
            Name = "TransportListReportTemplate";
            Tag = "TransportListReportTemplate.repx";
        }

        public string GetTemplateFileName()
        {
            return (string) Tag;
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
}

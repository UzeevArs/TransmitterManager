using System.IO;
using DevExpress.XtraReports.UI;
using System;

namespace ReportManager.Reports
{
    public partial class TransportListReport : XtraReport, ISavingReport
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
            return "Маршрутный лист";
        }
    }
}

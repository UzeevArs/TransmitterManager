using DevExpress.XtraReports.UI;
using System.IO;
using ReportManager.Data.Settings;

namespace ReportManager.Reports
{
    public partial class PasportReport : XtraReport, ISavingReport
    {
        public PasportReport()
        {
            InitializeComponent();
            Name = "PasportReportTemplate";
            Tag = "PasportReportTemplate.repx";
        }

        public string GetTemplateFileName()
        {
            return (string)Tag;
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
            return "Паспорт";
        }
    }
}

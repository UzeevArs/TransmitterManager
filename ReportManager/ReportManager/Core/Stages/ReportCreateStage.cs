using ReportManager.Forms.Stages;

namespace ReportManager.Core.Stages
{
    public class ReportCreateStage : AbstractStage
    {
        public ReportCreateStage()
        {
            Name = "Стадия создания отчетов";
            ChildForm = new ReportForm();
        }
    }
}

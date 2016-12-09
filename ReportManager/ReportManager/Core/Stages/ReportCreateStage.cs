using ReportManager.Forms.Stages;

namespace ReportManager.Core.Stages
{
    public class ReportCreateStage : Stage
    {
        public ReportCreateStage()
        {
            Name = "Стадия создания отчетов";
        }

        public override void Create()
        {
            base.Create();
            ChildForm = new ReportForm();
        }
    }
}

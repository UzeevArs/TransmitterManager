using ReportManager.Forms.Stages;

namespace ReportManager.Core.Stages
{
    public class MaxigrafStage : AbstractStage
    {
        public MaxigrafStage()
        {
            Name = "Стадия гравировки";
        }

        public override void Create()
        {
            base.Create();
            ChildForm = new MaxigrafStageForm();
        }
    }
}

using ReportManager.Forms.Stages;

namespace ReportManager.Core.Stages
{
    public class MaxigrafStage : AbstractStage
    {
        public MaxigrafStage()
        {
            Name = "Стадия гравировки";
            ChildForm = new MaxigrafStageForm();
        }
    }
}

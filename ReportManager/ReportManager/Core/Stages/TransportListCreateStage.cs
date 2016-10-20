using ReportManager.Forms.Stages;

namespace ReportManager.Core.Stages
{
    public class TransportListCreateStage : AbstractStage
    {
        public TransportListCreateStage()
        {
            Name = "Стадия создания траспортного листа";
        }

        public override void Create()
        {
            base.Create();
            ChildForm = new TransportListGenerateStageForm();
        }
    }
}

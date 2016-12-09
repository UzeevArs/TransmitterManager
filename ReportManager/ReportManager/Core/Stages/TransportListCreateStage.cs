using ReportManager.Forms.Stages;

namespace ReportManager.Core.Stages
{
    internal class TransportListCreateStage : Stage
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

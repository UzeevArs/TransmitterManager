using System.Windows.Forms;
using System.Xml.Serialization;
using DevExpress.XtraEditors;

namespace ReportManager.Core.Stages
{
    [XmlInclude(typeof(TransportListCreateStage))]
    [XmlInclude(typeof(MaxigrafStage))]
    [XmlInclude(typeof(ReportCreateStage))]
    public abstract class AbstractStage
    {
        [XmlIgnore]
        public XtraForm ChildForm { get; protected set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public event StageHandler StageStatusChanged;

        public virtual void Create()
        {
            Dispose();
            StageStatusChanged?.Invoke(this, StageStatus.Created);
        }

        public virtual void OpenForm(Form mdiParent = null)
        {
            Create();
            ChildForm.MdiParent = mdiParent;
            ChildForm.Show();
            StageStatusChanged?.Invoke(this, StageStatus.OpenedForm);
        }

        public virtual void CloseForm()
        {
            ChildForm?.Close();
            StageStatusChanged?.Invoke(this, StageStatus.ClosedForm);
        }

        public virtual void Dispose()
        {
            StageStatusChanged?.Invoke(this, StageStatus.Disposed);
        }
    }

    public delegate void StageHandler(object sender, StageStatus status);
    public enum StageStatus { Created, OpenedForm, ClosedForm, Disposed, Error }
}

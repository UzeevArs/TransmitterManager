using DevExpress.XtraEditors;
using ReportManager.Core;
using ReportManager.Data.Extensions;
using System.Windows.Forms;

namespace ReportManager.Forms
{
    public partial class WaitForm : XtraForm
    {
        private string MsCode { get; set; }
        public WaitForm(string msCode)
        {
            InitializeComponent();
            MsCode = msCode;
            ReportManagerContext.GetInstance().InputDataCreatedStatus += WaitForm_InputDataCreatedStatus;
        }

        private void WaitForm_InputDataCreatedStatus(object sender, 
            (DeviceModelStatus Status, string ErrorMessage, ReportManager.Data.DataModel.InputData data) e)
        {
            this.SafeInvoke(() => Close());
        }

        private void WaitForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReportManagerContext.GetInstance().InputDataCreatedStatus += WaitForm_InputDataCreatedStatus;
        }

        private async void WaitForm_Shown(object sender, System.EventArgs e)
        {
            await ReportManagerContext.GetInstance().FillCurrentDeviceByMsCodeAsync(MsCode);
        }
    }
}

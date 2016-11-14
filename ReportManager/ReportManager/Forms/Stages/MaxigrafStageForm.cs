using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.DashboardCommon.Native;
using DevExpress.XtraEditors;
using ReportManager.Core;
using ReportManager.Data.DataModel;
using ReportManager.MaxigrafIntegration;

namespace ReportManager.Forms.Stages
{
    public partial class MaxigrafStageForm : XtraForm
    {
        private MaxiConnection Connection;
        private TextBox memo;

        public MaxigrafStageForm()
        {
            InitializeComponent();

            memo = GetInnerTextBox(memoEdit1);
            textEdit1.Text = "test.txt";
        }

        private void OnDeviceModelCreatedStatus(object sender, Tuple<DeviceModelStatus, DeviceModel> data)
        {
            if (data.Item1 == DeviceModelStatus.CreatedSuccess)
            {
                textBox1.Text = ReportManagerContext.GetInstance().CurrentDeviceModel.InputData[0].IndexNumber;
            }
            else
            {
                Connection?.Dispose();
                Close();
            }
        }

        private void Create()
        {
            Connection = new MaxiConnection();
            Connection.ConnectionEventHandler += ConnectionOnConnectionEventHandler;
            Connection.ReadEventHandler += ConnectionOnReadEventHandler;
            Connection.WriteEventHandler += ConnectionOnWriteEventHandler;
        }

        private void ConnectionOnWriteEventHandler(object sender, Tuple<ReadWriteStatus, string> status)
        {
            Invoke((MethodInvoker)delegate
            {
                memo.AppendText($"OnWriteHandler. Status: {status.Item1}. Message: {status.Item2}\n");
            });
        }

        private void ConnectionOnReadEventHandler(object sender, Tuple<ReadWriteStatus, string> status)
        {
            Invoke((MethodInvoker)delegate
            {
                memo.AppendText($"OnReadHandler. Status: {status.Item1}. Message: {status.Item2}\n");
            });
        }

        private void ConnectionOnConnectionEventHandler(object sender, Tuple<ConnectStatus, string> status)
        {
            Invoke((MethodInvoker) delegate
            {
                memo.AppendText($"OnConnectionStatus. Status: {status.Item1}. Message: {status.Item2}\n");
            });
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Connection.Connect();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Connection.ShowCrossJoystick();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Connection.Dispose();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Connection.ReadServerPipe();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            Connection?.Dispose();
            Create();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            memo.Clear();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            Connection.StopMarking();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            Connection.SendTextScript(textEdit1.Text);
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            Connection.StartMarking();
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            Connection.ShowRectJoystick();
        }

        private void MaxigrafStageForm_Shown(object sender, EventArgs e)
        {
            ReportManagerContext.GetInstance().DeviceModelCreatedStatus += OnDeviceModelCreatedStatus;
            textBox1.Text = ReportManagerContext.GetInstance().CurrentDeviceModel.InputData[0].IndexNumber;
        }

        private void MaxigrafStageForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ReportManagerContext.GetInstance().DeviceModelCreatedStatus -= OnDeviceModelCreatedStatus;
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            Connection.SendLeScript(textEdit1.Text);
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            using (var fileDialog = new OpenFileDialog())
            {
                if (fileDialog.ShowDialog() == DialogResult.OK)
                    textEdit1.Text = fileDialog.FileName;
            }
        }

        private void memoEdit1_TextChanged(object sender, EventArgs e)
        {
            BeginInvoke(new MethodInvoker(SetSelection));
        }

        private void SetSelection()
        {
            memoEdit1.SelectionStart = memoEdit1.Text.Length;
            memoEdit1.ScrollToCaret();
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            var i = 0;
            var list = new List<string>();
            while (i++ < 10000)
            {
                memo.AppendText("sgsdgsdgsdg\n");
                //list.Add("sgsdgsdgsdg");
                //memoEdit1.Lines = list.ToArray();
            }
        }

        private TextBox GetInnerTextBox(TextEdit editor)
        {
            if (editor != null)
                foreach (Control control in editor.Controls)
                    if (control is TextBox)
                        return (TextBox)control;
            return null;
        }
    }
}

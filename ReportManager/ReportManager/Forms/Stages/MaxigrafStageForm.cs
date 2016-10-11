using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ReportManager.Core;
using ReportManager.Data.DataModel;
using ReportManager.MaxigrafIntegration;

namespace ReportManager.Forms.Stages
{
    public partial class MaxigrafStageForm : XtraForm
    {
        private MaxiConnection Connection;
        private readonly List<string> log;

        public MaxigrafStageForm()
        {
            InitializeComponent();
            log = new List<string>();
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
                log.Add($"OnWriteHandler. Status: {status.Item1}. Message: {status.Item2}\n");
                memoEdit1.Lines = log.ToArray();
            });
        }

        private void ConnectionOnReadEventHandler(object sender, Tuple<ReadWriteStatus, string> status)
        {
            Invoke((MethodInvoker)delegate
            {
                log.Add($"OnReadHandler. Status: {status.Item1}. Message: {status.Item2}\n");
                memoEdit1.Lines = log.ToArray();
            });
        }

        private void ConnectionOnConnectionEventHandler(object sender, Tuple<ConnectStatus, string> status)
        {
            Invoke((MethodInvoker) delegate
            {
                log.Add($"OnConnectionStatus. Status: {status.Item1}. Message: {status.Item2}\n");
                memoEdit1.Lines = log.ToArray();
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
            log.Clear();
            memoEdit1.Lines = log.ToArray();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            Connection.StopMarking();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            Connection.SendScript();
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
    }
}

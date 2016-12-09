using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ReportManager.Core;
using ReportManager.Data.DataModel;
using ReportManager.MaxigrafIntegration;
using ReportManager.Properties;

using static ReportManager.MaxigrafIntegration.ServerPipeSettings;
using static ReportManager.MaxigrafIntegration.ServerPipeSettings.Commands;

namespace ReportManager.Forms.Stages.MaxigraphStageForm
{
    public partial class MaxigrafStageForm : XtraForm
    {
        private MaxiConnection _connection;
        private readonly TextBox _memo;
        private InputData _inputData;

        public MaxigrafStageForm()
        {
            InitializeComponent();
            _memo = GetInnerTextBox(memoLog);
            _inputData = ReportManagerContext.GetInstance().CurrentInput;
        }

        private void MaxigrafStageForm_Shown(object sender, EventArgs e)
        {
            ReportManagerContext.GetInstance().InputDataCreatedStatus += OnDeviceModelCreatedStatus;
            tbSerial.Text = _inputData.INDEX_NO;
        }

        private void MaxigrafStageForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DestroyConnection();
            ReportManagerContext.GetInstance().InputDataCreatedStatus -= OnDeviceModelCreatedStatus;
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            progressPanel.Visible = true;
            btnConnect.Enabled = false;
            CreateConnectionAsync();
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            btnDisconnect.Enabled = false;
            grpControl.Enabled = false;
            DestroyConnection();
        }

        private async void BtnShowCross_ClickAsync(object sender, EventArgs e)
        {
            var asyncShowCrossJoystick = _connection?.ShowCrossJoystickAsync();
            if (asyncShowCrossJoystick != null) await asyncShowCrossJoystick;
        }

        private async void BtnShowRect_ClickAsync(object sender, EventArgs e)
        {
            var asyncShowRectJoystick = _connection?.ShowRectJoystickAsync();
            if (asyncShowRectJoystick != null) await asyncShowRectJoystick;
        }

        private async void BtnStart_ClickAsync(object sender, EventArgs e)
        {
            grpConnection.Enabled = false;
            progressMarking.Position = 10;
            tbGraphStatus.Text = Resources.MaxigrafStageForm_btnStart_Click_LeLoadStart;

            var asyncSendLeScript = _connection?.SendLeScriptAsync("Путь до файла скрипта");
            if (asyncSendLeScript != null) await asyncSendLeScript;

            progressMarking.Position = 30;
            tbGraphStatus.Text = Resources.MaxigrafStageForm_btnStart_Click_ValueSettingStart;

            /*
             Загрузка полей для скрипта
             */
            var asyncSetNewValue = _connection?.SetNewValueAsync("Путь", "Значение");
            if (asyncSetNewValue != null) await asyncSetNewValue;

            progressMarking.Position = 60;
            tbGraphStatus.Text = Resources.MaxigrafStageForm_btnStart_Click_GraphStart;

            var asyncStartMarking = _connection?.StartMarkingAsync();
            if (asyncStartMarking != null) await asyncStartMarking;

            progressMarking.Position = 80;
        }

        private async void BtnStop_ClickAsync(object sender, EventArgs e)
        {

            var asyncStopMarking = _connection?.StopMarkingAsync();
            if (asyncStopMarking != null) await asyncStopMarking;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            _memo.Clear();
        }

        private void OnDeviceModelCreatedStatus(object sender, (DeviceModelStatus, InputData) data)
        {
            var (status, input) = data;
            _inputData = input;

            if (status == DeviceModelStatus.CreatedSuccess)
            {
                tbSerial.Text = _inputData.INDEX_NO;
            }
            else
            {
                _connection?.Dispose();
                Close();
            }
        }

        private void MemoLog_TextChanged(object sender, EventArgs e)
        {
            BeginInvoke(new MethodInvoker(SetSelection));
        }

        private void SetSelection()
        {
            memoLog.SelectionStart = memoLog.Text.Length;
            memoLog.ScrollToCaret();
        }

        private async void CreateConnectionAsync()
        {
            _connection?.Dispose();
            _connection = new MaxiConnection();
            _connection.ConnectionEventHandler += ConnectionOnConnectionEventHandler;
            _connection.ReadEventHandler += ConnectionOnReadEventHandler;
            _connection.WriteEventHandler += ConnectionOnWriteEventHandler;
            await _connection.ConnectAsync();
            _connection.StartReadServerPipe();
        }

        private void ConnectionOnWriteEventHandler(object sender, Tuple<ReadWriteStatus, string> status)
        {
            Invoke((MethodInvoker)delegate
            {
                _memo.AppendText($"[Write handler]. Status: {status.Item1}. Message: {status.Item2}\n\n");
            });
        }

        private void ConnectionOnReadEventHandler(object sender, Tuple<ReadWriteStatus, string> status)
        {
            Invoke((MethodInvoker)delegate
            {
                _memo.AppendText($"[Read handler]. Status: {status.Item1}. Message: {status.Item2}\n\n");

                if (status.Item1 != ReadWriteStatus.Success) return;

                if (status.Item2 == CommandsList[MarkingCompleted])
                {
                    grpConnection.Enabled = true;
                    tbGraphStatus.Text = Resources.MaxigrafStageForm_ConnectionOnReadEventHandler_GraphSuccess;
                    progressMarking.Position = 100;
                }
                else if (status.Item2 == CommandsList[MarkingStopped])
                {
                    grpConnection.Enabled = true;
                    tbGraphStatus.Text = Resources.MaxigrafStageForm_ConnectionOnReadEventHandler_GraphStopped;
                    progressMarking.Position = 0;
                }
            });
        }

        private void ConnectionOnConnectionEventHandler(object sender, Tuple<ConnectStatus, string> status)
        {
            Invoke((MethodInvoker) delegate
            {
                _memo.AppendText($"[Connection handler]. Status: {status.Item1}. Message: {status.Item2}\n\n");

                progressPanel.Visible = false;
                if (status.Item1 == ConnectStatus.SuccessConnected)
                {
                    btnDisconnect.Enabled = true;
                    grpControl.Enabled = true;
                }
                else
                {
                    btnConnect.Enabled = true;
                }
            });
        }

        private void DestroyConnection()
        {
            _connection?.Dispose();
        }

        private static TextBox GetInnerTextBox(TextEdit editor)
        {
            return editor?.Controls.OfType<TextBox>().FirstOrDefault();
        }
    }
}

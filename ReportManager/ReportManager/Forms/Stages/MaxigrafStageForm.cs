using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ReportManager.Core;
using ReportManager.Data.DataModel;
using ReportManager.MaxigrafIntegration;
using ReportManager.Properties;
using ReportManager.Data.Extensions;

using static ReportManager.MaxigrafIntegration.ServerPipeSettings;
using static ReportManager.MaxigrafIntegration.ServerPipeSettings.Commands;
using ReportManager.Data.SAP.ConcreteAdapters;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using ReportManager.Data.AbstractAdapters;

namespace ReportManager.Forms.Stages.MaxigraphStageForm
{
    public partial class MaxigrafStageForm : XtraForm
    {
        private MaxiConnection _connection;
        private readonly TextBox _memo;
        private InputData _inputData;
        private MaxigrafPlate _plate;

        public MaxigrafStageForm()
        {
            InitializeComponent();
            _memo = GetInnerTextBox(memoLog);
            _inputData = ReportManagerContext.GetInstance().CurrentInput;
        }

        private async void SetDataSource()
        {
            var results = new NifudaInputDataDatabaseAdapter()
                .SelectFromProcedure(_plate.StoredProcedureName, _plate.PlateID, _inputData.SERIAL_NO)
                .ToList();

            gridControl1.DataSource = results;
            gridControl1.RefreshDataSource();

            await Task.Run(() =>
            {
                Thread.Sleep(500);
                Invoke((Action)(() => btnConnect.PerformClick()));
            });
        }

        private bool FindPlate()
        {
            _plate = MatchPlate(_inputData.MS_CODE);
            if (_plate == null)
            {
                MessageBox.Show($"Не найдена табличка, удовлетворяющая данному MSCode {_inputData.MS_CODE}");
                Close();
                return false;
            }
            return true;
        }

        private MaxigrafPlate MatchPlate(string msCode)
        {
            var plates = (new MaxigrafPlatesDatabaseAdapter()).Select();
            return plates.FirstOrDefault(p => Regex.Match(msCode, p.Regex).Success);
        }

        private void MaxigrafStageForm_Shown(object sender, EventArgs e)
        {
            ReportManagerContext.GetInstance().InputDataCreatedStatus += OnDeviceModelCreatedStatus;
            if (!FindPlate()) return;
            SetDataSource();
            tbSerial.Text = _inputData.INDEX_NO;
            tbPlateName.Text = _plate.PlateName;
        }

        private void MaxigrafStageForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DestroyConnection();
            ReportManagerContext.GetInstance().InputDataCreatedStatus -= OnDeviceModelCreatedStatus;
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            if (_connection == null || !_connection.Alive)
            {
                progressPanel.Visible = true;
                btnConnect.Enabled = false;
                CreateConnectionAsync();
            }
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            if (_connection != null && _connection.Alive)
            {
                btnDisconnect.Enabled = false;
                grpControl.Enabled = false;
                DestroyConnection();
            }
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
            btnStart.Enabled = false;
            tbGraphStatus.Text = Resources.MaxigrafStageForm_btnStart_Click_LeLoadStart;

            var asyncSendLeScript = _connection?.SendLeScriptAsync(_plate.ScriptPath);
            if (asyncSendLeScript != null) await asyncSendLeScript;

            progressMarking.Position = 30;
            tbGraphStatus.Text = Resources.MaxigrafStageForm_btnStart_Click_ValueSettingStart;

            foreach (var setting in (gridControl1.DataSource as List<Pair>))
            {
                if (setting.Item2 != string.Empty)
                {
                    var asyncSetNewValue = _connection?.SetNewValueAsync($"{setting.Item1}.Text",
                                                                         setting.Item2);
                    if (asyncSetNewValue != null) await asyncSetNewValue;
                }
                else
                {
                    var asyncSetNewValue = _connection?.SetNewValueAsync($"{setting.Item1}.MarkPrim",
                                                                         "false");
                    if (asyncSetNewValue != null) await asyncSetNewValue;
                }
            }

            /*
             Загрузка полей для скрипта

             В цикле по принятому курсору
             foreach(var setting in "Курсор")
             {
                 var asyncSetNewValue = _connection?.SetNewValueAsync(setting.ObjectPath, setting.Value);
                 if (asyncSetNewValue != null) await asyncSetNewValue;
             }
             */

            progressMarking.Position = 60;
            tbGraphStatus.Text = Resources.MaxigrafStageForm_btnStart_Click_GraphStart;

            var asyncStartMarking = _connection?.StartMarkingAsync();
            if (asyncStartMarking != null) await asyncStartMarking;

            btnStop.Enabled = true;
            progressMarking.Position = 80;
        }

        private async void BtnStop_ClickAsync(object sender, EventArgs e)
        {
            var asyncStopMarking = _connection?.StopMarkingAsync();
            if (asyncStopMarking != null) await asyncStopMarking;
            btnStop.Enabled = false;
            btnStart.Enabled = true;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            _memo.Clear();
        }

        private void OnDeviceModelCreatedStatus(object sender, (DeviceModelStatus, string, InputData) data)
        {
            this.SafeInvoke(() =>
            {
                var (status, error, input) = data;
                _inputData = input;
                if (!FindPlate()) return;
                SetDataSource();
                if (status != DeviceModelStatus.SuccessNifuda
                    || status != DeviceModelStatus.SuccessSap)
                {
                    tbSerial.Text = _inputData.INDEX_NO;
                    tbPlateName.Text = _plate.PlateName;
                }
                else
                {
                    _connection?.Dispose();
                    Close();
                }
            });
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

        private void ConnectionOnWriteEventHandler(object sender, (Status status, string message) status)
        {
            Invoke((MethodInvoker)delegate
            {
                if (status.status == Status.Message)
                {
                    _memo.AppendText($"!!! {status.message} !!!");
                }
                else
                {
                    _memo.AppendText($"[Write handler]. Status: {status.status}. Message: {status.message}\n\n");
                }
            });
        }

        private void ConnectionOnReadEventHandler(object sender, (Status status, string message) status)
        {
            Invoke((MethodInvoker)delegate
            {
                _memo.AppendText($"[Read handler]. Status: {status.status}. Message: {status.message}\n\n");

                if (status.Item1 != Status.Success) return;

                if (status.Item2 == CommandsList[MarkingCompleted])
                {
                    btnStart.Enabled = true;
                    btnStop.Enabled = false;
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

        private void ConnectionOnConnectionEventHandler(object sender, (ConnectStatus status, string message) status)
        {
            Invoke((MethodInvoker)delegate
            {
                _memo.AppendText($"[Connection handler]. Status: {status.status}. Message: {status.message}\n\n");

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

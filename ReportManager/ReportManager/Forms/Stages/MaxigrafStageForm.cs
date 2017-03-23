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

            var table = new List<GU1_Table> {
                new GU1_Table
                {
                    MODEL = ("", _inputData.MODEL),
                    PROD_CAREER = ("", _inputData.PROD_CAREER),
                    MS_CODE = ("", _inputData.MS_CODE),
                    POWER = ("", _inputData.MS_CODE),
                    MWP = ("", _inputData.MS_CODE),
                    ORD_INST_MIN_502 = ("", _inputData.ORD_INST_MIN_502),
                    ORD_INST_MAX_502 = ("", _inputData.ORD_INST_MAX_502),
                    UNIT_502 = ("", _inputData.UNIT_502),
                    SERIAL_NO = ("", _inputData.SERIAL_NO),
                    ORD = ("", ""),
                    ORD_INST_CONTECT1_Z30 = ("", _inputData.ORD_INST_CONTECT1_Z30),
                    TAG_NO_525 = ("", _inputData.TAG_NO_525),
                    TAG_NO_525_1 = ("", _inputData.TAG_NO_525)
            } }
            .PropertiesToDict()
            .Select(el => new Pair { Item1 = (((string, string))el.Value).Item1, Item2 = (((string, string))el.Value).Item2 } )
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
                SetDataSource();
                if (!FindPlate()) return;

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

    internal class GU1_Table
    {
        private string model_path => @"DPharp_Parameters\MODEL";
        private string prod_career_path => @"DPharp_Parameters\PROD_CAREER";
        private string ms_code_path => @"DPharp_Parameters\MS_CODE";
        private string ms_code_1_path => @"DPharp_Parameters\MS_CODE1";
        private string power_path => @"DPharp_Parameters\POWER";
        private string mwp_path => @"DPharp_Parameters\MWP";
        private string ord_inst_min_525_path => @"DPharp_Parameters\ORD_INST_MIN_502";
        private string ord_inst_max_525_path => @"DPharp_Parameters\ORD_INST_MAX_502";
        private string unit_502_path => @"DPharp_Parameters\UNIT_502";
        private string serial_no_path => @"DPharp_Parameters\SERIAL_NO";
        private string ord_path => @"DPharp_Parameters\ORD";
        private string ord_inst_contect1_z30_path => @"DPharp_Parameters\ORD_INST_CONTECT1_Z30";
        private string tag_no_525_path => @"DPharp_Parameters\TAG_NO_525";
        private string tag_no_525_1_path => @"DPharp_Parameters\TAG_NO_525_1";

        private string model_value { get; set; } = "";
        private string prod_career_value { get; set; } = "";
        private string ms_code_value { get; set; } = "";
        private string ms_code_1_value { get; set; } = "";
        private string power_value { get; set; } = "";
        private string mwp_value { get; set; } = "";
        private string ord_inst_min_525_value { get; set; } = "";
        private string ord_inst_max_525_value { get; set; } = "";
        private string unit_502_value { get; set; } = "";
        private string serial_no_value { get; set; } = "";
        private string ord_value { get; set; } = "";
        private string ord_inst_contect1_z30_value { get; set; } = "";
        private string tag_no_525_value { get; set; } = "";
        private string tag_no_525_1_value { get; set; } = "";

        public (string path, string value) MODEL
        {
            get { return (model_path, model_value); }
            set { model_value = value.value; }
        }
        public (string path, string value) PROD_CAREER
        {
            get { return (prod_career_path, prod_career_value); }
            set { prod_career_value = value.value; }
        }
        public (string path, string value) MS_CODE
        {
            get { return (ms_code_path, ms_code_value); }
            set
            {
                if (value.value.Length <= 31)
                    ms_code_value = value.value.Substring(7);
                else
                {
                    ms_code_value = value.value.Substring(7, 24);
                    ms_code_1_value = value.value.Substring(31);
                }
            }
        }
        public (string path, string value) MS_CODE1
        {
            get { return (ms_code_1_path, ms_code_1_value); }
            set { ms_code_1_value = value.value; }
        }
        public (string path, string value) POWER
        {
            get { return (power_path, power_value); }
            set
            {
                if (Regex.Match(value.value, "/A").Success)
                    power_value = "10.5-30(32)";
                else
                    power_value = "10.5-30(42)";
            }
        }
        public (string path, string value) MWP
        {
            get { return (mwp_path, mwp_value); }
            set
            {
                if (Regex.Match(value.value, "EJA110E").Success 
                    && Regex.Match(value.value, "/HG").Success)
                {
                    mwp_value = "25";
                }
                else if (Regex.Match(value.value, "EJA110E").Success
                         && !Regex.Match(value.value, "/HG").Success)
                {
                    mwp_value = "16";
                }
                else if (Regex.Match(value.value, "EJA530E").Success)
                {
                    switch (value.value[9])
                    {
                        case 'A': mwp_value = "0.2"; break;
                        case 'B': mwp_value = "2"; break;
                        case 'C': mwp_value = "10"; break;
                        case 'D': mwp_value = Regex.Match(value.value, "/HG").Success ? "70" : "50"; break;
                    }
                }
            }
        }
        public (string path, string value) ORD_INST_MIN_502
        {
            get { return (ord_inst_min_525_path, ord_inst_min_525_value); }
            set { ord_inst_min_525_value = value.value; }
        }
        public (string path, string value) ORD_INST_MAX_502
        {
            get { return (ord_inst_max_525_path, ord_inst_max_525_value); }
            set { ord_inst_max_525_value = value.value; }
        }
        public (string path, string value) UNIT_502
        {
            get { return (unit_502_path, unit_502_value); }
            set { unit_502_value = value.value; }
        }
        public (string path, string value) SERIAL_NO
        {
            get { return (serial_no_path, serial_no_value); }
            set { serial_no_value = value.value; }
        }
        public (string path, string value) ORD
        {
            get { return (ord_path, ord_value); }
            set
            {
                ord_value = $"{DateTime.Now.Year.ToString()[3]}{GetIso8601WeekOfYear(DateTime.Now)}";
            }
        }
        public (string path, string value) ORD_INST_CONTECT1_Z30
        {
            get { return (ord_inst_contect1_z30_path, ord_inst_contect1_z30_value); }
            set { ord_inst_contect1_z30_value = value.value; }
        }
        public (string path, string value) TAG_NO_525
        {
            get { return (tag_no_525_path, tag_no_525_value); }
            set { tag_no_525_value = value.value; }
        }
        public (string path, string value) TAG_NO_525_1
        {
            get { return (tag_no_525_1_path, tag_no_525_1_value); }
            set { tag_no_525_1_value = value.value; }
        }

        private static int GetIso8601WeekOfYear(DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
    }
}

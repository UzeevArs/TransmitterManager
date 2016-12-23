using System;
using System.Data;
using System.Drawing;
using System.Security.Permissions;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ReportManager.Core;
using ReportManager.Core.Functional;
using ReportManager.Core.Stages;
using ReportManager.Core.Utility;
using ReportManager.Data.Database;
using ReportManager.Data.DataModel;
using ReportManager.Data.Settings;
using ReportManager.Forms.Data;
using ReportManager.Forms.Settings;
using ReportManager.Forms.Stages.MaxigraphStageForm;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;

namespace ReportManager.Forms
{
    public partial class StagesForm : XtraForm
    {
        public StagesForm()
        {
            InitializeComponent();

            FillData();
            
            var keyFilter = new KeyMessageFilter();
            keyFilter.EventKeyHandler += KeyFilter_EventKeyHandler;
            Application.AddMessageFilter(keyFilter);
            Application.ApplicationExit += Application_ApplicationExit;

            ReportManagerContext.GetInstance().Fill();
            ReportManagerContext.GetInstance().Start();

            UpdateStageButtons();

            SettingsContext.SettingsLoadingEvent += SettingsContextOnSettingsLoadingEvent;
            ReportManagerContext.GetInstance().InputDataCreatedStatus += StagesForm_DeviceModelCreatedStatus;
            FunctionalSubscribe();
        }

        private void FillData()
        {
            ribbonPage3.Visible = SettingsContext.CurrentUser.TUSER == "ReportManagerAdmin";
            lblUserName.Caption += SettingsContext.CurrentUser.FullName;
        }

        private void StagesForm_DeviceModelCreatedStatus(object sender, (DeviceModelStatus, InputData) data)
        {
            var (status, input) = data;

            Invoke((MethodInvoker) delegate
            {
                if (status == DeviceModelStatus.CreatedError)
                {
                    MessageBox.Show("Серийный номер не найден", "Предупреждение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    btnTrasportListCreateStage.Enabled = false;
                    btnReportCreateStage.Enabled = false;
                    btnMaxigrafStage.Enabled = false;
                    lblExtraInformation.EditValue = "";
                    lblExtraInformation.Visibility = BarItemVisibility.Never;
                    edtMsCode.EditValue = "";
                }
                else
                {
                    btnTrasportListCreateStage.Enabled = true;
                    btnReportCreateStage.Enabled = true;
                    btnMaxigrafStage.Enabled = true;
                }
            });
        }

        private void FunctionalSubscribe()
        {
            foreach (var functional in SettingsContext.CurrentUser.UserExtraFunction)
            {
                if (functional.GetType() == typeof(CheckIsupDbConnectionFunctional))
                {
                    (functional as CheckIsupDbConnectionFunctional).StateChange += IsupDbConnectionOnStateChange;
                }
                else if (functional.GetType() == typeof(CheckManifactureDbConnectionFunctional))
                {
                    (functional as CheckManifactureDbConnectionFunctional).StateChange +=
                        ManifactureDbConnectionOnStateChange;
                }
                else if (functional.GetType() == typeof(SynchronizeDbFunctional))
                {
                    (functional as SynchronizeDbFunctional).SyncronizeDataIncome += SyncOnStateChanged;
                }
            }
        }

        private void SyncOnStateChanged(object sender, (IEnumerable<InputData>, DateTime) data)
        {
            try
            {
                Invoke((MethodInvoker) delegate
                {
                    var (input, date) = data;
                    lblStatus.Caption = $"Дата: {date}. Непринятых заказов: {input.Count()}";
                });
            }
            catch
            {
            }
        }

        private void ManifactureDbConnectionOnStateChange(object sender, StateChangeEventArgs stateChangeEventArgs)
        {
            try
            {
                Invoke((MethodInvoker) delegate
                {
                    if (stateChangeEventArgs.CurrentState == ConnectionState.Closed)
                    {
                        btnTrasportListCreateStage.Enabled = false;
                        btnReportCreateStage.Enabled = false;
                        btnMaxigrafStage.Enabled = false;
                        lblNifudaConnectionStatus.Caption = "Соединение с производственной бд отсутствует";
                    }
                    else if (stateChangeEventArgs.CurrentState == ConnectionState.Open)
                    {
                        lblNifudaConnectionStatus.Caption = "Соединение с производственной бд установлено";
                    }
                });
            }
            catch { }
        }

        private void IsupDbConnectionOnStateChange(object sender, StateChangeEventArgs stateChangeEventArgs)
        {
            try
            {
                Invoke((MethodInvoker)delegate
                {
                    if (stateChangeEventArgs.CurrentState == ConnectionState.Closed)
                    {
                        btnTrasportListCreateStage.Enabled = false;
                        lblIsupConnectionStatus.Caption = "Соединение с ISUP бд отсутствует";
                    }
                    else if (stateChangeEventArgs.CurrentState == ConnectionState.Open)
                    {
                        lblIsupConnectionStatus.Caption = "Соединение с ISUP бд установлено";
                    }
                });
            }
            catch { }
        }

        private void SettingsContextOnSettingsLoadingEvent(object sender, (ReportManager.Data.Settings.Settings, SettingsStatus, string) status)
        {
            var (settings, settingsStatus, message) = status;
            if (settingsStatus == SettingsStatus.Changed || settingsStatus == SettingsStatus.SuccessLoaded)
            {
                lblIsupConnectionStatus.Caption = "";
                lblNifudaConnectionStatus.Caption = "";
                lblStatus.Caption = "";
                UpdateStageButtons();
                FunctionalSubscribe();
            }
        }

        private void UpdateStageButtons()
        {
            btnTrasportListCreateStage.Visibility = SettingsContext.CurrentUser.UserStages.Find(stage =>
                stage.GetType() == typeof(TransportListCreateStage)) != null ? BarItemVisibility.Always : BarItemVisibility.Never;
            btnTrasportListCreateStage.Tag =
                SettingsContext.CurrentUser.UserStages.Find(stage => stage.GetType() == typeof(TransportListCreateStage));

            btnReportCreateStage.Visibility = SettingsContext.CurrentUser.UserStages.Find(stage =>
                stage.GetType() == typeof(ReportCreateStage)) != null ? BarItemVisibility.Always : BarItemVisibility.Never;
            btnReportCreateStage.Tag =
                SettingsContext.CurrentUser.UserStages.Find(stage => stage.GetType() == typeof(ReportCreateStage));

            btnMaxigrafStage.Visibility = SettingsContext.CurrentUser.UserStages.Find(stage =>
                stage.GetType() == typeof(MaxigrafStage)) != null ? BarItemVisibility.Always : BarItemVisibility.Never;
            btnMaxigrafStage.Tag =
                SettingsContext.CurrentUser.UserStages.Find(stage => stage.GetType() == typeof(MaxigrafStage));
        }

        #region Application launch
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_SHOWME)
            {
                ShowMe();
            }
            base.WndProc(ref m);
        }

        private void ShowMe()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            if (!Visible)
            {
                Show();
            }
            notifyIcon.Visible = false;
        }

        private void StagesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                e.Cancel = true;
                Hide();
                notifyIcon.Visible = true;
            }
        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Show();
                notifyIcon.Visible = false;
            }
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            ReportManagerContext.GetInstance().Dispose();
        }

        private void BtnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region KeyEvents
        private void KeyFilter_EventKeyHandler(object sender, Keys key, string serial)
        {
            lblExtraInformation.EditValue = "";
            lblExtraInformation.Visibility = BarItemVisibility.Never;
            edtMsCode.EditValue = "";
            edtMsCode.EditValue = serial;
        }

        private void EdtSerial_EditValueChanged(object sender, EventArgs e)
        {
            if (edtMsCode.EditValue != null && !edtMsCode.EditValue.Equals(string.Empty))
            {
                btnToSetManual.Enabled = true;

                edtMsCode.CanOpenEdit = false;
                edtMsCode.Edit.BorderStyle = BorderStyles.Default;
                edtMsCode.Edit.Appearance.BorderColor = DefaultBackColor;
                if (ReportManagerContext.GetInstance().FillCurrentDeviceByMsCode(edtMsCode.EditValue as string).Item1 ==
                    DeviceModelStatus.CreatedError)
                {
                    lblExtraInformation.EditValue = "";
                    lblExtraInformation.Visibility = BarItemVisibility.Never;
                    edtMsCode.EditValue = "";
                }
                else
                {
                    var input = ReportManagerContext.GetInstance().CurrentInput;
                    lblExtraInformation.EditValue = $"Модель: {input.MODEL}. Серийный номер: {input.SERIAL_NO}";
                    lblExtraInformation.Visibility = BarItemVisibility.Always;
                }
            }
        }
        #endregion

        private void BtnTrasportListCreateStage_ItemClick(object sender, ItemClickEventArgs e)
        {
            (btnTrasportListCreateStage.Tag as Stage)?.OpenForm(this);
        }

        private void BtnReportCreateStage_ItemClick(object sender, ItemClickEventArgs e)
        {
            (btnReportCreateStage.Tag as Stage)?.OpenForm(this);
        }

        private void BtnLoadData_ItemClick(object sender, ItemClickEventArgs e)
        {
            (btnMaxigrafStage.Tag as Stage)?.OpenForm(this);
        }

        private void BtnOpenSettings_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new SettingsForm().ShowDialog();
        }

        private void BtnToSetManual_ItemClick(object sender, ItemClickEventArgs e)
        {
            edtMsCode.CanOpenEdit = true;
            edtMsCode.Edit.BorderStyle = BorderStyles.HotFlat;
            edtMsCode.Edit.Appearance.BorderColor = Color.Brown;
            btnToSetManual.Enabled = false;
        }

        private void BtnAllData_ItemClick(object sender, ItemClickEventArgs e)
        {
            new AllDataForm {MdiParent = this}.Show();
        }

        private void BtnUserSettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            new UserSettingsForm { MdiParent = this }.Show();
        }

        private void BtnPlates_ItemClick(object sender, ItemClickEventArgs e)
        {
            new PlatesForm { MdiParent = this }.Show();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            
           

            SqlConnection sqlConnection1 = new SqlConnection("Data Source = localhost\\SQLEXPRESS; Initial Catalog = YruPCIassembling; Integrated Security = True");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "MaxiQuery";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@plateID", SqlDbType.Char, 20);
            cmd.Parameters["@plateID"].Value = "7";
            cmd.Parameters.Add("@sn", SqlDbType.Char, 20);
            cmd.Parameters["@sn"].Value = "Y2S900004";
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.

            if (reader.HasRows)
            {
                StringBuilder builder = new StringBuilder();
                while (reader.Read())
                {
                    builder.Append($"{new String(reader.GetSqlChars(0).Value)}\t{new String(reader.GetSqlChars(1).Value)}\n");
                }

                MessageBox.Show(builder.ToString());
            }
            else
            {
                MessageBox.Show("No rows found.");
            }
        
        sqlConnection1.Close();

            //TestClass tst = new TestClass();
            //tst.RunStoredProc();
            //tst.CreateUser();
        }
    }

    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
    public class KeyMessageFilter : IMessageFilter
    {
        public delegate void KeyHandler(object sender, Keys key, string keyChar);
        public event KeyHandler EventKeyHandler;

        private int _maxNumCount = 10;
        private int _currentNumCount = 0;

        private string _tempString = "";

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg != 0x101) return false;

            var keyData = (Keys)m.WParam;
            Console.WriteLine($"Blocked messages: { new KeysConverter().ConvertToString(keyData) }");

            if (keyData >= Keys.D0 && keyData <= Keys.D9)
            {
                _tempString += new KeysConverter().ConvertToString(keyData);
                _currentNumCount++;
            }
            else if (keyData == Keys.Enter)
            {
                if (_currentNumCount == _maxNumCount)
                {
                    GenerateEvent(keyData, _tempString);
                    _tempString = "";
                    _currentNumCount = 0;
                    return true;
                }

                _tempString = "";
                _currentNumCount = 0;
            }
            else
            {
                _tempString = "";
                _currentNumCount = 0;
            }

            return false;
        }

        private void GenerateEvent(Keys keyData, string generatedString)
        {
            EventKeyHandler?.Invoke(this, keyData, generatedString);
            Console.WriteLine($"GeneratingEvent: {generatedString}");
        }
    }
}

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

namespace ReportManager.Forms
{
    public partial class StagesForm : XtraForm
    {
        public StagesForm()
        {
            InitializeComponent();

            var keyFilter = new KeyMessageFilter();
            keyFilter.EventKeyHandler += KeyFilter_EventKeyHandler;
            Application.AddMessageFilter(keyFilter);
            Application.ApplicationExit += Application_ApplicationExit;

            ReportManagerContext.GetInstance().Fill();
            ReportManagerContext.GetInstance().Start();

            UpdateStageButtons();

            SettingsContext.SettingsLoadingEvent += SettingsContextOnSettingsLoadingEvent;
            ReportManagerContext.GetInstance().DeviceModelCreatedStatus += StagesForm_DeviceModelCreatedStatus;
            FunctionalSubscribe();
        }

        private void StagesForm_DeviceModelCreatedStatus(object sender,
            Tuple<DeviceModelStatus, DeviceModel> data)
        {
            Invoke((MethodInvoker) delegate
            {
                if (data.Item1 == DeviceModelStatus.CreatedError)
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
            foreach (var functional in SettingsContext.GlobalSettings.Functionals)
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

        private void SyncOnStateChanged(object sender, Tuple<NifudaDataSet.NifudaDataTableDataTable, DateTime> data)
        {
            try
            {
                Invoke((MethodInvoker) delegate
                {
                    lblStatus.Caption = $"Дата: {data.Item2}. Непринятых заказов: {data.Item1.Count}";
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
            catch
            {
            }
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

        private void SettingsContextOnSettingsLoadingEvent(object sender, 
            Tuple<Settings, SettingsStatus, string> status)
        {
            if (status.Item2 == SettingsStatus.Changed
                || status.Item2 == SettingsStatus.SuccessLoaded)
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
            btnTrasportListCreateStage.Visibility = SettingsContext.GlobalSettings.Stages.Find(stage =>
                stage.GetType() == typeof(TransportListCreateStage)) != null ? BarItemVisibility.Always : BarItemVisibility.Never;
            btnTrasportListCreateStage.Tag =
                SettingsContext.GlobalSettings.Stages.Find(stage => stage.GetType() == typeof(TransportListCreateStage));

            btnReportCreateStage.Visibility = SettingsContext.GlobalSettings.Stages.Find(stage =>
                stage.GetType() == typeof(ReportCreateStage)) != null ? BarItemVisibility.Always : BarItemVisibility.Never;
            btnReportCreateStage.Tag =
                SettingsContext.GlobalSettings.Stages.Find(stage => stage.GetType() == typeof(ReportCreateStage));

            btnMaxigrafStage.Visibility = SettingsContext.GlobalSettings.Stages.Find(stage =>
                stage.GetType() == typeof(MaxigrafStage)) != null ? BarItemVisibility.Always : BarItemVisibility.Never;
            btnMaxigrafStage.Tag =
                SettingsContext.GlobalSettings.Stages.Find(stage => stage.GetType() == typeof(MaxigrafStage));
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

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
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

        private void btnExit_ItemClick(object sender, ItemClickEventArgs e)
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

        private void edtSerial_EditValueChanged(object sender, EventArgs e)
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
                    var model = ReportManagerContext.GetInstance().CurrentDeviceModel;
                    lblExtraInformation.EditValue = $"Модель: {model.InputData[0].Model}. Серийный номер: {model.InputData[0].SerialNumber}";
                    lblExtraInformation.Visibility = BarItemVisibility.Always;
                }
            }
        }
        #endregion

        private void btnTrasportListCreateStage_ItemClick(object sender, ItemClickEventArgs e)
        {
            (btnTrasportListCreateStage.Tag as AbstractStage)?.OpenForm(this);
        }

        private void btnReportCreateStage_ItemClick(object sender, ItemClickEventArgs e)
        {
            (btnReportCreateStage.Tag as AbstractStage)?.OpenForm(this);
        }

        private void btnLoadData_ItemClick(object sender, ItemClickEventArgs e)
        {
            (btnMaxigrafStage.Tag as AbstractStage)?.OpenForm(this);
        }

        private void btnOpenSettings_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new SettingsForm().ShowDialog();
        }

        private void btnToSetManual_ItemClick(object sender, ItemClickEventArgs e)
        {
            edtMsCode.CanOpenEdit = true;
            edtMsCode.Edit.BorderStyle = BorderStyles.HotFlat;
            edtMsCode.Edit.Appearance.BorderColor = Color.Brown;
            btnToSetManual.Enabled = false;
        }

        private void btnAllData_ItemClick(object sender, ItemClickEventArgs e)
        {
            new AllDataForm {MdiParent = this}.Show();
        }

    }

    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
    public class KeyMessageFilter : IMessageFilter
    {
        public delegate void KeyHandler(object sender, Keys key, string keyChar);
        public event KeyHandler EventKeyHandler;

        private int _maxNumCount = 10;
        private int _currentNumCount = 0;
        private bool _enterPressed;

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

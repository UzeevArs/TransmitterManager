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
using ReportManager.Data.SAP;
using ReportManager.Data.DataModel;
using ReportManager.Data.Settings;
using ReportManager.Forms.Data;
using ReportManager.Forms.Settings;
using ReportManager.Forms.Stages.MaxigraphStageForm;
using System.Collections.Generic;
using System.Linq;
using ReportManager.TemperatureLogger.Modbus;
using ReportManager.Forms.Stages;
using DevExpress.XtraEditors.Repository;
using ReportManager.Data.Extensions;

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
            ReportManagerContext.GetInstance().Device.OnChangeState += ModbusDevice_OnChangeState;
            FunctionalSubscribe();

            CreateFunctionalControls();
        }

        private void ModbusDevice_OnChangeState(object sender, TemperatureDevice.TemperatureDeviceState e)
        {
            switch (e)
            {
                case TemperatureDevice.TemperatureDeviceState.CheckConnection:
                    lblDevice.Caption = "Проверка соединения с устройством";
                    break;
                case TemperatureDevice.TemperatureDeviceState.FindPortName:
                    lblDevice.Caption = "Поиск COM порта";
                    break;
                case TemperatureDevice.TemperatureDeviceState.Read:
                    lblDevice.Caption = "Чтение с устройства";
                    break;
                case TemperatureDevice.TemperatureDeviceState.StopRead:
                    lblDevice.Caption = "Приостановлено чтение с устройства";
                    break;
                case TemperatureDevice.TemperatureDeviceState.Idle:
                    lblDevice.Caption = "Отключение устройства";
                    break;
            }
        }

        private void CreateFunctionalControls()
        {
            foreach (var func in ReportManagerContext.GetInstance().Functionals)
                CreateBarItem(func);
        }

        private int NextId = 100;
        private BarEditItem CreateBarItem(Functional functional)
        {
            RepositoryItemButtonEdit buttons = new RepositoryItemButtonEdit();
            buttons.BeginInit();

            BarEditItem item = new BarEditItem
            {
                Caption = $"{functional.Name}: ",
                Edit = buttons,
                Id = ++NextId,
                Name = $"barEditItem{NextId}",
                Tag = functional,
            };
            item.EditWidth = 110;
            item.Edit.ReadOnly = true;
            ribbonControl1.Items.Add(item);
            pgFunctionals.ItemLinks.Add(item);

            buttons.AutoHeight = true;
            buttons.TextEditStyle = TextEditStyles.DisableTextEditor;
            buttons.BorderStyle = BorderStyles.HotFlat;
            buttons.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.SpinRight),
                                                          new EditorButton(ButtonPredefines.Close) });
            buttons.Buttons[0].Click += (sender, args) => functional.Start();
            buttons.Buttons[1].Click += (sender, args) => functional.Stop();
            functional.StatusChanged += (sender, isRunning) => this.SafeInvoke(() => 
            {
                buttons.Buttons[0].Enabled = !isRunning;
                buttons.Buttons[1].Enabled = isRunning;
            });
            buttons.Name = $"repositoryItemButtonEdit{NextId}";
            buttons.Buttons[0].Enabled = !functional.IsRunning ?? true;
            buttons.Buttons[1].Enabled = functional.IsRunning ?? false;

            buttons.EndInit();

            functional.StatusChanged += (sender, isRunning) => 
                this.SafeInvoke(() => item.EditValue = isRunning ? "Выполняется" : "Остановлено");
            item.EditValue = (functional.IsRunning ?? false) ? "Выполняется" : "Остановлено";

            return item;
        }

        private void FillData()
        {
            ribbonPage3.Visible = SettingsContext.CurrentUser.TUSER == "ReportManagerAdmin";
            lblUserName.Caption += SettingsContext.CurrentUser.FullName;
        }

        private void StagesForm_DeviceModelCreatedStatus(object sender, 
                                                         (DeviceModelStatus, string, InputData) data)
        {
            var (status, error, input) = data;
            Action OnSuccess = () =>
            {
                lblExtraInformation.EditValue = $"Модель: {input.MODEL}. Серийный номер: {input.SERIAL_NO}";
                lblExtraInformation.Visibility = BarItemVisibility.Always;
                lblInputDataStatus.ItemAppearance.Normal.ForeColor = Color.Transparent;
                btnTrasportListCreateStage.Enabled = true;
                btnReportCreateStage.Enabled = true;
                btnMaxigrafStage.Enabled = true;
            };
            Action OnError = () =>
            {
                btnTrasportListCreateStage.Enabled = false;
                btnReportCreateStage.Enabled = false;
                btnMaxigrafStage.Enabled = false;
                lblInputDataStatus.ItemAppearance.Normal.ForeColor = Color.Coral;
                lblExtraInformation.EditValue = "";
                lblExtraInformation.Visibility = BarItemVisibility.Never;
                edtMsCode.EditValue = "";
            };

            this.SafeInvoke(() =>
            {
                switch (status)
                {
                    case DeviceModelStatus.ErrorNifudaConnection:
                        lblInputDataStatus.Caption = $"Произошла ошибка. Проверьте подключение к Nifuda БД";
                        OnError();
                        break;
                    case DeviceModelStatus.ErrorSapConnection:
                        lblInputDataStatus.Caption = $"Произошла ошибка. Проверьте подключение к SAP";
                        OnError();
                        break;
                    case DeviceModelStatus.ErrorSapNoData:
                        lblInputDataStatus.Caption = $"Произошла ошибка. Введённый серийный номер не найден в SAP";
                        OnError();
                        break;
                    case DeviceModelStatus.NifudaInsertError:
                        lblInputDataStatus.Caption = $"Произошла ошибка. Копирование данных в Nifuda БД произошло с ошибкой";
                        OnError();
                        break;
                    case DeviceModelStatus.SuccessNifuda:
                        lblInputDataStatus.Caption = $"Данные успешно загружены из Nifuda БД";
                        OnSuccess();
                        break;
                    case DeviceModelStatus.SuccessSap:
                        lblInputDataStatus.Caption = $"Данные успешно загружены из SAP и скопированы в Nifuda";
                        OnSuccess();
                        break;
                    case DeviceModelStatus.ErrorIndexNOGeneration:
                        lblInputDataStatus.Caption = $"Внутренний Index_NO не сгенерирован";
                        OnError();
                        break;
                    case DeviceModelStatus.ErrorIndexNoDatabaseConnection:
                        lblInputDataStatus.Caption = $"Отсутствует подключение к Таблице Index_NO";
                        OnError();
                        break;
                }
            });
        }

        private void FunctionalSubscribe()
        {
            foreach (var functional in SettingsContext.CurrentUser.UserExtraFunction)
            {
                if (functional.GetType() == typeof(CheckManifactureDbConnectionFunctional))
                {
                    (functional as CheckManifactureDbConnectionFunctional).StateChange +=
                        ManifactureDbConnectionOnStateChange;
                    (functional as CheckManifactureDbConnectionFunctional).StatusChanged += (sender, status) =>
                    {
                        if (!status) { lblNifudaConnectionStatus.Caption = ""; lblNifudaConnectionStatus.Visibility = BarItemVisibility.Never; }
                        else { lblNifudaConnectionStatus.Visibility = BarItemVisibility.Always; }
                    };
                }
                else if (functional.GetType() == typeof(TempteratureDeviceFunctional))
                {
                    (functional as TempteratureDeviceFunctional).StatusChanged += (sender, status) =>
                    {
                        if (!status) { lblDevice.Caption = ""; lblDevice.Visibility = BarItemVisibility.Never; }
                        else { lblDevice.Visibility = BarItemVisibility.Always; }
                    };
                }
            }
        }

        private void ManifactureDbConnectionOnStateChange(object sender, StateChangeEventArgs stateChangeEventArgs)
        {
            this.SafeInvoke(() =>
            {
                switch (stateChangeEventArgs.CurrentState)
                {
                    case ConnectionState.Closed:
                        btnTrasportListCreateStage.Enabled = false;
                        btnReportCreateStage.Enabled = false;
                        btnMaxigrafStage.Enabled = false;
                        lblNifudaConnectionStatus.Caption = "Соединение с производственной бд отсутствует";
                        break;
                    case ConnectionState.Open:
                        lblNifudaConnectionStatus.Caption = "Соединение с производственной бд установлено";
                        break;
                }
            });
        }

        private void IsupDbConnectionOnStateChange(object sender, StateChangeEventArgs stateChangeEventArgs)
        {
            this.SafeInvoke(() =>
            {
                switch (stateChangeEventArgs.CurrentState)
                {
                    case ConnectionState.Closed:
                        btnTrasportListCreateStage.Enabled = false;
                        lblIsupConnectionStatus.Caption = "Соединение с ISUP бд отсутствует";
                        break;
                    case ConnectionState.Open:
                        lblIsupConnectionStatus.Caption = "Соединение с ISUP бд установлено";
                        break;
                }
            });
        }

        private void SettingsContextOnSettingsLoadingEvent(object sender, 
                                                           (ReportManager.Data.Settings.Settings, SettingsStatus, string) status)
        {
            var (settings, settingsStatus, message) = status;
            if (settingsStatus == SettingsStatus.Changed 
                || settingsStatus == SettingsStatus.SuccessLoaded)
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

            btnTemperatureStage.Visibility = SettingsContext.CurrentUser.UserStages.Find(stage =>
                stage.GetType() == typeof(TemperatureStage)) != null ? BarItemVisibility.Always : BarItemVisibility.Never;
            btnTemperatureStage.Tag =
                SettingsContext.CurrentUser.UserStages.Find(stage => stage.GetType() == typeof(TemperatureStage));
        }

        #region Application launch
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_SHOWME)
                ShowMe();
            base.WndProc(ref m);
        }

        private void ShowMe()
        {
            if (WindowState == FormWindowState.Minimized)
                WindowState = FormWindowState.Normal;
            if (!Visible)
                Show();
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
            if (edtMsCode.EditValue != null 
                && !edtMsCode.EditValue.Equals(string.Empty))
            {
                btnToSetManual.Enabled = true;

                edtMsCode.CanOpenEdit = false;
                edtMsCode.Edit.BorderStyle = BorderStyles.Default;
                edtMsCode.Edit.Appearance.BorderColor = DefaultBackColor;

                new WaitForm(edtMsCode.EditValue as string).ShowDialog();                
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

        private void BtnTemperatureStage_ItemClick(object sender, ItemClickEventArgs e)
        {
            (btnTemperatureStage.Tag as Stage)?.OpenForm(this);
        }

        private void BtnOpenSettings_ItemClick(object sender, ItemClickEventArgs e)
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
    }

    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
    public class KeyMessageFilter : IMessageFilter
    {
        public delegate void KeyHandler(object sender, Keys key, string keyChar);
        public event KeyHandler EventKeyHandler;

        private IEnumerable<int> _maxNumCount = Enumerable.Range(10, 13);
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
                if (_maxNumCount.Contains(_currentNumCount))
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

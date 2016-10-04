using ReportManager.Database.ISUPDataTableAdapters;
using ReportManager.Database.NifudaDataSetTableAdapters;
using ReportManager.Database;
using ReportManager.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Permissions;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using ReportManager.DataModel;

namespace ReportManager
{
    public partial class StagesForm : Form
    {
        private Thread CheckNifudaThread;
        private Thread CheckIsupThread;
        private NifudaDataTableAdapter NifudaDataTableAdapter = new NifudaDataTableAdapter();
        private ISUPNifudaDataTableAdapter IsupDataTableAdapter = new ISUPNifudaDataTableAdapter();

        public StagesForm()
        {
            InitializeComponent();

            var keyFilter = new KeyMessageFilter();
            keyFilter.EventKeyHandler += KeyFilter_EventKeyHandler;
            Application.AddMessageFilter(keyFilter);

            edtSerial.Enabled = false;

            Init();

            Application.ApplicationExit += Application_ApplicationExit;
        }

        private void Init()
        {
            edtSerial.Enabled = false;
            btnGenerateSerial.Enabled = false;
            btnGenerateReports.Enabled = false;

            lblNifudaConnectionStatus.Caption = "Установка соединения...";
            lblIsupConnectionStatus.Caption = "Установка соединения...";
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            StopCheckNifudaConnection();
            StopCheckIsupConnection();
        }

        #region KeyEvents

        private void KeyFilter_EventKeyHandler(object sender, Keys key, string serial)
        {
            edtSerial.EditValue = serial;
            btnGenerateReports.Enabled = edtSerial.EditValue != null && !edtSerial.EditValue.Equals(string.Empty);
        }

        private void edtSerial_EditValueChanged(object sender, EventArgs e)
        {
            btnGenerateReports.Enabled = edtSerial.EditValue != null && !edtSerial.EditValue.Equals(string.Empty);
            edtSerial.Enabled = !(edtSerial.EditValue != null && !edtSerial.EditValue.Equals(string.Empty));
        }

        #endregion

        private void btnGenerateReports_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dataBySerial = nifudaDataTableAdapter.GetDataBySerial(edtSerial.EditValue.ToString());
            if (dataBySerial.Count == 0)
            {
                MessageBox.Show("Серийный номер не найден", "Предупреждение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                btnGenerateReports.Enabled = false;
                return;
            }

            var deviceModel =
                DataModelCreator.GetDeviceBySerial(new DataModel.SerialNumber {Serial = dataBySerial[0].SERIAL_NO});
            ReportManagerContext.GetInstance().SetDeviceModel(deviceModel);
            new ReportForm {MdiParent = this}.Show();
        }

        private void btnGenerateTransportList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new TransportListGenerateForm {MdiParent = this}.Show();
        }

        private Tuple<int, DateTime> SynchronizeData()
        {
            var isupDevice = DataModelCreator.GetDeviceFromOtherTable(IsupDataTableAdapter);
            
            if (isupDevice.InputData[0].SerialNumber != null)
            {
                foreach (var data in isupDevice.InputData)
                {
                    var incomedFields = nifudaDataTableAdapter.GetDataBy(data.SerialNumber);
                    if (incomedFields.Count == 0)
                    {
                        nifudaDataTableAdapter.InsertQuery(data.MsCode,
                            data.Model, data.ProductionNumber,
                            data.ProductionNumberSuffix,
                            data.LineNumber, data.CrpGroupNumber,
                            data.ProductionCareer, data.IndexNumber,
                            data.TestCertSign, data.DocumentationLangType,
                            data.InstFinishD, data.TestCertYn,
                            data.EndUserCustNJ, data.OrderNumber,
                            data.ItemNumber, data.ProductionItemRevisionNumber,
                            data.ProductionInstRevisionNumber, data.CompNumber,
                            data.StartScheduleD, data.FinishScheduleD,
                            data.StartNumber, data.SerialNumber,
                            data.AllowanceSign, data.ProductionNumberJapan,
                            data.ProductionNumberEnglish,
                            data.TokuchuSpecificationSign,
                            data.SapLinkageNumber, data.RangeInstSign_500,
                            data.OrderInstMax_500, data.OrderInstMin_500,
                            data.Unit_500, data.Features_500,
                            data.RangeInstSign_502, data.OrderInstMax_502,
                            data.OrderInstMin_502, data.Unit_502,
                            data.OrderInstContect1W69,
                            data.OrderInstContect1X72,
                            data.OrderInstContect1X91,
                            data.OrderInstContect1Z30,
                            data.TagNumber_525, data.XjNumber,
                            data.OrderInstContect1H46,
                            data.OrderInstContect1X92,
                            data.OrderInstContect1Y28,
                            data.OrderInstContect1W35,
                            data.OrderInstContect1X78,
                            data.OrderInstContect1X94,
                            data.CapsuleNumber);
                    }
                }

                IsupDataTableAdapter.UpdateQuery();
            }

            return new Tuple<int, DateTime>(nifudaDataTableAdapter.GetNotGeneratedData().Count, DateTime.Now);
        }

        private void btnChangeConnectionString_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (new DatabaseSettingChange().ShowDialog() == DialogResult.OK)
            {
                StopCheckNifudaConnection();
                StopCheckIsupConnection();

                NifudaDataTableAdapter.Connection.ConnectionString =
                    ConnectionStringContainer.GetInstance().NifudaConnectionString;
                IsupDataTableAdapter.Connection.ConnectionString =
                    ConnectionStringContainer.GetInstance().IsupConnectionString;

                StartCheckNifudaConnection();
                StartCheckIsupConnection();
            }
        }

        public void StartCheckNifudaConnection()
        {
            CheckNifudaThread = new Thread(CheckNifudaConnection);
            CheckNifudaThread.Start();
        }

        public void StopCheckNifudaConnection()
        {
            CheckNifudaThread?.Abort();
        }

        private void CheckNifudaConnection()
        {
            var lastStateNifuda = ConnectionState.Fetching;
            var lastStateIsup = ConnectionState.Fetching;

            while (true)
            {
                try
                {
                    EmptyNifudaQueryExecute();

                    if (NifudaDataTableAdapter.Connection.State == ConnectionState.Open)
                    {
                        if (lastStateNifuda != NifudaDataTableAdapter.Connection.State)
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                NifudaConnectionOnStateChange(this,
                                    new StateChangeEventArgs(lastStateNifuda,
                                        NifudaDataTableAdapter.Connection.State));
                            });
                            lastStateNifuda = NifudaDataTableAdapter.Connection.State;
                            continue;
                        }
                        // Проверка заказов
                    }
                    else if (NifudaDataTableAdapter.Connection.State == ConnectionState.Closed)
                    {
                        if (lastStateNifuda != NifudaDataTableAdapter.Connection.State)
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                NifudaConnectionOnStateChange(this,
                                    new StateChangeEventArgs(lastStateNifuda,
                                        NifudaDataTableAdapter.Connection.State));
                            });
                            lastStateNifuda = NifudaDataTableAdapter.Connection.State;
                            continue;
                        }
                        try
                        {
                            NifudaDataTableAdapter.Connection.Open();
                        }
                        catch { }
                    }


                    if (IsupDataTableAdapter.Connection.State == ConnectionState.Open)
                    {
                        if (lastStateIsup != IsupDataTableAdapter.Connection.State)
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                ISUPConnectionOnStateChange(this,
                                    new StateChangeEventArgs(lastStateIsup,
                                        IsupDataTableAdapter.Connection.State));
                            });
                            lastStateIsup = IsupDataTableAdapter.Connection.State;
                            continue;
                        }
                        // Проверка заказов
                    }
                    else if (IsupDataTableAdapter.Connection.State == ConnectionState.Closed)
                    {
                        if (lastStateIsup != IsupDataTableAdapter.Connection.State)
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                ISUPConnectionOnStateChange(this,
                                    new StateChangeEventArgs(lastStateIsup,
                                        IsupDataTableAdapter.Connection.State));
                            });
                            lastStateIsup = IsupDataTableAdapter.Connection.State;
                            continue;
                        }

                        try
                        {
                            IsupDataTableAdapter.Connection.Open();
                        }
                        catch { }
                    }

                    Thread.Sleep(100);
                }
                catch (ThreadAbortException)
                {
                    break;
                }
                catch (SqlException)
                {
                }
            }
        }

        public void StartCheckIsupConnection()
        {
            CheckIsupThread = new Thread(CheckIsupConnection);
            CheckIsupThread.Start();
        }

        public void StopCheckIsupConnection()
        {
            CheckIsupThread?.Abort();
        }

        private void CheckIsupConnection()
        {
            var lastStateIsup = ConnectionState.Fetching;

            while (true)
            {
                try
                {
                    EmptyIsupQueryExecute();

                    if (IsupDataTableAdapter.Connection.State == ConnectionState.Open)
                    {
                        if (lastStateIsup != IsupDataTableAdapter.Connection.State)
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                ISUPConnectionOnStateChange(this,
                                    new StateChangeEventArgs(lastStateIsup,
                                        IsupDataTableAdapter.Connection.State));
                            });
                            lastStateIsup = IsupDataTableAdapter.Connection.State;
                            continue;
                        }
                        var data = SynchronizeData();
                        Invoke((MethodInvoker)delegate
                        {
                            lblStatus.Caption =
                                $"Время последнего обновления: {data.Item2}. " +
                                $"Количество невыполненных заказов: {data.Item1}";
                        });
                    }
                    else if (IsupDataTableAdapter.Connection.State == ConnectionState.Closed)
                    {
                        if (lastStateIsup != IsupDataTableAdapter.Connection.State)
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                ISUPConnectionOnStateChange(this,
                                    new StateChangeEventArgs(lastStateIsup,
                                        IsupDataTableAdapter.Connection.State));
                            });
                            lastStateIsup = IsupDataTableAdapter.Connection.State;
                            continue;
                        }

                        try
                        {
                            IsupDataTableAdapter.Connection.Open();
                        }
                        catch { }
                    }

                    Thread.Sleep(100);
                }
                catch (ThreadAbortException)
                {
                    break;
                }
                catch (SqlException)
                {
                }
            }
        }

        private void EmptyNifudaQueryExecute()
        {
            try
            {
                NifudaDataTableAdapter.CheckConnection();
            }
            catch (Exception)
            {
                try
                {
                    NifudaDataTableAdapter.Connection.Open();
                }
                catch { }
            }
        }

        private void EmptyIsupQueryExecute()
        {
            try
            {
                IsupDataTableAdapter.ConnectionCheck();
            }
            catch (Exception)
            {
                try
                {
                    IsupDataTableAdapter.Connection.Open();
                }
                catch { }
            }
        }

        private void StagesForm_Load(object sender, EventArgs e)
        {
            try
            {
                ConnectionStringContainer.LoadGlobalSettings();
            }
            catch
            {
                ConnectionStringContainer.LoadDefaultSettings();
            }

            NifudaDataTableAdapter.Connection.ConnectionString = ConnectionStringContainer.GetInstance().NifudaConnectionString;
            IsupDataTableAdapter.Connection.ConnectionString = ConnectionStringContainer.GetInstance().IsupConnectionString;

            StartCheckNifudaConnection();
            StartCheckIsupConnection();
        }

        private void NifudaConnectionOnStateChange(object sender, StateChangeEventArgs stateChangeEventArgs)
        {
            if (stateChangeEventArgs.CurrentState == ConnectionState.Closed)
            {
                edtSerial.Enabled = false;
                btnGenerateSerial.Enabled = false;
                btnGenerateReports.Enabled = false;
                lblNifudaConnectionStatus.Caption = $"Соединение с {nifudaDataTableAdapter.Connection.Database} отсутствует";
            }
            else if (stateChangeEventArgs.CurrentState == ConnectionState.Open)
            {
                edtSerial.Enabled = true;
                btnGenerateSerial.Enabled = true;
                btnGenerateReports.Enabled = true;
                lblNifudaConnectionStatus.Caption = $"Соединение с {nifudaDataTableAdapter.Connection.Database} установлено";
            }
        }

        private void ISUPConnectionOnStateChange(object sender, StateChangeEventArgs stateChangeEventArgs)
        {
            if (stateChangeEventArgs.CurrentState == ConnectionState.Closed)
            {
                edtSerial.Enabled = false;
                btnGenerateSerial.Enabled = false;
                btnGenerateReports.Enabled = false;
                lblIsupConnectionStatus.Caption = $"Соединение с {IsupDataTableAdapter.Connection.Database} отсутствует";
            }
            else if (stateChangeEventArgs.CurrentState == ConnectionState.Open)
            {
                edtSerial.Enabled = true;
                btnGenerateSerial.Enabled = true;
                btnGenerateReports.Enabled = true;
                lblIsupConnectionStatus.Caption = $"Соединение с {IsupDataTableAdapter.Connection.Database} установлено";
            }
        }

        private void btnToSetManual_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            edtSerial.Enabled = true;
        }
    }

    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
    public class KeyMessageFilter : IMessageFilter
    {
        public delegate void KeyHandler(object sender, Keys key, string keyChar);
        public event KeyHandler EventKeyHandler;

        private bool _ctrlPressed;
        private bool _shiftPressed;
        private bool _twoPressed;

        private bool _firstEnter;

        private string _tempString = "";

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg != 0x101) return false;

            var keyData = (Keys)m.WParam;
            Console.WriteLine($"Blocked messages: { new KeysConverter().ConvertToString(keyData) }");

            switch (keyData)
            {
                case Keys.ControlKey:
                    if (_ctrlPressed && _shiftPressed && _twoPressed) break;
                    _ctrlPressed = true;
                    break;

                case Keys.ShiftKey:
                    if (_ctrlPressed && _shiftPressed && _twoPressed) break;
                    _shiftPressed = _ctrlPressed;
                    break;

                case Keys.D2:
                    if (_ctrlPressed && _shiftPressed && _twoPressed)
                    {
                        _tempString += "2";
                        break;
                    }
                    _twoPressed = _ctrlPressed && _shiftPressed;
                    break;

                case Keys.Enter:
                    if (_firstEnter)
                    {
                        GenerateEvent(keyData, _tempString);
                        _ctrlPressed = false;
                        _shiftPressed = false;
                        _twoPressed = false;
                        _firstEnter = false;
                        _tempString = "";
                        break;
                    }
                    _firstEnter = true;
                    break;

                default:
                    if (_ctrlPressed && _shiftPressed && _twoPressed)
                    {
                        _tempString += new KeysConverter().ConvertToString(keyData);
                    }
                    break;
            }
            return false;
        }

        private void GenerateEvent(Keys keyData, string generatedString)
        {
            EventKeyHandler?.Invoke(this, keyData, generatedString);
            Console.WriteLine($"Blocked messages: {generatedString}");
        }
    }
}

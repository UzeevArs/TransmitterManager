﻿using ReportManager.Database.ISUPDataTableAdapters;
using ReportManager.Database.NifudaDataSetTableAdapters;
using ReportManager.Database;
using ReportManager.Forms;
using System;
using System.IO;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Xml.Serialization;
using DevExpress.XtraReports.UI;
using DevExpress.LookAndFeel;
using ReportManager.DataModel;
using ReportManager.Reports;
using System.Collections.Generic;

namespace ReportManager
{
    public partial class StagesForm : Form
    {
        public StagesForm()
        {
            InitializeComponent();
            var keyFilter = new KeyMessageFilter();
            keyFilter.EventKeyHandler += KeyFilter_EventKeyHandler;
            Application.AddMessageFilter(keyFilter);
            edtSerial.Enabled = false;


        }



        private static string _settingsPath =
            $@"{Environment.GetEnvironmentVariable("AllUsersProfile")}\ReportManagerSettings\Settings.xml";

        public object ReportName { get; private set; }

        public void LoadGlobalSettings()
        {
            try
            {
                var xs = new XmlSerializer(typeof(ConnectionStringContainer));
                using (Stream reader = new FileStream(_settingsPath, FileMode.Open))
                {
                    ConnectionStringContainer.SetInstance((ConnectionStringContainer)xs.Deserialize(reader));
                    reader.Close();
                }
            }
            catch { }
        }

        private void KeyFilter_EventKeyHandler(object sender, Keys key, string serial)
        {
            edtSerial.EditValue = serial;
            if (edtSerial.EditValue != null && !edtSerial.EditValue.Equals(string.Empty))
            {
                btnGenerateReports.Enabled = true;
            }
            else
            {
                btnGenerateReports.Enabled = false;
            }
        }

        private void edtSerial_EditValueChanged(object sender, EventArgs e)
        {
            if (edtSerial.EditValue != null && !edtSerial.EditValue.Equals(string.Empty))
            {
                btnGenerateReports.Enabled = true;
                edtSerial.Enabled = false;
            }
            else
            {
                btnGenerateReports.Enabled = false;
                edtSerial.Enabled = false;
            }
        }



        
        private void btnGenerateReports_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var SerialTest = "";

            if (nifudaDataTableAdapter.GetDataBySerial(edtSerial.EditValue.ToString()).Count == 0)
            {
                MessageBox.Show("Производственный номер не найден");
                SerialTest = "no Data";
                btnGenerateReports.Enabled = false;
            }
            else
            {
                SerialTest = nifudaDataTableAdapter.GetDataBySerial(edtSerial.EditValue.ToString())[0].SERIAL_NO;
            }
          
                        
            var deviceModel =

                DataModelCreator.GetDeviceBySerial(new DataModel.SerialNumber { Serial = SerialTest });


            if (deviceModel != null) //&& nifudaDataTableAdapter.GetDataBySerial(edtSerial.EditValue.ToString()).Count != 0)
            {
                ReportManagerContext.GetInstance().SetDeviceModel(deviceModel);
                (new ReportForm { MdiParent = this }).Show();
            }
            else
            {
                MessageBox.Show("Серийный номер не найден", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnGenerateReports.Enabled = false;
            }
        }


        
        //private XtraReport CreateReportInstance()
        //{

            

        //    XtraReport report = (XtraReport)
        //        Activator.CreateInstance((ReportName).ReportType);

        //    //cbReports.SelectedItem

        //    if (!(report is ISavingReport))
        //    {
        //        MessageBox.Show("Забыл унаследоваться от интерфейс ISavingReport");
        //        return null;
        //    };

        //    if ((report as ISavingReport).IsExistTemplateFile())
        //    {
        //        report.LoadLayout((report as ISavingReport).GetTemplateFileName());
        //    }


        //    //new List<InputData> { ReportManagerContext.GetInstance().CurrentDeviceModel.InputData[0] };

        //    //new DeviceModel().InputData
        //    //{

        //    //ReportManagerContext.GetInstance().CurrentDeviceModel.InputData[0]                   
        //    //    }

        //    report.DataSource =
        //        new List<AggregatedFieldsModel> {new AggregatedFieldsModel(

        //            ReportManagerContext.GetInstance().CurrentDeviceModel.SerialNumber[0],
        //            ReportManagerContext.GetInstance().CurrentDeviceModel.InputData[0],
        //            ReportManagerContext.GetInstance().CurrentDeviceModel.CalibrationResults[0],
        //            ReportManagerContext.GetInstance().CurrentDeviceModel.DeviceTestResults[0])
        //    };

        //    return report;
        //}


        private void btnGenerateSerial_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var report = CreateReportInstance();
            //if (report == null) return;

            //using (ReportPrintTool printTool = new ReportPrintTool(report))
            //{
            //    printTool.ShowRibbonPreviewDialog(UserLookAndFeel.Default);
            //}
            
            (new SerialNumberGenerateForm { MdiParent = this }).Show();
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public class KeyMessageFilter : IMessageFilter
        {
            public delegate void KeyHandler(object sender, Keys key, string keyChar);
            public event KeyHandler EventKeyHandler;

            private bool ctrlPressed = false;
            private bool shiftPressed = false;
            private bool twoPressed = false;

            private bool firstEnter = false;

            private string tempString = "";

            public bool PreFilterMessage(ref Message m)
            {
                if (m.Msg == 0x101)
                {
                    Keys keyData = (Keys)m.WParam;
                    Console.WriteLine($"Blocked messages: { new KeysConverter().ConvertToString(keyData) }");
                    switch (keyData)
                    {
                        case Keys.ControlKey:
                            if (ctrlPressed && shiftPressed && twoPressed) break;
                            ctrlPressed = true;
                            break;
                        case Keys.ShiftKey:
                            if (ctrlPressed && shiftPressed && twoPressed) break;
                            shiftPressed = ctrlPressed;
                            break;
                        case Keys.D2:
                            if (ctrlPressed && shiftPressed && twoPressed)
                            {
                                tempString += "2";
                                break;
                            }
                            twoPressed = ctrlPressed && shiftPressed;
                            break;
                        case Keys.Enter:
                            if (firstEnter)
                            {
                                GenerateEvent(keyData, tempString);
                                ctrlPressed = false;
                                shiftPressed = false;
                                twoPressed = false;
                                firstEnter = false;
                                tempString = "";
                                break;
                            }
                            else
                            {
                                firstEnter = true;
                                break;
                            }

                        default:
                            if (ctrlPressed && shiftPressed && twoPressed)
                            {
                                tempString += new KeysConverter().ConvertToString(keyData);
                            }
                            break;
                    }
                }
                return false;
            }

            private void GenerateEvent(Keys keyData, string generatedString)
            {
                EventKeyHandler?.Invoke(this, keyData, generatedString);
                // Console.WriteLine($"Blocked messages: {generatedString}");
            }
        }

        private void btnOpenTestWindow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NifudaDataTableAdapter nifudaDataTableAdapter = new NifudaDataTableAdapter();
            ISUPNifudaDataTableAdapter iSUPNifudaDataTableAdapter = new ISUPNifudaDataTableAdapter();
            nifudaDataTableAdapter.Connection.ConnectionString = ConnectionStringContainer.GetInstance().ConnStrNifuda;
            iSUPNifudaDataTableAdapter.Connection.ConnectionString = ConnectionStringContainer.GetInstance().ConnStrISUP;

            //MessageBox.Show(iSUPNifudaDataTableAdapter.Connection.ConnectionTimeout.ToString());

            //РАЗОБРАТЬСЯ С ТАЙМАУТОМ, cоnnection.open выполняется в течение таймаута 

            try
            {
                
                nifudaDataTableAdapter.Connection.Open();
            }
            catch (System.Data.SqlClient.SqlException s)
            {
                edtSerial.Enabled = false;
                btnGenerateSerial.Enabled = false;
                btnGenerateReports.Enabled = false;
                MessageBox.Show("Соединение с" + nifudaDataTableAdapter.Connection.Database + ' ' + "отсутствует" + '\n' + "Причина: " + s.Message.ToString());
            }

            try
            {
                
                iSUPNifudaDataTableAdapter.Connection.Open();
            }
            catch (System.Data.SqlClient.SqlException s)
            {
                edtSerial.Enabled = false;
                btnGenerateSerial.Enabled = false;
                btnGenerateReports.Enabled = false;
                MessageBox.Show("Соединение с" + iSUPNifudaDataTableAdapter.Connection.Database + ' ' + "отсутствует" + '\n' + "Причина: " + s.Message.ToString());
            }


            if ((nifudaDataTableAdapter.Connection.State == System.Data.ConnectionState.Open) && 
                (iSUPNifudaDataTableAdapter.Connection.State == System.Data.ConnectionState.Open))
            {
                edtSerial.Enabled = true;
                btnGenerateSerial.Enabled = true;
                btnGenerateReports.Enabled = true;
                
                var isupDevice = DataModelCreator.GetDeviceFromOtherTable();

                if (isupDevice.InputData[0].SerialNumber == null)
                {
                    MessageBox.Show("Новых заказов не поступало");
                }
                else
                {
                    for (int i = 0; i < isupDevice.InputData.Count; i++)
                    {
                        var incomedFields = nifudaDataTableAdapter.GetDataBy(isupDevice.InputData[i].SerialNumber);
                        if (incomedFields.Count == 0)
                        {
                            nifudaDataTableAdapter.InsertQuery(isupDevice.InputData[i].MsCode, isupDevice.InputData[i].Model, isupDevice.InputData[i].ProductionNumber, isupDevice.InputData[i].ProductionNumberSuffix,
                                isupDevice.InputData[i].LineNumber, isupDevice.InputData[i].CrpGroupNumber, isupDevice.InputData[i].ProductionCareer, isupDevice.InputData[i].IndexNumber,
                                isupDevice.InputData[i].TestCertSign, isupDevice.InputData[i].DocumentationLangType, isupDevice.InputData[i].InstFinishD, isupDevice.InputData[i].TestCertYn,
                                isupDevice.InputData[i].EndUserCustNJ, isupDevice.InputData[i].OrderNumber, isupDevice.InputData[i].ItemNumber, isupDevice.InputData[i].ProductionItemRevisionNumber,
                                isupDevice.InputData[i].ProductionInstRevisionNumber, isupDevice.InputData[i].CompNumber, isupDevice.InputData[i].StartScheduleD, isupDevice.InputData[i].FinishScheduleD,
                                isupDevice.InputData[i].StartNumber, isupDevice.InputData[i].SerialNumber, isupDevice.InputData[i].AllowanceSign, isupDevice.InputData[i].ProductionNumberJapan,
                                isupDevice.InputData[i].ProductionNumberEnglish, isupDevice.InputData[i].TokuchuSpecificationSign, isupDevice.InputData[i].SapLinkageNumber, isupDevice.InputData[i].RangeInstSign_500,
                                isupDevice.InputData[i].OrderInstMax_500, isupDevice.InputData[i].OrderInstMin_500, isupDevice.InputData[i].Unit_500, isupDevice.InputData[i].Features_500,
                                isupDevice.InputData[i].RangeInstSign_502, isupDevice.InputData[i].OrderInstMax_502, isupDevice.InputData[i].OrderInstMin_502, isupDevice.InputData[i].Unit_502,
                                isupDevice.InputData[i].OrderInstContect1W69, isupDevice.InputData[i].OrderInstContect1X72, isupDevice.InputData[i].OrderInstContect1X91, isupDevice.InputData[i].OrderInstContect1Z30,
                                isupDevice.InputData[i].TagNumber_525, isupDevice.InputData[i].XjNumber, isupDevice.InputData[i].OrderInstContect1H46, isupDevice.InputData[i].OrderInstContect1X92,
                                isupDevice.InputData[i].OrderInstContect1Y28, isupDevice.InputData[i].OrderInstContect1W35, isupDevice.InputData[i].OrderInstContect1X78, isupDevice.InputData[i].OrderInstContect1X94,
                                isupDevice.InputData[i].CapsuleNumber);
                        }
                    }

                    iSUPNifudaDataTableAdapter.UpdateQuery();
                }
                iSUPNifudaDataTableAdapter.Connection.Close();
                nifudaDataTableAdapter.Connection.Close();
            }

            iSUPNifudaDataTableAdapter.Connection.Close();
            nifudaDataTableAdapter.Connection.Close();
        }

        private void btnChangeConnectionString_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DatabaseSettingChange databaseSettingChange = new DatabaseSettingChange();
            databaseSettingChange.Show();
        }

        private void StagesForm_Load(object sender, EventArgs e)
        {
            LoadGlobalSettings();

            NifudaDataTableAdapter nifudaDataTableAdapter = new NifudaDataTableAdapter();
            ISUPNifudaDataTableAdapter iSUPNifudaDataTableAdapter = new ISUPNifudaDataTableAdapter();

            nifudaDataTableAdapter.Connection.ConnectionString = ConnectionStringContainer.GetInstance().ConnStrNifuda;
            iSUPNifudaDataTableAdapter.Connection.ConnectionString = ConnectionStringContainer.GetInstance().ConnStrISUP;


            //int TimeOutConnectionISUP = iSUPNifudaDataTableAdapter.Connection.ConnectionTimeout;
            //int TimeOutConnectionProduction = nifudaDataTableAdapter.Connection.ConnectionTimeout;
            //TimeOutConnectionProduction = '1';
            //TimeOutConnectionISUP = '1';


            // ЧУТЬ-ЧУТЬ МОЖНО, НО СИЛЬНО НЕ УГОРАЙ Я НОВИЧОК В ЭТИХ ДЕЛАХ, преобразую в классы как время будет))
            try
            {
                nifudaDataTableAdapter.Connection.Open();
            }
            catch (System.Data.SqlClient.SqlException s)
            {
                edtSerial.Enabled = false;
                btnGenerateSerial.Enabled = false;
                btnGenerateReports.Enabled = false;
                MessageBox.Show("Соединение с" + nifudaDataTableAdapter.Connection.Database + ' ' + "отсутствует" + '\n' + "Причина: " + s.Message.ToString());
            }

            try
            {
                iSUPNifudaDataTableAdapter.Connection.Open();
            }
            catch (System.Data.SqlClient.SqlException s)
            {
                edtSerial.Enabled = false;
                btnGenerateSerial.Enabled = false;
                btnGenerateReports.Enabled = false;
                MessageBox.Show("Соединение с" + iSUPNifudaDataTableAdapter.Connection.Database + ' ' + "отсутствует" + '\n' + "Причина: " + s.Message.ToString());
            }

            //if ((nifudaDataTableAdapter.Connection.State.ToString() == "Open") & (iSUPNifudaDataTableAdapter.Connection.State.ToString() == "Open"))
            //{

            //    var isupDevice = DataModelCreator.GetDeviceFromOtherTable();

            //    if (isupDevice.InputData[0].SerialNumber == null)
            //    {
            //        MessageBox.Show("Новых заказов не поступало");
            //    }
            //    else
            //    {
            //        for (int i = 0; i < isupDevice.InputData.Count; i++)
            //        {

            //            nifudaDataTableAdapter.InsertQuery(isupDevice.InputData[i].MsCode, isupDevice.InputData[i].Model, isupDevice.InputData[i].ProductionNumber, isupDevice.InputData[i].ProductionNumberSuffix,
            //                isupDevice.InputData[i].LineNumber, isupDevice.InputData[i].CrpGroupNumber, isupDevice.InputData[i].ProductionCareer, isupDevice.InputData[i].IndexNumber,
            //                isupDevice.InputData[i].TestCertSign, isupDevice.InputData[i].DocumentationLangType, isupDevice.InputData[i].InstFinishD, isupDevice.InputData[i].TestCertYn,
            //                isupDevice.InputData[i].EndUserCustNJ, isupDevice.InputData[i].OrderNumber, isupDevice.InputData[i].ItemNumber, isupDevice.InputData[i].ProductionItemRevisionNumber,
            //                isupDevice.InputData[i].ProductionInstRevisionNumber, isupDevice.InputData[i].CompNumber, isupDevice.InputData[i].StartScheduleD, isupDevice.InputData[i].FinishScheduleD,
            //                isupDevice.InputData[i].StartNumber, isupDevice.InputData[i].SerialNumber, isupDevice.InputData[i].AllowanceSign, isupDevice.InputData[i].ProductionNumberJapan,
            //                isupDevice.InputData[i].ProductionNumberEnglish, isupDevice.InputData[i].TokuchuSpecificationSign, isupDevice.InputData[i].SapLinkageNumber, isupDevice.InputData[i].RangeInstSign_500,
            //                isupDevice.InputData[i].OrderInstMax_500, isupDevice.InputData[i].OrderInstMin_500, isupDevice.InputData[i].Unit_500, isupDevice.InputData[i].Features_500,
            //                isupDevice.InputData[i].RangeInstSign_502, isupDevice.InputData[i].OrderInstMax_502, isupDevice.InputData[i].OrderInstMin_502, isupDevice.InputData[i].Unit_502,
            //                isupDevice.InputData[i].OrderInstContect1W69, isupDevice.InputData[i].OrderInstContect1X72, isupDevice.InputData[i].OrderInstContect1X91, isupDevice.InputData[i].OrderInstContect1Z30,
            //                isupDevice.InputData[i].TagNumber_525, isupDevice.InputData[i].XjNumber, isupDevice.InputData[i].OrderInstContect1H46, isupDevice.InputData[i].OrderInstContect1X92,
            //                isupDevice.InputData[i].OrderInstContect1Y28, isupDevice.InputData[i].OrderInstContect1W35, isupDevice.InputData[i].OrderInstContect1X78, isupDevice.InputData[i].OrderInstContect1X94,
            //                isupDevice.InputData[i].CapsuleNumber);
            //        }

            //        MessageBox.Show(iSUPNifudaDataTableAdapter.Connection.State.ToString());
            //        iSUPNifudaDataTableAdapter.UpdateQuery();
            //    }
            //    iSUPNifudaDataTableAdapter.Connection.Close();
            //    nifudaDataTableAdapter.Connection.Close();
            //}

            iSUPNifudaDataTableAdapter.Connection.Close();
            nifudaDataTableAdapter.Connection.Close();

        }

        private void btnToSetManual_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            edtSerial.Enabled = true;
        }


    }
}

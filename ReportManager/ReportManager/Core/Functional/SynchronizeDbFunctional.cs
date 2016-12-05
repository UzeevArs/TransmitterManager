using System;
using System.Data;
using System.Threading;
using System.Xml.Serialization;
using ReportManager.Core.Utility;
using ReportManager.Data.Database;
using ReportManager.Data.Database.ISUPDataTableAdapters;
using ReportManager.Data.Database.NifudaDataSetTableAdapters;
using ReportManager.Data.Settings;

namespace ReportManager.Core.Functional
{
    public class SynchronizeDbFunctional : AbstractFunctional
    {
        public event EventHandler<Tuple<NifudaDataSet.NifudaDataTableDataTable, DateTime>> SyncronizeDataIncome;

        [XmlIgnore]
        private ISUPNifudaDataTableAdapter IsupDataTableAdapter { get; } = new ISUPNifudaDataTableAdapter();

        [XmlIgnore]
        private NifudaDataTableAdapter NifudaDataTableAdapter { get; } = new NifudaDataTableAdapter();

        [XmlIgnore]
        private Thread SyncThread { get; set; }

        [XmlIgnore]
        public bool? IsAlive => SyncThread?.IsAlive;
        
        public SynchronizeDbFunctional()
        {
            Name = "Синхронизация БД";
        }

        public override void Start()
        {
            NifudaDataTableAdapter.Connection.ConnectionString =
                SettingsContext.GlobalSettings.NifudaConnectionString;
            IsupDataTableAdapter.Connection.ConnectionString =
                SettingsContext.GlobalSettings.IsupConnectionString;
            SyncThread = new Thread(Syncronize);
            SyncThread.Start();
        }

        private void Syncronize()
        {
            while (true)
            {
                try
                {
                    if (NifudaDataTableAdapter.Connection.State == ConnectionState.Open &&
                        IsupDataTableAdapter.Connection.State == ConnectionState.Open)
                    {
                        SyncronizeDataIncome?.Invoke(this, SynchronizeData());
                    }
                    else
                    {
                        try
                        {
                            NifudaDataTableAdapter.Connection.Open();
                            IsupDataTableAdapter.Connection.Open();
                        }
                        catch { }
                    }

                    Thread.Sleep((int)SettingsContext.GlobalSettings.UpdateTimeout);
                }
                catch (ThreadAbortException)
                {
                    break;
                }
            }
        }

        private Tuple<NifudaDataSet.NifudaDataTableDataTable, DateTime> SynchronizeData()
        {
            var isupDevice = DataModelCreator.GetDeviceFromOtherTable(IsupDataTableAdapter);

            if (isupDevice.InputData[0].SERIAL_NO == null)
                return new Tuple<NifudaDataSet.NifudaDataTableDataTable, DateTime>(
                    NifudaDataTableAdapter.GetNotGeneratedData(), DateTime.Now);

            foreach (var data in isupDevice.InputData)
            {
                var incomedFields = NifudaDataTableAdapter.GetDataBy(data.SERIAL_NO);
                if (incomedFields.Count == 0)
                {
                    NifudaDataTableAdapter.InsertQuery(data.MS_CODE,
                        data.MODEL, data.PROD_NO,
                        data.PROD_NO_SFIX,
                        data.LINE_NO, data.CRP_GR_NO,
                        data.PROD_CAREER, data.INDEX_NO,
                        data.TEST_CERT_SIGN, data.DOC_LANG_TYPE,
                        data.INST_FINISH_D, data.TEST_CERT_YN,
                        data.END_USER_CUST_N_J, data.ORDER_NO,
                        data.ITEM_NO, data.PROD_ITEM_REV_NO,
                        data.PROD_INST_REV_NO, data.COMP_NO,
                        data.START_SCHDULE_D, data.FINISH_SCHDULE_D,
                        data.START_NO, data.SERIAL_NO,
                        data.ALLOWANCE_SIGN, data.PROD_N_J,
                        data.PROD_N_E,
                        data.TOKUCHU_SPEC_SIGN,
                        data.SAP_LINKAGE_NO, data.RANGE_INST_SIGN_500,
                        data.ORD_INST_MAX_500, data.ORD_INST_MIN_500,
                        data.UNIT_500, data.FEATURES_500,
                        data.RANGE_INST_SIGN_502, data.ORD_INST_MAX_502,
                        data.ORD_INST_MIN_502, data.UNIT_502,
                        data.ORD_INST_CONTECT1_W69,
                        data.ORD_INST_CONTECT1_X72,
                        data.ORD_INST_CONTECT1_X91,
                        data.ORD_INST_CONTECT1_Z30,
                        data.TAG_NO_525, data.XJ_NO,
                        data.ORD_INST_CONTECT1_H46,
                        data.ORD_INST_CONTECT1_X92,
                        data.ORD_INST_CONTECT1_Y28,
                        data.ORD_INST_CONTECT1_W35,
                        data.ORD_INST_CONTECT1_X78,
                        data.ORD_INST_CONTECT1_X94,
                        data.CAP_NO);
                }
            }
            IsupDataTableAdapter.UpdateQuery();

            return new Tuple<NifudaDataSet.NifudaDataTableDataTable, DateTime>(
                NifudaDataTableAdapter.GetNotGeneratedData(), DateTime.Now);
        }

        public override void Stop()
        {
            SyncThread?.Abort();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

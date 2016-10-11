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
        public event SynchronizeEventHandler SyncronizeDataIncome;

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

            if (isupDevice.InputData[0].SerialNumber == null)
                return new Tuple<NifudaDataSet.NifudaDataTableDataTable, DateTime>(
                    NifudaDataTableAdapter.GetNotGeneratedData(), DateTime.Now);

            foreach (var data in isupDevice.InputData)
            {
                var incomedFields = NifudaDataTableAdapter.GetDataBy(data.SerialNumber);
                if (incomedFields.Count == 0)
                {
                    NifudaDataTableAdapter.InsertQuery(data.MsCode,
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

    public delegate void SynchronizeEventHandler(
        object sender, Tuple<NifudaDataSet.NifudaDataTableDataTable, DateTime> data);
}

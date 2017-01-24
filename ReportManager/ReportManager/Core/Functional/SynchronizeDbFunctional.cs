using System;
using System.Linq;
using System.Data;
using System.Threading;
using System.Xml.Serialization;
using ReportManager.Data.Database.ISUPDataTableAdapters;
using ReportManager.Data.Database.NifudaDataSetTableAdapters;
using ReportManager.Data.Settings;
using ReportManager.Data.Database.ConcreteAdapters;
using System.Collections.Generic;
using ReportManager.Data.DataModel;

namespace ReportManager.Core.Functional
{
    internal class SynchronizeDbFunctional : Functional
    {
        public event EventHandler<(IEnumerable<InputData>, DateTime)> SyncronizeDataIncome;
        public override event EventHandler<bool> StatusChanged;

        private ISUPNifudaDataTableAdapter IsupDataTableAdapter { get; } = new ISUPNifudaDataTableAdapter();

        private NifudaDataTableAdapter NifudaDataTableAdapter { get; } = new NifudaDataTableAdapter();

        private Thread SyncThread { get; set; }

        public override bool IsRunning { get { return (bool) SyncThread?.IsAlive; } }

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
            StatusChanged?.Invoke(this, true);
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

        private (IEnumerable<InputData>, DateTime) SynchronizeData()
        {
            var isupInput = (new IsupInputDataDatabaseAdapter()).Select();

            if (isupInput.Count() == 0)
                return ((new NifudaInputDataDatabaseAdapter()).SelectNotGeneratedData(), DateTime.Now);

            (new NifudaInputDataDatabaseAdapter()).Insert(isupInput);

            (new IsupInputDataDatabaseAdapter()).UpdateDownloaded();

            return ((new NifudaInputDataDatabaseAdapter()).SelectNotGeneratedData(), DateTime.Now);
        }

        public override void Stop()
        {
            SyncThread?.Abort();
            StatusChanged?.Invoke(this, false);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Xml.Serialization;
using ReportManager.Data.SAP.NifudaDataSetTableAdapters;
using ReportManager.Data.Settings;

namespace ReportManager.Core.Functional
{
    internal class CheckManifactureDbConnectionFunctional : Functional
    {
        public virtual event StateChangeEventHandler StateChange;
        public override event EventHandler<bool> StatusChanged;

        private Thread CheckNifudaThread { get; set; }

        private NifudaDataTableAdapter NifudaDataTableAdapter { get; set; }

        public override bool? IsRunning { get { return CheckNifudaThread?.IsAlive; } }

        public CheckManifactureDbConnectionFunctional()
        {
            Name = "Проверка подключения к производственной бд";
        }

        public override void Start()
        {
            NifudaDataTableAdapter = new NifudaDataTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            };

            CheckNifudaThread = new Thread(CheckNifudaConnection);
            CheckNifudaThread.Start();
            StatusChanged?.Invoke(this, true);
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
                            StateChange?.Invoke(this,
                                new StateChangeEventArgs(lastStateIsup, NifudaDataTableAdapter.Connection.State));
                            lastStateNifuda = NifudaDataTableAdapter.Connection.State;
                            continue;
                        }
                    }
                    else if (NifudaDataTableAdapter.Connection.State == ConnectionState.Closed)
                    {
                        if (lastStateNifuda != NifudaDataTableAdapter.Connection.State)
                        {
                            StateChange?.Invoke(this,
                                new StateChangeEventArgs(lastStateIsup, NifudaDataTableAdapter.Connection.State));
                            lastStateNifuda = NifudaDataTableAdapter.Connection.State;
                            continue;
                        }

                        try
                        {
                            NifudaDataTableAdapter.Connection.Open();
                        }
                        catch { }
                    }

                    Thread.Sleep((int) SettingsContext.GlobalSettings.UpdateTimeout);
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

        public override void Stop()
        {
            CheckNifudaThread?.Abort();
            StatusChanged?.Invoke(this, false);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

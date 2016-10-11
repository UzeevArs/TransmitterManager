using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Xml.Serialization;
using ReportManager.Data.Database.NifudaDataSetTableAdapters;
using ReportManager.Data.Settings;

namespace ReportManager.Core.Functional
{
    public class CheckManifactureDbConnectionFunctional : AbstractFunctional
    {
        public virtual event StateChangeEventHandler StateChange;

        [XmlIgnore]
        private Thread CheckNifudaThread { get; set; }

        [XmlIgnore]
        private NifudaDataTableAdapter NifudaDataTableAdapter { get; set; }

        [XmlIgnore]
        public bool? IsAlive => CheckNifudaThread?.IsAlive;

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
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

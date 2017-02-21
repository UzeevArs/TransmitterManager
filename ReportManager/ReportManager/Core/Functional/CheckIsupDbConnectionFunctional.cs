using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Xml.Serialization;
using ReportManager.Data.Database.ISUPDataTableAdapters;
using ReportManager.Data.Settings;

namespace ReportManager.Core.Functional
{
    internal class CheckIsupDbConnectionFunctional : Functional
    {
        public virtual event StateChangeEventHandler StateChange;
        public override event EventHandler<bool> StatusChanged;

        private ISUPNifudaDataTableAdapter IsupDataTableAdapter { get; set; }

        private Thread CheckIsupThread { get; set; }

        public override bool? IsRunning { get { return CheckIsupThread?.IsAlive; } }

        public CheckIsupDbConnectionFunctional()
        {
            Name = "Проверка подключения к ISUP бд";
        }

        public override void Start()
        {
            IsupDataTableAdapter = new ISUPNifudaDataTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.IsupConnectionString)
            };
            CheckIsupThread = new Thread(CheckIsupConnection);
            CheckIsupThread.Start();
            StatusChanged?.Invoke(this, true);
        }

        public override void Stop()
        {
            CheckIsupThread?.Abort();
            StatusChanged?.Invoke(this, false);
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
                            StateChange?.Invoke(this,
                                new StateChangeEventArgs(lastStateIsup, IsupDataTableAdapter.Connection.State));
                            lastStateIsup = IsupDataTableAdapter.Connection.State;
                            continue;
                        }

                    }
                    else if (IsupDataTableAdapter.Connection.State == ConnectionState.Closed)
                    {
                        if (lastStateIsup != IsupDataTableAdapter.Connection.State)
                        {
                            StateChange?.Invoke(this,
                                new StateChangeEventArgs(lastStateIsup, IsupDataTableAdapter.Connection.State));
                            lastStateIsup = IsupDataTableAdapter.Connection.State;
                            continue;
                        }

                        try
                        {
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
                catch (SqlException)
                {
                }
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

        public override string ToString()
        {
            return Name;
        }
    }
}

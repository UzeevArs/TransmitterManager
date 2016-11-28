using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Xml.Serialization;
using ReportManager.Data.Database.ISUPDataTableAdapters;
using ReportManager.Data.Settings;

namespace ReportManager.Core.Functional
{
    public class CheckIsupDbConnectionFunctional : AbstractFunctional
    {
        public virtual event StateChangeEventHandler StateChange;

        [XmlIgnore]
        private ISUPNifudaDataTableAdapter IsupDataTableAdapter { get; set; }

        [XmlIgnore]
        private Thread CheckIsupThread { get; set; }

        [XmlIgnore]
        public bool? IsAlive => CheckIsupThread?.IsAlive;
        
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
        }

        public override void Stop()
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

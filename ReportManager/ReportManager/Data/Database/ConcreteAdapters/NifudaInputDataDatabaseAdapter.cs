using ReportManager.Data.AbstractAdapters;
using ReportManager.Data.AbstractAdapters.Generic;
using ReportManager.Data.Database.NifudaDataSetTableAdapters;
using ReportManager.Data.DataModel;
using ReportManager.Data.Extensions;
using ReportManager.Data.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Data.Database.ConcreteAdapters
{
    class NifudaInputDataDatabaseAdapter : ICommonAdapter<InputData>, IExtraInputDataAdapter<InputData>, ISelectBySerialAdapter<InputData>
    {
        public IEnumerable<InputData> Select(object state = null)
        {
            using (var adapter = new NifudaDataTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (adapter.Connection.State != ConnectionState.Open)
                    yield break;

                var dataTable = adapter.GetData();
                foreach (var obj in dataTable.AdaptWithSameProperties<InputData,
                                                                      NifudaDataSet.NifudaDataTableRow>())
                    yield return obj;
            }
        }

        public (Result, string) Insert(IEnumerable<InputData> data, object state = null)
        {
            using (var adapter = new NifudaDataTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (adapter.Connection.State != ConnectionState.Open)
                    return (Result.Unsuccess, $"Database connection error");

                var methodInfo = typeof(NifudaDataTableAdapter).GetMethod("Insert");

                foreach (var obj in data)
                {
                    var tupleParameters = obj.PropertiesToTuple();
                    var values = methodInfo.GetParameters().Select(info =>
                                                                   tupleParameters.FirstOrDefault(p =>
                                                                                                  p.Name.ToLower()
                                                                                                  == info.Name.ToLower()).Value ?? "");
                    methodInfo.Invoke(adapter, values.ToArray());
                }

                return (Result.Success, $"Ok");
            }
        }

        public (Result, string) Update(IEnumerable<InputData> data, object state = null)
        {
            using (var adapter = new NifudaDataTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (adapter.Connection.State != ConnectionState.Open)
                    return (Result.Unsuccess, $"Database connection error");

                int fieldsCount = (new NifudaDataSet.NifudaDataTableDataTable()).Columns.Count;
                var methodInfo = typeof(NifudaDataTableAdapter).GetMethod("Update",
                    Enumerable.Range(0, fieldsCount).Select(i => typeof(string)).ToArray());

                foreach (var obj in data)
                {
                    var tupleParameters = obj.PropertiesToTuple();
                    var values = methodInfo.GetParameters().Select(info =>
                                                                   tupleParameters.FirstOrDefault(p =>
                                                                                                  p.Name.ToLower()
                                                                                                  == info.Name.ToLower()).Value ?? "");
                    methodInfo.Invoke(adapter, values.ToArray());
                }

                return (Result.Success, $"Ok");
            }
        }

        public (Result, string) Delete(IEnumerable<InputData> data, object state = null)
        {
            using (var adapter = new NifudaDataTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (adapter.Connection.State != ConnectionState.Open)
                    return (Result.Unsuccess, $"Database connection error");

                var methodInfo = typeof(NifudaDataTableAdapter).GetMethod("Delete");

                foreach (var obj in data)
                {
                    var tupleParameters = obj.PropertiesToTuple();
                    var values = methodInfo.GetParameters().Select(info =>
                                                                   tupleParameters.FirstOrDefault(p =>
                                                                                                  p.Name.ToLower()
                                                                                                  == info.Name.ToLower()).Value ?? "");
                    methodInfo.Invoke(adapter, values.ToArray());
                }

                return (Result.Success, $"Ok");
            }
        }


        public IEnumerable<InputData> SelectBySerial(string serial, object state = null)
        {
            using (var adapter = new NifudaDataTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (adapter.Connection.State != ConnectionState.Open)
                    yield break;

                var dataTable = adapter.GetDataBy(serial);
                foreach (var obj in dataTable.AdaptWithSameProperties<InputData,
                                                                      NifudaDataSet.NifudaDataTableRow>())
                    yield return obj;
            }
        }

        public IEnumerable<InputData> SelectDataByIndex(string index, object state = null)
        {
            using (var adapter = new NifudaDataTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (adapter.Connection.State != ConnectionState.Open)
                    yield break;

                var dataTable = adapter.GetDataBySerial(index);
                foreach (var obj in dataTable.AdaptWithSameProperties<InputData,
                                                                      NifudaDataSet.NifudaDataTableRow>())
                    yield return obj;
            }
        }

        public IEnumerable<InputData> SelectNotGeneratedData(object state = null)
        {
            using (var adapter = new NifudaDataTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (adapter.Connection.State != ConnectionState.Open)
                    yield break;

                var dataTable = adapter.GetNotGeneratedData();
                foreach (var obj in dataTable.AdaptWithSameProperties<InputData,
                                                                      NifudaDataSet.NifudaDataTableRow>())
                    yield return obj;
            }
        }

        public IEnumerable<InputData> SelectByEmptyBarCode(object state = null)
        {
            using (var adapter = new NifudaDataTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (adapter.Connection.State != ConnectionState.Open)
                    yield break;

                var dataTable = new NifudaDataSet.NifudaDataTableDataTable();
                adapter.FillByEmptyBarCode(new NifudaDataSet.NifudaDataTableDataTable(dataTable));
                foreach (var obj in dataTable.AdaptWithSameProperties<InputData,
                                                                      NifudaDataSet.NifudaDataTableRow>())
                    yield return obj;
            }
        }
    }
}

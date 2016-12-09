using ReportManager.Data.AbstractAdapters;
using System.Collections.Generic;
using ReportManager.Data.Extensions;
using ReportManager.Data.DataModel;
using ReportManager.Data.Database.ISUPDataTableAdapters;
using ReportManager.Data.Settings;
using System.Linq;
using System.Data.SqlClient;

using static ReportManager.Data.Database.ISUPData;
using System.Data;

namespace ReportManager.Data.Database.ConcreteAdapters
{
    internal class IsupInputDataDatabaseAdapter : ICommonAdapter<InputData>
    {
        public IEnumerable<InputData> Select(object state = null)
        {
            using (var adapter = new ISUPNifudaDataTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.IsupConnectionString)
            })
            {
                if (!SafeCheck.IsValidConnection(adapter.Connection))
                    yield break;

                var dataTable = adapter.GetData();
                foreach (var obj in dataTable.AdaptWithSameProperties<InputData,
                                                                      ISUPNifudaDataTableRow>())
                    yield return obj;
            }
        }

        public (Result, string) Insert(IEnumerable<InputData> data, object state = null)
        {
            using (var adapter = new ISUPNifudaDataTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.IsupConnectionString)
            })
            {
                if (!SafeCheck.IsValidConnection(adapter.Connection))
                    return (Result.Unsuccess, $"Database connection error");

                var methodInfo = typeof(ISUPNifudaDataTableAdapter).GetMethod("Insert");

                foreach (var obj in data)
                {
                    var tupleParameters = obj.PropertiesToTuple();
                    var values = methodInfo.GetParameters().Select(info =>
                                                                   tupleParameters.FirstOrDefault(p =>
                                                                                                  p.Name.ToLower()
                                                                                                  == info.Name.ToLower()).Value ?? "");
                    if (values == null) continue;
                    methodInfo.Invoke(adapter, values.ToArray());
                }

                return (Result.Success, $"Ok");
            }
        }

        public (Result, string) Update(IEnumerable<InputData> data, object state = null)
        {
            using (var adapter = new ISUPNifudaDataTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.IsupConnectionString)
            })
            {
                if (!SafeCheck.IsValidConnection(adapter.Connection))
                    return (Result.Unsuccess, $"Database connection error");

                var methodInfo = typeof(ISUPNifudaDataTableAdapter).GetMethod("Update", 
                    Enumerable.Range(0, 49).Select(i => typeof(string)).ToArray());

                foreach (var obj in data)
                {
                    var tupleParameters = obj.PropertiesToTuple();
                    var values = methodInfo.GetParameters().Select(info =>
                                                                   tupleParameters.FirstOrDefault(p =>
                                                                                                  p.Name.ToLower()
                                                                                                  == info.Name.ToLower()).Value ?? "");
                    if (values == null) continue;
                    methodInfo.Invoke(adapter, values.ToArray());
                }

                return (Result.Success, $"Ok");
            }
        }

        public (Result, string) UpdateDownloaded(object state = null)
        {
            using (var adapter = new ISUPNifudaDataTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.IsupConnectionString)
            })
            {
                if (!SafeCheck.IsValidConnection(adapter.Connection))
                    return (Result.Unsuccess, $"Database connection error");

                adapter.UpdateQuery();
                return (Result.Success, $"Ok");
            }
        }

        public (Result, string) Delete(IEnumerable<InputData> data, object state = null)
        {
            using (var adapter = new ISUPNifudaDataTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.IsupConnectionString)
            })
            {
                if (!SafeCheck.IsValidConnection(adapter.Connection))
                    return (Result.Unsuccess, $"Database connection error");

                var methodInfo = typeof(ISUPNifudaDataTableAdapter).GetMethod("Delete");

                foreach (var obj in data)
                {
                    var tupleParameters = obj.PropertiesToTuple();
                    var values = methodInfo.GetParameters().Select(info =>
                                                                   tupleParameters.FirstOrDefault(p =>
                                                                                                  p.Name.ToLower()
                                                                                                  == info.Name.ToLower()).Value ?? "");
                    if (values == null) continue;
                    methodInfo.Invoke(adapter, values.ToArray());
                }

                return (Result.Success, $"Ok");
            }
        }
    }
}

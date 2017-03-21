using ReportManager.Data.AbstractAdapters;
using System.Linq;
using System.Collections.Generic;
using ReportManager.Data.DataModel;
using ReportManager.Data.Extensions;
using ReportManager.Data.Settings;
using System.Data.SqlClient;
using System;
using System.Data;
using ReportManager.Data.Database.MaxigrafDataSetTableAdapters;
using static ReportManager.Data.Database.MaxigrafDataSet;

namespace ReportManager.Data.SAP.ConcreteAdapters
{
    internal class MaxigrafPlatesSettingsDatabaseAdapter : ICommonAdapter<MaxigrafPlateSetting>
    {
        public IEnumerable<MaxigrafPlateSetting> Select(object state = null)
        {
            using (var adapter = new MaxigrafPlatesSettingDataTableTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (!SafeCheck.IsValidConnection(adapter.Connection))
                    yield break;

                var dataTable = adapter.GetDataBy();
                foreach (var obj in dataTable.AdaptWithSameProperties<MaxigrafPlateSetting,
                                                                      MaxigrafPlatesSettingDataTableRow>())
                    yield return obj;
            }
        }

        public IEnumerable<MaxigrafPlateSetting> SelectByPlateId(int plateId, object state = null)
        {
            using (var adapter = new MaxigrafPlatesSettingDataTableTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (!SafeCheck.IsValidConnection(adapter.Connection))
                    yield break;

                var dataTable = adapter.GetData(plateId);
                foreach (var obj in dataTable.AdaptWithSameProperties<MaxigrafPlateSetting,
                                                                      MaxigrafPlatesSettingDataTableRow>())
                    yield return obj;
            }
        }

        public (Result, string) Insert(IEnumerable<MaxigrafPlateSetting> data, object state = null)
        {
            using (var adapter = new MaxigrafPlatesSettingDataTableTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (!SafeCheck.IsValidConnection(adapter.Connection))
                    return (Result.Unsuccess, $"Database connection error");

                var methodInfo = typeof(MaxigrafPlatesSettingDataTableTableAdapter).GetMethod("Insert");

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

        public (Result, string) Update(IEnumerable<MaxigrafPlateSetting> data, object state = null)
        {
            using (var adapter = new MaxigrafPlatesSettingDataTableTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (!SafeCheck.IsValidConnection(adapter.Connection))
                    return (Result.Unsuccess, $"Database connection error");

                var methodInfo = typeof(MaxigrafPlatesSettingDataTableTableAdapter).GetMethod("Update",
                     new List<Type> { typeof(string), typeof(string), typeof(string),
                                      typeof(int), typeof(int), typeof(string), typeof(string),
                                      typeof(string), typeof(string), typeof(int) }.ToArray());

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

        public (Result, string) Delete(IEnumerable<MaxigrafPlateSetting> data, object state = null)
        {
            using (var adapter = new MaxigrafPlatesSettingDataTableTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (!SafeCheck.IsValidConnection(adapter.Connection))
                    return (Result.Unsuccess, $"Database connection error");

                foreach (var obj in data)
                {
                    adapter.Delete(obj.Num);
                }

                return (Result.Success, $"Ok");
            }
        }
    }
}

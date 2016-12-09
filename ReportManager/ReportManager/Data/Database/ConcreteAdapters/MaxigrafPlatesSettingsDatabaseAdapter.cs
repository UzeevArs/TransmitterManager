using ReportManager.Data.AbstractAdapters;
using System.Linq;
using System.Collections.Generic;
using ReportManager.Data.DataModel;
using ReportManager.Data.Database.MaxigrafDataSetTableAdapters;
using ReportManager.Data.Extensions;
using ReportManager.Data.Settings;
using System.Data.SqlClient;
using System;

using static ReportManager.Data.Database.MaxigrafDataSet;
using System.Data;

namespace ReportManager.Data.Database.ConcreteAdapters
{
    internal class MaxigrafPlatesSettingsDatabaseAdapter : ICommonAdapter<MaxigrafPlatesSettings>
    {
        public IEnumerable<MaxigrafPlatesSettings> Select(object state)
        {
            using (var adapter = new MaxigrafPlatesSettingDataTableTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (adapter.Connection.State != ConnectionState.Open)
                    yield break;

                var dataTable = adapter.GetDataBy();
                foreach (var obj in dataTable.AdaptWithSameProperties<MaxigrafPlatesSettings,
                                                                      MaxigrafPlatesSettingDataTableRow>())
                    yield return obj;
            }
        }

        public IEnumerable<MaxigrafPlatesSettings> SelectByPlateId(int plateId, object state)
        {
            using (var adapter = new MaxigrafPlatesSettingDataTableTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (adapter.Connection.State != ConnectionState.Open)
                    yield break;

                var dataTable = adapter.GetData(plateId);
                foreach (var obj in dataTable.AdaptWithSameProperties<MaxigrafPlatesSettings,
                                                                      MaxigrafPlatesSettingDataTableRow>())
                    yield return obj;
            }
        }

        public (Result, string) Insert(IEnumerable<MaxigrafPlatesSettings> data, object state)
        {
            using (var adapter = new MaxigrafPlatesSettingDataTableTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (adapter.Connection.State != ConnectionState.Open)
                    return (Result.Unsuccess, $"Database connection error");

                var methodInfo = typeof(MaxigrafPlatesSettingDataTableTableAdapter).GetMethod("Insert");

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

        public (Result, string) Update(IEnumerable<MaxigrafPlatesSettings> data, object state)
        {
            using (var adapter = new MaxigrafPlatesSettingDataTableTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (adapter.Connection.State != ConnectionState.Open)
                    return (Result.Unsuccess, $"Database connection error");

                int fieldsCount = (new MaxigrafPlatesSettingDataTableDataTable()).Columns.Count;
                var methodInfo = typeof(MaxigrafPlatesSettingDataTableTableAdapter).GetMethod("Update",
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

        public (Result, string) Delete(IEnumerable<MaxigrafPlatesSettings> data, object state) => throw new NotImplementedException();
    }
}

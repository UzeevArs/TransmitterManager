using ReportManager.Data.AbstractAdapters;
using System.Linq;
using System.Collections.Generic;
using ReportManager.Data.DataModel;
using ReportManager.Data.Database.MaxigrafDataSetTableAdapters;
using ReportManager.Data.Extensions;
using ReportManager.Data.Settings;
using System.Data.SqlClient;

using static ReportManager.Data.Database.MaxigrafDataSet;
using System.Data;

namespace ReportManager.Data.Database.ConcreteAdapters
{
    internal class MaxigrafPlatesDatabaseAdapter : ICommonAdapter<MaxigrafPlates>
    {
        public IEnumerable<MaxigrafPlates> Select(object state)
        {
            using (var adapter = new MaxiGrafPlatesTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (!SafeCheck.IsValidConnection(adapter.Connection))
                    yield break;

                var dataTable = adapter.GetDataBy();
                foreach (var obj in dataTable.AdaptWithSameProperties<MaxigrafPlates,
                                                                      MaxigrafPlatesDataTableRow>())
                    yield return obj;
            }
        }

        public (Result, string) Insert(IEnumerable<MaxigrafPlates> data, object state)
        {
            using (var adapter = new MaxiGrafPlatesTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (!SafeCheck.IsValidConnection(adapter.Connection))
                    return (Result.Unsuccess, $"Database connection error");

                var methodInfo = typeof(MaxiGrafPlatesTableAdapter).GetMethod("Insert");

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

        public (Result, string) Update(IEnumerable<MaxigrafPlates> data, object state)
        {
            using (var adapter = new MaxiGrafPlatesTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (!SafeCheck.IsValidConnection(adapter.Connection))
                    return (Result.Unsuccess, $"Database connection error");

                int fieldsCount = (new MaxigrafPlatesSettingDataTableDataTable()).Columns.Count;
                var methodInfo = typeof(MaxiGrafPlatesTableAdapter).GetMethod("Update",
                    Enumerable.Range(0, fieldsCount).Select(i => typeof(string)).ToArray());

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

        public (Result, string) Delete(IEnumerable<MaxigrafPlates> data, object state)
        {
            using (var adapter = new MaxiGrafPlatesTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (!SafeCheck.IsValidConnection(adapter.Connection))
                    return (Result.Unsuccess, $"Database connection error");

                foreach (var obj in data)
                {
                    adapter.Delete(obj.PlateID);
                }

                return (Result.Success, $"Ok");
            }
        }
    }
}

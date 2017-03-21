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
    internal class MaxigrafPlatesDatabaseAdapter : ICommonAdapter<MaxigrafPlate>
    {
        public IEnumerable<MaxigrafPlate> Select(object state = null)
        {
            using (var adapter = new MaxiGrafPlatesTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (!SafeCheck.IsValidConnection(adapter.Connection))
                    yield break;

                var dataTable = adapter.GetDataBy();
                foreach (var obj in dataTable.AdaptWithSameProperties<MaxigrafPlate,
                                                                      MaxigrafPlatesDataTableRow>())
                    yield return obj;
            }
        }

        public (Result, string) Insert(IEnumerable<MaxigrafPlate> data, object state = null)
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

        public (Result, string) Update(IEnumerable<MaxigrafPlate> data, object state = null)
        {
            using (var adapter = new MaxiGrafPlatesTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (!SafeCheck.IsValidConnection(adapter.Connection))
                    return (Result.Unsuccess, $"Database connection error");

                var methodInfo = typeof(MaxiGrafPlatesTableAdapter).GetMethod("Update",
                    new List<Type> { typeof(string), typeof(string), typeof(string),
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

        public (Result, string) Delete(IEnumerable<MaxigrafPlate> data, object state = null)
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

using ReportManager.Data.AbstractAdapters;
using System.Collections.Generic;
using ReportManager.Data.DataModel;
using ReportManager.Data.Extensions;
using System.Data.SqlClient;
using ReportManager.Data.Database.CalibrationDataSetTableAdapters;
using ReportManager.Data.AbstractAdapters.Generic;
using System.Linq;
using ReportManager.Data.Settings;
using System;
using System.Data;

using static ReportManager.Data.Database.CalibrationDataSet;

namespace ReportManager.Data.Database.ConcreteAdapters
{
    internal class CalibrationResultsDatabaseAdapter : ICommonAdapter<CalibrationResults>, ISelectBySerialAdapter<CalibrationResults>
    {
        public IEnumerable<CalibrationResults> Select(object state = null)
        {
            using (var adapter = new CalibrationDataTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (!SafeCheck.IsValidConnection(adapter.Connection))
                    yield break;

                var dataTable = adapter.GetData();
                foreach (var obj in dataTable.AdaptWithSameProperties<CalibrationResults,
                                                                      CalibrationDataTableRow>())
                    yield return obj;
            }
        }

        public IEnumerable<CalibrationResults> SelectBySerial(string serial, object state = null)
        {
            using (var adapter = new CalibrationDataTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (!SafeCheck.IsValidConnection(adapter.Connection))
                    yield break;

                var dataTable = adapter.GetDataBy(serial);
                foreach (var obj in dataTable.AdaptWithSameProperties<CalibrationResults,
                                                                      CalibrationDataTableRow>())
                    yield return obj;
            }
        }

        public (Result, string) Insert(IEnumerable<CalibrationResults> data, object state = null)
        {
            using (var adapter = new CalibrationDataTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (!SafeCheck.IsValidConnection(adapter.Connection))
                    return (Result.Unsuccess, $"Database connection error");

                var methodInfo = typeof(CalibrationDataTableAdapter).GetMethod("Insert");

                foreach (var obj in data)
                {
                    var tupleParameters = obj.PropertiesToTuple();
                    var values = methodInfo.GetParameters().Select(info =>
                                                                   tupleParameters.FirstOrDefault(p =>
                                                                                                  p.Name.ToLower() == 
                                                                                                  info.Name.ToLower()).Value ?? "");
                    if (values == null) continue;

                    methodInfo.Invoke(adapter, values.ToArray());
                }

                return (Result.Success, $"Ok");
            }
        }

        public (Result, string) Update(IEnumerable<CalibrationResults> data, object state) => throw new NotImplementedException();

        public (Result, string) Delete(IEnumerable<CalibrationResults> data, object state = null) => throw new NotImplementedException();
    }
}

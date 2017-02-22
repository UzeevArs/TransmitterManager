using ReportManager.Data.AbstractAdapters;
using ReportManager.Data.SAP.TemperatureDataSetTableAdapters;
using ReportManager.Data.DataModel;
using ReportManager.Data.Settings;
using ReportManager.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static ReportManager.Data.SAP.TemperatureDataSet;

namespace ReportManager.Data.SAP.ConcreteAdapters
{
    internal class TemperatureFrameDatabaseAdapter : ICommonAdapter<TemperatureFrame>
    {
        public IEnumerable<TemperatureFrame> Select(object state = null)
        {
            using (var adapter = new TemperatureTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (!SafeCheck.IsValidConnection(adapter.Connection))
                    yield break;

                var dataTable = adapter.GetData();
                foreach (var obj in dataTable.AdaptWithSameProperties<TemperatureFrame,
                                                                      TemperatureDataTableRow>())
                    yield return obj;
            }
        }

        public (Result, string) Insert(IEnumerable<TemperatureFrame> data, object state = null)
        {
            using (var adapter = new TemperatureTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (!SafeCheck.IsValidConnection(adapter.Connection))
                    return (Result.Unsuccess, $"Database connection error");

                var methodInfo = typeof(TemperatureTableAdapter).GetMethod("Insert");

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

        public (Result, string) Delete(IEnumerable<TemperatureFrame> data, object state) => throw new NotImplementedException();

        public (Result, string) Update(IEnumerable<TemperatureFrame> data, object state) => throw new NotImplementedException();
    }
}

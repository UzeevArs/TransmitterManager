using ReportManager.Data.AbstractAdapters;
using System;
using System.Collections.Generic;
using ReportManager.Data.Extensions;
using ReportManager.Data.DataModel;
using ReportManager.Data.SAP.HipotDataTableTableAdapters;
using ReportManager.Data.AbstractAdapters.Generic;
using System.Data.SqlClient;
using System.Linq;
using ReportManager.Data.Settings;

using static ReportManager.Data.SAP.HipotDataTable;
using System.Data;

namespace ReportManager.Data.SAP.ConcreteAdapters
{
    internal class DeviceTestResultsDatabaseAdapter : ICommonAdapter<DeviceTestResults>, ISelectBySerialAdapter<DeviceTestResults>
    {
        public IEnumerable<DeviceTestResults> Select(object state = null)
        {
            using (var adapter = new HipotDataTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (!SafeCheck.IsValidConnection(adapter.Connection))
                    throw new ConnectionException(SettingsContext.GlobalSettings.NifudaConnectionString);

                var dataTable = adapter.GetData();
                foreach (var obj in dataTable.AdaptWithSameProperties<DeviceTestResults,
                                                                      HipotDataTableRow>())
                    yield return obj;
            }
        }

        public IEnumerable<DeviceTestResults> SelectBySerial(string barcode, object state = null)
        {
            using (var adapter = new HipotDataTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (!SafeCheck.IsValidConnection(adapter.Connection))
                    throw new ConnectionException(SettingsContext.GlobalSettings.NifudaConnectionString);

                var dataTable = adapter.GetDataBy(barcode);
                foreach (var obj in dataTable.AdaptWithSameProperties<DeviceTestResults,
                                                                      HipotDataTableRow>())
                    yield return obj;
            }
        }

        public (Result, string) Insert(IEnumerable<DeviceTestResults> data, object state = null)
        {
            using (var adapter = new HipotDataTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (!SafeCheck.IsValidConnection(adapter.Connection))
                    return (Result.Unsuccess, $"Database connection error");

                var methodInfo = typeof(HipotDataTableAdapter).GetMethod("Insert");

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

        public (Result, string) Update(IEnumerable<DeviceTestResults> data, object state = null) => throw new NotImplementedException();

        public (Result, string) Delete(IEnumerable<DeviceTestResults> data, object state = null) => throw new NotImplementedException();
    }
}

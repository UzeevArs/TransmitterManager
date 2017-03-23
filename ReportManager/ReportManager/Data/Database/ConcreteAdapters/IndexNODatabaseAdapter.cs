using System;
using System.Collections.Generic;
using ReportManager.Data.AbstractAdapters;
using ReportManager.Data.DataModel;
using ReportManager.Data.Settings;
using ReportManager.Data.Extensions;
using System.Data.SqlClient;
using System.Linq;
using ReportManager.Data.Database.DataSet1TableAdapters;
using ReportManager.Data.SAP;
using static ReportManager.Data.Database.DataSet1;
using ReportManager.Data.AbstractAdapters.Generic;

namespace ReportManager.Data.Database.ConcreteAdapters
{
    internal class IndexNODataAdapter : ICommonAdapter<IndexNOResult>, IExtraInputDataAdapter<IndexNOResult>, ISelectBySerialAdapter<IndexNOResult>
    {
        public SqlConnection Connection { get; private set; }

        public (Result, string) Insert(IEnumerable<IndexNOResult> data, object state)
        {
             using (var adapter = new IndexNODataTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (!SafeCheck.IsValidConnection(adapter.Connection))
                    return (Result.Unsuccess, $"Database connection error");

                var methodInfo = typeof(IndexNODataTableAdapter).GetMethod("Insert");

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

        public IEnumerable<IndexNOResult> Select(object state = null)
        {

            using (var adapter = new IndexNODataTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (!SafeCheck.IsValidConnection(adapter.Connection))
                    throw new ConnectionException(SettingsContext.GlobalSettings.NifudaConnectionString);

                var dataTable = adapter.GetData();
                foreach (var obj in dataTable.AdaptWithSameProperties<IndexNOResult,
                                                                       IndexNODataTableRow>())
                    yield return obj;
            }
        }

        public (Result, string) Update(IEnumerable<IndexNOResult> data, object state)
        {
            throw new NotImplementedException();
        }
        public (Result, string) Delete(IEnumerable<IndexNOResult> data, object state)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IndexNOResult> SelectDataByIndex(string index, object state)
        {
            using (var adapter = new IndexNODataTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (!SafeCheck.IsValidConnection(adapter.Connection))
                    throw new ConnectionException(SettingsContext.GlobalSettings.NifudaConnectionString);

                var dataTable = adapter.GetDataBySapIndexNO(index);
                foreach (var obj in dataTable.AdaptWithSameProperties<IndexNOResult,
                                                                       IndexNODataTableRow>())
                    yield return obj;
            }
        }

        public IEnumerable<IndexNOResult> SelectNotGeneratedData(object state)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IndexNOResult> SelectByEmptyBarCode(object state)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IndexNOResult> SelectBySerial(string serial, object state)
        {
            using (var adapter = new IndexNODataTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (!SafeCheck.IsValidConnection(adapter.Connection))
                    throw new ConnectionException(SettingsContext.GlobalSettings.NifudaConnectionString);

                var dataTable = adapter.GetDataByIndexNO(serial);
                foreach (var obj in dataTable.AdaptWithSameProperties<IndexNOResult,
                                                                       IndexNODataTableRow>())
                    yield return obj;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using ReportManager.Data.Extensions;
using ReportManager.Data.AbstractAdapters;
using ReportManager.Data.DataModel;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using ReportManager.Data.Settings;
using ReportManager.Data.Database.UsersDataSetTableAdapters;

using static ReportManager.Data.Database.UsersDataSet;

namespace ReportManager.Data.Database.ConcreteAdapters
{
    internal class UsersDatabaseAdapter : ICommonAdapter<User>
    {
        public IEnumerable<User> Select(object state = null)
        {
            using (var adapter = new UsersTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (!SafeCheck.IsValidConnection(adapter.Connection))
                    yield break;

                var dataTable = adapter.GetData();
                foreach (var obj in dataTable.AdaptWithSameProperties<User,
                                                                      USERS_TBRow>())
                    yield return obj;
            }
        }

        public (Result, string) Insert(IEnumerable<User> data, object state = null)
        {
            using (var adapter = new UsersTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (!SafeCheck.IsValidConnection(adapter.Connection))
                    return (Result.Unsuccess, $"Database connection error");

                var methodInfo = typeof(UsersTableAdapter).GetMethod("InsertQuery");

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

        public (Result, string) Update(IEnumerable<User> data, object state = null)
        {
            using (var adapter = new UsersTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (!SafeCheck.IsValidConnection(adapter.Connection))
                    return (Result.Unsuccess, $"Database connection error");
                var methodInfo = typeof(UsersTableAdapter).GetMethod("UpdateQuery");

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

        public (Result, string) Delete(IEnumerable<User> data, object state = null)
        {
            using (var adapter = new UsersTableAdapter
            {
                Connection = new SqlConnection(SettingsContext.GlobalSettings.NifudaConnectionString)
            })
            {
                if (!SafeCheck.IsValidConnection(adapter.Connection))
                    return (Result.Unsuccess, $"Database connection error");

                foreach (var obj in data)
                {
                    adapter.DeleteQuery(obj.TUSER);
                }

                return (Result.Success, $"Ok");
            }
        }
    }
}

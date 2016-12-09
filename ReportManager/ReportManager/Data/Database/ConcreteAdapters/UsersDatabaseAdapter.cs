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

        public (Result, string) Insert(IEnumerable<User> data, object state = null) => throw new NotImplementedException();

        public (Result, string) Update(IEnumerable<User> data, object state = null) => throw new NotImplementedException();

        public (Result, string) Delete(IEnumerable<User> data, object state = null) => throw new NotImplementedException();
    }
}

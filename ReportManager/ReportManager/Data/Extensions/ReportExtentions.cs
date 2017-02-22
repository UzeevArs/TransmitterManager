using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ReportManager.Data.Extensions
{
    public static class ReportExtensions
    {
        static Func<XRControl, XRControl> RecursiveFind = null;
        static Func<object, XRControl> GetParent = (s) => (s as XRControl).Parent;

        public static DataTable GetDataTable(this object sender)
        {
            RecursiveFind = (s) => GetParent(s) == null ? s : RecursiveFind(GetParent(s));
            var report = RecursiveFind(sender as XRControl).Parent as XtraReport;
            return report.DataSource as DataTable;
        }

        public static Dictionary<string, string> DataTableToDict(this DataTable dataTable)
        {
            var items = new Dictionary<string, string>();
            foreach (var i in Enumerable.Range(0, dataTable.Columns.Count))
                items[dataTable.Columns[i].ColumnName] = dataTable.Rows[0][i].ToString();
            return items;
        }
    }
}
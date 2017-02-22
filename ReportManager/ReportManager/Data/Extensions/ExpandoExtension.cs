using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;

namespace ReportManager.Data.Extensions
{
    internal static class ExpandoExtension
    {
        public static DataTable ToDataTable(this IEnumerable<dynamic> items)
        {
            var data = items.ToArray();
            if (data.Count() == 0) return null;

            var dt = new DataTable();
            foreach (var key in ((IDictionary<string, object>)data[0]).Keys)
            {
                dt.Columns.Add(key);
            }
            foreach (var d in data)
            {
                dt.Rows.Add(((IDictionary<string, object>)d).Values.ToArray());
            }
            return dt;
        }
        
        public static ExpandoObject ToExpando(this IEnumerable<KeyValuePair<string, object>> dictionary)
        {
            var expando = new ExpandoObject();
            var expandoDic = (IDictionary<string, object>)expando;

            foreach (var kvp in dictionary)
            {
                if (kvp.Value is IDictionary<string, object>)
                {
                    var expandoValue = ((IDictionary<string, object>)kvp.Value).ToExpando();
                    if (!expandoDic.ContainsKey(kvp.Key))
                        expandoDic.Add(kvp.Key, expandoValue);
                    else
                        expandoDic[kvp.Key] = expandoValue;
                }
                else if (kvp.Value is ICollection)
                {
                    var itemList = new List<object>();
                    foreach (var item in (ICollection)kvp.Value)
                    {
                        if (item is IDictionary<string, object>)
                        {
                            var expandoItem = ((IDictionary<string, object>)item).ToExpando();
                            itemList.Add(expandoItem);
                        }
                        else
                        {
                            itemList.Add(item);
                        }
                    }

                    if (!expandoDic.ContainsKey(kvp.Key))
                        expandoDic.Add(kvp.Key, itemList);
                    else
                        expandoDic[kvp.Key] = itemList;
                }
                else
                {
                    if (!expandoDic.ContainsKey(kvp.Key))
                        expandoDic.Add(kvp);
                    else
                        expandoDic[kvp.Key] = kvp.Value;
                }
            }

            return expando;
        }

        public static IEnumerable<dynamic> ToDynamicArray(this ExpandoObject obj)
        {
            yield return obj;
        }
    }
}

using ReportManager.Data.DataModel;
using System.Collections.Generic;

namespace ReportManager.Data.AbstractAdapters
{
    internal enum Result
    {
        Success, Unsuccess
    }

    internal interface ICommonAdapter<T> where T: class, new()
    {
        IEnumerable<T> Select(object state);
        (Result, string) Insert(IEnumerable<T> data, object state);
        (Result, string) Update(IEnumerable<T> data, object state);
        (Result, string) Delete(IEnumerable<T> data, object state);
    }
}

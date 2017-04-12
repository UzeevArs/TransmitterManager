using ReportManager.Data.DataModel;
using System.Collections.Generic;

namespace ReportManager.Data.AbstractAdapters
{
    public enum Result
    {
        Success, Unsuccess
    }

    public interface ICommonAdapter<T> where T: class, new()
    {
        IEnumerable<T> Select(object state);
        (Result, string) Insert(IEnumerable<T> data, object state);
        (Result, string) Update(IEnumerable<T> data, object state);
        (Result, string) Delete(IEnumerable<T> data, object state);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Data.AbstractAdapters
{
    public interface IExtraInputDataAdapter<T> where T : class, new()
    {
        IEnumerable<T> SelectDataByIndex(string index, object state);
        IEnumerable<T> SelectNotGeneratedData(object state);
        IEnumerable<T> SelectByEmptyBarCode(object state);
    }
}

using System.Collections.Generic;

namespace ReportManager.Data.AbstractAdapters.Generic
{
    interface ISelectBySerialAdapter<T> where T: class, new()
    {
        IEnumerable<T> SelectBySerial(string serial, object state = null);
    }
}

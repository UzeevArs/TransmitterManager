using ReportManager.Data.AbstractAdapters.Generic;
using System.Collections.Generic;
using ReportManager.Data.DataModel;
using ReportManager.Data.Extensions;

namespace ReportManager.Data.SAP.ConcreteAdapters
{
    class SapResultDatabaseAdapter : ISelectBySerialAdapter<InputData>
    {
        public IEnumerable<InputData> SelectBySerial(string ProdNo, object state = null)
        {
            var data = SapConnection.GetData(ProdNo);
            
            foreach (var obj in data.SapAdaptWithSameProperties<InputData>())
                yield return obj;
        }
    }
}

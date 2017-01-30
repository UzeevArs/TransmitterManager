using ReportManager.Data.AbstractAdapters;
using ReportManager.Data.AbstractAdapters.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportManager.Data.DataModel;
using ReportManager.Data.Database.ISUPDataTableAdapters;
using SAP.Middleware.Connector;
using ReportManager.Data.Database;
using ReportManager.Data.Extensions;


namespace ReportManager.Data.SAP.ConcreteAdapters
{
    class SapResultDatabaseAdapter : ISelectBySerialAdapter<InputData>
    {
        public IEnumerable<InputData> SelectBySerial(string serial, object state = null)
        {
            var data = SaveSapConnection.SapGetData(serial);
            
            foreach (var obj in data.SapAdaptWithSameProperties<InputData>())
                yield return obj;
        }
    }
}

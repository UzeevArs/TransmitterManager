using ReportManager.Data.Database;
using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Data.SAP
{
    class SaveSapConnection
    {

        public static IEnumerable<(string, string)> SapGetData(string OrderNo)
        {

            try
            {
                var destination = RfcDestinationManager.GetDestination("DEV");
                var function = destination.Repository.CreateFunction("Z_GPP_PRODUCTION_ORDER_IF");
                return SapConnection.SapGetData(destination, function, OrderNo);
            }

            catch
            {
                return new List<(string, string)>();
            }
        }

}
}

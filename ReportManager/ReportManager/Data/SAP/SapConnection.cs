using ReportManager.Data.SAP;
using SAP.Middleware.Connector;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReportManager.Data.SAP
{
    internal class SapConnection
    {
        public static IEnumerable<(string, string)> GetData(string OrderNo)
        {
            var destination = RfcDestinationManager.GetDestination("DEV");
            var function = destination.Repository.CreateFunction("Z_GPP_PRODUCTION_ORDER_IF");
            return SapDataParcer.Parce(destination, function, OrderNo);
        }

        public static async Task<IEnumerable<(string, string)>> GetDataAsync(string OrderNo)
        {
            var destination = RfcDestinationManager.GetDestination("DEV");
            var function = destination.Repository.CreateFunction("Z_GPP_PRODUCTION_ORDER_IF");
            return await SapDataParcer.ParceAsync(destination, function, OrderNo);
        }
    }
}

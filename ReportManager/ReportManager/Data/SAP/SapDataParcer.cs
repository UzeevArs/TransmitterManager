using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SAP.Middleware.Connector;

namespace ReportManager.Data.SAP
{
    internal class SapDataParcer
    {
        public static IEnumerable<(string, string)> Parce(RfcDestination destination, IRfcFunction function, string LinkageNo)
        {
            function.SetValue("I_LINKAGE_NO", LinkageNo);
            function.Invoke(destination);

            return function.GetTable("E_PROD_ORDERS")
                           .Take(1)
                           .Single()
                           .Select(item => (item.Metadata.Name, item.GetString()));
        }

        public static async Task<IEnumerable<(string, string)>> ParceAsync(RfcDestination destination, IRfcFunction function, string LinkageNo)
        {
            return await Task.Run(() =>
            {
                function.SetValue("I_LINKAGE_NO", LinkageNo);
                function.Invoke(destination);

                return function.GetTable("E_PROD_ORDERS")
                               .Take(1)
                               .Single()
                               .Select(item => (item.Metadata.Name, item.GetString()));
            });
        }
    }
}

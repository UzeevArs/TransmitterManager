using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAP.Middleware.Connector;

namespace ReportManager.Data.Database
{
    public class SapConnection
    {

        public static IEnumerable<(string, string)> SapGetData(RfcDestination destination, IRfcFunction function, string OrderNo)
        {
            function.SetValue("I_ORDER_NO", OrderNo);
            function.Invoke(destination);

            return function.GetTable("E_PROD_ORDERS")
                           .Take(1)
                           .Single()
                           .Select(item => (item.Metadata.Name, item.GetString()));
        }

        public static async Task<IEnumerable<(string, string)>> SapTestGetDataAsync(RfcDestination destination, IRfcFunction function, string OrderNo)
        {
            return await Task.Run(() =>
            {
                function.SetValue("I_ORDER_NO", OrderNo);
                function.Invoke(destination);

                return function.GetTable("E_PROD_ORDERS")
                               .Take(1)
                               .Single()
                               .Select(item => (item.Metadata.Name, item.GetString()));
            });
        }


        /*#region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ReadSapDatabase() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
        */
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Data.AbstractAdapters
{
    class ConnectionException : Exception
    {
        public ConnectionException(string message) : base(message)
        {
        }
    }
}

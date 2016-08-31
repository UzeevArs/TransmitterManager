using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.DataModel
{
    public class DeviceTestResult
    {
        private string _result;

        public string Result
        {
            get
            {
                return _result;
            }

            set
            {
                _result = value;
            }
        }
    }
}

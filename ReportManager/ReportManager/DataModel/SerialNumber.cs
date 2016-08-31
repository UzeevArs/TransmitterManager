using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.DataModel
{
    public class SerialNumber
    {
        private string _serial;

        public string Serial
        {
            get
            {
                return _serial;
            }

            set
            {
                _serial = value;
            }
        }

        public static implicit operator List<object>(SerialNumber v)
        {
            throw new NotImplementedException();
        }
    }
}

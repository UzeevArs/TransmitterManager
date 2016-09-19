using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportManager.Database
{
    public class ConnectionStringContainer
    {
        private static ConnectionStringContainer _instance;
        public static ConnectionStringContainer GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ConnectionStringContainer();
            }
            return _instance;
        }
        public static void SetInstance(ConnectionStringContainer instance)
        {
            _instance = instance;
        }

        public string ConnStrNifuda { get; set;}
        public string ConnStrISUP { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Data.DataModel
{
    class MaxiGrafPlates
    {
        private string _plateID;
        private string _plateName;
        private string _plateDescription;
        private string _scriptPath;
        private string _regex;
        private string _storedProcedureName;
        


        public string PLATE_ID
        {
            get
            {
                return _plateID;
            }

            set
            {
                _plateID = value;
            }
        }
        public string PLATE_NAME
        {
            get
            {
                return _plateName;
            }

            set
            {
                _plateName = value;
            }
        }

        public string PLATE_DESCRIPTION
        {
            get
            {
                return _plateDescription;
            }

            set
            {
                _plateDescription = value;
            }
        }

        public string SCRIPT_PATH
        { 
            get
            {
                return _scriptPath;
            }

            set
            {
                _scriptPath = value;
            }
        }

        public string REGEX
        {
            get
            {
                return _regex;
            }

            set
            {
                _regex = value;
            }
        }

        public string STORED_PROCEDURE_NAME
        {
            get
            {
                return _storedProcedureName;
            }

            set
            {
                _storedProcedureName = value;
            }
        }

    }
}

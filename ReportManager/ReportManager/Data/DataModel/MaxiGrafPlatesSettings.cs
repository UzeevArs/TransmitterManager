using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Data.DataModel
{
    class MaxiGrafPlatesSettings
    {

        private string _num;
        private string _objectPath;
        private string _nifudaPath;
        private string _defaultValue;
        private string _maxSymvolCount;
        private string _registertype;
        private string _regex;
        private string _comments;
        private string _owerFlowMovePath;
        private string _plateID;
        private string _moveTo;


        public string NUM
        {
            get
            {
                return _num;
            }

            set
            {
                _num = value;
            }
        }
        public string OBJECT_PATH
        {
            get
            {
                return _objectPath;
            }

            set
            {
                _objectPath = value;
            }
        }
         public string NIFUDA_PATH
                {
                    get
                    {
                        return _nifudaPath;
                    }

                    set
                    {
                _nifudaPath = value;
                    }
                }
        public string DEFAULT_VALUE
        {
            get
            {
                return _defaultValue;
            }

            set
            {
                _defaultValue = value;
            }
        }


        public string MAX_SYMVOL_COUNT
        {
            get
            {
                return _maxSymvolCount;
            }

            set
            {
                _maxSymvolCount = value;
            }
        }

        public string REGISTER_TYPE
        {
            get
            {
                return _registertype;
            }

            set
            {
                _registertype = value;
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

        public string COMMENTS
        {
            get
            {
                return _comments;
            }

            set
            {
                _comments = value;
            }
        }

        public string OWER_FLOW_MOVE_PATH
        {
            get
            {
                return _owerFlowMovePath;
            }

            set
            {
                _owerFlowMovePath = value;
            }
        }

        public string PALTE_ID
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

        public string MOVE_TO
        {
            get
            {
                return _moveTo;
            }

            set
            {
                _moveTo = value;
            }
        }

    }
}

namespace ReportManager.Data.DataModel
{
    public class DeviceTestResult
    {
        private string _serialNumberHipot;
        private string _result;
        private string _isolationV;
        private string _isolationR;
        private string _isolationT;
        private string _iResult;
        private string _withStandV;
        private string _withStandI;
        private string _withStandT;
        private string _wResult;
        private string _testDate;
        private string _testTime;
        private string _tUser;

        public string SerialNumberHipot
        {
            get
            {
                return _serialNumberHipot;
            }

            set
            {
                _serialNumberHipot = value;
            }
        }

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

        public string IsolationV
        {
            get
            {
                return _isolationV;
            }

            set
            {
                _isolationV = value;
            }
        }

        public string IsolationR
        {
            get
            {
                return _isolationR;
            }

            set
            {
                _isolationR = value;
            }
        }

        public string IsolationT
        {
            get
            {
                return _isolationT;
            }

            set
            {
                _isolationT = value;
            }
        }

        public string IResult
        {
            get
            {
                return _iResult;
            }

            set
            {
                _iResult = value;
            }
        }

        public string WithStandV
        {
            get
            {
                return _withStandV;
            }

            set
            {
                _withStandV = value;
            }
        }

        public string WithStandI
        {
            get
            {
                return _withStandI;
            }

            set
            {
                _withStandI = value;
            }
        }

        public string WithStandT
        {
            get
            {
                return _withStandT;
            }

            set
            {
                _withStandT = value;
            }
        }


        public string WResult
        {
            get
            {
                return _wResult;
            }

            set
            {
                _wResult = value;
            }
        }

        public string TestDate
        {
            get
            {
                return _testDate;
            }

            set
            {
                _testDate = value;
            }
        }

        public string TestTime
        {
            get
            {
                return _testTime;
            }

            set
            {
                _testTime = value;
            }
        }

        public string TUser
        {
            get
            {
                return _tUser;
            }

            set
            {
                _tUser = value;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Data.DataModel
{
    class UsersData
    {

        private string _userStagesMask;
        private string _userExtraFuncMask;
        private string _tUser;
        private string _password;
        private string _fullName;



        public string USER_STAGES_MASK
        {
            get
            {
                return _userStagesMask;
            }

            set
            {
                _userStagesMask = value;
            }
        }

        public string USER_EXTRA_FUNCTIONAL_MASK
        {
            get
            {
                return _userExtraFuncMask;
            }

            set
            {
                _userExtraFuncMask = value;
            }
        }

        public string TUSER
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

        public string PASSWORD
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

        public string FULL_NAME
        {
            get
            {
                return _fullName;
            }

            set
            {
                _fullName = value;
            }
        }
    }
}

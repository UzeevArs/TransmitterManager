using ReportManager.Core.Functional;
using ReportManager.Core.Stages;
using ReportManager.Core.Utility;
using System;
using System.Collections.Generic;

namespace ReportManager.Data.DataModel
{
    [Flags]
    public enum UsersStages
    {
        None = 0,
        TransportListCreateStage = 1,
        ReportCreateStage = 2,
        MaxigrafStage = 3
    }

    [Flags]
    public enum UserExtraFunc
    {
        None = 0,
        CheckIsupDb = 1,
        CheckNifudaDb = 2,
        SynchronizeDb = 3
    }

    public class User
    {
        private List<Stage> _stages;
        private List<Functional> _functions;


        public long UserStagesMask { get; set; }
        public List<Stage> UserStages
        {
            get
            {
                if (_stages != null) return _stages;

                _stages = new List<Stage>();

                if (((UsersStages)UserStagesMask).IsSet(UsersStages.TransportListCreateStage))
                    _stages.Add(new TransportListCreateStage());

                if (((UsersStages)UserStagesMask).IsSet(UsersStages.ReportCreateStage))
                    _stages.Add(new ReportCreateStage());

                if (((UsersStages)UserStagesMask).IsSet(UsersStages.MaxigrafStage))
                    _stages.Add(new MaxigrafStage());

                return _stages;
            }
        }

        public long UserExtraFuncMask { get; set; }
        public List<Functional> UserExtraFunction
        {
            get
            {
                if (_functions != null) return _functions;

                _functions = new List<Functional>();

                if (((UserExtraFunc)UserStagesMask).IsSet(UserExtraFunc.CheckIsupDb))
                    _functions.Add(new CheckIsupDbConnectionFunctional());

                if (((UserExtraFunc)UserStagesMask).IsSet(UserExtraFunc.CheckNifudaDb))
                    _functions.Add(new CheckManifactureDbConnectionFunctional());

                if (((UserExtraFunc)UserStagesMask).IsSet(UserExtraFunc.SynchronizeDb))
                    _functions.Add(new SynchronizeDbFunctional());

                return _functions;
            }
        }

        public string TUSER { get; set; } = "";
        public string PASSWORD { get; set; } = "";
        public string FullName { get; set; } = "";
    }
}

using ReportManager.Core.Functional;
using ReportManager.Core.Stages;
using ReportManager.Core.Utility;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ReportManager.Data.DataModel
{
    [Flags]
    public enum UsersStages : long
    {
        None                                        = 0x0,
        TransportListCreateStage                    = 0x1,
        ReportCreateStage                           = 0x2,
        MaxigrafStage                               = 0x4,
        TemperatureStage                            = 0x8
    }

    [Flags]
    public enum UserExtraFunc : long
    {
        None                                        = 0x0,
        CheckIsupDbConnectionFunctional             = 0x1,
        CheckManifactureDbConnectionFunctional      = 0x2,
        TemperatureDbWriteFunctional                = 0x4,
        TempteratureDeviceFunctional                = 0x8
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

                var namesp = typeof(TransportListCreateStage).Namespace;
                _stages = new List<Stage>();
                _stages.AddRange(Enum.GetNames(typeof(UsersStages))
                       .Where(en => en != "None" && UserStagesMask.IsSet((long)Enum.Parse(typeof(UsersStages), en)))
                       .Select(en => (Stage) Activator.CreateInstance(Type.GetType($"{namesp}.{en}"))));

                return _stages;
            }
        }

        public long UserExtraFuncMask { get; set; }
        public List<Functional> UserExtraFunction
        {
            get
            {
                if (_functions != null) return _functions;

                var namesp = typeof(CheckIsupDbConnectionFunctional).Namespace;
                _functions = new List<Functional>();
                _functions.AddRange(Enum.GetNames(typeof(UserExtraFunc))
                          .Where(en => en != "None" && UserExtraFuncMask.IsSet((long)Enum.Parse(typeof(UserExtraFunc), en)))
                          .Select(en => (Functional) Activator.CreateInstance(Type.GetType($"{namesp}.{en}"))));

                return _functions;
            }
        }

        public string TUSER { get; set; } = "";
        public string PASSWORD { get; set; } = "";
        public string FullName { get; set; } = "";
    }
}

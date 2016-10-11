using System.Collections.Generic;
using ReportManager.Core.Functional;
using ReportManager.Core.Stages;

namespace ReportManager.Data.Settings
{
    public class Settings
    {
        public string NifudaConnectionString { get; set; }

        public string IsupConnectionString { get; set; }

        public string ReportSavePath { get; set; }

        public uint UpdateTimeout { get; set; }

        public List<AbstractFunctional> Functionals { get; set; }

        public List<AbstractStage> Stages { get; set; }
    }
}

using System.Collections.Generic;
using ReportManager.Core.Functional;
using ReportManager.Core.Stages;

namespace ReportManager.Data.Settings
{
    internal class Settings
    {
        public string NifudaConnectionString { get; set; }

        public string IsupConnectionString { get; set; }

        public string ReportSavePath { get; set; }

        public uint UpdateTimeout { get; set; }
    }
}

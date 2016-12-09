namespace ReportManager.Data.DataModel
{
    public class MaxigrafPlateSetting
    {
        public int Num { get; set; }
        public string ObjectPath { get; set; } = "";
        public string NifudaPath { get; set; } = "";
        public string DefaultValue { get; set; } = "";
        public int MaxSymbolCount { get; set; }
        public int RegisterType { get; set; }
        public string Regex { get; set; } = "";
        public string Comments { get; set; } = "";
        public string OwerFlowMovePath { get; set; } = "";
        public int PlateID { get; set; }
        public string MoveTo { get; set; } = "";
        public string Value { get; set; } = "";
    }
}

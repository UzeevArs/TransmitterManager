namespace ReportManager.Data.DataModel
{
    public class MaxigrafPlates
    {
        public int PlateID { get; set; }
        public string PlateName { get; set; } = "";
        public string PlateDescription { get; set; } = "";
        public string ScriptPath { get; set; } = "";
        public string Regex { get; set; } = "";
        public string StoredProcedureName { get; set; } = "";
    }
}

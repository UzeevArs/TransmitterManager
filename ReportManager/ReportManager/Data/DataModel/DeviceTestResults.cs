namespace ReportManager.Data.DataModel
{
    public class DeviceTestResults
    {
        public string SERIAL { get; set; } = "";
        public string RESULT { get; set; } = "";
        public float? ISOLATION_V { get; set; }
        public float? ISOLATION_R { get; set; }
        public float? ISOLATION_T { get; set; }
        public string IRESULT { get; set; } = "";
        public float? WITHSTAND_V { get; set; }
        public float? WITHSTAND_I { get; set; }
        public float? WITHSTAND_T { get; set; }
        public string WRESULT { get; set; } = "";
        public string TEST_DATE { get; set; } = "";
        public string TEST_TIME { get; set; } = "";
        public string TUSER { get; set; } = "";
    }
}

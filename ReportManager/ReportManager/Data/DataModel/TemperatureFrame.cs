using System;

namespace ReportManager.Data.DataModel
{
    public class TemperatureFrame
    {
        public DateTime Time { get; set; }
        public float? Temperature { get; set; }
        public float? Humidity { get; set; }
        public float? Pressure { get; set; }
    }
}

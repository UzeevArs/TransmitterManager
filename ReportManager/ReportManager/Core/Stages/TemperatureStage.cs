using ReportManager.Forms.Stages;
using ReportManager.TemperatureLogger.Modbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Core.Stages
{
    public class TemperatureStage : Stage
    {
        public TemperatureStage()
        {
            Name = "Стадия отслеживания работы температурного датчика";
        }

        public override void Create()
        {
            base.Create();
            ChildForm = new TemperatureForm();
        }
    }
}

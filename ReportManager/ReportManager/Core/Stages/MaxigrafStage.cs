﻿using ReportManager.Forms.Stages;
using ReportManager.Forms.Stages.MaxigraphStageForm;

namespace ReportManager.Core.Stages
{
    public class MaxigrafStage : Stage
    {
        public MaxigrafStage()
        {
            Name = "Стадия гравировки";
        }

        public override void Create()
        {
            base.Create();
            ChildForm = new MaxigrafStageForm();
        }
    }
}

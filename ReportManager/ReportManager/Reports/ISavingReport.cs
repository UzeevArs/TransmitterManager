
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Reports
{
    public interface ISavingReport
    {
        bool IsExistTemplateFile();
        string GetTemplateFileName();
    }
}

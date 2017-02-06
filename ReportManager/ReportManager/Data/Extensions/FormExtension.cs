using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportManager.Data.Extensions
{
    internal static class FormExtension
    {
        public static bool SafeInvoke(this Control control, Action action)
        {
            try
            {
                if (control.InvokeRequired)
                    control.Invoke(action);
                else
                    action.Invoke();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

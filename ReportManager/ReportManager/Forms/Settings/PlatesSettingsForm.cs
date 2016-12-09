using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ReportManager.Forms.Stages.MaxigraphStageForm
{
    public partial class PlatesSettingsForm : DevExpress.XtraEditors.XtraForm
    {
        public PlatesSettingsForm()
        {
            InitializeComponent();
        }

        private void GrdPlatesSettings_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mainMenu.ShowPopup(MousePosition);
            }
        }
    }
}
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
    public partial class PlatesForm : DevExpress.XtraEditors.XtraForm
    {
        public PlatesForm()
        {
            InitializeComponent();
        }

        private void GrdPlates_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mainMenu.ShowPopup(MousePosition);
            }
        }
    }
}
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
using ReportManager.Data.Settings;
using ReportManager.Data.Database.ConcreteAdapters;

namespace ReportManager.Forms.Settings
{
    public partial class UserSettingsForm : XtraForm
    {
        public UserSettingsForm()
        {
            InitializeComponent();
            grdUsers.DataSource = (new UsersDatabaseAdapter()).Select();
        }

        private void GridControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mainMenu.ShowPopup(MousePosition);
            }
        }

        private void BtnAddUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            (new AddUserForm()).ShowDialog();
        }

        private void BtnEditUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            (new AddUserForm()).ShowDialog();
        }

        private void BtnDeleteUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            (new UsersDatabaseAdapter()).Delete(null);
        }
    }
}
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
using ReportManager.Data.DataModel;
using ReportManager.Data.AbstractAdapters;

namespace ReportManager.Forms.Settings
{
    public partial class UserSettingsForm : XtraForm
    {
        public UserSettingsForm()
        {
            InitializeComponent();
            UpdateDataSource();
        }

        private void UpdateDataSource()
        {
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
            var user = new User();
            if (new AddUserForm(user).ShowDialog() == DialogResult.OK)
            {
                var (result, error) = (new UsersDatabaseAdapter()).Insert(new List<User> { user });

                if (result == Result.Unsuccess)
                    MessageBox.Show($"Произошла ошибка: {error}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    UpdateDataSource();
            }
        }

        private void BtnEditUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var selected = gridView1.GetSelectedRows()
                                    .Select(i => gridView1.GetRow(i) as User)
                                    .ToList();

            foreach (var obj in selected)
            {
                if (new AddUserForm(obj).ShowDialog() == DialogResult.OK)
                {
                    var (result, error) = (new UsersDatabaseAdapter()).Update(new List<User> { obj });

                    if (result == Result.Unsuccess)
                        MessageBox.Show($"Произошла ошибка: {error}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        UpdateDataSource();
                }
            }
        }

        private void BtnDeleteUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var selected = gridView1.GetSelectedRows()
                        .Select(i => gridView1.GetRow(i) as User);

            var (result, error) = (new UsersDatabaseAdapter()).Delete(selected);

            if (result == Result.Unsuccess)
                MessageBox.Show($"Произошла ошибка: {error}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                UpdateDataSource();
        }
    }
}
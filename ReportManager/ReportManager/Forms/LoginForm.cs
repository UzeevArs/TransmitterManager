using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Management;
using System.DirectoryServices;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ReportManager.Data.Settings;

namespace ReportManager.Forms
{
    public partial class LoginForm : XtraForm
    {
        public LoginForm()
        {
            DialogResult = DialogResult.Cancel;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var users = GetActiveMachineUsers();
            cbUsersName.Properties.Items.AddRange(users.ToList());
            cbUsersName.SelectedItem = Environment.UserName;
        }

        private static IEnumerable<string> GetActiveMachineUsers()
        {
            var searcher = new ManagementObjectSearcher(new SelectQuery("Win32_UserAccount"));
            foreach (var envVar in searcher.Get())
                yield return (string) envVar["Name"];
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SettingsContext.UserName = cbUsersName.SelectedItem.ToString();
            SettingsContext.UserPassword = tbPassword.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnOpenSettings_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
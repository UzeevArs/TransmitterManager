using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ReportManager.Data.Settings;
using ReportManager.Data.Database.ConcreteAdapters;
using ReportManager.Data.DataModel;
using ReportManager.Core.Functional;

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
            var users = GetDbUsers();
            cbUsersName.Properties.Items.AddRange(users.ToList());
            cbUsersName.Properties.Items.Add("ReportManagerAdmin");
            cbUsersName.SelectedItem = Environment.UserName;
        }

        private static IEnumerable<string> GetActiveMachineUsers()
        {
            var searcher = new ManagementObjectSearcher(new ManagementScope("\\\\localhost\\"), 
                                                        new SelectQuery("Win32_UserAccount")).Get();
            foreach (var envVar in searcher)
                yield return (string) envVar["Name"];
        }

        private static IEnumerable<string> GetDbUsers()
        {
            return (new UsersDatabaseAdapter())
                .Select()
                .Select(u => u.TUSER);
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            CheckUser();
        }

        private void CheckUser()
        {
            if (cbUsersName.SelectedItem.ToString() == "ReportManagerAdmin"
                && tbPassword.Text == "FDc5sZLq")
            {
                SettingsContext.CurrentUser = new User
                {
                    FullName = "Report manager administrator",
                    TUSER = "ReportManagerAdmin",
                    PASSWORD = "FDc5sZLq",
                    UserExtraFuncMask = 65535,
                    UserStagesMask = 65535,
                };

                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            if ((new UsersDatabaseAdapter())
                .Select()
                .Any(user => user.TUSER == cbUsersName.SelectedItem.ToString()
                             && user.PASSWORD == tbPassword.Text))
            {
                SettingsContext.CurrentUser = (new UsersDatabaseAdapter())
                    .Select()
                    .FirstOrDefault(user => user.TUSER == cbUsersName.SelectedItem.ToString()
                                            && user.PASSWORD == tbPassword.Text);

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Логин / пароль неверные. Попытайтесь ещё раз",
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void BtnOpenSettings_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void Cancel()
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void LoginForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CheckUser();
            else if (e.KeyCode == Keys.Escape)
                Cancel();
        }
    }
}
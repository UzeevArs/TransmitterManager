using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using ReportManager.Core.Functional;
using ReportManager.Core.Stages;
using ReportManager.Data.DataModel;
using DevExpress.XtraEditors.Controls;
using ReportManager.Core.Utility;

namespace ReportManager.Forms.Settings
{
    public partial class AddUserForm : XtraForm
    {
        private User CurrentUser { get; set; }

        public AddUserForm(User user)
        {
            InitializeComponent();
            CurrentUser = user;
            FillWithTypes<Stage>(cbStageList);
            FillWithTypes<Functional>(cbFunctionsList);
            LoadUser();
        }

        private void LoadUser()
        {
            if (CurrentUser == null) CurrentUser = new User();
            tbUserName.Properties.ReadOnly = CurrentUser.TUSER != string.Empty;

            tbUserName.Text = CurrentUser.TUSER;
            tbFullUserName.Text = CurrentUser.FullName;
            tbUserPassword.Text = CurrentUser.PASSWORD;

            foreach (var stage in CurrentUser.UserStages)
                cbStageList.Items.FirstOrDefault(s =>
                    s.Value.GetType().Equals(stage.GetType())).CheckState = CheckState.Checked;

            foreach (var func in CurrentUser.UserExtraFunction)
                cbFunctionsList.Items.FirstOrDefault(s =>
                    s.Value.GetType().Equals(func.GetType())).CheckState = CheckState.Checked;
        }

        private bool FieldsIsValid()
        {
            foreach (var control in Controls)
                if (control is TextEdit && (control as TextEdit).Text == string.Empty)
                    return false;
            return true;
        }

        private void FillWithTypes<T>(CheckedListBoxControl cb) where T: class
        {
            cb.Items.Clear();
            cb.Items.AddRange(typeof(T).Assembly.GetTypes()
                    .Where(t => t.GetBaseType() == typeof(T))
                    .Select(t => (T) Activator.CreateInstance(t))
                    .ToArray());
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (!FieldsIsValid())
            {
                MessageBox.Show("Заполните все поля", "Предупреждение",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            CurrentUser.TUSER = tbUserName.Text;
            CurrentUser.FullName = tbFullUserName.Text;
            CurrentUser.PASSWORD = tbUserPassword.Text;

            UsersStages stageAgregate = UsersStages.None;
            foreach (CheckedListBoxItem en in cbStageList.Items)
            {
                if (!(en.CheckState == CheckState.Checked)) continue;
                Enum.TryParse(en.Value.GetType().Name, out UsersStages result);
                FlagsHelper.Set(ref stageAgregate, result);
            }
            CurrentUser.UserStagesMask = (long) stageAgregate;

            var funcAgregate = UserExtraFunc.None;
            foreach (CheckedListBoxItem en in cbFunctionsList.Items)
            {
                if (!(en.CheckState == CheckState.Checked)) continue;
                Enum.TryParse(en.Value.GetType().Name, out UserExtraFunc result);
                FlagsHelper.Set(ref funcAgregate, result);
            }
            CurrentUser.UserExtraFuncMask = (long) funcAgregate;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
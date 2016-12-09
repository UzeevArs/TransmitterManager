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
using ReportManager.Data.DataModel;

namespace ReportManager.Forms.Settings
{
    internal partial class AddPlateSettingForm : XtraForm
    {
        private MaxigrafPlateSetting Setting { get; set; }

        public AddPlateSettingForm(MaxigrafPlateSetting setting)
        {
            InitializeComponent();
            Setting = setting;
            LoadPlateSetting();
        }

        private void LoadPlateSetting()
        {
            if (Setting == null) Setting = new MaxigrafPlateSetting();
            tbObjectPath.Text       = Setting.ObjectPath;
            tbNifudaPath.Text       = Setting.NifudaPath;
            tbDefaultValue.Text     = Setting.DefaultValue;
            tbMaxSymbolCount.Value  = Setting.MaxSymbolCount;
            tbRegex.Text            = Setting.Regex;
            tbMoveTo.Text           = Setting.MoveTo;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (!FieldsIsValid())
            {
                MessageBox.Show("Заполните все поля", "Предупреждение",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Setting.ObjectPath      = tbObjectPath.Text;
            Setting.NifudaPath      = tbNifudaPath.Text;
            Setting.DefaultValue    = tbDefaultValue.Text;
            Setting.MaxSymbolCount  = (int) tbMaxSymbolCount.Value;
            Setting.Regex           = tbRegex.Text;
            Setting.MoveTo          = tbMoveTo.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool FieldsIsValid()
        {
            foreach (var control in Controls)
                if (control is TextEdit && (control as TextEdit).Text == string.Empty)
                    return false;
            return true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
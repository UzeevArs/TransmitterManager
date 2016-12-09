using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ReportManager.Data.DataModel;

namespace ReportManager.Forms.Settings
{
    internal partial class AddPlateForm : XtraForm
    {
        private MaxigrafPlate IncomingPlate { get; set; }

        public AddPlateForm(MaxigrafPlate plate)
        {
            InitializeComponent();
            IncomingPlate = plate;
            LoadPlate();
        }

        private void LoadPlate()
        {
            if (IncomingPlate == null) IncomingPlate = new MaxigrafPlate();
            tbName.Text             = IncomingPlate.PlateName;
            tbDescription.Text      = IncomingPlate.PlateDescription;
            tbPath.Text             = IncomingPlate.ScriptPath;
            tbRegex.Text            = IncomingPlate.Regex;
            tbProcedureName.Text    = IncomingPlate.StoredProcedureName;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (!FieldsIsValid())
            {
                MessageBox.Show("Заполните все поля", "Предупреждение", 
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            IncomingPlate.PlateName =           tbName.Text;
            IncomingPlate.PlateDescription =    tbDescription.Text;
            IncomingPlate.ScriptPath =          tbPath.Text;
            IncomingPlate.Regex =               tbRegex.Text;
            IncomingPlate.StoredProcedureName = tbProcedureName.Text;

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

        private void TbPath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            scriptFileDialog.FileName = tbPath.Text;

            if (scriptFileDialog.ShowDialog() == DialogResult.OK)
                tbPath.Text = scriptFileDialog.FileName;
        }
    }
}
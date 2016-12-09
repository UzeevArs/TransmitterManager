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
using ReportManager.Data.Database.ConcreteAdapters;
using ReportManager.Forms.Settings;
using ReportManager.Data.AbstractAdapters;

namespace ReportManager.Forms.Stages.MaxigraphStageForm
{
    internal partial class PlatesSettingsForm : XtraForm
    {
        private MaxigrafPlate Plate { get; set; }

        public PlatesSettingsForm(MaxigrafPlate plate)
        {
            InitializeComponent();

            Plate = plate;
            Text += $" {Plate.PlateName}";

            UpdateDataSource();
        }

        private void UpdateDataSource()
        {
            grdPlatesSettings.DataSource = (new MaxigrafPlatesSettingsDatabaseAdapter()).SelectByPlateId(Plate.PlateID);
        }

        private void GrdPlatesSettings_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                mainMenu.ShowPopup(MousePosition);
        }

        private void BtnAddPlateSetting_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var plateSetting = new MaxigrafPlateSetting { PlateID = Plate.PlateID };
            if (new AddPlateSettingForm(plateSetting).ShowDialog() == DialogResult.OK)
            {
                var (result, error) = (new MaxigrafPlatesSettingsDatabaseAdapter())
                    .Insert(new List<MaxigrafPlateSetting> { plateSetting });

                if (result == Result.Unsuccess)
                    MessageBox.Show($"Произошла ошибка: {error}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    UpdateDataSource();
            }
        }

        private void BtnChangePlateSetting_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var selected = gridView1.GetSelectedRows()
                        .Select(i => gridView1.GetRow(i) as MaxigrafPlateSetting)
                        .ToList();

            foreach (var obj in selected)
            {
                if (new AddPlateSettingForm(obj).ShowDialog() == DialogResult.OK)
                {
                    var (result, error) = (new MaxigrafPlatesSettingsDatabaseAdapter()).Update(new List<MaxigrafPlateSetting> { obj });

                    if (result == Result.Unsuccess)
                        MessageBox.Show($"Произошла ошибка: {error}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        UpdateDataSource();
                }
            }
        }

        private void BtnDeletePlateSetting_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var selected = gridView1.GetSelectedRows()
                        .Select(i => gridView1.GetRow(i) as MaxigrafPlateSetting);

            var (result, error) = (new MaxigrafPlatesSettingsDatabaseAdapter()).Delete(selected);

            if (result == Result.Unsuccess)
                MessageBox.Show($"Произошла ошибка: {error}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                UpdateDataSource();
        }
    }
}
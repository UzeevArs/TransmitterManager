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
using ReportManager.Forms.Settings;
using ReportManager.Data.DataModel;
using ReportManager.Data.Database.ConcreteAdapters;
using ReportManager.Data.AbstractAdapters;

namespace ReportManager.Forms.Stages.MaxigraphStageForm
{
    public partial class PlatesForm : XtraForm
    {
        public PlatesForm()
        {
            InitializeComponent();
            UpdateDataSource();
        }

        private void UpdateDataSource()
        {
            grdPlates.DataSource = (new MaxigrafPlatesDatabaseAdapter()).Select();
        }

        private void GrdPlates_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mainMenu.ShowPopup(MousePosition);
            }
        }

        private void BtnAddPlate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var plate = new MaxigrafPlate();
            if (new AddPlateForm(plate).ShowDialog() == DialogResult.OK)
            {
                var (result, error) = (new MaxigrafPlatesDatabaseAdapter()).Insert(new List<MaxigrafPlate> { plate });

                if (result == Result.Unsuccess)
                    MessageBox.Show($"Произошла ошибка: {error}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    UpdateDataSource();
            }
        }

        private void BtnChangePlate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var selected = gridView1.GetSelectedRows()
                                    .Select(i => gridView1.GetRow(i) as MaxigrafPlate)
                                    .ToList();

            foreach (var obj in selected)
            {
                if (new AddPlateForm(obj).ShowDialog() == DialogResult.OK)
                {
                    var (result, error) = (new MaxigrafPlatesDatabaseAdapter()).Update(new List<MaxigrafPlate> { obj });

                    if (result == Result.Unsuccess)
                        MessageBox.Show($"Произошла ошибка: {error}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        UpdateDataSource();
                }
            }
        }

        private void BtnDeletePlate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var selected = gridView1.GetSelectedRows()
                                    .Select(i => gridView1.GetRow(i) as MaxigrafPlate);

            var (result, error) = (new MaxigrafPlatesDatabaseAdapter()).Delete(selected);

            if (result == Result.Unsuccess)
                MessageBox.Show($"Произошла ошибка: {error}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                UpdateDataSource();
        }

        private void GrdPlates_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var selected = gridView1.GetSelectedRows()
                                    .Select(i => gridView1.GetRow(i) as MaxigrafPlate)
                                    .ToList();

            foreach (var obj in selected)
            {
                (new PlatesSettingsForm(obj) { MdiParent = MdiParent }).Show();
            }
        }
    }
}
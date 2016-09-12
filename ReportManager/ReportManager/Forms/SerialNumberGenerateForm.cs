using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Windows.Forms;

namespace ReportManager.Forms
{
    public partial class SerialNumberGenerateForm : Form
    {
        public SerialNumberGenerateForm()
        {
            InitializeComponent();
            nifudaDataTableAdapter1.FillByEmptySerial(nifudaDataSet1.NifudaDataTable);
        }

        private void grdEmptySerial_DoubleClick(object sender, EventArgs e)
        {
            var rows = (grdEmptySerial.MainView as GridView).GetSelectedRows();
            if (rows.Length > 0)
            {
                var serial = SerialGenerator.Generate(nifudaDataSet1.NifudaDataTable[rows[0]]);
                MessageBox.Show(serial.ToString());
            }
        }
    }
}

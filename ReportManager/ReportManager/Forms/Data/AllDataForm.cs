using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ReportManager.Forms.Data
{
    public partial class AllDataForm : DevExpress.XtraEditors.XtraForm
    {
        public AllDataForm()
        {
            InitializeComponent();
        }

        private void AllData_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nifudaDataSet.NifudaDataTable' table. You can move, or remove it, as needed.
            this.nifudaDataTableAdapter.Fill(this.nifudaDataSet.NifudaDataTable);

        }
    }
}
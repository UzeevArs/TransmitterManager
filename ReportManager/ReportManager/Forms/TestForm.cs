using ReportManager.Database.NifudaDataSetTableAdapters;
using ReportManager.Database.ISUPDataTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReportManager.Forms
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            
        }

        private void btnTestData_Click(object sender, EventArgs e)
        {

            ISUPNifudaDataTableAdapter iSUPNifudaDataTableAdapter = new ISUPNifudaDataTableAdapter();
            NifudaDataTableAdapter nifudaDataTableAdapter = new NifudaDataTableAdapter();
            nifudaDataTableAdapter.InsertQuery();
            

        }
    }
}

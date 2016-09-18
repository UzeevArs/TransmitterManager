using ReportManager.Database;
using ReportManager.Database.ISUPDataTableAdapters;
using ReportManager.Database.NifudaDataSetTableAdapters;
using System;
using System.Windows.Forms;

namespace ReportManager.Forms
{
    public partial class DatabaseSettingChange : Form
    {
        public DatabaseSettingChange()
        {
            InitializeComponent();
            edtISUPConnString.Text = ConnectionStringContainer.ConnStrISUP;
            edtNifudaConnString.Text = ConnectionStringContainer.ConnStrNifuda;

        }
        

        private void btnSetNifudaConnString_Click(object sender, EventArgs e)
        {
            ConnectionStringContainer.ConnStrNifuda = edtNifudaConnString.Text;
        }
        
        private void btnSetISUPConnStr_Click(object sender, EventArgs e)
        {
            ConnectionStringContainer.ConnStrISUP = edtISUPConnString.Text;
        }

        private void btnCheckConnNifuda_Click(object sender, EventArgs e)
        {
            NifudaDataTableAdapter nifudaDataTableAdapter = new NifudaDataTableAdapter();
            nifudaDataTableAdapter.Connection.ConnectionString = edtNifudaConnString.Text;

            try
            {
                nifudaDataTableAdapter.Connection.Open();
                MessageBox.Show("Подключение к " + nifudaDataTableAdapter.Connection.ConnectionString + " выполнено успешно");
            }
            catch (Exception s)
            {
                MessageBox.Show("Соединение с" + nifudaDataTableAdapter.Connection.ConnectionString + ' ' + "отсутствует" + '\n' + "Причина: " + s.Message.ToString());
            }
                        
        }

        private void btnCheckConnISUP_Click(object sender, EventArgs e)
        {
            ISUPNifudaDataTableAdapter iSUPNifudaDataTableAdapter = new ISUPNifudaDataTableAdapter();
            iSUPNifudaDataTableAdapter.Connection.ConnectionString = edtISUPConnString.Text;
            try
            {
                iSUPNifudaDataTableAdapter.Connection.Open();
                MessageBox.Show("Подключение к " + iSUPNifudaDataTableAdapter.Connection.ConnectionString + " выполнено успешно");
            }
            catch (Exception s)
            {

                MessageBox.Show("Соединение с" + iSUPNifudaDataTableAdapter.Connection.ConnectionString + ' ' + "отсутствует" + '\n' + "Причина: " + s.Message.ToString());
            }
        }
    }
}

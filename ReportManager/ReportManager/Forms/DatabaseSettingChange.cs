using ReportManager.Database;
using ReportManager.Database.ISUPDataTableAdapters;
using ReportManager.Database.NifudaDataSetTableAdapters;
using ReportManager;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ReportManager.Forms
{
    public partial class DatabaseSettingChange : Form
    {
        private bool _isChanged;

        public DatabaseSettingChange()
        {
            InitializeComponent();
            edtISUPConnString.Text = ConnectionStringContainer.GetInstance().IsupConnectionString;
            edtNifudaConnString.Text = ConnectionStringContainer.GetInstance().NifudaConnectionString;
            btnSetNifudaConnString.Enabled = false;
            btnSetISUPConnStr.Enabled = false;
        }

        private void btnSetNifudaConnString_Click(object sender, EventArgs e)
        {
            ConnectionStringContainer.GetInstance().NifudaConnectionString = edtNifudaConnString.Text;
            try
            {
                ConnectionStringContainer.SaveSettings();
                _isChanged = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Невозможно сохранить настройки: {ex}");
            }
        }
                
        private void btnSetISUPConnStr_Click(object sender, EventArgs e)
        {
            ConnectionStringContainer.GetInstance().IsupConnectionString = edtISUPConnString.Text;
            try
            {
                ConnectionStringContainer.SaveSettings();
                _isChanged = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Невозможно сохранить настройки: {ex}");
            }
        }

        private void btnCheckConnNifuda_Click(object sender, EventArgs e)
        {
            var nifudaDataTableAdapter = new NifudaDataTableAdapter
            {
                Connection = { ConnectionString = edtNifudaConnString.Text }
            };

            try
            {
                nifudaDataTableAdapter.Connection.Open();
                btnSetNifudaConnString.Enabled = true;
                MessageBox.Show($"Подключение к {nifudaDataTableAdapter.Connection.ConnectionString} выполнено успешно");
            }
            catch (Exception s)
            {
                MessageBox.Show($"Соединение с {nifudaDataTableAdapter.Connection.ConnectionString} отсутствует\nПричина: {s.Message}");
                btnSetNifudaConnString.Enabled = false;
            }
                        
        }

        private void btnCheckConnISUP_Click(object sender, EventArgs e)
        {
            var iSupNifudaDataTableAdapter = new ISUPNifudaDataTableAdapter
            {
                Connection = { ConnectionString = edtISUPConnString.Text }
            };

            try
            {
                iSupNifudaDataTableAdapter.Connection.Open();
                btnSetISUPConnStr.Enabled = true;
                MessageBox.Show($"Подключение к {iSupNifudaDataTableAdapter.Connection.ConnectionString} выполнено успешно");
            }
            catch (Exception s)
            {
                MessageBox.Show($"Соединение с {iSupNifudaDataTableAdapter.Connection.ConnectionString} отсутствует\nПричина: {s.Message}");
                btnSetISUPConnStr.Enabled = false;
            }
        }

        private void DatabaseSettingChange_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = _isChanged ? DialogResult.OK : DialogResult.Ignore;
        }
    }
}

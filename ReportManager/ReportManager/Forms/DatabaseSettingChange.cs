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
        public DatabaseSettingChange()
        {
            InitializeComponent();
            edtISUPConnString.Text = ConnectionStringContainer.GetInstance().ConnStrISUP;
            edtNifudaConnString.Text = ConnectionStringContainer.GetInstance().ConnStrNifuda;
            btnSetNifudaConnString.Enabled = false;
            btnSetISUPConnStr.Enabled = false;

        }
        private static string _settingsPath =
            $@"{Environment.GetEnvironmentVariable("AllUsersProfile")}\ReportManagerSettings\Settings.xml";

        public bool CheckOkNifuda;
        public bool CheckOkISUP;


        public void SaveNifudaSettings()
        {
            try
            {
                var xs = new XmlSerializer(typeof(ConnectionStringContainer));
                using (Stream writer = new FileStream(_settingsPath, FileMode.Create))
                {
                    xs.Serialize(writer, ConnectionStringContainer.GetInstance());
                    writer.Close();
                }
            }

            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }

        }

        public void SaveISUPSettings()
        {
            try
            {
                var xs = new XmlSerializer(typeof(ConnectionStringContainer));
                using (Stream writer = new FileStream(_settingsPath, FileMode.Create))
                {
                    xs.Serialize(writer, ConnectionStringContainer.GetInstance());
                    writer.Close();
                }
            }
            catch (Exception s)
            {
                MessageBox.Show( s.Message );
            }

        }


        private void btnSetNifudaConnString_Click(object sender, EventArgs e)
        {
            ConnectionStringContainer.GetInstance().ConnStrNifuda = edtNifudaConnString.Text;
            SaveNifudaSettings();
        }
           
                
        private void btnSetISUPConnStr_Click(object sender, EventArgs e)
        {
            ConnectionStringContainer.GetInstance().ConnStrISUP = edtISUPConnString.Text;
            SaveISUPSettings();
        }

        private void btnCheckConnNifuda_Click(object sender, EventArgs e)
        {
            NifudaDataTableAdapter nifudaDataTableAdapter = new NifudaDataTableAdapter();
            nifudaDataTableAdapter.Connection.ConnectionString = edtNifudaConnString.Text;

            try
            {
                nifudaDataTableAdapter.Connection.Open();
                btnSetNifudaConnString.Enabled = true;
                MessageBox.Show("Подключение к " + nifudaDataTableAdapter.Connection.ConnectionString + " выполнено успешно");
            }
            catch (Exception s)
            {
                MessageBox.Show("Соединение с" + nifudaDataTableAdapter.Connection.ConnectionString + ' ' + "отсутствует" + '\n' + "Причина: " + s.Message.ToString());
                btnSetNifudaConnString.Enabled = false;
            }
                        
        }

        private void btnCheckConnISUP_Click(object sender, EventArgs e)
        {
            ISUPNifudaDataTableAdapter iSUPNifudaDataTableAdapter = new ISUPNifudaDataTableAdapter();
            iSUPNifudaDataTableAdapter.Connection.ConnectionString = edtISUPConnString.Text;
            try
            {
                iSUPNifudaDataTableAdapter.Connection.Open();
                btnSetISUPConnStr.Enabled = true;
                MessageBox.Show("Подключение к " + iSUPNifudaDataTableAdapter.Connection.ConnectionString + " выполнено успешно");
                

            }
            catch (Exception s)
            {

                MessageBox.Show("Соединение с" + iSUPNifudaDataTableAdapter.Connection.ConnectionString + ' ' + "отсутствует" + '\n' + "Причина: " + s.Message.ToString());
                btnSetISUPConnStr.Enabled = false;
            }
        }
    }
}

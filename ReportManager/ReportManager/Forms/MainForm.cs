using System;
using System.Windows.Forms;

namespace ReportManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLoadDeviceModel_Click(object sender, EventArgs e)
        {
            var deviceModel = 
                DataModelCreator.GetDeviceBySerial(new DataModel.SerialNumber { Serial = edtSerial.Text });

            if (deviceModel != null)
            {
                ReportManagerContext.GetInstance().SetDeviceModel(deviceModel);
                (new ReportForm()).ShowDialog();
            }
            else
            {
                MessageBox.Show("Серийный номер не найден", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

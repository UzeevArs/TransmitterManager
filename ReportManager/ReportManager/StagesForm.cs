using ReportManager.Forms;
using System;
using System.Security.Permissions;
using System.Windows.Forms;

namespace ReportManager
{
    public partial class StagesForm : Form
    {
        public StagesForm()
        {
            InitializeComponent();
            var keyFilter = new KeyMessageFilter();
            keyFilter.EventKeyHandler += KeyFilter_EventKeyHandler;
            Application.AddMessageFilter(keyFilter);

            btnGenerateReports.Enabled = false;
        }

        private void KeyFilter_EventKeyHandler(object sender, Keys key, string serial)
        {
            edtSerial.EditValue = serial;
            if (edtSerial.EditValue != null && !edtSerial.EditValue.Equals(string.Empty))
            {
                btnGenerateReports.Enabled = true;
            }
            else
            {
                btnGenerateReports.Enabled = false;
            }
        }

        private void edtSerial_EditValueChanged(object sender, EventArgs e)
        {
            if (edtSerial.EditValue != null && !edtSerial.EditValue.Equals(string.Empty))
            {
                btnGenerateReports.Enabled = true;
            }
            else
            {
                btnGenerateReports.Enabled = false;
            }
        }

        private void btnGenerateReports_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var deviceModel =
                DataModelCreator.GetDeviceBySerial(new DataModel.SerialNumber { Serial = edtSerial.EditValue.ToString() });

            if (deviceModel != null)
            {
                ReportManagerContext.GetInstance().SetDeviceModel(deviceModel);
                (new ReportForm { MdiParent = this }).Show();
            }
            else
            {
                MessageBox.Show("Серийный номер не найден", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerateSerial_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            (new SerialNumberGenerateForm { MdiParent = this }).Show();
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public class KeyMessageFilter : IMessageFilter
        {
            public delegate void KeyHandler(object sender, Keys key, string keyChar);
            public event KeyHandler EventKeyHandler;

            private bool ctrlPressed = false;
            private bool shiftPressed = false;
            private bool twoPressed = false;

            private bool firstEnter = false;

            private string tempString = "";

            public bool PreFilterMessage(ref Message m)
            {
                if (m.Msg == 0x101)
                {
                    Keys keyData = (Keys)m.WParam;
                    Console.WriteLine($"Blocked messages: { new KeysConverter().ConvertToString(keyData) }");
                    switch (keyData)
                    {
                        case Keys.ControlKey:
                            if (ctrlPressed && shiftPressed && twoPressed) break;
                            ctrlPressed = true;
                            break;
                        case Keys.ShiftKey:
                            if (ctrlPressed && shiftPressed && twoPressed) break;
                            shiftPressed = ctrlPressed;
                            break;
                        case Keys.D2:
                            if (ctrlPressed && shiftPressed && twoPressed)
                            {
                                tempString += "2";
                                break;
                            }
                            twoPressed = ctrlPressed && shiftPressed;
                            break;
                        case Keys.Enter:
                            if (firstEnter)
                            {
                                GenerateEvent(keyData, tempString);
                                ctrlPressed = false;
                                shiftPressed = false;
                                twoPressed = false;
                                firstEnter = false;
                                tempString = "";
                                break;
                            }
                            else
                            {
                                firstEnter = true;
                                break;
                            }

                        default:
                            if (ctrlPressed && shiftPressed && twoPressed)
                            {
                                tempString += new KeysConverter().ConvertToString(keyData);
                            }
                            break;
                    }
                }
                return false;
            }

            private void GenerateEvent(Keys keyData, string generatedString)
            {
                EventKeyHandler?.Invoke(this, keyData, generatedString);
                // Console.WriteLine($"Blocked messages: {generatedString}");
            }
        }
    }
}

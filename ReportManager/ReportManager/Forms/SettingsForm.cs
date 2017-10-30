using ReportManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.UI;
using ReportManager.Core.Functional;
using ReportManager.Core.Stages;
using ReportManager.Data.Database.NifudaDataSetTableAdapters;
using ReportManager.Data.Settings;
using ReportManager.Reports;
using ReportManager.Data.Extensions;

namespace ReportManager.Forms
{
    public partial class SettingsForm : XtraForm
    {
        public SettingsForm()
        {
            InitializeComponent();
            SettingsContext.SettingsLoadingEvent += SettingsContextOnSettingsLoadingEvent;
            LoadSettings();
        }
       
        private void SettingsContextOnSettingsLoadingEvent(object sender, (ReportManager.Data.Settings.Settings, SettingsStatus, string) status)
        {
            if (status.Item2 == SettingsStatus.ErrorSaved)
            {
                if (MessageBox.Show($"Ошибка при сохранении настроек:\n{status.Item3}",
                        "Повторите попытку или отмените",
                        MessageBoxButtons.RetryCancel,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button2) == DialogResult.Retry)
                {
                    SettingsContext.SaveSettings();   
                }
            }
        }

        private void LoadSettings()
        {
            edtManufString.Text = SettingsContext.GlobalSettings.NifudaConnectionString;
            edtUpdateTimeout.Value = SettingsContext.GlobalSettings.UpdateTimeout;
            btnReportSavePath.Text = SettingsContext.GlobalSettings.ReportSavePath;
            signaturePict.LoadAsync(SettingsContext.SignaturePath);
        }

        private (SettingsStatus status, string message) SaveSettings()
        {
            SettingsContext.GlobalSettings.NifudaConnectionString = edtManufString.Text;
            SettingsContext.GlobalSettings.UpdateTimeout = (uint) edtUpdateTimeout.Value;
            SettingsContext.GlobalSettings.ReportSavePath = btnReportSavePath.Text;

            SettingsContext.NotifyChanged();
            return SettingsContext.SaveSettings();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (SaveSettings().Item1 == SettingsStatus.SuccessSaved)
                Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnTryConnectManif_Click(object sender, EventArgs e)
        {
            btnOk.Enabled = false;
            btnCancel.Enabled = false;
            grpMainSettings.Enabled = false;
            prgsDbConnect.Visible = true;

            new Thread(delegate ()
            {
                var nifudaDataTableAdapter = new NifudaDataTableAdapter
                {
                    Connection = { ConnectionString = edtManufString.Text }
                };

                try
                {
                    nifudaDataTableAdapter.Connection.Open();
                    SuccessConnection();
                }
                catch (Exception s)
                {
                    ErrorConnection(s.Message);
                }
            }).Start();
        }

        private void SuccessConnection()
        {
            this.SafeInvoke(() =>
            {
                btnOk.Enabled = true;
                btnCancel.Enabled = true;
                grpMainSettings.Enabled = true;
                prgsDbConnect.Visible = false;

                MessageBox.Show("Подключение к производственной БД выполнено успешно. ",
                                "Статус подключения",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.None);
            });
        }

        private void ErrorConnection(string error)
        {
            this.SafeInvoke(() => 
            {
                btnOk.Enabled = true;
                btnCancel.Enabled = true;
                grpMainSettings.Enabled = true;
                prgsDbConnect.Visible = false;

                MessageBox.Show($"Подключение к БД не выполнено\n{error}",
                      "Статус подключения",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
            });
        }

        private void BtnReportSavePath_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Ellipsis)
            {
                var dialog = new FolderBrowserDialog
                {
                    Description = "Выберите папку для сохранения отчетов",
                    ShowNewFolderButton = true,
                    RootFolder = Environment.SpecialFolder.MyComputer
                };

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    btnReportSavePath.Text = dialog.SelectedPath;
                }
            }
        }

        private void SettingsForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancel.PerformClick();
            } 
            else if (e.KeyCode == Keys.Enter)
            {
                btnOk.PerformClick();
            }
        }

        private void signaturePict_DoubleClick(object sender, EventArgs e)
        {
            signaturePict.LoadAsync(SettingsContext.SignaturePath);
        }

        private void btnReportSavePath_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}

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
using ReportManager.Data.Database.ISUPDataTableAdapters;
using ReportManager.Data.Database.NifudaDataSetTableAdapters;
using ReportManager.Data.Settings;
using ReportManager.Reports;

namespace ReportManager.Forms
{
    public partial class SettingsForm : XtraForm
    {
        public SettingsForm()
        {
            InitializeComponent();
            SettingsContext.SettingsLoadingEvent += SettingsContextOnSettingsLoadingEvent;
            FillStages();
            FillFunctionals();
            LoadSettings();
        }

        private void FillStages()
        {
            cbStageList.Items.Clear();
            var mscorlib = typeof(AbstractStage).Assembly;
            foreach (var type in mscorlib.GetTypes())
            {
                if (type.GetBaseType() == typeof(AbstractStage))
                {
                    cbStageList.Items.Add((AbstractStage)Activator.CreateInstance(type));
                }
            }
        }

        private void FillFunctionals()
        {
            cbFunctionsList.Items.Clear();
            var mscorlib = typeof(AbstractFunctional).Assembly;
            foreach (var type in mscorlib.GetTypes())
            {
                if (type.GetBaseType() == typeof(AbstractFunctional))
                {
                    cbFunctionsList.Items.Add((AbstractFunctional)Activator.CreateInstance(type));
                }
            }
        }

        private void SettingsContextOnSettingsLoadingEvent(object sender, Tuple<Settings, SettingsStatus, string> status)
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
            edtIsupString.Text = SettingsContext.GlobalSettings.IsupConnectionString;
            edtManufString.Text = SettingsContext.GlobalSettings.NifudaConnectionString;
            edtUpdateTimeout.Value = SettingsContext.GlobalSettings.UpdateTimeout;
            btnReportSavePath.Text = SettingsContext.GlobalSettings.ReportSavePath;
            if (SettingsContext.GlobalSettings.Stages == null)
            {
                SettingsContext.GlobalSettings.Stages = new List<AbstractStage>();
            }
            else
            {
                foreach (var stage in SettingsContext.GlobalSettings.Stages)
                    cbStageList.Items.First(item => item.ToString().Equals(stage.Name)).CheckState = CheckState.Checked;
            }

            if (SettingsContext.GlobalSettings.Functionals == null)
            {
                SettingsContext.GlobalSettings.Functionals = new List<AbstractFunctional>();
            }
            else
            {
                foreach (var functional in SettingsContext.GlobalSettings.Functionals)
                    cbFunctionsList.Items.First(item => item.ToString().Equals(functional.Name)).CheckState = CheckState.Checked;
            }
        }

        private Tuple<SettingsStatus, string> SaveSettings()
        {
            SettingsContext.GlobalSettings.IsupConnectionString = edtIsupString.Text;
            SettingsContext.GlobalSettings.NifudaConnectionString = edtManufString.Text;
            SettingsContext.GlobalSettings.UpdateTimeout = (uint) edtUpdateTimeout.Value;
            SettingsContext.GlobalSettings.ReportSavePath = btnReportSavePath.Text;

            SettingsContext.GlobalSettings.Stages.Clear();
            SettingsContext.GlobalSettings.Functionals.Clear();

            foreach (var stage in cbStageList.Items.GetCheckedValues())
                SettingsContext.GlobalSettings.Stages.Add(stage as AbstractStage);

            foreach (var functional in cbFunctionsList.Items.GetCheckedValues())
                SettingsContext.GlobalSettings.Functionals.Add(functional as AbstractFunctional);

            SettingsContext.NotifyChanged();
            return SettingsContext.SaveSettings();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (SaveSettings().Item1 == SettingsStatus.SuccessSaved)
                Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTryConnectIsup_Click(object sender, EventArgs e)
        {
            btnOk.Enabled = false;
            btnCancel.Enabled = false;
            grpMainSettings.Enabled = false;
            grpStages.Enabled = false;
            grpFunctions.Enabled = false;
            prgsDbConnect.Visible = true;

            new Thread(delegate()
            {
                var iSupNifudaDataTableAdapter = new ISUPNifudaDataTableAdapter
                {
                    Connection = { ConnectionString = edtIsupString.Text }
                };

                try
                {
                    iSupNifudaDataTableAdapter.Connection.Open();
                    SuccessConnection();
                }
                catch (Exception s)
                {
                    ErrorConnection(s.Message);
                }
            }).Start();
        }

        private void btnTryConnectManif_Click(object sender, EventArgs e)
        {
            btnOk.Enabled = false;
            btnCancel.Enabled = false;
            grpMainSettings.Enabled = false;
            grpStages.Enabled = false;
            grpFunctions.Enabled = false;
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
            Invoke((MethodInvoker) delegate
            {
                btnOk.Enabled = true;
                btnCancel.Enabled = true;
                grpMainSettings.Enabled = true;
                grpStages.Enabled = true;
                grpFunctions.Enabled = true;
                prgsDbConnect.Visible = false;

                MessageBox.Show("Подключение к производственной БД выполнено успешно. ",
                                "Статус подключения",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.None);
            });
        }

        private void ErrorConnection(string error)
        {
            Invoke((MethodInvoker)delegate
            {
                btnOk.Enabled = true;
                btnCancel.Enabled = true;
                grpMainSettings.Enabled = true;
                grpFunctions.Enabled = true;
                grpStages.Enabled = true;
                prgsDbConnect.Visible = false;

                MessageBox.Show($"Подключение к БД не выполнено\n{error}",
                      "Статус подключения",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
            });
        }

        private void btnReportSavePath_ButtonClick(object sender, ButtonPressedEventArgs e)
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
    }
}

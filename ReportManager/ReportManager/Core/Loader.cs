using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReportManager.Data.Settings;
using ReportManager.Forms;

namespace ReportManager.Core
{
    internal class Loader : Form
    {
        public Loader()
        {
            Width = 0;
            Height = 0;
            Shown += OnShown;
        }

        private void OnShown(object sender, EventArgs eventArgs)
        {
            Visible = false;

            if (OpenLoginForm())
                OpenStagesForm();
            else
                Close();
        }

        private void OpenStagesForm()
        {
            new StagesForm().Show();
        }

        private bool OpenLoginForm()
        {
            return new LoginForm().ShowDialog() == DialogResult.OK;
        }
    }
}

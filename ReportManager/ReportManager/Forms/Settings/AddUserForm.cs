using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using ReportManager.Core.Functional;
using ReportManager.Core.Stages;

namespace ReportManager.Forms.Settings
{
    public partial class AddUserForm : XtraForm
    {
        public AddUserForm()
        {
            InitializeComponent();
            FillStages();
            FillFunctionals();
        }

        private void FillStages()
        {
            cbStageList.Items.Clear();
            var mscorlib = typeof(Stage).Assembly;
            foreach (var type in mscorlib.GetTypes())
            {
                if (type.GetBaseType() == typeof(Stage))
                {
                    cbStageList.Items.Add((Stage)Activator.CreateInstance(type));
                }
            }
        }

        private void FillFunctionals()
        {
            cbFunctionsList.Items.Clear();
            var mscorlib = typeof(Functional).Assembly;
            foreach (var type in mscorlib.GetTypes())
            {
                if (type.GetBaseType() == typeof(Functional))
                {
                    cbFunctionsList.Items.Add((Functional)Activator.CreateInstance(type));
                }
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {

        }
    }
}
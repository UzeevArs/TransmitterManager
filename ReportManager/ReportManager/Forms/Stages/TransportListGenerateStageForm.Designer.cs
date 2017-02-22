using ReportManager.Data.SAP;

namespace ReportManager.Forms.Stages
{
    partial class TransportListGenerateStageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.nifudaDataSet1 = new ReportManager.Data.SAP.NifudaDataSet();
            this.nifudaDataTableAdapter1 = new ReportManager.Data.SAP.NifudaDataSetTableAdapters.NifudaDataTableAdapter();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.snapDockManager1 = new DevExpress.Snap.Extensions.SnapDockManager(this.components);
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.grpStages = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.nifudaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.snapDockManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpStages)).BeginInit();
            this.SuspendLayout();
            // 
            // nifudaDataSet1
            // 
            this.nifudaDataSet1.DataSetName = "NifudaDataSet";
            this.nifudaDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nifudaDataTableAdapter1
            // 
            this.nifudaDataTableAdapter1.ClearBeforeFill = true;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(27, 72);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(258, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Количество сгенерированных маршрутных листов";
            this.labelControl1.Visible = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(27, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(269, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Количество сохраненных сертификатов калибровки";
            this.labelControl2.Visible = false;
            // 
            // snapDockManager1
            // 
            this.snapDockManager1.Form = this;
            this.snapDockManager1.SnapControl = null;
            this.snapDockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl"});
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(27, 39);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(248, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Открытие списка калибровочных сертификатов";
            this.labelControl5.Visible = false;
            // 
            // grpStages
            // 
            this.grpStages.Location = new System.Drawing.Point(27, 101);
            this.grpStages.Name = "grpStages";
            this.grpStages.Size = new System.Drawing.Size(382, 236);
            this.grpStages.TabIndex = 1000;
            this.grpStages.Text = "Информация о последнем маршрутном листе";
            this.grpStages.Visible = false;
            // 
            // TransportListGenerateStageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 351);
            this.Controls.Add(this.grpStages);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransportListGenerateStageForm";
            this.Text = "Генерация серийного номера";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TransportListGenerateStageForm_FormClosed);
            this.Shown += new System.EventHandler(this.TransportListGenerateStageForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.nifudaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.snapDockManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpStages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private NifudaDataSet nifudaDataSet1;
        private ReportManager.Data.SAP.NifudaDataSetTableAdapters.NifudaDataTableAdapter nifudaDataTableAdapter1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.Snap.Extensions.SnapDockManager snapDockManager1;
        private DevExpress.XtraEditors.GroupControl grpStages;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}
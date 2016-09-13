namespace ReportManager
{
    partial class StagesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StagesForm));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnGenerateSerial = new DevExpress.XtraBars.BarButtonItem();
            this.btnGenerateReports = new DevExpress.XtraBars.BarButtonItem();
            this.edtSerial = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.pgSerial = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pgStages = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.nifudaDataTableAdapter = new ReportManager.NifudaDataSetTableAdapters.NifudaDataTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnGenerateSerial,
            this.btnGenerateReports,
            this.edtSerial});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 5;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.ribbonControl1.Size = new System.Drawing.Size(1012, 141);
            // 
            // btnGenerateSerial
            // 
            this.btnGenerateSerial.Caption = "Генерация маршрутного листа";
            this.btnGenerateSerial.Glyph = ((System.Drawing.Image)(resources.GetObject("btnGenerateSerial.Glyph")));
            this.btnGenerateSerial.Id = 2;
            this.btnGenerateSerial.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnGenerateSerial.LargeGlyph")));
            this.btnGenerateSerial.Name = "btnGenerateSerial";
            this.btnGenerateSerial.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnGenerateSerial.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGenerateSerial_ItemClick);
            // 
            // btnGenerateReports
            // 
            this.btnGenerateReports.Caption = "Генерация отчётов";
            this.btnGenerateReports.Glyph = ((System.Drawing.Image)(resources.GetObject("btnGenerateReports.Glyph")));
            this.btnGenerateReports.Id = 3;
            this.btnGenerateReports.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnGenerateReports.LargeGlyph")));
            this.btnGenerateReports.Name = "btnGenerateReports";
            this.btnGenerateReports.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnGenerateReports.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGenerateReports_ItemClick);
            // 
            // edtSerial
            // 
            this.edtSerial.Caption = "Серийный номер:  ";
            this.edtSerial.Edit = this.repositoryItemTextEdit1;
            this.edtSerial.EditValue = "";
            this.edtSerial.EditWidth = 150;
            this.edtSerial.Id = 4;
            this.edtSerial.Name = "edtSerial";
            this.edtSerial.EditValueChanged += new System.EventHandler(this.edtSerial_EditValueChanged);
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.pgSerial,
            this.pgStages});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Сборка";
            // 
            // pgSerial
            // 
            this.pgSerial.ItemLinks.Add(this.edtSerial);
            this.pgSerial.Name = "pgSerial";
            this.pgSerial.Text = "Серийный номер";
            // 
            // pgStages
            // 
            this.pgStages.ItemLinks.Add(this.btnGenerateSerial);
            this.pgStages.ItemLinks.Add(this.btnGenerateReports);
            this.pgStages.Name = "pgStages";
            this.pgStages.Text = "Стадии сборки";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            // 
            // dataTable1TableAdapter1
            // 
            this.nifudaDataTableAdapter.ClearBeforeFill = true;
            // 
            // StagesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 803);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "StagesForm";
            this.Text = "StagesForm";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pgSerial;
        private DevExpress.XtraBars.BarButtonItem btnGenerateSerial;
        private DevExpress.XtraBars.BarButtonItem btnGenerateReports;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarEditItem edtSerial;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pgStages;
        private System.Windows.Forms.Timer timer1;
        private NifudaDataSetTableAdapters.NifudaDataTableAdapter nifudaDataTableAdapter;
    }
}
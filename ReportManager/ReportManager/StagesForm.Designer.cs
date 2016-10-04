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
            this.btnLoadData = new DevExpress.XtraBars.BarButtonItem();
            this.btnChangeConnectionString = new DevExpress.XtraBars.BarButtonItem();
            this.btnToSetManual = new DevExpress.XtraBars.BarButtonItem();
            this.lblNifudaConnectionStatus = new DevExpress.XtraBars.BarStaticItem();
            this.lblIsupConnectionStatus = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.pgSerial = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pgStages = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.nifudaDataTableAdapter = new ReportManager.Database.NifudaDataSetTableAdapters.NifudaDataTableAdapter();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
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
            this.edtSerial,
            this.btnLoadData,
            this.btnChangeConnectionString,
            this.btnToSetManual,
            this.lblNifudaConnectionStatus,
            this.lblIsupConnectionStatus,
            this.barStaticItem1,
            this.lblStatus});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 13;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.ribbonControl1.Size = new System.Drawing.Size(1012, 141);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // btnGenerateSerial
            // 
            this.btnGenerateSerial.Caption = "Формирование маршрутного листа";
            this.btnGenerateSerial.Glyph = ((System.Drawing.Image)(resources.GetObject("btnGenerateSerial.Glyph")));
            this.btnGenerateSerial.Id = 2;
            this.btnGenerateSerial.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnGenerateSerial.LargeGlyph")));
            this.btnGenerateSerial.Name = "btnGenerateSerial";
            this.btnGenerateSerial.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnGenerateSerial.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGenerateTransportList_ItemClick);
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
            this.edtSerial.Caption = "Производственный номер:  ";
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
            // btnLoadData
            // 
            this.btnLoadData.Caption = "Обновление данных";
            this.btnLoadData.Glyph = ((System.Drawing.Image)(resources.GetObject("btnLoadData.Glyph")));
            this.btnLoadData.Id = 5;
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnChangeConnectionString
            // 
            this.btnChangeConnectionString.Caption = "Настройка подключений к БД";
            this.btnChangeConnectionString.Glyph = ((System.Drawing.Image)(resources.GetObject("btnChangeConnectionString.Glyph")));
            this.btnChangeConnectionString.Id = 6;
            this.btnChangeConnectionString.Name = "btnChangeConnectionString";
            this.btnChangeConnectionString.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnChangeConnectionString.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChangeConnectionString_ItemClick);
            // 
            // btnToSetManual
            // 
            this.btnToSetManual.Caption = "Ввод вручную";
            this.btnToSetManual.Id = 7;
            this.btnToSetManual.Name = "btnToSetManual";
            this.btnToSetManual.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnToSetManual_ItemClick);
            // 
            // lblNifudaConnectionStatus
            // 
            this.lblNifudaConnectionStatus.Id = 8;
            this.lblNifudaConnectionStatus.Name = "lblNifudaConnectionStatus";
            this.lblNifudaConnectionStatus.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblIsupConnectionStatus
            // 
            this.lblIsupConnectionStatus.Id = 10;
            this.lblIsupConnectionStatus.Name = "lblIsupConnectionStatus";
            this.lblIsupConnectionStatus.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "     ";
            this.barStaticItem1.Id = 11;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.pgSerial,
            this.pgStages,
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Сборка";
            // 
            // pgSerial
            // 
            this.pgSerial.ItemLinks.Add(this.edtSerial);
            this.pgSerial.ItemLinks.Add(this.btnToSetManual);
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
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLoadData);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnChangeConnectionString);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Базы данных";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.lblNifudaConnectionStatus);
            this.ribbonStatusBar1.ItemLinks.Add(this.barStaticItem1);
            this.ribbonStatusBar1.ItemLinks.Add(this.lblIsupConnectionStatus);
            this.ribbonStatusBar1.ItemLinks.Add(this.lblStatus);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 776);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1012, 27);
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            // 
            // nifudaDataTableAdapter
            // 
            this.nifudaDataTableAdapter.ClearBeforeFill = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 141);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1012, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Id = 12;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // StagesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 803);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "StagesForm";
            this.Text = "StagesForm";
            this.Load += new System.EventHandler(this.StagesForm_Load);
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
        public DevExpress.XtraBars.BarButtonItem btnGenerateSerial;
        public DevExpress.XtraBars.BarButtonItem btnGenerateReports;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        public DevExpress.XtraBars.BarEditItem edtSerial;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pgStages;
        private System.Windows.Forms.Timer timer1;
        private Database.NifudaDataSetTableAdapters.NifudaDataTableAdapter nifudaDataTableAdapter;
        private DevExpress.XtraBars.BarButtonItem btnLoadData;
        private DevExpress.XtraBars.BarButtonItem btnChangeConnectionString;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnToSetManual;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private DevExpress.XtraBars.BarStaticItem lblNifudaConnectionStatus;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarStaticItem lblIsupConnectionStatus;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem lblStatus;
    }
}
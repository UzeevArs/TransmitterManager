namespace ReportManager.Forms
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
            this.btnTrasportListCreateStage = new DevExpress.XtraBars.BarButtonItem();
            this.btnReportCreateStage = new DevExpress.XtraBars.BarButtonItem();
            this.edtMsCode = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.btnMaxigrafStage = new DevExpress.XtraBars.BarButtonItem();
            this.btnChangeConnectionString = new DevExpress.XtraBars.BarButtonItem();
            this.btnToSetManual = new DevExpress.XtraBars.BarButtonItem();
            this.lblNifudaConnectionStatus = new DevExpress.XtraBars.BarStaticItem();
            this.lblIsupConnectionStatus = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.btnAllData = new DevExpress.XtraBars.BarButtonItem();
            this.lblExtraInformation = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.pgSerial = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pgStages = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.barButtonItem1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.lblUserName = new DevExpress.XtraBars.BarStaticItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnTrasportListCreateStage,
            this.btnReportCreateStage,
            this.edtMsCode,
            this.btnMaxigrafStage,
            this.btnChangeConnectionString,
            this.btnToSetManual,
            this.lblNifudaConnectionStatus,
            this.lblIsupConnectionStatus,
            this.barStaticItem1,
            this.lblStatus,
            this.btnExit,
            this.btnAllData,
            this.lblExtraInformation,
            this.lblUserName});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 18;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2});
            this.ribbonControl1.QuickToolbarItemLinks.Add(this.btnChangeConnectionString);
            this.ribbonControl1.QuickToolbarItemLinks.Add(this.btnExit);
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemTextEdit3});
            this.ribbonControl1.Size = new System.Drawing.Size(1012, 140);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // btnTrasportListCreateStage
            // 
            this.btnTrasportListCreateStage.Caption = "Формирование маршрутного листа";
            this.btnTrasportListCreateStage.Enabled = false;
            this.btnTrasportListCreateStage.Glyph = ((System.Drawing.Image)(resources.GetObject("btnTrasportListCreateStage.Glyph")));
            this.btnTrasportListCreateStage.Id = 2;
            this.btnTrasportListCreateStage.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnTrasportListCreateStage.LargeGlyph")));
            this.btnTrasportListCreateStage.Name = "btnTrasportListCreateStage";
            this.btnTrasportListCreateStage.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnTrasportListCreateStage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTrasportListCreateStage_ItemClick);
            // 
            // btnReportCreateStage
            // 
            this.btnReportCreateStage.Caption = "Генерация отчётов";
            this.btnReportCreateStage.Enabled = false;
            this.btnReportCreateStage.Glyph = ((System.Drawing.Image)(resources.GetObject("btnReportCreateStage.Glyph")));
            this.btnReportCreateStage.Id = 3;
            this.btnReportCreateStage.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnReportCreateStage.LargeGlyph")));
            this.btnReportCreateStage.Name = "btnReportCreateStage";
            this.btnReportCreateStage.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnReportCreateStage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReportCreateStage_ItemClick);
            // 
            // edtMsCode
            // 
            this.edtMsCode.CanOpenEdit = false;
            this.edtMsCode.Caption = "Производственный номер:  ";
            this.edtMsCode.Edit = this.repositoryItemTextEdit1;
            this.edtMsCode.EditValue = "";
            this.edtMsCode.EditWidth = 250;
            this.edtMsCode.Id = 4;
            this.edtMsCode.Name = "edtMsCode";
            this.edtMsCode.EditValueChanged += new System.EventHandler(this.edtSerial_EditValueChanged);
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AllowFocused = false;
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // btnMaxigrafStage
            // 
            this.btnMaxigrafStage.Caption = "Гравировка";
            this.btnMaxigrafStage.Enabled = false;
            this.btnMaxigrafStage.Glyph = ((System.Drawing.Image)(resources.GetObject("btnMaxigrafStage.Glyph")));
            this.btnMaxigrafStage.Id = 5;
            this.btnMaxigrafStage.Name = "btnMaxigrafStage";
            this.btnMaxigrafStage.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnMaxigrafStage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLoadData_ItemClick);
            // 
            // btnChangeConnectionString
            // 
            this.btnChangeConnectionString.Caption = "Настройки";
            this.btnChangeConnectionString.Glyph = ((System.Drawing.Image)(resources.GetObject("btnChangeConnectionString.Glyph")));
            this.btnChangeConnectionString.Id = 6;
            this.btnChangeConnectionString.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnChangeConnectionString.LargeGlyph")));
            this.btnChangeConnectionString.Name = "btnChangeConnectionString";
            this.btnChangeConnectionString.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnChangeConnectionString.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpenSettings_ItemClick);
            // 
            // btnToSetManual
            // 
            this.btnToSetManual.Caption = "Ввод производственного номера вручную";
            this.btnToSetManual.Glyph = ((System.Drawing.Image)(resources.GetObject("btnToSetManual.Glyph")));
            this.btnToSetManual.Id = 7;
            this.btnToSetManual.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnToSetManual.LargeGlyph")));
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
            // lblStatus
            // 
            this.lblStatus.Id = 12;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnExit
            // 
            this.btnExit.Caption = "Выход";
            this.btnExit.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExit.Glyph")));
            this.btnExit.Id = 13;
            this.btnExit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExit.LargeGlyph")));
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // btnAllData
            // 
            this.btnAllData.Caption = "таблица";
            this.btnAllData.Id = 14;
            this.btnAllData.Name = "btnAllData";
            this.btnAllData.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAllData_ItemClick);
            // 
            // lblExtraInformation
            // 
            this.lblExtraInformation.CanOpenEdit = false;
            this.lblExtraInformation.Edit = this.repositoryItemTextEdit2;
            this.lblExtraInformation.EditWidth = 393;
            this.lblExtraInformation.Id = 15;
            this.lblExtraInformation.Name = "lblExtraInformation";
            this.lblExtraInformation.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
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
            this.pgSerial.ItemLinks.Add(this.edtMsCode);
            this.pgSerial.ItemLinks.Add(this.lblExtraInformation);
            this.pgSerial.ItemLinks.Add(this.btnToSetManual);
            this.pgSerial.Name = "pgSerial";
            this.pgSerial.Text = "Серийный номер";
            // 
            // pgStages
            // 
            this.pgStages.ItemLinks.Add(this.btnTrasportListCreateStage);
            this.pgStages.ItemLinks.Add(this.btnReportCreateStage);
            this.pgStages.ItemLinks.Add(this.btnMaxigrafStage);
            this.pgStages.Name = "pgStages";
            this.pgStages.Text = "Стадии";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.barButtonItem1});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Данные";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.ItemLinks.Add(this.btnAllData);
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.Text = "Производственная БД";
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.lblNifudaConnectionStatus);
            this.ribbonStatusBar1.ItemLinks.Add(this.lblIsupConnectionStatus);
            this.ribbonStatusBar1.ItemLinks.Add(this.lblStatus);
            this.ribbonStatusBar1.ItemLinks.Add(this.lblUserName);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 775);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1012, 28);
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Менеджер отчетов";
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            // 
            // lblUserName
            // 
            this.lblUserName.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblUserName.Caption = "Имя пользователя: ";
            this.lblUserName.Id = 17;
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // StagesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 803);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MinimizeBox = false;
            this.Name = "StagesForm";
            this.Text = "Менеджер отчётов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StagesForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pgSerial;
        public DevExpress.XtraBars.BarButtonItem btnTrasportListCreateStage;
        public DevExpress.XtraBars.BarButtonItem btnReportCreateStage;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        public DevExpress.XtraBars.BarEditItem edtMsCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pgStages;
        private DevExpress.XtraBars.BarButtonItem btnMaxigrafStage;
        private DevExpress.XtraBars.BarButtonItem btnChangeConnectionString;
        private DevExpress.XtraBars.BarButtonItem btnToSetManual;
        private DevExpress.XtraBars.BarStaticItem lblNifudaConnectionStatus;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarStaticItem lblIsupConnectionStatus;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem lblStatus;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.BarButtonItem btnExit;
        private DevExpress.XtraBars.BarButtonItem btnAllData;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup barButtonItem1;
        private DevExpress.XtraBars.BarEditItem lblExtraInformation;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraBars.BarStaticItem lblUserName;
    }
}
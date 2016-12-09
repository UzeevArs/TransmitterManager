namespace ReportManager.Forms.Stages.MaxigraphStageForm
{
    partial class PlatesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlatesForm));
            this.grdPlates = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.mainMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnAddSetting = new DevExpress.XtraBars.BarButtonItem();
            this.btnChangeSetting = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeleteSetting = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPlates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdPlates
            // 
            this.grdPlates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPlates.Location = new System.Drawing.Point(0, 0);
            this.grdPlates.MainView = this.gridView1;
            this.grdPlates.Name = "grdPlates";
            this.grdPlates.Size = new System.Drawing.Size(867, 520);
            this.grdPlates.TabIndex = 0;
            this.grdPlates.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grdPlates.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GrdPlates_MouseClick);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdPlates;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // mainMenu
            // 
            this.mainMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAddSetting),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnChangeSetting),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDeleteSetting)});
            this.mainMenu.Manager = this.barManager1;
            this.mainMenu.Name = "mainMenu";
            // 
            // btnAddSetting
            // 
            this.btnAddSetting.Caption = "Добавить табличку";
            this.btnAddSetting.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAddSetting.Glyph")));
            this.btnAddSetting.Id = 0;
            this.btnAddSetting.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAddSetting.LargeGlyph")));
            this.btnAddSetting.Name = "btnAddSetting";
            // 
            // btnChangeSetting
            // 
            this.btnChangeSetting.Caption = "Изменить табличку";
            this.btnChangeSetting.Glyph = ((System.Drawing.Image)(resources.GetObject("btnChangeSetting.Glyph")));
            this.btnChangeSetting.Id = 2;
            this.btnChangeSetting.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnChangeSetting.LargeGlyph")));
            this.btnChangeSetting.Name = "btnChangeSetting";
            // 
            // btnDeleteSetting
            // 
            this.btnDeleteSetting.Caption = "Удалить табличку";
            this.btnDeleteSetting.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDeleteSetting.Glyph")));
            this.btnDeleteSetting.Id = 1;
            this.btnDeleteSetting.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnDeleteSetting.LargeGlyph")));
            this.btnDeleteSetting.Name = "btnDeleteSetting";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAddSetting,
            this.btnDeleteSetting,
            this.btnChangeSetting,
            this.barEditItem1});
            this.barManager1.MaxItemId = 4;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(867, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 520);
            this.barDockControlBottom.Size = new System.Drawing.Size(867, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 520);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(867, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 520);
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = this.repositoryItemTextEdit1;
            this.barEditItem1.Id = 3;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // PlatesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 520);
            this.Controls.Add(this.grdPlates);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "PlatesForm";
            this.Text = "Настройка табличек";
            ((System.ComponentModel.ISupportInitialize)(this.grdPlates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdPlates;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.PopupMenu mainMenu;
        private DevExpress.XtraBars.BarButtonItem btnAddSetting;
        private DevExpress.XtraBars.BarButtonItem btnChangeSetting;
        private DevExpress.XtraBars.BarButtonItem btnDeleteSetting;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
    }
}
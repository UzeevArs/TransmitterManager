namespace ReportManager.Forms.Stages.MaxigraphStageForm
{
    partial class PlatesSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlatesSettingsForm));
            this.grdPlatesSettings = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.mainMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnAddPlate = new DevExpress.XtraBars.BarButtonItem();
            this.btnChangePlate = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeletePlate = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdPlatesSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdPlatesSettings
            // 
            this.grdPlatesSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPlatesSettings.Location = new System.Drawing.Point(0, 0);
            this.grdPlatesSettings.MainView = this.gridView1;
            this.grdPlatesSettings.Name = "grdPlatesSettings";
            this.grdPlatesSettings.Size = new System.Drawing.Size(810, 540);
            this.grdPlatesSettings.TabIndex = 0;
            this.grdPlatesSettings.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grdPlatesSettings.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GrdPlatesSettings_MouseClick);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdPlatesSettings;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // mainMenu
            // 
            this.mainMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAddPlate),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnChangePlate),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDeletePlate)});
            this.mainMenu.Manager = this.barManager1;
            this.mainMenu.Name = "mainMenu";
            // 
            // btnAddPlate
            // 
            this.btnAddPlate.Caption = "Добавить параметр";
            this.btnAddPlate.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAddPlate.Glyph")));
            this.btnAddPlate.Id = 0;
            this.btnAddPlate.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAddPlate.LargeGlyph")));
            this.btnAddPlate.Name = "btnAddPlate";
            // 
            // btnChangePlate
            // 
            this.btnChangePlate.Caption = "Изменить параметр";
            this.btnChangePlate.Glyph = ((System.Drawing.Image)(resources.GetObject("btnChangePlate.Glyph")));
            this.btnChangePlate.Id = 1;
            this.btnChangePlate.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnChangePlate.LargeGlyph")));
            this.btnChangePlate.Name = "btnChangePlate";
            // 
            // btnDeletePlate
            // 
            this.btnDeletePlate.Caption = "Удалить параметр";
            this.btnDeletePlate.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDeletePlate.Glyph")));
            this.btnDeletePlate.Id = 2;
            this.btnDeletePlate.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnDeletePlate.LargeGlyph")));
            this.btnDeletePlate.Name = "btnDeletePlate";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAddPlate,
            this.btnChangePlate,
            this.btnDeletePlate});
            this.barManager1.MaxItemId = 3;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(810, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 540);
            this.barDockControlBottom.Size = new System.Drawing.Size(810, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 540);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(810, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 540);
            // 
            // PlatesSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 540);
            this.Controls.Add(this.grdPlatesSettings);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "PlatesSettingsForm";
            this.Text = "Настройка параметров таблички";
            ((System.ComponentModel.ISupportInitialize)(this.grdPlatesSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdPlatesSettings;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.PopupMenu mainMenu;
        private DevExpress.XtraBars.BarButtonItem btnAddPlate;
        private DevExpress.XtraBars.BarButtonItem btnChangePlate;
        private DevExpress.XtraBars.BarButtonItem btnDeletePlate;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}
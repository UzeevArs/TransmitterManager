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
            this.colPlateId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRegex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProcedureName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mainMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnAddPlate = new DevExpress.XtraBars.BarButtonItem();
            this.btnChangePlate = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeletePlate = new DevExpress.XtraBars.BarButtonItem();
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
            this.grdPlates.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.GrdPlates_MouseDoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPlateId,
            this.colName,
            this.colDescription,
            this.colPath,
            this.colRegex,
            this.colProcedureName});
            this.gridView1.GridControl = this.grdPlates;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colPlateId
            // 
            this.colPlateId.Caption = "Номер";
            this.colPlateId.FieldName = "PlateID";
            this.colPlateId.Name = "colPlateId";
            // 
            // colName
            // 
            this.colName.Caption = "Имя таблички";
            this.colName.FieldName = "PlateName";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.ReadOnly = true;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Описание таблички";
            this.colDescription.FieldName = "PlateDescription";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.OptionsColumn.ReadOnly = true;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            // 
            // colPath
            // 
            this.colPath.Caption = "Путь до скрипта";
            this.colPath.FieldName = "ScriptPath";
            this.colPath.Name = "colPath";
            this.colPath.OptionsColumn.AllowEdit = false;
            this.colPath.OptionsColumn.ReadOnly = true;
            this.colPath.Visible = true;
            this.colPath.VisibleIndex = 2;
            // 
            // colRegex
            // 
            this.colRegex.Caption = "Регулярное выражение";
            this.colRegex.FieldName = "Regex";
            this.colRegex.Name = "colRegex";
            this.colRegex.OptionsColumn.AllowEdit = false;
            this.colRegex.OptionsColumn.ReadOnly = true;
            this.colRegex.Visible = true;
            this.colRegex.VisibleIndex = 3;
            // 
            // colProcedureName
            // 
            this.colProcedureName.Caption = "Имя хранимой процедуры";
            this.colProcedureName.FieldName = "StoredProcedureName";
            this.colProcedureName.Name = "colProcedureName";
            this.colProcedureName.OptionsColumn.AllowEdit = false;
            this.colProcedureName.OptionsColumn.ReadOnly = true;
            this.colProcedureName.Visible = true;
            this.colProcedureName.VisibleIndex = 4;
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
            this.btnAddPlate.Caption = "Добавить табличку";
            this.btnAddPlate.Id = 0;
            this.btnAddPlate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPlate.ImageOptions.Image")));
            this.btnAddPlate.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAddPlate.ImageOptions.LargeImage")));
            this.btnAddPlate.Name = "btnAddPlate";
            this.btnAddPlate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnAddPlate_ItemClick);
            // 
            // btnChangePlate
            // 
            this.btnChangePlate.Caption = "Изменить табличку";
            this.btnChangePlate.Id = 2;
            this.btnChangePlate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnChangePlate.ImageOptions.Image")));
            this.btnChangePlate.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnChangePlate.ImageOptions.LargeImage")));
            this.btnChangePlate.Name = "btnChangePlate";
            this.btnChangePlate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnChangePlate_ItemClick);
            // 
            // btnDeletePlate
            // 
            this.btnDeletePlate.Caption = "Удалить табличку";
            this.btnDeletePlate.Id = 1;
            this.btnDeletePlate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDeletePlate.ImageOptions.Image")));
            this.btnDeletePlate.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDeletePlate.ImageOptions.LargeImage")));
            this.btnDeletePlate.Name = "btnDeletePlate";
            this.btnDeletePlate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnDeletePlate_ItemClick);
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
            this.btnDeletePlate,
            this.btnChangePlate,
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
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(867, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 520);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(867, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 520);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(867, 0);
            this.barDockControlRight.Manager = this.barManager1;
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
        private DevExpress.XtraBars.BarButtonItem btnAddPlate;
        private DevExpress.XtraBars.BarButtonItem btnChangePlate;
        private DevExpress.XtraBars.BarButtonItem btnDeletePlate;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colPlateId;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colPath;
        private DevExpress.XtraGrid.Columns.GridColumn colRegex;
        private DevExpress.XtraGrid.Columns.GridColumn colProcedureName;
    }
}
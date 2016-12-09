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
            this.colNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObjectPath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNifudaPath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDefaulValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaxSymbolCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRegisterType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRegex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComments = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOverflowMovePath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlateId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMoveTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mainMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnAddPlateSetting = new DevExpress.XtraBars.BarButtonItem();
            this.btnChangePlateSetting = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeletePlateSetting = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.colValue = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNum,
            this.colObjectPath,
            this.colNifudaPath,
            this.colDefaulValue,
            this.colMaxSymbolCount,
            this.colRegisterType,
            this.colRegex,
            this.colComments,
            this.colOverflowMovePath,
            this.colPlateId,
            this.colMoveTo,
            this.colValue});
            this.gridView1.GridControl = this.grdPlatesSettings;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colNum
            // 
            this.colNum.Caption = "Номер";
            this.colNum.FieldName = "Num";
            this.colNum.Name = "colNum";
            this.colNum.OptionsColumn.AllowEdit = false;
            this.colNum.OptionsColumn.ReadOnly = true;
            // 
            // colObjectPath
            // 
            this.colObjectPath.Caption = "Путь до объекта";
            this.colObjectPath.FieldName = "ObjectPath";
            this.colObjectPath.Name = "colObjectPath";
            this.colObjectPath.OptionsColumn.AllowEdit = false;
            this.colObjectPath.OptionsColumn.ReadOnly = true;
            this.colObjectPath.Visible = true;
            this.colObjectPath.VisibleIndex = 0;
            // 
            // colNifudaPath
            // 
            this.colNifudaPath.Caption = "Поле в таблице";
            this.colNifudaPath.FieldName = "NifudaPath";
            this.colNifudaPath.Name = "colNifudaPath";
            this.colNifudaPath.OptionsColumn.AllowEdit = false;
            this.colNifudaPath.OptionsColumn.ReadOnly = true;
            this.colNifudaPath.Visible = true;
            this.colNifudaPath.VisibleIndex = 1;
            // 
            // colDefaulValue
            // 
            this.colDefaulValue.Caption = "Значение по умолчанию";
            this.colDefaulValue.FieldName = "DefaultValue";
            this.colDefaulValue.Name = "colDefaulValue";
            this.colDefaulValue.OptionsColumn.AllowEdit = false;
            this.colDefaulValue.OptionsColumn.ReadOnly = true;
            this.colDefaulValue.Visible = true;
            this.colDefaulValue.VisibleIndex = 2;
            // 
            // colMaxSymbolCount
            // 
            this.colMaxSymbolCount.Caption = "Максимальное количество символов";
            this.colMaxSymbolCount.FieldName = "MaxSymbolCount";
            this.colMaxSymbolCount.Name = "colMaxSymbolCount";
            this.colMaxSymbolCount.OptionsColumn.AllowEdit = false;
            this.colMaxSymbolCount.OptionsColumn.ReadOnly = true;
            this.colMaxSymbolCount.Visible = true;
            this.colMaxSymbolCount.VisibleIndex = 3;
            // 
            // colRegisterType
            // 
            this.colRegisterType.Caption = "Тип регистра";
            this.colRegisterType.FieldName = "RegisterType";
            this.colRegisterType.Name = "colRegisterType";
            this.colRegisterType.OptionsColumn.AllowEdit = false;
            this.colRegisterType.OptionsColumn.ReadOnly = true;
            // 
            // colRegex
            // 
            this.colRegex.Caption = "Регулярное выражение";
            this.colRegex.FieldName = "Regex";
            this.colRegex.Name = "colRegex";
            this.colRegex.OptionsColumn.AllowEdit = false;
            this.colRegex.OptionsColumn.ReadOnly = true;
            this.colRegex.Visible = true;
            this.colRegex.VisibleIndex = 4;
            // 
            // colComments
            // 
            this.colComments.Caption = "Комментарии";
            this.colComments.FieldName = "Comments";
            this.colComments.Name = "colComments";
            this.colComments.OptionsColumn.AllowEdit = false;
            this.colComments.OptionsColumn.ReadOnly = true;
            // 
            // colOverflowMovePath
            // 
            this.colOverflowMovePath.Caption = "Путь для переноса";
            this.colOverflowMovePath.FieldName = "OwerFlowMovePath";
            this.colOverflowMovePath.Name = "colOverflowMovePath";
            this.colOverflowMovePath.OptionsColumn.AllowEdit = false;
            this.colOverflowMovePath.OptionsColumn.ReadOnly = true;
            // 
            // colPlateId
            // 
            this.colPlateId.Caption = "ID таблички";
            this.colPlateId.FieldName = "PlateID";
            this.colPlateId.Name = "colPlateId";
            this.colPlateId.OptionsColumn.AllowEdit = false;
            this.colPlateId.OptionsColumn.ReadOnly = true;
            // 
            // colMoveTo
            // 
            this.colMoveTo.Caption = "Путь для переноса";
            this.colMoveTo.FieldName = "MoveTo";
            this.colMoveTo.Name = "colMoveTo";
            this.colMoveTo.OptionsColumn.AllowEdit = false;
            this.colMoveTo.OptionsColumn.ReadOnly = true;
            this.colMoveTo.Visible = true;
            this.colMoveTo.VisibleIndex = 5;
            // 
            // mainMenu
            // 
            this.mainMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAddPlateSetting),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnChangePlateSetting),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDeletePlateSetting)});
            this.mainMenu.Manager = this.barManager1;
            this.mainMenu.Name = "mainMenu";
            // 
            // btnAddPlateSetting
            // 
            this.btnAddPlateSetting.Caption = "Добавить параметр";
            this.btnAddPlateSetting.Id = 0;
            this.btnAddPlateSetting.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPlateSetting.ImageOptions.Image")));
            this.btnAddPlateSetting.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAddPlateSetting.ImageOptions.LargeImage")));
            this.btnAddPlateSetting.Name = "btnAddPlateSetting";
            this.btnAddPlateSetting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnAddPlateSetting_ItemClick);
            // 
            // btnChangePlateSetting
            // 
            this.btnChangePlateSetting.Caption = "Изменить параметр";
            this.btnChangePlateSetting.Id = 1;
            this.btnChangePlateSetting.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnChangePlateSetting.ImageOptions.Image")));
            this.btnChangePlateSetting.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnChangePlateSetting.ImageOptions.LargeImage")));
            this.btnChangePlateSetting.Name = "btnChangePlateSetting";
            this.btnChangePlateSetting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnChangePlateSetting_ItemClick);
            // 
            // btnDeletePlateSetting
            // 
            this.btnDeletePlateSetting.Caption = "Удалить параметр";
            this.btnDeletePlateSetting.Id = 2;
            this.btnDeletePlateSetting.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDeletePlateSetting.ImageOptions.Image")));
            this.btnDeletePlateSetting.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDeletePlateSetting.ImageOptions.LargeImage")));
            this.btnDeletePlateSetting.Name = "btnDeletePlateSetting";
            this.btnDeletePlateSetting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnDeletePlateSetting_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAddPlateSetting,
            this.btnChangePlateSetting,
            this.btnDeletePlateSetting});
            this.barManager1.MaxItemId = 3;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(810, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 540);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(810, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 540);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(810, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 540);
            // 
            // colValue
            // 
            this.colValue.Caption = "Значение";
            this.colValue.FieldName = "Value";
            this.colValue.Name = "colValue";
            this.colValue.OptionsColumn.AllowEdit = false;
            this.colValue.OptionsColumn.ReadOnly = true;
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
        private DevExpress.XtraBars.BarButtonItem btnAddPlateSetting;
        private DevExpress.XtraBars.BarButtonItem btnChangePlateSetting;
        private DevExpress.XtraBars.BarButtonItem btnDeletePlateSetting;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.Columns.GridColumn colNum;
        private DevExpress.XtraGrid.Columns.GridColumn colObjectPath;
        private DevExpress.XtraGrid.Columns.GridColumn colNifudaPath;
        private DevExpress.XtraGrid.Columns.GridColumn colDefaulValue;
        private DevExpress.XtraGrid.Columns.GridColumn colMaxSymbolCount;
        private DevExpress.XtraGrid.Columns.GridColumn colRegisterType;
        private DevExpress.XtraGrid.Columns.GridColumn colRegex;
        private DevExpress.XtraGrid.Columns.GridColumn colComments;
        private DevExpress.XtraGrid.Columns.GridColumn colOverflowMovePath;
        private DevExpress.XtraGrid.Columns.GridColumn colPlateId;
        private DevExpress.XtraGrid.Columns.GridColumn colMoveTo;
        private DevExpress.XtraGrid.Columns.GridColumn colValue;
    }
}
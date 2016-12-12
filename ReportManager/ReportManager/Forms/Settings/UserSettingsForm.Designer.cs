namespace ReportManager.Forms.Settings
{
    partial class UserSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserSettingsForm));
            this.grdUsers = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserPassword = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserStagesMask = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserFuncMask = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mainMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnAddUser = new DevExpress.XtraBars.BarButtonItem();
            this.btnEditUser = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeleteUser = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdUsers
            // 
            this.grdUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUsers.Location = new System.Drawing.Point(0, 0);
            this.grdUsers.MainView = this.gridView1;
            this.grdUsers.Name = "grdUsers";
            this.grdUsers.Size = new System.Drawing.Size(976, 654);
            this.grdUsers.TabIndex = 0;
            this.grdUsers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grdUsers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GridControl1_MouseClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserName,
            this.colUserFullName,
            this.colUserPassword,
            this.colUserStagesMask,
            this.colUserFuncMask});
            this.gridView1.GridControl = this.grdUsers;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colUserName
            // 
            this.colUserName.Caption = "Имя";
            this.colUserName.FieldName = "TUSER";
            this.colUserName.Name = "colUserName";
            this.colUserName.OptionsColumn.AllowEdit = false;
            this.colUserName.OptionsColumn.ReadOnly = true;
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 0;
            // 
            // colUserFullName
            // 
            this.colUserFullName.Caption = "Полное имя";
            this.colUserFullName.FieldName = "FullName";
            this.colUserFullName.Name = "colUserFullName";
            this.colUserFullName.OptionsColumn.AllowEdit = false;
            this.colUserFullName.OptionsColumn.ReadOnly = true;
            this.colUserFullName.Visible = true;
            this.colUserFullName.VisibleIndex = 1;
            // 
            // colUserPassword
            // 
            this.colUserPassword.Caption = "Пароль";
            this.colUserPassword.FieldName = "PASSWORD";
            this.colUserPassword.Name = "colUserPassword";
            this.colUserPassword.OptionsColumn.AllowEdit = false;
            this.colUserPassword.OptionsColumn.ReadOnly = true;
            this.colUserPassword.Visible = true;
            this.colUserPassword.VisibleIndex = 2;
            // 
            // colUserStagesMask
            // 
            this.colUserStagesMask.Caption = "Маска стадий";
            this.colUserStagesMask.FieldName = "UserStagesMask";
            this.colUserStagesMask.Name = "colUserStagesMask";
            this.colUserStagesMask.OptionsColumn.AllowEdit = false;
            this.colUserStagesMask.OptionsColumn.ReadOnly = true;
            // 
            // colUserFuncMask
            // 
            this.colUserFuncMask.Caption = "Маска функций";
            this.colUserFuncMask.FieldName = "UserExtraFuncMask";
            this.colUserFuncMask.Name = "colUserFuncMask";
            this.colUserFuncMask.OptionsColumn.AllowEdit = false;
            this.colUserFuncMask.OptionsColumn.ReadOnly = true;
            // 
            // mainMenu
            // 
            this.mainMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAddUser),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEditUser),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDeleteUser)});
            this.mainMenu.Manager = this.barManager1;
            this.mainMenu.Name = "mainMenu";
            // 
            // btnAddUser
            // 
            this.btnAddUser.Caption = "Добавить пользователя";
            this.btnAddUser.Id = 0;
            this.btnAddUser.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddUser.ImageOptions.Image")));
            this.btnAddUser.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAddUser.ImageOptions.LargeImage")));
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnAddUser_ItemClick);
            // 
            // btnEditUser
            // 
            this.btnEditUser.Caption = "Изменить пользователя";
            this.btnEditUser.Id = 1;
            this.btnEditUser.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEditUser.ImageOptions.Image")));
            this.btnEditUser.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEditUser.ImageOptions.LargeImage")));
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnEditUser_ItemClick);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Caption = "Удалить пользователя";
            this.btnDeleteUser.Id = 2;
            this.btnDeleteUser.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteUser.ImageOptions.Image")));
            this.btnDeleteUser.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDeleteUser.ImageOptions.LargeImage")));
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnDeleteUser_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAddUser,
            this.btnEditUser,
            this.btnDeleteUser});
            this.barManager1.MaxItemId = 3;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(976, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 654);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(976, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 654);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(976, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 654);
            // 
            // UserSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 654);
            this.Controls.Add(this.grdUsers);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "UserSettingsForm";
            this.Text = "Настройка пользователей";
            ((System.ComponentModel.ISupportInitialize)(this.grdUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdUsers;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.PopupMenu mainMenu;
        private DevExpress.XtraBars.BarButtonItem btnAddUser;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnEditUser;
        private DevExpress.XtraBars.BarButtonItem btnDeleteUser;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colUserFullName;
        private DevExpress.XtraGrid.Columns.GridColumn colUserPassword;
        private DevExpress.XtraGrid.Columns.GridColumn colUserStagesMask;
        private DevExpress.XtraGrid.Columns.GridColumn colUserFuncMask;
    }
}
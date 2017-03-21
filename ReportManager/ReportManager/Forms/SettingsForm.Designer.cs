namespace ReportManager.Forms
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.grpMainSettings = new DevExpress.XtraEditors.GroupControl();
            this.btnTryConnectManif = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnReportSavePath = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.edtUpdateTimeout = new DevExpress.XtraEditors.SpinEdit();
            this.edtManufString = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.prgsDbConnect = new DevExpress.XtraWaitForm.ProgressPanel();
            ((System.ComponentModel.ISupportInitialize)(this.grpMainSettings)).BeginInit();
            this.grpMainSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnReportSavePath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUpdateTimeout.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtManufString.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(462, 181);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Сохранить";
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 181);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // grpMainSettings
            // 
            this.grpMainSettings.Controls.Add(this.btnTryConnectManif);
            this.grpMainSettings.Controls.Add(this.labelControl4);
            this.grpMainSettings.Controls.Add(this.btnReportSavePath);
            this.grpMainSettings.Controls.Add(this.labelControl3);
            this.grpMainSettings.Controls.Add(this.edtUpdateTimeout);
            this.grpMainSettings.Controls.Add(this.edtManufString);
            this.grpMainSettings.Controls.Add(this.labelControl2);
            this.grpMainSettings.Location = new System.Drawing.Point(12, 12);
            this.grpMainSettings.Name = "grpMainSettings";
            this.grpMainSettings.Size = new System.Drawing.Size(550, 146);
            this.grpMainSettings.TabIndex = 999;
            this.grpMainSettings.Text = "Основные настройки";
            // 
            // btnTryConnectManif
            // 
            this.btnTryConnectManif.Image = ((System.Drawing.Image)(resources.GetObject("btnTryConnectManif.Image")));
            this.btnTryConnectManif.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnTryConnectManif.Location = new System.Drawing.Point(505, 29);
            this.btnTryConnectManif.Name = "btnTryConnectManif";
            this.btnTryConnectManif.Size = new System.Drawing.Size(22, 22);
            this.btnTryConnectManif.TabIndex = 3;
            this.btnTryConnectManif.Click += new System.EventHandler(this.BtnTryConnectManif_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(18, 120);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(136, 13);
            this.labelControl4.TabIndex = 999;
            this.labelControl4.Text = "Путь сохранения отчетов:";
            // 
            // btnReportSavePath
            // 
            this.btnReportSavePath.Location = new System.Drawing.Point(270, 116);
            this.btnReportSavePath.Name = "btnReportSavePath";
            this.btnReportSavePath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnReportSavePath.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.btnReportSavePath.Size = new System.Drawing.Size(229, 20);
            this.btnReportSavePath.TabIndex = 999;
            this.btnReportSavePath.TabStop = false;
            this.btnReportSavePath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.BtnReportSavePath_ButtonClick);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(18, 91);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(246, 13);
            this.labelControl3.TabIndex = 999;
            this.labelControl3.Text = "Период обновления статуса подключения к бд:";
            // 
            // edtUpdateTimeout
            // 
            this.edtUpdateTimeout.EditValue = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.edtUpdateTimeout.Location = new System.Drawing.Point(270, 88);
            this.edtUpdateTimeout.Name = "edtUpdateTimeout";
            this.edtUpdateTimeout.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtUpdateTimeout.Properties.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.edtUpdateTimeout.Properties.IsFloatValue = false;
            this.edtUpdateTimeout.Properties.Mask.EditMask = "N00";
            this.edtUpdateTimeout.Properties.MaxValue = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.edtUpdateTimeout.Properties.MinValue = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.edtUpdateTimeout.Size = new System.Drawing.Size(229, 20);
            this.edtUpdateTimeout.TabIndex = 4;
            // 
            // edtManufString
            // 
            this.edtManufString.Location = new System.Drawing.Point(270, 28);
            this.edtManufString.Name = "edtManufString";
            this.edtManufString.Size = new System.Drawing.Size(229, 54);
            this.edtManufString.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(18, 30);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(237, 13);
            this.labelControl2.TabIndex = 999;
            this.labelControl2.Text = "Строка подключения к производственной бд:";
            // 
            // prgsDbConnect
            // 
            this.prgsDbConnect.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.prgsDbConnect.Appearance.Options.UseBackColor = true;
            this.prgsDbConnect.BarAnimationElementThickness = 2;
            this.prgsDbConnect.Caption = "Пожалуйста, подождите";
            this.prgsDbConnect.Description = "Попытка подключения к БД...";
            this.prgsDbConnect.Location = new System.Drawing.Point(172, 160);
            this.prgsDbConnect.Name = "prgsDbConnect";
            this.prgsDbConnect.Size = new System.Drawing.Size(243, 66);
            this.prgsDbConnect.TabIndex = 999;
            this.prgsDbConnect.TabStop = false;
            this.prgsDbConnect.Text = "progressPanel1";
            this.prgsDbConnect.Visible = false;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(575, 228);
            this.Controls.Add(this.grpMainSettings);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.prgsDbConnect);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Настройки";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SettingsForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.grpMainSettings)).EndInit();
            this.grpMainSettings.ResumeLayout(false);
            this.grpMainSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnReportSavePath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUpdateTimeout.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtManufString.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.GroupControl grpMainSettings;
        private DevExpress.XtraEditors.MemoEdit edtManufString;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraWaitForm.ProgressPanel prgsDbConnect;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ButtonEdit btnReportSavePath;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SpinEdit edtUpdateTimeout;
        private DevExpress.XtraEditors.SimpleButton btnTryConnectManif;
    }
}
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.grpMainSettings = new DevExpress.XtraEditors.GroupControl();
            this.btnTryConnectManif = new DevExpress.XtraEditors.SimpleButton();
            this.btnTryConnectIsup = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnReportSavePath = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.edtUpdateTimeout = new DevExpress.XtraEditors.SpinEdit();
            this.edtManufString = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.edtIsupString = new DevExpress.XtraEditors.MemoEdit();
            this.prgsDbConnect = new DevExpress.XtraWaitForm.ProgressPanel();
            this.grpStages = new DevExpress.XtraEditors.GroupControl();
            this.cbStageList = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.grpFunctions = new DevExpress.XtraEditors.GroupControl();
            this.cbFunctionsList = new DevExpress.XtraEditors.CheckedListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.grpMainSettings)).BeginInit();
            this.grpMainSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnReportSavePath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUpdateTimeout.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtManufString.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIsupString.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpStages)).BeginInit();
            this.grpStages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbStageList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpFunctions)).BeginInit();
            this.grpFunctions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbFunctionsList)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 45);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(165, 13);
            this.labelControl1.TabIndex = 999;
            this.labelControl1.Text = "Строка подключения к ISUP бд:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(462, 512);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Сохранить";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 512);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grpMainSettings
            // 
            this.grpMainSettings.Controls.Add(this.btnTryConnectManif);
            this.grpMainSettings.Controls.Add(this.btnTryConnectIsup);
            this.grpMainSettings.Controls.Add(this.labelControl4);
            this.grpMainSettings.Controls.Add(this.btnReportSavePath);
            this.grpMainSettings.Controls.Add(this.labelControl3);
            this.grpMainSettings.Controls.Add(this.edtUpdateTimeout);
            this.grpMainSettings.Controls.Add(this.edtManufString);
            this.grpMainSettings.Controls.Add(this.labelControl2);
            this.grpMainSettings.Controls.Add(this.edtIsupString);
            this.grpMainSettings.Controls.Add(this.labelControl1);
            this.grpMainSettings.Location = new System.Drawing.Point(12, 12);
            this.grpMainSettings.Name = "grpMainSettings";
            this.grpMainSettings.Size = new System.Drawing.Size(550, 236);
            this.grpMainSettings.TabIndex = 999;
            this.grpMainSettings.Text = "Основные настройки";
            // 
            // btnTryConnectManif
            // 
            this.btnTryConnectManif.Image = ((System.Drawing.Image)(resources.GetObject("btnTryConnectManif.Image")));
            this.btnTryConnectManif.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnTryConnectManif.Location = new System.Drawing.Point(508, 104);
            this.btnTryConnectManif.Name = "btnTryConnectManif";
            this.btnTryConnectManif.Size = new System.Drawing.Size(22, 22);
            this.btnTryConnectManif.TabIndex = 3;
            this.btnTryConnectManif.Click += new System.EventHandler(this.btnTryConnectManif_Click);
            // 
            // btnTryConnectIsup
            // 
            this.btnTryConnectIsup.Image = ((System.Drawing.Image)(resources.GetObject("btnTryConnectIsup.Image")));
            this.btnTryConnectIsup.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnTryConnectIsup.Location = new System.Drawing.Point(508, 44);
            this.btnTryConnectIsup.Name = "btnTryConnectIsup";
            this.btnTryConnectIsup.Size = new System.Drawing.Size(22, 22);
            this.btnTryConnectIsup.TabIndex = 1;
            this.btnTryConnectIsup.Click += new System.EventHandler(this.btnTryConnectIsup_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(21, 195);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(136, 13);
            this.labelControl4.TabIndex = 999;
            this.labelControl4.Text = "Путь сохранения отчетов:";
            // 
            // btnReportSavePath
            // 
            this.btnReportSavePath.Location = new System.Drawing.Point(273, 191);
            this.btnReportSavePath.Name = "btnReportSavePath";
            this.btnReportSavePath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnReportSavePath.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.btnReportSavePath.Size = new System.Drawing.Size(229, 20);
            this.btnReportSavePath.TabIndex = 999;
            this.btnReportSavePath.TabStop = false;
            this.btnReportSavePath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnReportSavePath_ButtonClick);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(21, 166);
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
            this.edtUpdateTimeout.Location = new System.Drawing.Point(273, 163);
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
            this.edtManufString.Location = new System.Drawing.Point(273, 103);
            this.edtManufString.Name = "edtManufString";
            this.edtManufString.Size = new System.Drawing.Size(229, 54);
            this.edtManufString.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(21, 105);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(237, 13);
            this.labelControl2.TabIndex = 999;
            this.labelControl2.Text = "Строка подключения к производственной бд:";
            // 
            // edtIsupString
            // 
            this.edtIsupString.Location = new System.Drawing.Point(273, 43);
            this.edtIsupString.Name = "edtIsupString";
            this.edtIsupString.Size = new System.Drawing.Size(229, 54);
            this.edtIsupString.TabIndex = 0;
            // 
            // prgsDbConnect
            // 
            this.prgsDbConnect.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.prgsDbConnect.Appearance.Options.UseBackColor = true;
            this.prgsDbConnect.Caption = "Пожалуйста, подождите";
            this.prgsDbConnect.Description = "Попытка подключения к БД...";
            this.prgsDbConnect.Location = new System.Drawing.Point(172, 491);
            this.prgsDbConnect.Name = "prgsDbConnect";
            this.prgsDbConnect.Size = new System.Drawing.Size(243, 66);
            this.prgsDbConnect.TabIndex = 999;
            this.prgsDbConnect.TabStop = false;
            this.prgsDbConnect.Text = "progressPanel1";
            this.prgsDbConnect.Visible = false;
            // 
            // grpStages
            // 
            this.grpStages.Controls.Add(this.cbStageList);
            this.grpStages.Location = new System.Drawing.Point(12, 254);
            this.grpStages.Name = "grpStages";
            this.grpStages.Size = new System.Drawing.Size(272, 236);
            this.grpStages.TabIndex = 999;
            this.grpStages.Text = "Настройка стадий";
            // 
            // cbStageList
            // 
            this.cbStageList.CheckOnClick = true;
            this.cbStageList.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbStageList.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Стадия 1"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Стадия 2"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Стадия 3", System.Windows.Forms.CheckState.Checked)});
            this.cbStageList.Location = new System.Drawing.Point(5, 43);
            this.cbStageList.Name = "cbStageList";
            this.cbStageList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.cbStageList.Size = new System.Drawing.Size(262, 170);
            this.cbStageList.TabIndex = 999;
            this.cbStageList.TabStop = false;
            // 
            // grpFunctions
            // 
            this.grpFunctions.Controls.Add(this.cbFunctionsList);
            this.grpFunctions.Location = new System.Drawing.Point(290, 254);
            this.grpFunctions.Name = "grpFunctions";
            this.grpFunctions.Size = new System.Drawing.Size(272, 236);
            this.grpFunctions.TabIndex = 1000;
            this.grpFunctions.Text = "Настройка доп. функций";
            // 
            // cbFunctionsList
            // 
            this.cbFunctionsList.CheckOnClick = true;
            this.cbFunctionsList.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbFunctionsList.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Функция 1"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Функция 2", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Функция 3")});
            this.cbFunctionsList.Location = new System.Drawing.Point(5, 43);
            this.cbFunctionsList.Name = "cbFunctionsList";
            this.cbFunctionsList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.cbFunctionsList.Size = new System.Drawing.Size(262, 170);
            this.cbFunctionsList.TabIndex = 999;
            this.cbFunctionsList.TabStop = false;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(575, 557);
            this.Controls.Add(this.grpFunctions);
            this.Controls.Add(this.grpStages);
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
            ((System.ComponentModel.ISupportInitialize)(this.edtIsupString.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpStages)).EndInit();
            this.grpStages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbStageList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpFunctions)).EndInit();
            this.grpFunctions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbFunctionsList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.GroupControl grpMainSettings;
        private DevExpress.XtraEditors.MemoEdit edtManufString;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.MemoEdit edtIsupString;
        private DevExpress.XtraWaitForm.ProgressPanel prgsDbConnect;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ButtonEdit btnReportSavePath;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SpinEdit edtUpdateTimeout;
        private DevExpress.XtraEditors.SimpleButton btnTryConnectIsup;
        private DevExpress.XtraEditors.SimpleButton btnTryConnectManif;
        private DevExpress.XtraEditors.GroupControl grpStages;
        private DevExpress.XtraEditors.CheckedListBoxControl cbStageList;
        private DevExpress.XtraEditors.GroupControl grpFunctions;
        private DevExpress.XtraEditors.CheckedListBoxControl cbFunctionsList;
    }
}
namespace ReportManager.Forms.Settings
{
    partial class AddUserForm
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
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tbUserName = new DevExpress.XtraEditors.TextEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.tbUserPassword = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.grpFunctions = new DevExpress.XtraEditors.GroupControl();
            this.cbFunctionsList = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.grpStages = new DevExpress.XtraEditors.GroupControl();
            this.cbStageList = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.tbFullUserName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tbUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbUserPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpFunctions)).BeginInit();
            this.grpFunctions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbFunctionsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpStages)).BeginInit();
            this.grpStages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbStageList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbFullUserName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(487, 364);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ок";
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(97, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Имя пользователя:";
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(167, 23);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(378, 20);
            this.tbUserName.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 364);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // tbUserPassword
            // 
            this.tbUserPassword.Location = new System.Drawing.Point(167, 75);
            this.tbUserPassword.Name = "tbUserPassword";
            this.tbUserPassword.Size = new System.Drawing.Size(378, 20);
            this.tbUserPassword.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 78);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(41, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Пароль:";
            // 
            // grpFunctions
            // 
            this.grpFunctions.Controls.Add(this.cbFunctionsList);
            this.grpFunctions.Location = new System.Drawing.Point(290, 122);
            this.grpFunctions.Name = "grpFunctions";
            this.grpFunctions.Size = new System.Drawing.Size(272, 236);
            this.grpFunctions.TabIndex = 1002;
            this.grpFunctions.Text = "Настройка доп. функций";
            // 
            // cbFunctionsList
            // 
            this.cbFunctionsList.CheckOnClick = true;
            this.cbFunctionsList.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbFunctionsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbFunctionsList.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Функция 1"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Функция 2", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Функция 3")});
            this.cbFunctionsList.Location = new System.Drawing.Point(2, 20);
            this.cbFunctionsList.Name = "cbFunctionsList";
            this.cbFunctionsList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.cbFunctionsList.Size = new System.Drawing.Size(268, 214);
            this.cbFunctionsList.TabIndex = 999;
            this.cbFunctionsList.TabStop = false;
            // 
            // grpStages
            // 
            this.grpStages.Controls.Add(this.cbStageList);
            this.grpStages.Location = new System.Drawing.Point(12, 122);
            this.grpStages.Name = "grpStages";
            this.grpStages.Size = new System.Drawing.Size(272, 236);
            this.grpStages.TabIndex = 1001;
            this.grpStages.Text = "Настройка стадий";
            // 
            // cbStageList
            // 
            this.cbStageList.CheckOnClick = true;
            this.cbStageList.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbStageList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbStageList.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Стадия 1"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Стадия 2"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Стадия 3", System.Windows.Forms.CheckState.Checked)});
            this.cbStageList.Location = new System.Drawing.Point(2, 20);
            this.cbStageList.Name = "cbStageList";
            this.cbStageList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.cbStageList.Size = new System.Drawing.Size(268, 214);
            this.cbStageList.TabIndex = 999;
            this.cbStageList.TabStop = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.tbFullUserName);
            this.groupControl1.Controls.Add(this.tbUserName);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.tbUserPassword);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(550, 104);
            this.groupControl1.TabIndex = 1002;
            this.groupControl1.Text = "Персональные данные";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(11, 52);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(62, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Полное имя:";
            // 
            // tbFullUserName
            // 
            this.tbFullUserName.Location = new System.Drawing.Point(167, 49);
            this.tbFullUserName.Name = "tbFullUserName";
            this.tbFullUserName.Size = new System.Drawing.Size(378, 20);
            this.tbFullUserName.TabIndex = 7;
            // 
            // AddUserForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(575, 393);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.grpFunctions);
            this.Controls.Add(this.grpStages);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddUserForm";
            this.Text = "Добавление / изменение пользователя";
            ((System.ComponentModel.ISupportInitialize)(this.tbUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbUserPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpFunctions)).EndInit();
            this.grpFunctions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbFunctionsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpStages)).EndInit();
            this.grpStages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbStageList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbFullUserName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit tbUserName;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.TextEdit tbUserPassword;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GroupControl grpFunctions;
        private DevExpress.XtraEditors.CheckedListBoxControl cbFunctionsList;
        private DevExpress.XtraEditors.GroupControl grpStages;
        private DevExpress.XtraEditors.CheckedListBoxControl cbStageList;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit tbFullUserName;
    }
}
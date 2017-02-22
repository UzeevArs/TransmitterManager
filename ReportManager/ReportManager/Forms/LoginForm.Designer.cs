namespace ReportManager.Forms
{
    partial class LoginForm
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.tbPassword = new DevExpress.XtraEditors.TextEdit();
            this.cbUsersName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnOpenSettings = new DevExpress.XtraEditors.SimpleButton();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tbPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUsersName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(149, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Выберите имя пользователя:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(283, 64);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Вход";
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            this.btnOk.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyUp);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 64);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = " Выход";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            this.btnCancel.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyUp);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(86, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Введите пароль:";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(178, 38);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Properties.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(180, 20);
            this.tbPassword.TabIndex = 0;
            this.tbPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyUp);
            // 
            // cbUsersName
            // 
            this.cbUsersName.Location = new System.Drawing.Point(178, 12);
            this.cbUsersName.Name = "cbUsersName";
            this.cbUsersName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbUsersName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbUsersName.Size = new System.Drawing.Size(180, 20);
            this.cbUsersName.TabIndex = 2;
            this.cbUsersName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyUp);
            // 
            // btnOpenSettings
            // 
            this.btnOpenSettings.Location = new System.Drawing.Point(151, 64);
            this.btnOpenSettings.Name = "btnOpenSettings";
            this.btnOpenSettings.Size = new System.Drawing.Size(75, 23);
            this.btnOpenSettings.TabIndex = 4;
            this.btnOpenSettings.Text = "Настройки";
            this.btnOpenSettings.Click += new System.EventHandler(this.BtnOpenSettings_Click);
            this.btnOpenSettings.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyUp);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 100);
            this.Controls.Add(this.btnOpenSettings);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cbUsersName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.Text = "Вход";
            ((System.ComponentModel.ISupportInitialize)(this.tbPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUsersName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit tbPassword;
        private DevExpress.XtraEditors.ComboBoxEdit cbUsersName;
        private DevExpress.XtraEditors.SimpleButton btnOpenSettings;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
    }
}
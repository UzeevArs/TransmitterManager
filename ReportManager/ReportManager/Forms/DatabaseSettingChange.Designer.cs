namespace ReportManager.Forms
{
    partial class DatabaseSettingChange
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
            this.edtNifudaConnString = new DevExpress.XtraEditors.TextEdit();
            this.edtISUPConnString = new DevExpress.XtraEditors.TextEdit();
            this.btnCheckConnNifuda = new DevExpress.XtraEditors.SimpleButton();
            this.btnCheckConnISUP = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSetNifudaConnString = new DevExpress.XtraEditors.SimpleButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSetISUPConnStr = new DevExpress.XtraEditors.SimpleButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.edtNifudaConnString.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtISUPConnString.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // edtNifudaConnString
            // 
            this.edtNifudaConnString.Location = new System.Drawing.Point(20, 74);
            this.edtNifudaConnString.Name = "edtNifudaConnString";
            this.edtNifudaConnString.Size = new System.Drawing.Size(212, 20);
            this.edtNifudaConnString.TabIndex = 1;
            // 
            // edtISUPConnString
            // 
            this.edtISUPConnString.Location = new System.Drawing.Point(23, 76);
            this.edtISUPConnString.Name = "edtISUPConnString";
            this.edtISUPConnString.Size = new System.Drawing.Size(218, 20);
            this.edtISUPConnString.TabIndex = 2;
            // 
            // btnCheckConnNifuda
            // 
            this.btnCheckConnNifuda.Location = new System.Drawing.Point(20, 110);
            this.btnCheckConnNifuda.Name = "btnCheckConnNifuda";
            this.btnCheckConnNifuda.Size = new System.Drawing.Size(94, 35);
            this.btnCheckConnNifuda.TabIndex = 3;
            this.btnCheckConnNifuda.Text = "Проверка \r\nподключения";
            this.btnCheckConnNifuda.Click += new System.EventHandler(this.btnCheckConnNifuda_Click);
            // 
            // btnCheckConnISUP
            // 
            this.btnCheckConnISUP.Location = new System.Drawing.Point(23, 112);
            this.btnCheckConnISUP.Name = "btnCheckConnISUP";
            this.btnCheckConnISUP.Size = new System.Drawing.Size(94, 35);
            this.btnCheckConnISUP.TabIndex = 4;
            this.btnCheckConnISUP.Text = "Проверка \r\nподключения";
            this.btnCheckConnISUP.Click += new System.EventHandler(this.btnCheckConnISUP_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSetNifudaConnString);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.btnCheckConnNifuda);
            this.groupBox1.Controls.Add(this.edtNifudaConnString);
            this.groupBox1.Location = new System.Drawing.Point(7, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 247);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Производственная база данных";
            // 
            // btnSetNifudaConnString
            // 
            this.btnSetNifudaConnString.Location = new System.Drawing.Point(149, 110);
            this.btnSetNifudaConnString.Name = "btnSetNifudaConnString";
            this.btnSetNifudaConnString.Size = new System.Drawing.Size(83, 35);
            this.btnSetNifudaConnString.TabIndex = 5;
            this.btnSetNifudaConnString.Text = "Запись \r\nновой строки";
            this.btnSetNifudaConnString.Click += new System.EventHandler(this.btnSetNifudaConnString_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(46, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(154, 22);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Строка подключения";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBox2.Controls.Add(this.btnSetISUPConnStr);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.btnCheckConnISUP);
            this.groupBox2.Controls.Add(this.edtISUPConnString);
            this.groupBox2.Location = new System.Drawing.Point(283, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(267, 248);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "База данных ИСУП";
            // 
            // btnSetISUPConnStr
            // 
            this.btnSetISUPConnStr.Location = new System.Drawing.Point(158, 112);
            this.btnSetISUPConnStr.Name = "btnSetISUPConnStr";
            this.btnSetISUPConnStr.Size = new System.Drawing.Size(83, 35);
            this.btnSetISUPConnStr.TabIndex = 6;
            this.btnSetISUPConnStr.Text = "Запись \r\nновой строки";
            this.btnSetISUPConnStr.Click += new System.EventHandler(this.btnSetISUPConnStr_Click);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(59, 36);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(154, 22);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "Строка подключения";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DatabaseSettingChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 262);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "DatabaseSettingChange";
            this.Text = "DatabaseSettingChange";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DatabaseSettingChange_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.edtNifudaConnString.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtISUPConnString.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit edtNifudaConnString;
        private DevExpress.XtraEditors.TextEdit edtISUPConnString;
        private DevExpress.XtraEditors.SimpleButton btnCheckConnNifuda;
        private DevExpress.XtraEditors.SimpleButton btnCheckConnISUP;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btnSetNifudaConnString;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.SimpleButton btnSetISUPConnStr;
        private System.Windows.Forms.TextBox textBox2;
    }
}
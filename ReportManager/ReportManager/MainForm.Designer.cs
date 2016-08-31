namespace ReportManager
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.edtSerial = new DevExpress.XtraEditors.TextEdit();
            this.btnLoadDeviceModel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.edtSerial.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // edtSerial
            // 
            this.edtSerial.EditValue = "0584796701";
            this.edtSerial.Location = new System.Drawing.Point(109, 12);
            this.edtSerial.Name = "edtSerial";
            this.edtSerial.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSerial.Size = new System.Drawing.Size(136, 22);
            this.edtSerial.TabIndex = 1;
            // 
            // btnLoadDeviceModel
            // 
            this.btnLoadDeviceModel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnLoadDeviceModel.Location = new System.Drawing.Point(251, 11);
            this.btnLoadDeviceModel.Name = "btnLoadDeviceModel";
            this.btnLoadDeviceModel.Size = new System.Drawing.Size(75, 23);
            this.btnLoadDeviceModel.TabIndex = 2;
            this.btnLoadDeviceModel.Text = "Загрузить";
            this.btnLoadDeviceModel.Click += new System.EventHandler(this.btnLoadDeviceModel_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(88, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Серийный номер:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 47);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnLoadDeviceModel);
            this.Controls.Add(this.edtSerial);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "ReportManager";
            ((System.ComponentModel.ISupportInitialize)(this.edtSerial.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit edtSerial;
        private DevExpress.XtraEditors.SimpleButton btnLoadDeviceModel;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}


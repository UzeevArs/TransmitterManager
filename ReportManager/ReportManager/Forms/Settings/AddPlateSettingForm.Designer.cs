namespace ReportManager.Forms.Settings
{
    partial class AddPlateSettingForm
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tbMoveTo = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new DevExpress.XtraEditors.LabelControl();
            this.tbRegex = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new DevExpress.XtraEditors.LabelControl();
            this.label4 = new DevExpress.XtraEditors.LabelControl();
            this.tbDefaultValue = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.tbNifudaPath = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.tbObjectPath = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tbMaxSymbolCount = new DevExpress.XtraEditors.SpinEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMoveTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRegex.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDefaultValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNifudaPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbObjectPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaxSymbolCount.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.tbMoveTo);
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Controls.Add(this.tbRegex);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.tbDefaultValue);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.tbNifudaPath);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.tbObjectPath);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.tbMaxSymbolCount);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(550, 180);
            this.groupControl1.TabIndex = 1006;
            this.groupControl1.Text = "Данные";
            // 
            // tbMoveTo
            // 
            this.tbMoveTo.Location = new System.Drawing.Point(167, 150);
            this.tbMoveTo.Name = "tbMoveTo";
            this.tbMoveTo.Size = new System.Drawing.Size(378, 20);
            this.tbMoveTo.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(5, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Путь для переноса:";
            // 
            // tbRegex
            // 
            this.tbRegex.Location = new System.Drawing.Point(167, 124);
            this.tbRegex.Name = "tbRegex";
            this.tbRegex.Size = new System.Drawing.Size(378, 20);
            this.tbRegex.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(5, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Регулярное выражение:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(5, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Максимальное количество:";
            // 
            // tbDefaultValue
            // 
            this.tbDefaultValue.Location = new System.Drawing.Point(167, 72);
            this.tbDefaultValue.Name = "tbDefaultValue";
            this.tbDefaultValue.Size = new System.Drawing.Size(378, 20);
            this.tbDefaultValue.TabIndex = 6;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(5, 75);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(127, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Значение по умолчанию:";
            // 
            // tbNifudaPath
            // 
            this.tbNifudaPath.Location = new System.Drawing.Point(167, 46);
            this.tbNifudaPath.Name = "tbNifudaPath";
            this.tbNifudaPath.Size = new System.Drawing.Size(378, 20);
            this.tbNifudaPath.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 49);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(83, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Поле в таблице:";
            // 
            // tbObjectPath
            // 
            this.tbObjectPath.Location = new System.Drawing.Point(167, 20);
            this.tbObjectPath.Name = "tbObjectPath";
            this.tbObjectPath.Size = new System.Drawing.Size(378, 20);
            this.tbObjectPath.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(91, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Путь до объекта:";
            // 
            // tbMaxSymbolCount
            // 
            this.tbMaxSymbolCount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbMaxSymbolCount.Location = new System.Drawing.Point(167, 98);
            this.tbMaxSymbolCount.Name = "tbMaxSymbolCount";
            this.tbMaxSymbolCount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbMaxSymbolCount.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.tbMaxSymbolCount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.tbMaxSymbolCount.Size = new System.Drawing.Size(378, 20);
            this.tbMaxSymbolCount.TabIndex = 8;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 198);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1008;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(487, 198);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1007;
            this.btnOk.Text = "Ок";
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // AddPlateSettingForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(574, 232);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddPlateSettingForm";
            this.Text = "Добавление / изменение параметров для таблички";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMoveTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRegex.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDefaultValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNifudaPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbObjectPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaxSymbolCount.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit tbObjectPath;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.TextEdit tbMoveTo;
        private DevExpress.XtraEditors.LabelControl label6;
        private DevExpress.XtraEditors.TextEdit tbRegex;
        private DevExpress.XtraEditors.LabelControl label5;
        private DevExpress.XtraEditors.LabelControl label4;
        private DevExpress.XtraEditors.TextEdit tbDefaultValue;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit tbNifudaPath;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SpinEdit tbMaxSymbolCount;
    }
}
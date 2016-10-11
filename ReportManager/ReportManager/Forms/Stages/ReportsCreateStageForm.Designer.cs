namespace ReportManager.Forms.Stages
{
    partial class ReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportForm));
            this.cbReports = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnOpenPreview = new DevExpress.XtraEditors.SimpleButton();
            this.btnOpenEditor = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cbReports.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cbReports
            // 
            this.cbReports.Location = new System.Drawing.Point(105, 7);
            this.cbReports.Name = "cbReports";
            this.cbReports.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.cbReports.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbReports.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbReports.Size = new System.Drawing.Size(248, 22);
            this.cbReports.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(87, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Выберите отчет:";
            // 
            // btnOpenPreview
            // 
            this.btnOpenPreview.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenPreview.Appearance.Image")));
            this.btnOpenPreview.Appearance.Options.UseImage = true;
            this.btnOpenPreview.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenPreview.Image")));
            this.btnOpenPreview.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnOpenPreview.Location = new System.Drawing.Point(359, 8);
            this.btnOpenPreview.Name = "btnOpenPreview";
            this.btnOpenPreview.Size = new System.Drawing.Size(22, 22);
            this.btnOpenPreview.TabIndex = 2;
            this.btnOpenPreview.Click += new System.EventHandler(this.btnOpenPreview_Click);
            // 
            // btnOpenEditor
            // 
            this.btnOpenEditor.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenEditor.Image")));
            this.btnOpenEditor.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnOpenEditor.Location = new System.Drawing.Point(387, 8);
            this.btnOpenEditor.Name = "btnOpenEditor";
            this.btnOpenEditor.Size = new System.Drawing.Size(22, 22);
            this.btnOpenEditor.TabIndex = 3;
            this.btnOpenEditor.Text = "\r\n";
            this.btnOpenEditor.Click += new System.EventHandler(this.btnOpenEditor_Click);
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 39);
            this.Controls.Add(this.btnOpenEditor);
            this.Controls.Add(this.btnOpenPreview);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cbReports);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportForm";
            this.Text = "Формирование отчётов";
            ((System.ComponentModel.ISupportInitialize)(this.cbReports.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit cbReports;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnOpenPreview;
        private DevExpress.XtraEditors.SimpleButton btnOpenEditor;
    }
}
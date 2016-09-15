namespace ReportManager.Forms
{
    partial class TestForm
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
            this.btnTestData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTestData
            // 
            this.btnTestData.Location = new System.Drawing.Point(87, 60);
            this.btnTestData.Name = "btnTestData";
            this.btnTestData.Size = new System.Drawing.Size(90, 23);
            this.btnTestData.TabIndex = 0;
            this.btnTestData.Text = "Считывание";
            this.btnTestData.UseVisualStyleBackColor = true;
            this.btnTestData.Click += new System.EventHandler(this.btnTestData_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnTestData);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTestData;
    }
}
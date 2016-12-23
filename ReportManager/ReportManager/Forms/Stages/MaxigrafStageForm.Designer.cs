namespace ReportManager.Forms.Stages.MaxigraphStageForm
{
    partial class MaxigrafStageForm
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
            this.progressPanel = new DevExpress.XtraWaitForm.ProgressPanel();
            this.btnConnect = new DevExpress.XtraEditors.SimpleButton();
            this.btnDisconnect = new DevExpress.XtraEditors.SimpleButton();
            this.grpConnection = new DevExpress.XtraEditors.GroupControl();
            this.grpControl = new DevExpress.XtraEditors.GroupControl();
            this.progressMarking = new DevExpress.XtraEditors.ProgressBarControl();
            this.btnStop = new DevExpress.XtraEditors.SimpleButton();
            this.btnShowRect = new DevExpress.XtraEditors.SimpleButton();
            this.btnStart = new DevExpress.XtraEditors.SimpleButton();
            this.btnShowCross = new DevExpress.XtraEditors.SimpleButton();
            this.grpPlateSettings = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grpCurrentDevice = new DevExpress.XtraEditors.GroupControl();
            this.tbGraphStatus = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.tbPlateName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.tbSerial = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.grpLog = new DevExpress.XtraEditors.GroupControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.memoLog = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grpConnection)).BeginInit();
            this.grpConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpControl)).BeginInit();
            this.grpControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressMarking.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPlateSettings)).BeginInit();
            this.grpPlateSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCurrentDevice)).BeginInit();
            this.grpCurrentDevice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraphStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPlateName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSerial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpLog)).BeginInit();
            this.grpLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoLog.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // progressPanel
            // 
            this.progressPanel.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel.Appearance.Options.UseBackColor = true;
            this.progressPanel.Caption = "Пожалуйста, подождите";
            this.progressPanel.Description = "Идёт подключение к Maxigraph";
            this.progressPanel.Location = new System.Drawing.Point(8, 53);
            this.progressPanel.Name = "progressPanel";
            this.progressPanel.RangeAnimationElementThickness = 2;
            this.progressPanel.Size = new System.Drawing.Size(232, 66);
            this.progressPanel.TabIndex = 0;
            this.progressPanel.Text = "Connection";
            this.progressPanel.Visible = false;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(127, 24);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(110, 23);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Подключиться";
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(8, 24);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(110, 23);
            this.btnDisconnect.TabIndex = 2;
            this.btnDisconnect.Text = "Отключиться";
            this.btnDisconnect.Click += new System.EventHandler(this.BtnDisconnect_Click);
            // 
            // grpConnection
            // 
            this.grpConnection.Controls.Add(this.progressPanel);
            this.grpConnection.Controls.Add(this.btnDisconnect);
            this.grpConnection.Controls.Add(this.btnConnect);
            this.grpConnection.Location = new System.Drawing.Point(12, 12);
            this.grpConnection.Name = "grpConnection";
            this.grpConnection.Size = new System.Drawing.Size(245, 132);
            this.grpConnection.TabIndex = 3;
            this.grpConnection.Text = "Панель подключения";
            // 
            // grpControl
            // 
            this.grpControl.Controls.Add(this.progressMarking);
            this.grpControl.Controls.Add(this.btnStop);
            this.grpControl.Controls.Add(this.btnShowRect);
            this.grpControl.Controls.Add(this.btnStart);
            this.grpControl.Controls.Add(this.btnShowCross);
            this.grpControl.Enabled = false;
            this.grpControl.Location = new System.Drawing.Point(12, 150);
            this.grpControl.Name = "grpControl";
            this.grpControl.Size = new System.Drawing.Size(245, 138);
            this.grpControl.TabIndex = 4;
            this.grpControl.Text = "Панель управления";
            // 
            // progressMarking
            // 
            this.progressMarking.Location = new System.Drawing.Point(8, 82);
            this.progressMarking.Name = "progressMarking";
            this.progressMarking.Size = new System.Drawing.Size(229, 18);
            this.progressMarking.TabIndex = 7;
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(8, 106);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(229, 23);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Остановить маркировку";
            this.btnStop.Click += new System.EventHandler(this.BtnStop_ClickAsync);
            // 
            // btnShowRect
            // 
            this.btnShowRect.Location = new System.Drawing.Point(127, 24);
            this.btnShowRect.Name = "btnShowRect";
            this.btnShowRect.Size = new System.Drawing.Size(110, 23);
            this.btnShowRect.TabIndex = 4;
            this.btnShowRect.Text = "Rect-джойстик";
            this.btnShowRect.Visible = false;
            this.btnShowRect.Click += new System.EventHandler(this.BtnShowRect_ClickAsync);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(8, 53);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(229, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Начать маркировку";
            this.btnStart.Click += new System.EventHandler(this.BtnStart_ClickAsync);
            // 
            // btnShowCross
            // 
            this.btnShowCross.Location = new System.Drawing.Point(8, 24);
            this.btnShowCross.Name = "btnShowCross";
            this.btnShowCross.Size = new System.Drawing.Size(110, 23);
            this.btnShowCross.TabIndex = 2;
            this.btnShowCross.Text = "Cross-джойстик";
            this.btnShowCross.Visible = false;
            this.btnShowCross.Click += new System.EventHandler(this.BtnShowCross_ClickAsync);
            // 
            // grpPlateSettings
            // 
            this.grpPlateSettings.Controls.Add(this.gridControl1);
            this.grpPlateSettings.Location = new System.Drawing.Point(263, 150);
            this.grpPlateSettings.Name = "grpPlateSettings";
            this.grpPlateSettings.Size = new System.Drawing.Size(656, 406);
            this.grpPlateSettings.TabIndex = 5;
            this.grpPlateSettings.Text = "Поля таблички";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 20);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(652, 384);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKey,
            this.colValue});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colKey
            // 
            this.colKey.Caption = "Путь";
            this.colKey.FieldName = "Item1";
            this.colKey.Name = "colKey";
            this.colKey.OptionsColumn.AllowEdit = false;
            this.colKey.OptionsColumn.ReadOnly = true;
            this.colKey.Visible = true;
            this.colKey.VisibleIndex = 0;
            // 
            // colValue
            // 
            this.colValue.Caption = "Значение";
            this.colValue.FieldName = "Item2";
            this.colValue.Name = "colValue";
            this.colValue.Visible = true;
            this.colValue.VisibleIndex = 1;
            // 
            // grpCurrentDevice
            // 
            this.grpCurrentDevice.Controls.Add(this.tbGraphStatus);
            this.grpCurrentDevice.Controls.Add(this.labelControl3);
            this.grpCurrentDevice.Controls.Add(this.tbPlateName);
            this.grpCurrentDevice.Controls.Add(this.labelControl2);
            this.grpCurrentDevice.Controls.Add(this.tbSerial);
            this.grpCurrentDevice.Controls.Add(this.labelControl1);
            this.grpCurrentDevice.Location = new System.Drawing.Point(265, 12);
            this.grpCurrentDevice.Name = "grpCurrentDevice";
            this.grpCurrentDevice.Size = new System.Drawing.Size(652, 132);
            this.grpCurrentDevice.TabIndex = 6;
            this.grpCurrentDevice.Text = "Информация:";
            // 
            // tbGraphStatus
            // 
            this.tbGraphStatus.Location = new System.Drawing.Point(318, 88);
            this.tbGraphStatus.Name = "tbGraphStatus";
            this.tbGraphStatus.Properties.ReadOnly = true;
            this.tbGraphStatus.Size = new System.Drawing.Size(200, 20);
            this.tbGraphStatus.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(129, 91);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(102, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Статус гравировки:";
            // 
            // tbPlateName
            // 
            this.tbPlateName.Location = new System.Drawing.Point(318, 62);
            this.tbPlateName.Name = "tbPlateName";
            this.tbPlateName.Properties.ReadOnly = true;
            this.tbPlateName.Size = new System.Drawing.Size(200, 20);
            this.tbPlateName.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(129, 65);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(74, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Имя таблички:";
            // 
            // tbSerial
            // 
            this.tbSerial.Location = new System.Drawing.Point(318, 36);
            this.tbSerial.Name = "tbSerial";
            this.tbSerial.Properties.ReadOnly = true;
            this.tbSerial.Size = new System.Drawing.Size(200, 20);
            this.tbSerial.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(129, 39);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(135, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Производственный номер:";
            // 
            // grpLog
            // 
            this.grpLog.Controls.Add(this.btnClear);
            this.grpLog.Controls.Add(this.memoLog);
            this.grpLog.Location = new System.Drawing.Point(12, 294);
            this.grpLog.Name = "grpLog";
            this.grpLog.Size = new System.Drawing.Size(245, 260);
            this.grpLog.TabIndex = 7;
            this.grpLog.Text = "Лог";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(5, 24);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(229, 23);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Очистить лог";
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // memoLog
            // 
            this.memoLog.Location = new System.Drawing.Point(0, 53);
            this.memoLog.Name = "memoLog";
            this.memoLog.Properties.ReadOnly = true;
            this.memoLog.Size = new System.Drawing.Size(245, 202);
            this.memoLog.TabIndex = 13;
            this.memoLog.TextChanged += new System.EventHandler(this.MemoLog_TextChanged);
            // 
            // MaxigrafStageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 568);
            this.Controls.Add(this.grpLog);
            this.Controls.Add(this.grpCurrentDevice);
            this.Controls.Add(this.grpPlateSettings);
            this.Controls.Add(this.grpControl);
            this.Controls.Add(this.grpConnection);
            this.Name = "MaxigrafStageForm";
            this.Text = "Гравировка табличек";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MaxigrafStageForm_FormClosed);
            this.Shown += new System.EventHandler(this.MaxigrafStageForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grpConnection)).EndInit();
            this.grpConnection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpControl)).EndInit();
            this.grpControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressMarking.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPlateSettings)).EndInit();
            this.grpPlateSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCurrentDevice)).EndInit();
            this.grpCurrentDevice.ResumeLayout(false);
            this.grpCurrentDevice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraphStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPlateName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSerial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpLog)).EndInit();
            this.grpLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoLog.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWaitForm.ProgressPanel progressPanel;
        private DevExpress.XtraEditors.SimpleButton btnConnect;
        private DevExpress.XtraEditors.SimpleButton btnDisconnect;
        private DevExpress.XtraEditors.GroupControl grpConnection;
        private DevExpress.XtraEditors.GroupControl grpControl;
        private DevExpress.XtraEditors.GroupControl grpPlateSettings;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.SimpleButton btnStop;
        private DevExpress.XtraEditors.SimpleButton btnShowRect;
        private DevExpress.XtraEditors.SimpleButton btnStart;
        private DevExpress.XtraEditors.SimpleButton btnShowCross;
        private DevExpress.XtraEditors.ProgressBarControl progressMarking;
        private DevExpress.XtraEditors.GroupControl grpCurrentDevice;
        private DevExpress.XtraEditors.TextEdit tbGraphStatus;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit tbPlateName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit tbSerial;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl grpLog;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.MemoEdit memoLog;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colKey;
        private DevExpress.XtraGrid.Columns.GridColumn colValue;
    }
}
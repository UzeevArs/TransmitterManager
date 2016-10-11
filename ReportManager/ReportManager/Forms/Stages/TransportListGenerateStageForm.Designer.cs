using ReportManager.Data.Database;

namespace ReportManager.Forms.Stages
{
    partial class TransportListGenerateStageForm
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
            this.grdEmptySerial = new DevExpress.XtraGrid.GridControl();
            this.nifudaDataSet1 = new ReportManager.Data.Database.NifudaDataSet();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMS_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMODEL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROD_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROD_NO_SFIX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colINDEX_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEST_CERT_SIGN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colINST_FINISH_D = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEND_USER_CUST_N_J = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colORDER_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colITEM_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROD_ITEM_REV_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROD_INST_REV_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCOMP_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTART_SCHDULE_D = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFINISH_SCHDULE_D = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTART_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSERIAL_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROD_N_E = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTOKUCHU_SPEC_SIGN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAP_LINKAGE_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nifudaDataTableAdapter1 = new ReportManager.Data.Database.NifudaDataSetTableAdapters.NifudaDataTableAdapter();
            this.colALLOWANCE_SIGN = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmptySerial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nifudaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdEmptySerial
            // 
            this.grdEmptySerial.DataMember = "NifudaDataTable";
            this.grdEmptySerial.DataSource = this.nifudaDataSet1;
            this.grdEmptySerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdEmptySerial.Location = new System.Drawing.Point(0, 0);
            this.grdEmptySerial.MainView = this.gridView1;
            this.grdEmptySerial.Name = "grdEmptySerial";
            this.grdEmptySerial.Size = new System.Drawing.Size(873, 611);
            this.grdEmptySerial.TabIndex = 0;
            this.grdEmptySerial.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grdEmptySerial.DoubleClick += new System.EventHandler(this.grdEmptySerial_DoubleClick);
            // 
            // nifudaDataSet1
            // 
            this.nifudaDataSet1.DataSetName = "NifudaDataSet";
            this.nifudaDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMS_CODE,
            this.colMODEL,
            this.colPROD_NO,
            this.colPROD_NO_SFIX,
            this.colINDEX_NO,
            this.colTEST_CERT_SIGN,
            this.colINST_FINISH_D,
            this.colEND_USER_CUST_N_J,
            this.colORDER_NO,
            this.colITEM_NO,
            this.colPROD_ITEM_REV_NO,
            this.colPROD_INST_REV_NO,
            this.colCOMP_NO,
            this.colSTART_SCHDULE_D,
            this.colFINISH_SCHDULE_D,
            this.colSTART_NO,
            this.colSERIAL_NO,
            this.colPROD_N_E,
            this.colTOKUCHU_SPEC_SIGN,
            this.colSAP_LINKAGE_NO,
            this.colALLOWANCE_SIGN});
            this.gridView1.GridControl = this.grdEmptySerial;
            this.gridView1.Name = "gridView1";
            // 
            // colMS_CODE
            // 
            this.colMS_CODE.FieldName = "MS_CODE";
            this.colMS_CODE.Name = "colMS_CODE";
            this.colMS_CODE.OptionsColumn.AllowEdit = false;
            this.colMS_CODE.OptionsColumn.ReadOnly = true;
            this.colMS_CODE.Visible = true;
            this.colMS_CODE.VisibleIndex = 0;
            // 
            // colMODEL
            // 
            this.colMODEL.FieldName = "MODEL";
            this.colMODEL.Name = "colMODEL";
            this.colMODEL.OptionsColumn.AllowEdit = false;
            this.colMODEL.OptionsColumn.ReadOnly = true;
            this.colMODEL.Visible = true;
            this.colMODEL.VisibleIndex = 1;
            // 
            // colPROD_NO
            // 
            this.colPROD_NO.FieldName = "PROD_NO";
            this.colPROD_NO.Name = "colPROD_NO";
            this.colPROD_NO.OptionsColumn.AllowEdit = false;
            this.colPROD_NO.OptionsColumn.ReadOnly = true;
            this.colPROD_NO.Visible = true;
            this.colPROD_NO.VisibleIndex = 2;
            // 
            // colPROD_NO_SFIX
            // 
            this.colPROD_NO_SFIX.FieldName = "PROD_NO_SFIX";
            this.colPROD_NO_SFIX.Name = "colPROD_NO_SFIX";
            this.colPROD_NO_SFIX.OptionsColumn.AllowEdit = false;
            this.colPROD_NO_SFIX.OptionsColumn.ReadOnly = true;
            this.colPROD_NO_SFIX.Visible = true;
            this.colPROD_NO_SFIX.VisibleIndex = 3;
            // 
            // colINDEX_NO
            // 
            this.colINDEX_NO.FieldName = "INDEX_NO";
            this.colINDEX_NO.Name = "colINDEX_NO";
            this.colINDEX_NO.OptionsColumn.AllowEdit = false;
            this.colINDEX_NO.OptionsColumn.ReadOnly = true;
            this.colINDEX_NO.Visible = true;
            this.colINDEX_NO.VisibleIndex = 4;
            // 
            // colTEST_CERT_SIGN
            // 
            this.colTEST_CERT_SIGN.FieldName = "TEST_CERT_SIGN";
            this.colTEST_CERT_SIGN.Name = "colTEST_CERT_SIGN";
            this.colTEST_CERT_SIGN.OptionsColumn.AllowEdit = false;
            this.colTEST_CERT_SIGN.OptionsColumn.ReadOnly = true;
            this.colTEST_CERT_SIGN.Visible = true;
            this.colTEST_CERT_SIGN.VisibleIndex = 5;
            // 
            // colINST_FINISH_D
            // 
            this.colINST_FINISH_D.FieldName = "INST_FINISH_D";
            this.colINST_FINISH_D.Name = "colINST_FINISH_D";
            this.colINST_FINISH_D.OptionsColumn.AllowEdit = false;
            this.colINST_FINISH_D.OptionsColumn.ReadOnly = true;
            this.colINST_FINISH_D.Visible = true;
            this.colINST_FINISH_D.VisibleIndex = 6;
            // 
            // colEND_USER_CUST_N_J
            // 
            this.colEND_USER_CUST_N_J.FieldName = "END_USER_CUST_N_J";
            this.colEND_USER_CUST_N_J.Name = "colEND_USER_CUST_N_J";
            this.colEND_USER_CUST_N_J.OptionsColumn.AllowEdit = false;
            this.colEND_USER_CUST_N_J.OptionsColumn.ReadOnly = true;
            this.colEND_USER_CUST_N_J.Visible = true;
            this.colEND_USER_CUST_N_J.VisibleIndex = 7;
            // 
            // colORDER_NO
            // 
            this.colORDER_NO.FieldName = "ORDER_NO";
            this.colORDER_NO.Name = "colORDER_NO";
            this.colORDER_NO.OptionsColumn.AllowEdit = false;
            this.colORDER_NO.OptionsColumn.ReadOnly = true;
            this.colORDER_NO.Visible = true;
            this.colORDER_NO.VisibleIndex = 8;
            // 
            // colITEM_NO
            // 
            this.colITEM_NO.FieldName = "ITEM_NO";
            this.colITEM_NO.Name = "colITEM_NO";
            this.colITEM_NO.OptionsColumn.AllowEdit = false;
            this.colITEM_NO.OptionsColumn.ReadOnly = true;
            this.colITEM_NO.Visible = true;
            this.colITEM_NO.VisibleIndex = 9;
            // 
            // colPROD_ITEM_REV_NO
            // 
            this.colPROD_ITEM_REV_NO.FieldName = "PROD_ITEM_REV_NO";
            this.colPROD_ITEM_REV_NO.Name = "colPROD_ITEM_REV_NO";
            this.colPROD_ITEM_REV_NO.OptionsColumn.AllowEdit = false;
            this.colPROD_ITEM_REV_NO.OptionsColumn.ReadOnly = true;
            this.colPROD_ITEM_REV_NO.Visible = true;
            this.colPROD_ITEM_REV_NO.VisibleIndex = 10;
            // 
            // colPROD_INST_REV_NO
            // 
            this.colPROD_INST_REV_NO.FieldName = "PROD_INST_REV_NO";
            this.colPROD_INST_REV_NO.Name = "colPROD_INST_REV_NO";
            this.colPROD_INST_REV_NO.OptionsColumn.AllowEdit = false;
            this.colPROD_INST_REV_NO.OptionsColumn.ReadOnly = true;
            this.colPROD_INST_REV_NO.Visible = true;
            this.colPROD_INST_REV_NO.VisibleIndex = 11;
            // 
            // colCOMP_NO
            // 
            this.colCOMP_NO.FieldName = "COMP_NO";
            this.colCOMP_NO.Name = "colCOMP_NO";
            this.colCOMP_NO.OptionsColumn.AllowEdit = false;
            this.colCOMP_NO.OptionsColumn.ReadOnly = true;
            this.colCOMP_NO.Visible = true;
            this.colCOMP_NO.VisibleIndex = 12;
            // 
            // colSTART_SCHDULE_D
            // 
            this.colSTART_SCHDULE_D.FieldName = "START_SCHDULE_D";
            this.colSTART_SCHDULE_D.Name = "colSTART_SCHDULE_D";
            this.colSTART_SCHDULE_D.OptionsColumn.AllowEdit = false;
            this.colSTART_SCHDULE_D.OptionsColumn.ReadOnly = true;
            this.colSTART_SCHDULE_D.Visible = true;
            this.colSTART_SCHDULE_D.VisibleIndex = 13;
            // 
            // colFINISH_SCHDULE_D
            // 
            this.colFINISH_SCHDULE_D.FieldName = "FINISH_SCHDULE_D";
            this.colFINISH_SCHDULE_D.Name = "colFINISH_SCHDULE_D";
            this.colFINISH_SCHDULE_D.OptionsColumn.AllowEdit = false;
            this.colFINISH_SCHDULE_D.OptionsColumn.ReadOnly = true;
            this.colFINISH_SCHDULE_D.Visible = true;
            this.colFINISH_SCHDULE_D.VisibleIndex = 14;
            // 
            // colSTART_NO
            // 
            this.colSTART_NO.FieldName = "START_NO";
            this.colSTART_NO.Name = "colSTART_NO";
            this.colSTART_NO.OptionsColumn.AllowEdit = false;
            this.colSTART_NO.OptionsColumn.ReadOnly = true;
            this.colSTART_NO.Visible = true;
            this.colSTART_NO.VisibleIndex = 15;
            // 
            // colSERIAL_NO
            // 
            this.colSERIAL_NO.FieldName = "SERIAL_NO";
            this.colSERIAL_NO.Name = "colSERIAL_NO";
            this.colSERIAL_NO.OptionsColumn.AllowEdit = false;
            this.colSERIAL_NO.OptionsColumn.ReadOnly = true;
            this.colSERIAL_NO.Visible = true;
            this.colSERIAL_NO.VisibleIndex = 16;
            // 
            // colPROD_N_E
            // 
            this.colPROD_N_E.FieldName = "PROD_N_E";
            this.colPROD_N_E.Name = "colPROD_N_E";
            this.colPROD_N_E.OptionsColumn.AllowEdit = false;
            this.colPROD_N_E.OptionsColumn.ReadOnly = true;
            this.colPROD_N_E.Visible = true;
            this.colPROD_N_E.VisibleIndex = 17;
            // 
            // colTOKUCHU_SPEC_SIGN
            // 
            this.colTOKUCHU_SPEC_SIGN.FieldName = "TOKUCHU_SPEC_SIGN";
            this.colTOKUCHU_SPEC_SIGN.Name = "colTOKUCHU_SPEC_SIGN";
            this.colTOKUCHU_SPEC_SIGN.OptionsColumn.AllowEdit = false;
            this.colTOKUCHU_SPEC_SIGN.OptionsColumn.ReadOnly = true;
            this.colTOKUCHU_SPEC_SIGN.Visible = true;
            this.colTOKUCHU_SPEC_SIGN.VisibleIndex = 18;
            // 
            // colSAP_LINKAGE_NO
            // 
            this.colSAP_LINKAGE_NO.FieldName = "SAP_LINKAGE_NO";
            this.colSAP_LINKAGE_NO.Name = "colSAP_LINKAGE_NO";
            this.colSAP_LINKAGE_NO.OptionsColumn.AllowEdit = false;
            this.colSAP_LINKAGE_NO.OptionsColumn.ReadOnly = true;
            this.colSAP_LINKAGE_NO.Visible = true;
            this.colSAP_LINKAGE_NO.VisibleIndex = 19;
            // 
            // nifudaDataTableAdapter1
            // 
            this.nifudaDataTableAdapter1.ClearBeforeFill = true;
            // 
            // colALLOWANCE_SIGN
            // 
            this.colALLOWANCE_SIGN.FieldName = "ALLOWANCE_SIGN";
            this.colALLOWANCE_SIGN.Name = "colALLOWANCE_SIGN";
            this.colALLOWANCE_SIGN.Visible = true;
            this.colALLOWANCE_SIGN.VisibleIndex = 20;
            // 
            // TransportListGenerateStageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 611);
            this.Controls.Add(this.grdEmptySerial);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransportListGenerateStageForm";
            this.Text = "Генерация серийного номера";
            ((System.ComponentModel.ISupportInitialize)(this.grdEmptySerial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nifudaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl grdEmptySerial;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private NifudaDataSet nifudaDataSet1;
        private DevExpress.XtraGrid.Columns.GridColumn colMS_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn colMODEL;
        private DevExpress.XtraGrid.Columns.GridColumn colPROD_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colPROD_NO_SFIX;
        private DevExpress.XtraGrid.Columns.GridColumn colINDEX_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colTEST_CERT_SIGN;
        private DevExpress.XtraGrid.Columns.GridColumn colINST_FINISH_D;
        private DevExpress.XtraGrid.Columns.GridColumn colEND_USER_CUST_N_J;
        private DevExpress.XtraGrid.Columns.GridColumn colORDER_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colITEM_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colPROD_ITEM_REV_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colPROD_INST_REV_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colCOMP_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colSTART_SCHDULE_D;
        private DevExpress.XtraGrid.Columns.GridColumn colFINISH_SCHDULE_D;
        private DevExpress.XtraGrid.Columns.GridColumn colSTART_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colSERIAL_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colPROD_N_E;
        private DevExpress.XtraGrid.Columns.GridColumn colTOKUCHU_SPEC_SIGN;
        private DevExpress.XtraGrid.Columns.GridColumn colSAP_LINKAGE_NO;
        private ReportManager.Data.Database.NifudaDataSetTableAdapters.NifudaDataTableAdapter nifudaDataTableAdapter1;
        private DevExpress.XtraGrid.Columns.GridColumn colALLOWANCE_SIGN;
    }
}
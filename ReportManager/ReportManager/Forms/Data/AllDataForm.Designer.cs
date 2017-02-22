namespace ReportManager.Forms.Data
{
    partial class AllDataForm
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.nifudaDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nifudaDataSet = new ReportManager.Data.SAP.NifudaDataSet();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMS_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMODEL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROD_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROD_NO_SFIX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLINE_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCRP_GR_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROD_CAREER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colINDEX_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEST_CERT_SIGN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDOC_LANG_TYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colINST_FINISH_D = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEST_CERT_YN = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.colALLOWANCE_SIGN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROD_N_J = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROD_N_E = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTOKUCHU_SPEC_SIGN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAP_LINKAGE_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRANGE_INST_SIGN_500 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colORD_INST_MAX_500 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colORD_INST_MIN_500 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUNIT_500 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFEATURES_500 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRANGE_INST_SIGN_502 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colORD_INST_MAX_502 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colORD_INST_MIN_502 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUNIT_502 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colORD_INST_CONTECT1_W69 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colORD_INST_CONTECT1_X72 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colORD_INST_CONTECT1_X91 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colORD_INST_CONTECT1_Z30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTAG_NO_525 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colXJ_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colORD_INST_CONTECT1_H46 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colORD_INST_CONTECT1_X92 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colORD_INST_CONTECT1_Y28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colORD_INST_CONTECT1_W35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colORD_INST_CONTECT1_X78 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colORD_INST_CONTECT1_X94 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCAP_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nifudaDataTableAdapter = new ReportManager.Data.SAP.NifudaDataSetTableAdapters.NifudaDataTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nifudaDataTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nifudaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.nifudaDataTableBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1290, 545);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // nifudaDataTableBindingSource
            // 
            this.nifudaDataTableBindingSource.DataMember = "NifudaDataTable";
            this.nifudaDataTableBindingSource.DataSource = this.nifudaDataSet;
            // 
            // nifudaDataSet
            // 
            this.nifudaDataSet.DataSetName = "NifudaDataSet";
            this.nifudaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMS_CODE,
            this.colMODEL,
            this.colPROD_NO,
            this.colPROD_NO_SFIX,
            this.colLINE_NO,
            this.colCRP_GR_NO,
            this.colPROD_CAREER,
            this.colINDEX_NO,
            this.colTEST_CERT_SIGN,
            this.colDOC_LANG_TYPE,
            this.colINST_FINISH_D,
            this.colTEST_CERT_YN,
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
            this.colALLOWANCE_SIGN,
            this.colPROD_N_J,
            this.colPROD_N_E,
            this.colTOKUCHU_SPEC_SIGN,
            this.colSAP_LINKAGE_NO,
            this.colRANGE_INST_SIGN_500,
            this.colORD_INST_MAX_500,
            this.colORD_INST_MIN_500,
            this.colUNIT_500,
            this.colFEATURES_500,
            this.colRANGE_INST_SIGN_502,
            this.colORD_INST_MAX_502,
            this.colORD_INST_MIN_502,
            this.colUNIT_502,
            this.colORD_INST_CONTECT1_W69,
            this.colORD_INST_CONTECT1_X72,
            this.colORD_INST_CONTECT1_X91,
            this.colORD_INST_CONTECT1_Z30,
            this.colTAG_NO_525,
            this.colXJ_NO,
            this.colORD_INST_CONTECT1_H46,
            this.colORD_INST_CONTECT1_X92,
            this.colORD_INST_CONTECT1_Y28,
            this.colORD_INST_CONTECT1_W35,
            this.colORD_INST_CONTECT1_X78,
            this.colORD_INST_CONTECT1_X94,
            this.colCAP_NO});
            this.gridView1.GridControl = this.gridControl1;
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
            // colLINE_NO
            // 
            this.colLINE_NO.FieldName = "LINE_NO";
            this.colLINE_NO.Name = "colLINE_NO";
            this.colLINE_NO.OptionsColumn.AllowEdit = false;
            this.colLINE_NO.OptionsColumn.ReadOnly = true;
            this.colLINE_NO.Visible = true;
            this.colLINE_NO.VisibleIndex = 4;
            // 
            // colCRP_GR_NO
            // 
            this.colCRP_GR_NO.FieldName = "CRP_GR_NO";
            this.colCRP_GR_NO.Name = "colCRP_GR_NO";
            this.colCRP_GR_NO.OptionsColumn.AllowEdit = false;
            this.colCRP_GR_NO.OptionsColumn.ReadOnly = true;
            this.colCRP_GR_NO.Visible = true;
            this.colCRP_GR_NO.VisibleIndex = 5;
            // 
            // colPROD_CAREER
            // 
            this.colPROD_CAREER.FieldName = "PROD_CAREER";
            this.colPROD_CAREER.Name = "colPROD_CAREER";
            this.colPROD_CAREER.OptionsColumn.AllowEdit = false;
            this.colPROD_CAREER.OptionsColumn.ReadOnly = true;
            this.colPROD_CAREER.Visible = true;
            this.colPROD_CAREER.VisibleIndex = 6;
            // 
            // colINDEX_NO
            // 
            this.colINDEX_NO.FieldName = "INDEX_NO";
            this.colINDEX_NO.Name = "colINDEX_NO";
            this.colINDEX_NO.OptionsColumn.AllowEdit = false;
            this.colINDEX_NO.OptionsColumn.ReadOnly = true;
            this.colINDEX_NO.Visible = true;
            this.colINDEX_NO.VisibleIndex = 7;
            // 
            // colTEST_CERT_SIGN
            // 
            this.colTEST_CERT_SIGN.FieldName = "TEST_CERT_SIGN";
            this.colTEST_CERT_SIGN.Name = "colTEST_CERT_SIGN";
            this.colTEST_CERT_SIGN.OptionsColumn.AllowEdit = false;
            this.colTEST_CERT_SIGN.OptionsColumn.ReadOnly = true;
            this.colTEST_CERT_SIGN.Visible = true;
            this.colTEST_CERT_SIGN.VisibleIndex = 8;
            // 
            // colDOC_LANG_TYPE
            // 
            this.colDOC_LANG_TYPE.FieldName = "DOC_LANG_TYPE";
            this.colDOC_LANG_TYPE.Name = "colDOC_LANG_TYPE";
            this.colDOC_LANG_TYPE.OptionsColumn.AllowEdit = false;
            this.colDOC_LANG_TYPE.OptionsColumn.ReadOnly = true;
            this.colDOC_LANG_TYPE.Visible = true;
            this.colDOC_LANG_TYPE.VisibleIndex = 9;
            // 
            // colINST_FINISH_D
            // 
            this.colINST_FINISH_D.FieldName = "INST_FINISH_D";
            this.colINST_FINISH_D.Name = "colINST_FINISH_D";
            this.colINST_FINISH_D.OptionsColumn.AllowEdit = false;
            this.colINST_FINISH_D.OptionsColumn.ReadOnly = true;
            this.colINST_FINISH_D.Visible = true;
            this.colINST_FINISH_D.VisibleIndex = 10;
            // 
            // colTEST_CERT_YN
            // 
            this.colTEST_CERT_YN.FieldName = "TEST_CERT_YN";
            this.colTEST_CERT_YN.Name = "colTEST_CERT_YN";
            this.colTEST_CERT_YN.OptionsColumn.AllowEdit = false;
            this.colTEST_CERT_YN.OptionsColumn.ReadOnly = true;
            this.colTEST_CERT_YN.Visible = true;
            this.colTEST_CERT_YN.VisibleIndex = 11;
            // 
            // colEND_USER_CUST_N_J
            // 
            this.colEND_USER_CUST_N_J.FieldName = "END_USER_CUST_N_J";
            this.colEND_USER_CUST_N_J.Name = "colEND_USER_CUST_N_J";
            this.colEND_USER_CUST_N_J.OptionsColumn.AllowEdit = false;
            this.colEND_USER_CUST_N_J.OptionsColumn.ReadOnly = true;
            this.colEND_USER_CUST_N_J.Visible = true;
            this.colEND_USER_CUST_N_J.VisibleIndex = 12;
            // 
            // colORDER_NO
            // 
            this.colORDER_NO.FieldName = "ORDER_NO";
            this.colORDER_NO.Name = "colORDER_NO";
            this.colORDER_NO.OptionsColumn.AllowEdit = false;
            this.colORDER_NO.OptionsColumn.ReadOnly = true;
            this.colORDER_NO.Visible = true;
            this.colORDER_NO.VisibleIndex = 13;
            // 
            // colITEM_NO
            // 
            this.colITEM_NO.FieldName = "ITEM_NO";
            this.colITEM_NO.Name = "colITEM_NO";
            this.colITEM_NO.OptionsColumn.AllowEdit = false;
            this.colITEM_NO.OptionsColumn.ReadOnly = true;
            this.colITEM_NO.Visible = true;
            this.colITEM_NO.VisibleIndex = 14;
            // 
            // colPROD_ITEM_REV_NO
            // 
            this.colPROD_ITEM_REV_NO.FieldName = "PROD_ITEM_REV_NO";
            this.colPROD_ITEM_REV_NO.Name = "colPROD_ITEM_REV_NO";
            this.colPROD_ITEM_REV_NO.OptionsColumn.AllowEdit = false;
            this.colPROD_ITEM_REV_NO.OptionsColumn.ReadOnly = true;
            this.colPROD_ITEM_REV_NO.Visible = true;
            this.colPROD_ITEM_REV_NO.VisibleIndex = 15;
            // 
            // colPROD_INST_REV_NO
            // 
            this.colPROD_INST_REV_NO.FieldName = "PROD_INST_REV_NO";
            this.colPROD_INST_REV_NO.Name = "colPROD_INST_REV_NO";
            this.colPROD_INST_REV_NO.OptionsColumn.AllowEdit = false;
            this.colPROD_INST_REV_NO.OptionsColumn.ReadOnly = true;
            this.colPROD_INST_REV_NO.Visible = true;
            this.colPROD_INST_REV_NO.VisibleIndex = 16;
            // 
            // colCOMP_NO
            // 
            this.colCOMP_NO.FieldName = "COMP_NO";
            this.colCOMP_NO.Name = "colCOMP_NO";
            this.colCOMP_NO.OptionsColumn.AllowEdit = false;
            this.colCOMP_NO.OptionsColumn.ReadOnly = true;
            this.colCOMP_NO.Visible = true;
            this.colCOMP_NO.VisibleIndex = 17;
            // 
            // colSTART_SCHDULE_D
            // 
            this.colSTART_SCHDULE_D.FieldName = "START_SCHDULE_D";
            this.colSTART_SCHDULE_D.Name = "colSTART_SCHDULE_D";
            this.colSTART_SCHDULE_D.OptionsColumn.AllowEdit = false;
            this.colSTART_SCHDULE_D.OptionsColumn.ReadOnly = true;
            this.colSTART_SCHDULE_D.Visible = true;
            this.colSTART_SCHDULE_D.VisibleIndex = 18;
            // 
            // colFINISH_SCHDULE_D
            // 
            this.colFINISH_SCHDULE_D.FieldName = "FINISH_SCHDULE_D";
            this.colFINISH_SCHDULE_D.Name = "colFINISH_SCHDULE_D";
            this.colFINISH_SCHDULE_D.OptionsColumn.AllowEdit = false;
            this.colFINISH_SCHDULE_D.OptionsColumn.ReadOnly = true;
            this.colFINISH_SCHDULE_D.Visible = true;
            this.colFINISH_SCHDULE_D.VisibleIndex = 19;
            // 
            // colSTART_NO
            // 
            this.colSTART_NO.FieldName = "START_NO";
            this.colSTART_NO.Name = "colSTART_NO";
            this.colSTART_NO.OptionsColumn.AllowEdit = false;
            this.colSTART_NO.OptionsColumn.ReadOnly = true;
            this.colSTART_NO.Visible = true;
            this.colSTART_NO.VisibleIndex = 20;
            // 
            // colSERIAL_NO
            // 
            this.colSERIAL_NO.FieldName = "SERIAL_NO";
            this.colSERIAL_NO.Name = "colSERIAL_NO";
            this.colSERIAL_NO.OptionsColumn.AllowEdit = false;
            this.colSERIAL_NO.OptionsColumn.ReadOnly = true;
            this.colSERIAL_NO.Visible = true;
            this.colSERIAL_NO.VisibleIndex = 21;
            // 
            // colALLOWANCE_SIGN
            // 
            this.colALLOWANCE_SIGN.FieldName = "ALLOWANCE_SIGN";
            this.colALLOWANCE_SIGN.Name = "colALLOWANCE_SIGN";
            this.colALLOWANCE_SIGN.OptionsColumn.AllowEdit = false;
            this.colALLOWANCE_SIGN.OptionsColumn.ReadOnly = true;
            this.colALLOWANCE_SIGN.Visible = true;
            this.colALLOWANCE_SIGN.VisibleIndex = 22;
            // 
            // colPROD_N_J
            // 
            this.colPROD_N_J.FieldName = "PROD_N_J";
            this.colPROD_N_J.Name = "colPROD_N_J";
            this.colPROD_N_J.OptionsColumn.AllowEdit = false;
            this.colPROD_N_J.OptionsColumn.ReadOnly = true;
            this.colPROD_N_J.Visible = true;
            this.colPROD_N_J.VisibleIndex = 23;
            // 
            // colPROD_N_E
            // 
            this.colPROD_N_E.FieldName = "PROD_N_E";
            this.colPROD_N_E.Name = "colPROD_N_E";
            this.colPROD_N_E.OptionsColumn.AllowEdit = false;
            this.colPROD_N_E.OptionsColumn.ReadOnly = true;
            this.colPROD_N_E.Visible = true;
            this.colPROD_N_E.VisibleIndex = 24;
            // 
            // colTOKUCHU_SPEC_SIGN
            // 
            this.colTOKUCHU_SPEC_SIGN.FieldName = "TOKUCHU_SPEC_SIGN";
            this.colTOKUCHU_SPEC_SIGN.Name = "colTOKUCHU_SPEC_SIGN";
            this.colTOKUCHU_SPEC_SIGN.OptionsColumn.AllowEdit = false;
            this.colTOKUCHU_SPEC_SIGN.OptionsColumn.ReadOnly = true;
            this.colTOKUCHU_SPEC_SIGN.Visible = true;
            this.colTOKUCHU_SPEC_SIGN.VisibleIndex = 25;
            // 
            // colSAP_LINKAGE_NO
            // 
            this.colSAP_LINKAGE_NO.FieldName = "SAP_LINKAGE_NO";
            this.colSAP_LINKAGE_NO.Name = "colSAP_LINKAGE_NO";
            this.colSAP_LINKAGE_NO.OptionsColumn.AllowEdit = false;
            this.colSAP_LINKAGE_NO.OptionsColumn.ReadOnly = true;
            this.colSAP_LINKAGE_NO.Visible = true;
            this.colSAP_LINKAGE_NO.VisibleIndex = 26;
            // 
            // colRANGE_INST_SIGN_500
            // 
            this.colRANGE_INST_SIGN_500.FieldName = "RANGE_INST_SIGN_500";
            this.colRANGE_INST_SIGN_500.Name = "colRANGE_INST_SIGN_500";
            this.colRANGE_INST_SIGN_500.OptionsColumn.AllowEdit = false;
            this.colRANGE_INST_SIGN_500.OptionsColumn.ReadOnly = true;
            this.colRANGE_INST_SIGN_500.Visible = true;
            this.colRANGE_INST_SIGN_500.VisibleIndex = 27;
            // 
            // colORD_INST_MAX_500
            // 
            this.colORD_INST_MAX_500.FieldName = "ORD_INST_MAX_500";
            this.colORD_INST_MAX_500.Name = "colORD_INST_MAX_500";
            this.colORD_INST_MAX_500.OptionsColumn.AllowEdit = false;
            this.colORD_INST_MAX_500.OptionsColumn.ReadOnly = true;
            this.colORD_INST_MAX_500.Visible = true;
            this.colORD_INST_MAX_500.VisibleIndex = 28;
            // 
            // colORD_INST_MIN_500
            // 
            this.colORD_INST_MIN_500.FieldName = "ORD_INST_MIN_500";
            this.colORD_INST_MIN_500.Name = "colORD_INST_MIN_500";
            this.colORD_INST_MIN_500.OptionsColumn.AllowEdit = false;
            this.colORD_INST_MIN_500.OptionsColumn.ReadOnly = true;
            this.colORD_INST_MIN_500.Visible = true;
            this.colORD_INST_MIN_500.VisibleIndex = 29;
            // 
            // colUNIT_500
            // 
            this.colUNIT_500.FieldName = "UNIT_500";
            this.colUNIT_500.Name = "colUNIT_500";
            this.colUNIT_500.OptionsColumn.AllowEdit = false;
            this.colUNIT_500.OptionsColumn.ReadOnly = true;
            this.colUNIT_500.Visible = true;
            this.colUNIT_500.VisibleIndex = 30;
            // 
            // colFEATURES_500
            // 
            this.colFEATURES_500.FieldName = "FEATURES_500";
            this.colFEATURES_500.Name = "colFEATURES_500";
            this.colFEATURES_500.OptionsColumn.AllowEdit = false;
            this.colFEATURES_500.OptionsColumn.ReadOnly = true;
            this.colFEATURES_500.Visible = true;
            this.colFEATURES_500.VisibleIndex = 31;
            // 
            // colRANGE_INST_SIGN_502
            // 
            this.colRANGE_INST_SIGN_502.FieldName = "RANGE_INST_SIGN_502";
            this.colRANGE_INST_SIGN_502.Name = "colRANGE_INST_SIGN_502";
            this.colRANGE_INST_SIGN_502.OptionsColumn.AllowEdit = false;
            this.colRANGE_INST_SIGN_502.OptionsColumn.ReadOnly = true;
            this.colRANGE_INST_SIGN_502.Visible = true;
            this.colRANGE_INST_SIGN_502.VisibleIndex = 32;
            // 
            // colORD_INST_MAX_502
            // 
            this.colORD_INST_MAX_502.FieldName = "ORD_INST_MAX_502";
            this.colORD_INST_MAX_502.Name = "colORD_INST_MAX_502";
            this.colORD_INST_MAX_502.OptionsColumn.AllowEdit = false;
            this.colORD_INST_MAX_502.OptionsColumn.ReadOnly = true;
            this.colORD_INST_MAX_502.Visible = true;
            this.colORD_INST_MAX_502.VisibleIndex = 33;
            // 
            // colORD_INST_MIN_502
            // 
            this.colORD_INST_MIN_502.FieldName = "ORD_INST_MIN_502";
            this.colORD_INST_MIN_502.Name = "colORD_INST_MIN_502";
            this.colORD_INST_MIN_502.OptionsColumn.AllowEdit = false;
            this.colORD_INST_MIN_502.OptionsColumn.ReadOnly = true;
            this.colORD_INST_MIN_502.Visible = true;
            this.colORD_INST_MIN_502.VisibleIndex = 34;
            // 
            // colUNIT_502
            // 
            this.colUNIT_502.FieldName = "UNIT_502";
            this.colUNIT_502.Name = "colUNIT_502";
            this.colUNIT_502.OptionsColumn.AllowEdit = false;
            this.colUNIT_502.OptionsColumn.ReadOnly = true;
            this.colUNIT_502.Visible = true;
            this.colUNIT_502.VisibleIndex = 35;
            // 
            // colORD_INST_CONTECT1_W69
            // 
            this.colORD_INST_CONTECT1_W69.FieldName = "ORD_INST_CONTECT1_W69";
            this.colORD_INST_CONTECT1_W69.Name = "colORD_INST_CONTECT1_W69";
            this.colORD_INST_CONTECT1_W69.OptionsColumn.AllowEdit = false;
            this.colORD_INST_CONTECT1_W69.OptionsColumn.ReadOnly = true;
            this.colORD_INST_CONTECT1_W69.Visible = true;
            this.colORD_INST_CONTECT1_W69.VisibleIndex = 36;
            // 
            // colORD_INST_CONTECT1_X72
            // 
            this.colORD_INST_CONTECT1_X72.FieldName = "ORD_INST_CONTECT1_X72";
            this.colORD_INST_CONTECT1_X72.Name = "colORD_INST_CONTECT1_X72";
            this.colORD_INST_CONTECT1_X72.OptionsColumn.AllowEdit = false;
            this.colORD_INST_CONTECT1_X72.OptionsColumn.ReadOnly = true;
            this.colORD_INST_CONTECT1_X72.Visible = true;
            this.colORD_INST_CONTECT1_X72.VisibleIndex = 37;
            // 
            // colORD_INST_CONTECT1_X91
            // 
            this.colORD_INST_CONTECT1_X91.FieldName = "ORD_INST_CONTECT1_X91";
            this.colORD_INST_CONTECT1_X91.Name = "colORD_INST_CONTECT1_X91";
            this.colORD_INST_CONTECT1_X91.OptionsColumn.AllowEdit = false;
            this.colORD_INST_CONTECT1_X91.OptionsColumn.ReadOnly = true;
            this.colORD_INST_CONTECT1_X91.Visible = true;
            this.colORD_INST_CONTECT1_X91.VisibleIndex = 38;
            // 
            // colORD_INST_CONTECT1_Z30
            // 
            this.colORD_INST_CONTECT1_Z30.FieldName = "ORD_INST_CONTECT1_Z30";
            this.colORD_INST_CONTECT1_Z30.Name = "colORD_INST_CONTECT1_Z30";
            this.colORD_INST_CONTECT1_Z30.OptionsColumn.AllowEdit = false;
            this.colORD_INST_CONTECT1_Z30.OptionsColumn.ReadOnly = true;
            this.colORD_INST_CONTECT1_Z30.Visible = true;
            this.colORD_INST_CONTECT1_Z30.VisibleIndex = 39;
            // 
            // colTAG_NO_525
            // 
            this.colTAG_NO_525.FieldName = "TAG_NO_525";
            this.colTAG_NO_525.Name = "colTAG_NO_525";
            this.colTAG_NO_525.OptionsColumn.AllowEdit = false;
            this.colTAG_NO_525.OptionsColumn.ReadOnly = true;
            this.colTAG_NO_525.Visible = true;
            this.colTAG_NO_525.VisibleIndex = 40;
            // 
            // colXJ_NO
            // 
            this.colXJ_NO.FieldName = "XJ_NO";
            this.colXJ_NO.Name = "colXJ_NO";
            this.colXJ_NO.OptionsColumn.AllowEdit = false;
            this.colXJ_NO.OptionsColumn.ReadOnly = true;
            this.colXJ_NO.Visible = true;
            this.colXJ_NO.VisibleIndex = 41;
            // 
            // colORD_INST_CONTECT1_H46
            // 
            this.colORD_INST_CONTECT1_H46.FieldName = "ORD_INST_CONTECT1_H46";
            this.colORD_INST_CONTECT1_H46.Name = "colORD_INST_CONTECT1_H46";
            this.colORD_INST_CONTECT1_H46.OptionsColumn.AllowEdit = false;
            this.colORD_INST_CONTECT1_H46.OptionsColumn.ReadOnly = true;
            this.colORD_INST_CONTECT1_H46.Visible = true;
            this.colORD_INST_CONTECT1_H46.VisibleIndex = 42;
            // 
            // colORD_INST_CONTECT1_X92
            // 
            this.colORD_INST_CONTECT1_X92.FieldName = "ORD_INST_CONTECT1_X92";
            this.colORD_INST_CONTECT1_X92.Name = "colORD_INST_CONTECT1_X92";
            this.colORD_INST_CONTECT1_X92.OptionsColumn.AllowEdit = false;
            this.colORD_INST_CONTECT1_X92.OptionsColumn.ReadOnly = true;
            this.colORD_INST_CONTECT1_X92.Visible = true;
            this.colORD_INST_CONTECT1_X92.VisibleIndex = 43;
            // 
            // colORD_INST_CONTECT1_Y28
            // 
            this.colORD_INST_CONTECT1_Y28.FieldName = "ORD_INST_CONTECT1_Y28";
            this.colORD_INST_CONTECT1_Y28.Name = "colORD_INST_CONTECT1_Y28";
            this.colORD_INST_CONTECT1_Y28.OptionsColumn.AllowEdit = false;
            this.colORD_INST_CONTECT1_Y28.OptionsColumn.ReadOnly = true;
            this.colORD_INST_CONTECT1_Y28.Visible = true;
            this.colORD_INST_CONTECT1_Y28.VisibleIndex = 44;
            // 
            // colORD_INST_CONTECT1_W35
            // 
            this.colORD_INST_CONTECT1_W35.FieldName = "ORD_INST_CONTECT1_W35";
            this.colORD_INST_CONTECT1_W35.Name = "colORD_INST_CONTECT1_W35";
            this.colORD_INST_CONTECT1_W35.OptionsColumn.AllowEdit = false;
            this.colORD_INST_CONTECT1_W35.OptionsColumn.ReadOnly = true;
            this.colORD_INST_CONTECT1_W35.Visible = true;
            this.colORD_INST_CONTECT1_W35.VisibleIndex = 45;
            // 
            // colORD_INST_CONTECT1_X78
            // 
            this.colORD_INST_CONTECT1_X78.FieldName = "ORD_INST_CONTECT1_X78";
            this.colORD_INST_CONTECT1_X78.Name = "colORD_INST_CONTECT1_X78";
            this.colORD_INST_CONTECT1_X78.OptionsColumn.AllowEdit = false;
            this.colORD_INST_CONTECT1_X78.OptionsColumn.ReadOnly = true;
            this.colORD_INST_CONTECT1_X78.Visible = true;
            this.colORD_INST_CONTECT1_X78.VisibleIndex = 46;
            // 
            // colORD_INST_CONTECT1_X94
            // 
            this.colORD_INST_CONTECT1_X94.FieldName = "ORD_INST_CONTECT1_X94";
            this.colORD_INST_CONTECT1_X94.Name = "colORD_INST_CONTECT1_X94";
            this.colORD_INST_CONTECT1_X94.OptionsColumn.AllowEdit = false;
            this.colORD_INST_CONTECT1_X94.OptionsColumn.ReadOnly = true;
            this.colORD_INST_CONTECT1_X94.Visible = true;
            this.colORD_INST_CONTECT1_X94.VisibleIndex = 47;
            // 
            // colCAP_NO
            // 
            this.colCAP_NO.FieldName = "CAP_NO";
            this.colCAP_NO.Name = "colCAP_NO";
            this.colCAP_NO.OptionsColumn.AllowEdit = false;
            this.colCAP_NO.OptionsColumn.ReadOnly = true;
            this.colCAP_NO.Visible = true;
            this.colCAP_NO.VisibleIndex = 48;
            // 
            // nifudaDataTableAdapter
            // 
            this.nifudaDataTableAdapter.ClearBeforeFill = true;
            // 
            // AllDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 545);
            this.Controls.Add(this.gridControl1);
            this.Name = "AllDataForm";
            this.Text = "Производственная БД, Nifuda";
            this.Load += new System.EventHandler(this.AllData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nifudaDataTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nifudaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private ReportManager.Data.SAP.NifudaDataSet nifudaDataSet;
        private System.Windows.Forms.BindingSource nifudaDataTableBindingSource;
        private ReportManager.Data.SAP.NifudaDataSetTableAdapters.NifudaDataTableAdapter nifudaDataTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colMS_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn colMODEL;
        private DevExpress.XtraGrid.Columns.GridColumn colPROD_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colPROD_NO_SFIX;
        private DevExpress.XtraGrid.Columns.GridColumn colLINE_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colCRP_GR_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colPROD_CAREER;
        private DevExpress.XtraGrid.Columns.GridColumn colINDEX_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colTEST_CERT_SIGN;
        private DevExpress.XtraGrid.Columns.GridColumn colDOC_LANG_TYPE;
        private DevExpress.XtraGrid.Columns.GridColumn colINST_FINISH_D;
        private DevExpress.XtraGrid.Columns.GridColumn colTEST_CERT_YN;
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
        private DevExpress.XtraGrid.Columns.GridColumn colALLOWANCE_SIGN;
        private DevExpress.XtraGrid.Columns.GridColumn colPROD_N_J;
        private DevExpress.XtraGrid.Columns.GridColumn colPROD_N_E;
        private DevExpress.XtraGrid.Columns.GridColumn colTOKUCHU_SPEC_SIGN;
        private DevExpress.XtraGrid.Columns.GridColumn colSAP_LINKAGE_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colRANGE_INST_SIGN_500;
        private DevExpress.XtraGrid.Columns.GridColumn colORD_INST_MAX_500;
        private DevExpress.XtraGrid.Columns.GridColumn colORD_INST_MIN_500;
        private DevExpress.XtraGrid.Columns.GridColumn colUNIT_500;
        private DevExpress.XtraGrid.Columns.GridColumn colFEATURES_500;
        private DevExpress.XtraGrid.Columns.GridColumn colRANGE_INST_SIGN_502;
        private DevExpress.XtraGrid.Columns.GridColumn colORD_INST_MAX_502;
        private DevExpress.XtraGrid.Columns.GridColumn colORD_INST_MIN_502;
        private DevExpress.XtraGrid.Columns.GridColumn colUNIT_502;
        private DevExpress.XtraGrid.Columns.GridColumn colORD_INST_CONTECT1_W69;
        private DevExpress.XtraGrid.Columns.GridColumn colORD_INST_CONTECT1_X72;
        private DevExpress.XtraGrid.Columns.GridColumn colORD_INST_CONTECT1_X91;
        private DevExpress.XtraGrid.Columns.GridColumn colORD_INST_CONTECT1_Z30;
        private DevExpress.XtraGrid.Columns.GridColumn colTAG_NO_525;
        private DevExpress.XtraGrid.Columns.GridColumn colXJ_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colORD_INST_CONTECT1_H46;
        private DevExpress.XtraGrid.Columns.GridColumn colORD_INST_CONTECT1_X92;
        private DevExpress.XtraGrid.Columns.GridColumn colORD_INST_CONTECT1_Y28;
        private DevExpress.XtraGrid.Columns.GridColumn colORD_INST_CONTECT1_W35;
        private DevExpress.XtraGrid.Columns.GridColumn colORD_INST_CONTECT1_X78;
        private DevExpress.XtraGrid.Columns.GridColumn colORD_INST_CONTECT1_X94;
        private DevExpress.XtraGrid.Columns.GridColumn colCAP_NO;
    }
}
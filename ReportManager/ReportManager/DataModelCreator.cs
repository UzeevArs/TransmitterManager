using ReportManager.DataModel;
using ReportManager.Database.HipotDataTableTableAdapters;
using ReportManager.Database.CalibrationDataSetTableAdapters;
using ReportManager.Database.ISUPDataTableAdapters;
using System.Collections.Generic;
using ReportManager.Database.NifudaDataSetTableAdapters;

namespace ReportManager
{
    public static class DataModelCreator
    {

        public static DeviceModel GetDeviceFromOtherTable()
        {
            var deviceModel = new DeviceModel();
            ISUPNifudaDataTableAdapter iSUPNifudaDataTableAdapter = new ISUPNifudaDataTableAdapter();
            var dataSetISNifuda = iSUPNifudaDataTableAdapter.GetData();

            if (dataSetISNifuda.Count == 0)
            {
                deviceModel.InputData = new List<InputData> { new InputData { } };
            }
            else
            {
                deviceModel.InputData = new List<InputData>();
                foreach (var nifudaElement in dataSetISNifuda)
                {
                    deviceModel.InputData.Add(new InputData
                    {
                        AllowanceSign = nifudaElement.ALLOWANCE_SIGN,
                        CompNumber = nifudaElement.COMP_NO,
                        CrpGroupNumber = nifudaElement.CRP_GR_NO,
                        DocumentationLangType = nifudaElement.DOC_LANG_TYPE,
                        EndUserCustNJ = nifudaElement.END_USER_CUST_N_J,
                        Features_500 = nifudaElement.FEATURES_500,
                        FinishScheduleD = nifudaElement.FINISH_SCHDULE_D,
                        InstFinishD = nifudaElement.INST_FINISH_D,
                        IndexNumber = nifudaElement.INDEX_NO,
                        ItemNumber = nifudaElement.ITEM_NO,
                        LineNumber = nifudaElement.LINE_NO,
                        Model = nifudaElement.MODEL,
                        MsCode = nifudaElement.MS_CODE,
                        OrderInstContect1H46 = nifudaElement.ORD_INST_CONTECT1_H46,
                        OrderInstContect1W35 = nifudaElement.ORD_INST_CONTECT1_W35,
                        OrderInstContect1W69 = nifudaElement.ORD_INST_CONTECT1_W69,
                        OrderInstContect1X72 = nifudaElement.ORD_INST_CONTECT1_X72,
                        OrderInstContect1X78 = nifudaElement.ORD_INST_CONTECT1_X78,
                        OrderInstContect1X91 = nifudaElement.ORD_INST_CONTECT1_X91,
                        OrderInstContect1X92 = nifudaElement.ORD_INST_CONTECT1_X92,
                        OrderInstContect1X94 = nifudaElement.ORD_INST_CONTECT1_X94,
                        OrderInstContect1Y28 = nifudaElement.ORD_INST_CONTECT1_Y28,
                        OrderInstContect1Z30 = nifudaElement.ORD_INST_CONTECT1_Z30,
                        OrderInstMax_500 = nifudaElement.ORD_INST_MAX_500,
                        OrderInstMax_502 = nifudaElement.ORD_INST_MAX_502,
                        OrderInstMin_500 = nifudaElement.ORD_INST_MIN_500,
                        OrderInstMin_502 = nifudaElement.ORD_INST_MIN_502,
                        OrderNumber = nifudaElement.ORDER_NO,
                        ProductionCareer = nifudaElement.PROD_CAREER,
                        ProductionInstRevisionNumber = nifudaElement.PROD_INST_REV_NO,
                        ProductionItemRevisionNumber = nifudaElement.PROD_ITEM_REV_NO,
                        ProductionNumber = nifudaElement.PROD_NO,
                        ProductionNumberEnglish = nifudaElement.PROD_N_E,
                        ProductionNumberJapan = nifudaElement.PROD_N_J,
                        ProductionNumberSuffix = nifudaElement.PROD_NO_SFIX,
                        RangeInstSign_500 = nifudaElement.RANGE_INST_SIGN_500,
                        RangeInstSign_502 = nifudaElement.RANGE_INST_SIGN_502,
                        SapLinkageNumber = nifudaElement.SAP_LINKAGE_NO,
                        SerialNumber = nifudaElement.SERIAL_NO,
                        StartNumber = nifudaElement.START_NO,
                        StartScheduleD = nifudaElement.START_SCHDULE_D,
                        TagNumber_525 = nifudaElement.TAG_NO_525,
                        TestCertSign = nifudaElement.TEST_CERT_SIGN,
                        TestCertYn = nifudaElement.TEST_CERT_YN,
                        TokuchuSpecificationSign = nifudaElement.TOKUCHU_SPEC_SIGN,
                        Unit_500 = nifudaElement.UNIT_500,
                        Unit_502 = nifudaElement.UNIT_502,
                        XjNumber = nifudaElement.XJ_NO,
                        CapsuleNumber = nifudaElement.CAP_NO
                    });
                }
            }

            return deviceModel;
        }

        public static DeviceModel GetDeviceBySerial(SerialNumber serialNumber)
        {
            NifudaDataTableAdapter nifudaDataTableAdapter = new NifudaDataTableAdapter();
            var deviceModel = new DeviceModel() { SerialNumber = new List<SerialNumber> { serialNumber } };
            var dataSetNifuda = nifudaDataTableAdapter.GetDataBy(serialNumber.Serial);
            CalibrationDataTableAdapter calibrationDataTableAdapter = new CalibrationDataTableAdapter();
            var dataSetCalibrate = calibrationDataTableAdapter.GetDataBy(serialNumber.Serial);
            HipotDataTableAdapter hipotDataTableAdapter = new HipotDataTableAdapter();
            var dataSetHipot = hipotDataTableAdapter.GetDataBy(serialNumber.Serial);

            if (dataSetNifuda.Count == 0)
            {
                
                deviceModel.InputData = new List<InputData> { new InputData {AllowanceSign = "No Data",
                CompNumber = "No Data",
                CrpGroupNumber = "No Data",
                DocumentationLangType = "No Data",
                EndUserCustNJ = "No Data",
                Features_500 = "No Data",
                FinishScheduleD = "No Data",
                InstFinishD = "No Data",
                IndexNumber = "No Data",
                ItemNumber = "No Data",
                LineNumber = "No Data",
                Model = "No Data",
                MsCode = "No Data",
                OrderInstContect1H46 = "No Data",
                OrderInstContect1W35 = "No Data",
                OrderInstContect1W69 = "No Data",
                OrderInstContect1X72 = "No Data",
                OrderInstContect1X78 = "No Data",
                OrderInstContect1X91 = "No Data",
                OrderInstContect1X92 = "No Data",
                OrderInstContect1X94 = "No Data",
                OrderInstContect1Y28 = "No Data",
                OrderInstContect1Z30 = "No Data",
                OrderInstMax_500 = "No Data",
                OrderInstMax_502 = "No Data",
                OrderInstMin_500 = "No Data",
                OrderInstMin_502 = "No Data",
                OrderNumber = "No Data",
                ProductionCareer = "No Data",
                ProductionInstRevisionNumber = "No Data",
                ProductionItemRevisionNumber = "No Data",
                ProductionNumber = "No Data",
                ProductionNumberEnglish = "No Data",
                ProductionNumberJapan = "No Data",
                ProductionNumberSuffix = "No Data",
                RangeInstSign_500 = "No Data",
                RangeInstSign_502 = "No Data",
                SapLinkageNumber = "No Data",
                SerialNumber = "No Data",
                StartNumber = "No Data",
                StartScheduleD = "No Data",
                TagNumber_525 = "No Data",
                TestCertSign = "No Data",
                TestCertYn = "No Data",
                TokuchuSpecificationSign = "No Data",
                Unit_500 = "No Data",
                Unit_502 = "No Data",
                XjNumber = "No Data",
                CapsuleNumber = "No Data"} };
            }
            else
            {
                deviceModel.InputData = new List<InputData> { new InputData {
                AllowanceSign = dataSetNifuda[0].ALLOWANCE_SIGN,
                CompNumber = dataSetNifuda[0].COMP_NO,
                CrpGroupNumber = dataSetNifuda[0].CRP_GR_NO,
                DocumentationLangType = dataSetNifuda[0].DOC_LANG_TYPE,
                EndUserCustNJ = dataSetNifuda[0].END_USER_CUST_N_J,
                Features_500 = dataSetNifuda[0].FEATURES_500,
                FinishScheduleD = dataSetNifuda[0].FINISH_SCHDULE_D,
                InstFinishD = dataSetNifuda[0].INST_FINISH_D,
                IndexNumber = dataSetNifuda[0].INDEX_NO,
                ItemNumber = dataSetNifuda[0].ITEM_NO,
                LineNumber = dataSetNifuda[0].LINE_NO,
                Model = dataSetNifuda[0].MODEL,
                MsCode = dataSetNifuda[0].MS_CODE,
                OrderInstContect1H46 = dataSetNifuda[0].ORD_INST_CONTECT1_H46,
                OrderInstContect1W35 = dataSetNifuda[0].ORD_INST_CONTECT1_W35,
                OrderInstContect1W69 = dataSetNifuda[0].ORD_INST_CONTECT1_W69,
                OrderInstContect1X72 = dataSetNifuda[0].ORD_INST_CONTECT1_X72,
                OrderInstContect1X78 = dataSetNifuda[0].ORD_INST_CONTECT1_X78,
                OrderInstContect1X91 = dataSetNifuda[0].ORD_INST_CONTECT1_X91,
                OrderInstContect1X92 = dataSetNifuda[0].ORD_INST_CONTECT1_X92,
                OrderInstContect1X94 = dataSetNifuda[0].ORD_INST_CONTECT1_X94,
                OrderInstContect1Y28 = dataSetNifuda[0].ORD_INST_CONTECT1_Y28,
                OrderInstContect1Z30 = dataSetNifuda[0].ORD_INST_CONTECT1_Z30,
                OrderInstMax_500 = dataSetNifuda[0].ORD_INST_MAX_500,
                OrderInstMax_502 = dataSetNifuda[0].ORD_INST_MAX_502,
                OrderInstMin_500 = dataSetNifuda[0].ORD_INST_MIN_500,
                OrderInstMin_502 = dataSetNifuda[0].ORD_INST_MIN_502,
                OrderNumber = dataSetNifuda[0].ORDER_NO,
                ProductionCareer = dataSetNifuda[0].PROD_CAREER,
                ProductionInstRevisionNumber = dataSetNifuda[0].PROD_INST_REV_NO,
                ProductionItemRevisionNumber = dataSetNifuda[0].PROD_ITEM_REV_NO,
                ProductionNumber = dataSetNifuda[0].PROD_NO,
                ProductionNumberEnglish = dataSetNifuda[0].PROD_N_E,
                ProductionNumberJapan = dataSetNifuda[0].PROD_N_J,
                ProductionNumberSuffix = dataSetNifuda[0].PROD_NO_SFIX,
                RangeInstSign_500 = dataSetNifuda[0].RANGE_INST_SIGN_500,
                RangeInstSign_502 = dataSetNifuda[0].RANGE_INST_SIGN_502,
                SapLinkageNumber = dataSetNifuda[0].SAP_LINKAGE_NO,
                SerialNumber = dataSetNifuda[0].SERIAL_NO,
                StartNumber = dataSetNifuda[0].START_NO,
                StartScheduleD = dataSetNifuda[0].START_SCHDULE_D,
                TagNumber_525 = dataSetNifuda[0].TAG_NO_525,
                TestCertSign = dataSetNifuda[0].TEST_CERT_SIGN,
                TestCertYn = dataSetNifuda[0].TEST_CERT_YN,
                TokuchuSpecificationSign = dataSetNifuda[0].TOKUCHU_SPEC_SIGN,
                Unit_500 = dataSetNifuda[0].UNIT_500,
                Unit_502 = dataSetNifuda[0].UNIT_502,
                XjNumber = dataSetNifuda[0].XJ_NO,
                CapsuleNumber = dataSetNifuda[0].CAP_NO
            } };
            }
            
        

           // public static DeviceModel GetDeviceBySerialCalibrate(SerialNumber serialNumber)
        //{

            
            //var deviceModel = new DeviceModel() { SerialNumber = new List<SerialNumber> { serialNumber } };
            
            if (dataSetCalibrate.Count == 0)
            {
                deviceModel.CalibrationResults = new List<CalibrationResults> { new CalibrationResults { SerialNumberCalibration = "No Data",
                    AdjustScale_0 = "No Data",
                    AdjustScale_100 = "No Data",
                    AmplificationNumber = "No Data",
                    AtmospherePressure = "No Data",
                    Bar = "No Data",
                    Sqrt = "No Data",
                    XjNumber = "No Data",
                    BhcomVersion = "No Data",
                    CalibrationDate = "No Data",
                    CalibrationTime = "No Data",
                    CapsuleNumber = "No Data",
                    CrcxInitialisation = "No Data",
                    Damping = "No Data",
                    EjxMsCodeInitialisation = "No Data",
                    EthercomVersion = "No Data",
                    Eui64adrs = "No Data",
                    HartSelection = "No Data",
                    Humd = "No Data",
                    KmSerial1 = "No Data",
                    KmSerial2 = "No Data",
                    LineName = "No Data",
                    MessageDisplay = "No Data",
                    MsCode = "No Data",
                    OrderNumber = "No Data",
                    PresscontVersion = "No Data",
                    PressInitialisation = "No Data",
                    Qic = "No Data",
                    Range = "No Data",
                    Result = "No Data",
                    Soft = "No Data",
                    StartNumber = "No Data",
                    Stbl = "No Data",
                    Stn = "No Data",
                    Style = "No Data",
                    Tag = "No Data",
                    Temp = "No Data",
                    Version = "No Data",
                    Acc = "No Data",
                    Calut = "No Data",
                    Cal1 = "No Data",
                    Cal2 = "No Data",
                    Cal3 = "No Data",
                    Desut = "No Data",
                    Des1 = "No Data",
                    Des2 = "No Data",
                    Des3 = "No Data",
                    Dtinc1 = "No Data",
                    Dtinc2 = "No Data",
                    Dtinc3 = "No Data",
                    Dtdec1 = "No Data",
                    Dtdec2 = "No Data",
                    Dtdec3 = "No Data",
                    Convtut = "No Data",
                    Convt1 = "No Data",
                    Convt2 = "No Data",
                    Convt3 = "No Data",
                    Kminc1 = "No Data",
                    Kminc2 = "No Data",
                    Kminc3 = "No Data",
                    Kmdec1 = "No Data",
                    Kmdec2 = "No Data",
                    Kmdec3 = "No Data",
                    Cpinc1 = "No Data",
                    Cpinc2 = "No Data",
                    Cpinc3 = "No Data",
                    Cpdec1 = "No Data",
                    Cpdec2 = "No Data",
                    Cpdec3 = "No Data",
                    Atmn = "No Data",
                    Caltime = "No Data",
                    Zeror = "No Data",
                    Spanr = "No Data",
                    AdjUnit = "No Data",
                    WtMatl = "No Data",
                    FlSize = "No Data"

                } };
            }
            else
            {
                deviceModel.CalibrationResults = new List<CalibrationResults> { new CalibrationResults
                {

                    SerialNumberCalibration = dataSetCalibrate[0].SERIAL,
                    AdjustScale_0 = dataSetCalibrate[0].ADJ_V0,
                    AdjustScale_100 = dataSetCalibrate[0].ADJ_V100,
                    AmplificationNumber = dataSetCalibrate[0].AMPNO,
                    AtmospherePressure = dataSetCalibrate[0].ATMOSPHERE,
                    Bar = dataSetCalibrate[0].BAR,
                    Sqrt = dataSetCalibrate[0].SQRT,
                    XjNumber = dataSetCalibrate[0].XJNO,
                    BhcomVersion = dataSetCalibrate[0].BHCOM_VER,
                    CalibrationDate = dataSetCalibrate[0].CAL_DATE,
                    CalibrationTime = dataSetCalibrate[0].CAL_TIME,
                    CapsuleNumber = dataSetCalibrate[0].CAPNO,
                    CrcxInitialisation = dataSetCalibrate[0].CRCX_INI,
                    Damping = dataSetCalibrate[0].DAMPING,
                    EjxMsCodeInitialisation = dataSetCalibrate[0].EJXMSCODE_INI,
                    EthercomVersion = dataSetCalibrate[0].ETHERCOM_VER,
                    Eui64adrs = dataSetCalibrate[0].EUI64ADRS,
                    HartSelection = dataSetCalibrate[0].HARTSEL,
                    Humd = dataSetCalibrate[0].HUMD,
                    KmSerial1 = dataSetCalibrate[0].KMSERIAL1,
                    KmSerial2 = dataSetCalibrate[0].KMSERIAL2,
                    LineName = dataSetCalibrate[0].LINENAME,
                    MessageDisplay = dataSetCalibrate[0].MSGDISP,
                    MsCode = dataSetCalibrate[0].MSCODE,
                    OrderNumber = dataSetCalibrate[0].ORDERNO,
                    PresscontVersion = dataSetCalibrate[0].PRESSCONT_VER,
                    PressInitialisation = dataSetCalibrate[0].PRESS_INI,
                    Qic = dataSetCalibrate[0].QIC,
                    Range = dataSetCalibrate[0].RANGE,
                    Result = dataSetCalibrate[0].RESULT,
                    Soft = dataSetCalibrate[0].SOFT,
                    StartNumber = dataSetCalibrate[0].STARTNO,
                    Stbl = dataSetCalibrate[0].STBL,
                    Stn = dataSetCalibrate[0].STN,
                    Style = dataSetCalibrate[0].STYLE,
                    Tag = dataSetCalibrate[0].TAG,
                    Temp = dataSetCalibrate[0].TEMP,
                    Version = dataSetCalibrate[0].VERSION,
                    Acc = dataSetCalibrate[0].ACC,
                    Calut = dataSetCalibrate[0].CALUT,
                    Cal1 = dataSetCalibrate[0].CAL1,
                    Cal2 = dataSetCalibrate[0].CAL2,
                    Cal3 = dataSetCalibrate[0].CAL3,
                    Desut = dataSetCalibrate[0].DESUT,
                    Des1 = dataSetCalibrate[0].DES1,
                    Des2 = dataSetCalibrate[0].DES2,
                    Des3 = dataSetCalibrate[0].DES3,
                    Dtinc1 = dataSetCalibrate[0].DTINC1,
                    Dtinc2 = dataSetCalibrate[0].DTINC2,
                    Dtinc3 = dataSetCalibrate[0].DTINC3,
                    Dtdec1 = dataSetCalibrate[0].DTDEC1,
                    Dtdec2 = dataSetCalibrate[0].DTDEC2,
                    Dtdec3 = dataSetCalibrate[0].DTDEC3,
                    Convtut = dataSetCalibrate[0].CONVTUT,
                    Convt1 = dataSetCalibrate[0].CONVT1,
                    Convt2 = dataSetCalibrate[0].CONVT2,
                    Convt3 = dataSetCalibrate[0].CONVT3,
                    Kminc1 = dataSetCalibrate[0].KMINC1,
                    Kminc2 = dataSetCalibrate[0].KMINC2,
                    Kminc3 = dataSetCalibrate[0].KMINC3,
                    Kmdec1 = dataSetCalibrate[0].KMDEC1,
                    Kmdec2 = dataSetCalibrate[0].KMDEC2,
                    Kmdec3 = dataSetCalibrate[0].KMDEC3,
                    Cpinc1 = dataSetCalibrate[0].CPINC1,
                    Cpinc2 = dataSetCalibrate[0].CPINC2,
                    Cpinc3 = dataSetCalibrate[0].CPINC3,
                    Cpdec1 = dataSetCalibrate[0].CPDEC1,
                    Cpdec2 = dataSetCalibrate[0].CPDEC2,
                    Cpdec3 = dataSetCalibrate[0].CPDEC3,
                    Atmn = dataSetCalibrate[0].ATMN,
                    Caltime = dataSetCalibrate[0].CALTIME,
                    Zeror = dataSetCalibrate[0].ZEROR,
                    Spanr = dataSetCalibrate[0].SPANR,
                    AdjUnit = dataSetCalibrate[0].ADJUNIT,
                    WtMatl = dataSetCalibrate[0].WTMATL,
                    FlSize = dataSetCalibrate[0].FLSIZE

    } };
            }

            if (dataSetHipot.Count == 0)
            {
                deviceModel.DeviceTestResults = new List<DeviceTestResult> { new DeviceTestResult {
                    SerialNumberHipot = "No Data",
                    Result = "No Data",
                    IsolationV = "No Data",
                    IsolationR = "No Data",
                    IsolationT = "No Data",
                    IResult = "No Data",
                    WithStandV = "No Data",
                    WithStandI = "No Data",
                    WithStandT = "No Data",
                    WResult = "No Data",
                    TestDate = "No Data",
                    TestTime = "No Data",
                    TUser = "No Data"} };
            }
            else
            {
                deviceModel.DeviceTestResults = new List<DeviceTestResult> { new DeviceTestResult
                {
                    SerialNumberHipot = dataSetHipot[0].SERIAL,
                    Result = dataSetHipot[0].RESULT,
                    IsolationV = dataSetHipot[0].ISOLATION_V.ToString(),
                    IsolationR = dataSetHipot[0].ISOLATION_R.ToString(),
                    IsolationT = dataSetHipot[0].ISOLATION_T.ToString(),
                    IResult = dataSetHipot[0].IRESULT,
                    WithStandV = dataSetHipot[0].WITHSTAND_V.ToString(),
                    WithStandI = dataSetHipot[0].WITHSTAND_I.ToString(),
                    WithStandT = dataSetHipot[0].WITHSTAND_T.ToString(),
                    WResult = dataSetHipot[0].WRESULT,
                    TestDate = dataSetHipot[0].TEST_DATE,
                    TestTime = dataSetHipot[0].TEST_TIME,
                    TUser = dataSetHipot[0].TUSER
    } };
            }

            return deviceModel;
        }
    }
    }


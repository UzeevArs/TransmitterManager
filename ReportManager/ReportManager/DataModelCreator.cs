using ReportManager.DataModel;
using ReportManager.NifudaDataSetTableAdapters;
using ReportManager.HipotDataTableTableAdapters;
using ReportManager.CalibrationDataSetTableAdapters;
using System.Collections.Generic;

namespace ReportManager
{
    public static class DataModelCreator
    {
        public static DeviceModel GetDeviceBySerial(SerialNumber serialNumber)
        {
            NifudaDataTableAdapter nifudaDataTableAdapter = new NifudaDataTableAdapter();
            var deviceModel = new DeviceModel() { SerialNumber = new List<SerialNumber> { serialNumber } };
            var dataSetNiduda = nifudaDataTableAdapter.GetDataBy(serialNumber.Serial);

            CalibrationDataTableAdapter calibrationDataTableAdapter = new CalibrationDataTableAdapter();
            var dataSetCalibrate = calibrationDataTableAdapter.GetDataBy(serialNumber.Serial);

            HipotDataTableAdapter hipotDataTableAdapter = new HipotDataTableAdapter();
            var dataSetHipot = hipotDataTableAdapter.GetDataBy(serialNumber.Serial);

            if (dataSetNiduda.Count == 0)
            {
                deviceModel.InputData = new List<InputData> { new InputData { } };
            }
            else
            {
                deviceModel.InputData = new List<InputData> { new InputData {
                AllowanceSign = dataSetNiduda[0].ALLOWANCE_SIGN,
                CompNumber = dataSetNiduda[0].COMP_NO,
                CrpGroupNumber = dataSetNiduda[0].CRP_GR_NO,
                DocumentationLangType = dataSetNiduda[0].DOC_LANG_TYPE,
                EndUserCustNJ = dataSetNiduda[0].END_USER_CUST_N_J,
                Features_500 = dataSetNiduda[0].FEATURES_500,
                FinishScheduleD = dataSetNiduda[0].FINISH_SCHDULE_D,
                InstFinishD = dataSetNiduda[0].INST_FINISH_D,
                IndexNumber = dataSetNiduda[0].INDEX_NO,
                ItemNumber = dataSetNiduda[0].ITEM_NO,
                LineNumber = dataSetNiduda[0].LINE_NO,
                Model = dataSetNiduda[0].MODEL,
                MsCode = dataSetNiduda[0].MS_CODE,
                OrderInstContect1H46 = dataSetNiduda[0].ORD_INST_CONTECT1_H46,
                OrderInstContect1W35 = dataSetNiduda[0].ORD_INST_CONTECT1_W35,
                OrderInstContect1W69 = dataSetNiduda[0].ORD_INST_CONTECT1_W69,
                OrderInstContect1X72 = dataSetNiduda[0].ORD_INST_CONTECT1_X72,
                OrderInstContect1X78 = dataSetNiduda[0].ORD_INST_CONTECT1_X78,
                OrderInstContect1X91 = dataSetNiduda[0].ORD_INST_CONTECT1_X91,
                OrderInstContect1X92 = dataSetNiduda[0].ORD_INST_CONTECT1_X92,
                OrderInstContect1X94 = dataSetNiduda[0].ORD_INST_CONTECT1_X94,
                OrderInstContect1Y28 = dataSetNiduda[0].ORD_INST_CONTECT1_Y28,
                OrderInstContect1Z30 = dataSetNiduda[0].ORD_INST_CONTECT1_Z30,
                OrderInstMax_500 = dataSetNiduda[0].ORD_INST_MAX_500,
                OrderInstMax_502 = dataSetNiduda[0].ORD_INST_MAX_502,
                OrderInstMin_500 = dataSetNiduda[0].ORD_INST_MIN_500,
                OrderInstMin_502 = dataSetNiduda[0].ORD_INST_MIN_502,
                OrderNumber = dataSetNiduda[0].ORDER_NO,
                ProductionCareer = dataSetNiduda[0].PROD_CAREER,
                ProductionInstRevisionNumber = dataSetNiduda[0].PROD_INST_REV_NO,
                ProductionItemRevisionNumber = dataSetNiduda[0].PROD_ITEM_REV_NO,
                ProductionNumber = dataSetNiduda[0].PROD_NO,
                ProductionNumberEnglish = dataSetNiduda[0].PROD_N_E,
                ProductionNumberJapan = dataSetNiduda[0].PROD_N_J,
                ProductionNumberSuffix = dataSetNiduda[0].PROD_NO_SFIX,
                RangeInstSign_500 = dataSetNiduda[0].RANGE_INST_SIGN_500,
                RangeInstSign_502 = dataSetNiduda[0].RANGE_INST_SIGN_502,
                SapLinkageNumber = dataSetNiduda[0].SAP_LINKAGE_NO,
                SerialNumber = dataSetNiduda[0].SERIAL_NO,
                StartNumber = dataSetNiduda[0].START_NO,
                StartScheduleD = dataSetNiduda[0].START_SCHDULE_D,
                TagNumber_525 = dataSetNiduda[0].TAG_NO_525,
                TestCertSign = dataSetNiduda[0].TEST_CERT_SIGN,
                TestCertYn = dataSetNiduda[0].TEST_CERT_YN,
                TokuchuSpecificationSign = dataSetNiduda[0].TOKUCHU_SPEC_SIGN,
                Unit_500 = dataSetNiduda[0].UNIT_500,
                Unit_502 = dataSetNiduda[0].UNIT_502,
                XjNumber = dataSetNiduda[0].XJ_NO,
                CapsuleNumber = dataSetNiduda[0].CAP_NO
            } };
            }

            if (dataSetCalibrate.Count == 0)
            {
                deviceModel.CalibrationResults = new List<CalibrationResults>{ new CalibrationResults { } };
            }
            else
            {
                deviceModel.CalibrationResults = new List<CalibrationResults> { new CalibrationResults
                {
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
                } };
            }
            if (dataSetHipot.Count == 0)
            {
                deviceModel.DeviceTestResults = new List<DeviceTestResult> { new DeviceTestResult { } };
            }
            else
            {
                deviceModel.DeviceTestResults = new List<DeviceTestResult> { new DeviceTestResult
                {
                    Result = dataSetHipot[0].RESULT
                } };
            }

            return deviceModel;
        }
    }
}

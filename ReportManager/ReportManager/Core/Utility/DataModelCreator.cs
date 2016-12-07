using System.Collections.Generic;
using System.Globalization;
using ReportManager.Data.Database;
using ReportManager.Data.Database.CalibrationDataSetTableAdapters;
using ReportManager.Data.Database.HipotDataTableTableAdapters;
using ReportManager.Data.Database.ISUPDataTableAdapters;
using ReportManager.Data.Database.NifudaDataSetTableAdapters;
using ReportManager.Data.Database.MaxigrafDataSetTableAdapters;
using ReportManager.Data.Database.UsersDataSetTableAdapters;
using ReportManager.Data.DataModel;
using ReportManager.Data.Settings;
using System.Linq;

namespace ReportManager.Core.Utility
{
    public static class DataModelCreator
    {
        public static DeviceModel GetDeviceFromOtherTable(ISUPNifudaDataTableAdapter adapter)
        {
            var deviceModel = new DeviceModel();
            
            var dataSetIsNifuda = adapter.GetData();

            if (dataSetIsNifuda.Count == 0)
            {
                deviceModel.InputData = new List<InputData> { new InputData() };
            }
            else
            {
                deviceModel.InputData = new List<InputData>();
                foreach (var nifudaElement in dataSetIsNifuda)
                {
                    deviceModel.InputData.Add(new InputData
                    {
                        ALLOWANCE_SIGN = nifudaElement.ALLOWANCE_SIGN,
                        COMP_NO = nifudaElement.COMP_NO,
                        CRP_GR_NO = nifudaElement.CRP_GR_NO,
                        DOC_LANG_TYPE = nifudaElement.DOC_LANG_TYPE,
                        END_USER_CUST_N_J = nifudaElement.END_USER_CUST_N_J,
                        FEATURES_500 = nifudaElement.FEATURES_500,
                        FINISH_SCHDULE_D = nifudaElement.FINISH_SCHDULE_D,
                        INST_FINISH_D = nifudaElement.INST_FINISH_D,
                        INDEX_NO = nifudaElement.INDEX_NO,
                        ITEM_NO = nifudaElement.ITEM_NO,
                        LINE_NO = nifudaElement.LINE_NO,
                        MODEL = nifudaElement.MODEL,
                        MS_CODE = nifudaElement.MS_CODE,
                        ORD_INST_CONTECT1_H46 = nifudaElement.ORD_INST_CONTECT1_H46,
                        ORD_INST_CONTECT1_W35 = nifudaElement.ORD_INST_CONTECT1_W35,
                        ORD_INST_CONTECT1_W69 = nifudaElement.ORD_INST_CONTECT1_W69,
                        ORD_INST_CONTECT1_X72 = nifudaElement.ORD_INST_CONTECT1_X72,
                        ORD_INST_CONTECT1_X78 = nifudaElement.ORD_INST_CONTECT1_X78,
                        ORD_INST_CONTECT1_X91 = nifudaElement.ORD_INST_CONTECT1_X91,
                        ORD_INST_CONTECT1_X92 = nifudaElement.ORD_INST_CONTECT1_X92,
                        ORD_INST_CONTECT1_X94 = nifudaElement.ORD_INST_CONTECT1_X94,
                        ORD_INST_CONTECT1_Y28 = nifudaElement.ORD_INST_CONTECT1_Y28,
                        ORD_INST_CONTECT1_Z30 = nifudaElement.ORD_INST_CONTECT1_Z30,
                        ORD_INST_MAX_500 = nifudaElement.ORD_INST_MAX_500,
                        ORD_INST_MAX_502 = nifudaElement.ORD_INST_MAX_502,
                        ORD_INST_MIN_500 = nifudaElement.ORD_INST_MIN_500,
                        ORD_INST_MIN_502 = nifudaElement.ORD_INST_MIN_502,
                        ORDER_NO = nifudaElement.ORDER_NO,
                        PROD_CAREER = nifudaElement.PROD_CAREER,
                        PROD_INST_REV_NO = nifudaElement.PROD_INST_REV_NO,
                        PROD_ITEM_REV_NO = nifudaElement.PROD_ITEM_REV_NO,
                        PROD_NO = nifudaElement.PROD_NO,
                        PROD_N_E = nifudaElement.PROD_N_E,
                        PROD_N_J = nifudaElement.PROD_N_J,
                        PROD_NO_SFIX = nifudaElement.PROD_NO_SFIX,
                        RANGE_INST_SIGN_500 = nifudaElement.RANGE_INST_SIGN_500,
                        RANGE_INST_SIGN_502 = nifudaElement.RANGE_INST_SIGN_502,
                        SAP_LINKAGE_NO = nifudaElement.SAP_LINKAGE_NO,
                        SERIAL_NO = nifudaElement.SERIAL_NO,
                        START_NO = nifudaElement.START_NO,
                        START_SCHDULE_D = nifudaElement.START_SCHDULE_D,
                        TAG_NO_525 = nifudaElement.TAG_NO_525,
                        TEST_CERT_SIGN = nifudaElement.TEST_CERT_SIGN,
                        TEST_CERT_YN = nifudaElement.TEST_CERT_YN,
                        TOKUCHU_SPEC_SIGN = nifudaElement.TOKUCHU_SPEC_SIGN,
                        UNIT_500 = nifudaElement.UNIT_500,
                        UNIT_502 = nifudaElement.UNIT_502,
                        XJ_NO = nifudaElement.XJ_NO,
                        CAP_NO = nifudaElement.CAP_NO
                    });
                }
            }

            return deviceModel;
        }

        public static DeviceModel GetDeviceBySerial(SerialNumber serialNumber)
        {
            var nifudaDataTableAdapter = new NifudaDataTableAdapter
            {
                Connection = { ConnectionString = SettingsContext.GlobalSettings.NifudaConnectionString }
            };
            var deviceModel = new DeviceModel { SerialNumber = new List<SerialNumber> { serialNumber } };
            
            var dataSetNifuda = nifudaDataTableAdapter.GetDataBy(serialNumber.Serial);

            var calibrationDataTableAdapter = new CalibrationDataTableAdapter
            {
                Connection = { ConnectionString = SettingsContext.GlobalSettings.NifudaConnectionString }
            };
            var dataSetCalibrate = calibrationDataTableAdapter.GetDataBy(serialNumber.Serial);

            var hipotDataTableAdapter = new HipotDataTableAdapter
            {
                Connection = { ConnectionString = SettingsContext.GlobalSettings.NifudaConnectionString }
            };
            var dataSetHipot = hipotDataTableAdapter.GetDataBy(serialNumber.Serial);

            var maxiGrafPlatesSettingTableAdapter = new MaxiGrafPlatesSettingTableAdapter { };
            var maxiGrafPlatesTableAdapter = new MaxiGrafPlatesTableAdapter { };

            var dataSetMaxiGrafPlates = maxiGrafPlatesTableAdapter.GetDataBy();
            var dataSetMaxiGrafPlatesSettings = maxiGrafPlatesSettingTableAdapter.GetDataBy();




            CheckNifudaDataTable(deviceModel, dataSetNifuda);
            CheckCalibrationDataTable(deviceModel, dataSetCalibrate);
            CheckHipotDataTable(deviceModel, dataSetHipot);
            

            return deviceModel;
        }

        private static void CheckNifudaDataTable(DeviceModel deviceModel, 
                                                 NifudaDataSet.NifudaDataTableDataTable dataSetNifuda)
        {
            if (dataSetNifuda.Count == 0)
            {
                var datasetnifuda = new InputData();
                foreach (var datamember in typeof(InputData).GetProperties())
                    datamember.SetValue(datasetnifuda, "No Data", null);
                deviceModel.InputData = new List<InputData> { datasetnifuda };
                      

            }
            else
            {
                deviceModel.InputData = new List<InputData> { new InputData {
                ALLOWANCE_SIGN = dataSetNifuda[0].ALLOWANCE_SIGN,
                COMP_NO = dataSetNifuda[0].COMP_NO,
                CRP_GR_NO = dataSetNifuda[0].CRP_GR_NO,
                DOC_LANG_TYPE = dataSetNifuda[0].DOC_LANG_TYPE,
                END_USER_CUST_N_J = dataSetNifuda[0].END_USER_CUST_N_J,
                FEATURES_500 = dataSetNifuda[0].FEATURES_500,
                FINISH_SCHDULE_D = dataSetNifuda[0].FINISH_SCHDULE_D,
                INST_FINISH_D = dataSetNifuda[0].INST_FINISH_D,
                INDEX_NO = dataSetNifuda[0].INDEX_NO,
                ITEM_NO = dataSetNifuda[0].ITEM_NO,
                LINE_NO = dataSetNifuda[0].LINE_NO,
                MODEL = dataSetNifuda[0].MODEL,
                MS_CODE = dataSetNifuda[0].MS_CODE,
                ORD_INST_CONTECT1_H46 = dataSetNifuda[0].ORD_INST_CONTECT1_H46,
                ORD_INST_CONTECT1_W35 = dataSetNifuda[0].ORD_INST_CONTECT1_W35,
                ORD_INST_CONTECT1_W69 = dataSetNifuda[0].ORD_INST_CONTECT1_W69,
                ORD_INST_CONTECT1_X72 = dataSetNifuda[0].ORD_INST_CONTECT1_X72,
                ORD_INST_CONTECT1_X78 = dataSetNifuda[0].ORD_INST_CONTECT1_X78,
                ORD_INST_CONTECT1_X91 = dataSetNifuda[0].ORD_INST_CONTECT1_X91,
                ORD_INST_CONTECT1_X92 = dataSetNifuda[0].ORD_INST_CONTECT1_X92,
                ORD_INST_CONTECT1_X94 = dataSetNifuda[0].ORD_INST_CONTECT1_X94,
                ORD_INST_CONTECT1_Y28 = dataSetNifuda[0].ORD_INST_CONTECT1_Y28,
                ORD_INST_CONTECT1_Z30 = dataSetNifuda[0].ORD_INST_CONTECT1_Z30,
                ORD_INST_MAX_500 = dataSetNifuda[0].ORD_INST_MAX_500,
                ORD_INST_MAX_502 = dataSetNifuda[0].ORD_INST_MAX_502,
                ORD_INST_MIN_500 = dataSetNifuda[0].ORD_INST_MIN_500,
                ORD_INST_MIN_502 = dataSetNifuda[0].ORD_INST_MIN_502,
                ORDER_NO = dataSetNifuda[0].ORDER_NO,
                PROD_CAREER = dataSetNifuda[0].PROD_CAREER,
                PROD_INST_REV_NO = dataSetNifuda[0].PROD_INST_REV_NO,
                PROD_ITEM_REV_NO = dataSetNifuda[0].PROD_ITEM_REV_NO,
                PROD_NO = dataSetNifuda[0].PROD_NO,
                PROD_N_E = dataSetNifuda[0].PROD_N_E,
                PROD_N_J = dataSetNifuda[0].PROD_N_J,
                PROD_NO_SFIX = dataSetNifuda[0].PROD_NO_SFIX,
                RANGE_INST_SIGN_500 = dataSetNifuda[0].RANGE_INST_SIGN_500,
                RANGE_INST_SIGN_502 = dataSetNifuda[0].RANGE_INST_SIGN_502,
                SAP_LINKAGE_NO = dataSetNifuda[0].SAP_LINKAGE_NO,
                SERIAL_NO = dataSetNifuda[0].SERIAL_NO,
                START_NO = dataSetNifuda[0].START_NO,
                START_SCHDULE_D = dataSetNifuda[0].START_SCHDULE_D,
                TAG_NO_525 = dataSetNifuda[0].TAG_NO_525,
                TEST_CERT_SIGN = dataSetNifuda[0].TEST_CERT_SIGN,
                TEST_CERT_YN = dataSetNifuda[0].TEST_CERT_YN,
                TOKUCHU_SPEC_SIGN = dataSetNifuda[0].TOKUCHU_SPEC_SIGN,
                UNIT_500 = dataSetNifuda[0].UNIT_500,
                UNIT_502 = dataSetNifuda[0].UNIT_502,
                XJ_NO = dataSetNifuda[0].XJ_NO,
                CAP_NO = dataSetNifuda[0].CAP_NO } };
            }
        }

        private static void CheckCalibrationDataTable(DeviceModel deviceModel, 
                                                      CalibrationDataSet.CalibrationDataTableDataTable dataSetCalibrate)
        {
            if (dataSetCalibrate.Count == 0)
            {
                var calibrationResults = new CalibrationResults();
                foreach (var member in typeof(CalibrationResults).GetProperties())
                    member.SetValue(calibrationResults, "No Data", null);
                deviceModel.CalibrationResults = new List<CalibrationResults> { calibrationResults };
            }
            else
            {

//Сделать рефлекцию, для этогонужно переименовать поля и внедрить template отчётов в проект



                deviceModel.CalibrationResults = new List<CalibrationResults> { new CalibrationResults
                {
                    SERIAL = dataSetCalibrate[0].SERIAL,
                    ADJ_V0 = dataSetCalibrate[0].ADJ_V0,
                    ADJ_V100 = dataSetCalibrate[0].ADJ_V100,
                    AMPNO = dataSetCalibrate[0].AMPNO,
                    ATMOSPHERE = dataSetCalibrate[0].ATMOSPHERE,
                    BAR = dataSetCalibrate[0].BAR,
                    SQRT = dataSetCalibrate[0].SQRT,
                    XJNO = dataSetCalibrate[0].XJNO,
                    BHCOM_VER = dataSetCalibrate[0].BHCOM_VER,
                    CAL_DATE = dataSetCalibrate[0].CAL_DATE,
                    CAL_TIME = dataSetCalibrate[0].CAL_TIME,
                    CAPNO = dataSetCalibrate[0].CAPNO,
                    CRCX_INI = dataSetCalibrate[0].CRCX_INI,
                    DAMPING = dataSetCalibrate[0].DAMPING,
                    EJXMSCODE_INI = dataSetCalibrate[0].EJXMSCODE_INI,
                    ETHERCOM_VER = dataSetCalibrate[0].ETHERCOM_VER,
                    EUI64ADRS = dataSetCalibrate[0].EUI64ADRS,
                    HARTSEL = dataSetCalibrate[0].HARTSEL,
                    HUMD = dataSetCalibrate[0].HUMD,
                    KMSERIAL1 = dataSetCalibrate[0].KMSERIAL1,
                    KMSERIAL2 = dataSetCalibrate[0].KMSERIAL2,
                    LINENAME = dataSetCalibrate[0].LINENAME,
                    MSGDISP = dataSetCalibrate[0].MSGDISP,
                    MSCODE = dataSetCalibrate[0].MSCODE,
                    ORDERNO = dataSetCalibrate[0].ORDERNO,
                    PRESSCONT_VER = dataSetCalibrate[0].PRESSCONT_VER,
                    PRESS_INI = dataSetCalibrate[0].PRESS_INI,
                    QIC = dataSetCalibrate[0].QIC,
                    RANGE = dataSetCalibrate[0].RANGE,
                    RESULT = dataSetCalibrate[0].RESULT,
                    SOFT = dataSetCalibrate[0].SOFT,
                    STARTNO = dataSetCalibrate[0].STARTNO,
                    STBL = dataSetCalibrate[0].STBL,
                    STN = dataSetCalibrate[0].STN,
                    STYLE = dataSetCalibrate[0].STYLE,
                    TAG = dataSetCalibrate[0].TAG,
                    TEMP = dataSetCalibrate[0].TEMP,
                    VERSION = dataSetCalibrate[0].VERSION,
                    ACC = dataSetCalibrate[0].ACC,
                    CALUT = dataSetCalibrate[0].CALUT,
                    CAL1 = dataSetCalibrate[0].CAL1,
                    CAL2 = dataSetCalibrate[0].CAL2,
                    CAL3 = dataSetCalibrate[0].CAL3,
                    CAL4 = dataSetCalibrate[0].CAL4,
                    CAL5 = dataSetCalibrate[0].CAL5,
                    CAL6 = dataSetCalibrate[0].CAL6,
                    CAL7 = dataSetCalibrate[0].CAL7,
                    DESUT = dataSetCalibrate[0].DESUT,
                    DES1 = dataSetCalibrate[0].DES1,
                    DES2 = dataSetCalibrate[0].DES2,
                    DES3 = dataSetCalibrate[0].DES3,
                    DES4 = dataSetCalibrate[0].DES4,
                    DES5 = dataSetCalibrate[0].DES5,
                    DES6 = dataSetCalibrate[0].DES6,
                    DES7 = dataSetCalibrate[0].DES7,
                    DTINC1 = dataSetCalibrate[0].DTINC1,
                    DTINC2 = dataSetCalibrate[0].DTINC2,
                    DTINC3 = dataSetCalibrate[0].DTINC3,
                    DTINC4 = dataSetCalibrate[0].DTINC4,
                    DTINC5 = dataSetCalibrate[0].DTINC5,
                    DTINC6 = dataSetCalibrate[0].DTINC6,
                    DTINC7 = dataSetCalibrate[0].DTINC7,
                    DTDEC1 = dataSetCalibrate[0].DTDEC1,
                    DTDEC2 = dataSetCalibrate[0].DTDEC2,
                    DTDEC3 = dataSetCalibrate[0].DTDEC3,
                    DTDEC4 = dataSetCalibrate[0].DTDEC4,
                    DTDEC5 = dataSetCalibrate[0].DTDEC5,
                    DTDEC6 = dataSetCalibrate[0].DTDEC6,
                    DTDEC7 = dataSetCalibrate[0].DTDEC7,
                    CONVTUT = dataSetCalibrate[0].CONVTUT,
                    CONVT1 = dataSetCalibrate[0].CONVT1,
                    CONVT2 = dataSetCalibrate[0].CONVT2,
                    CONVT3 = dataSetCalibrate[0].CONVT3,
                    CONVT4 = dataSetCalibrate[0].CONVT4,
                    CONVT5 = dataSetCalibrate[0].CONVT5,
                    CONVT6 = dataSetCalibrate[0].CONVT6,
                    CONVT7 = dataSetCalibrate[0].CONVT7,
                    KMINC1 = dataSetCalibrate[0].KMINC1,
                    KMINC2 = dataSetCalibrate[0].KMINC2,
                    KMINC3 = dataSetCalibrate[0].KMINC3,
                    KMINC4 = dataSetCalibrate[0].KMINC4,
                    KMINC5 = dataSetCalibrate[0].KMINC5,
                    KMINC6 = dataSetCalibrate[0].KMINC6,
                    KMINC7 = dataSetCalibrate[0].KMINC7,
                    KMDEC1 = dataSetCalibrate[0].KMDEC1,
                    KMDEC2 = dataSetCalibrate[0].KMDEC2,
                    KMDEC3 = dataSetCalibrate[0].KMDEC3,
                    KMDEC4 = dataSetCalibrate[0].KMDEC4,
                    KMDEC5 = dataSetCalibrate[0].KMDEC5,
                    KMDEC6 = dataSetCalibrate[0].KMDEC6,
                    KMDEC7 = dataSetCalibrate[0].KMDEC7,
                    CPINC1 = dataSetCalibrate[0].CPINC1,
                    CPINC2 = dataSetCalibrate[0].CPINC2,
                    CPINC3 = dataSetCalibrate[0].CPINC3,
                    CPINC4 = dataSetCalibrate[0].CPINC4,
                    CPINC5 = dataSetCalibrate[0].CPINC5,
                    CPINC6 = dataSetCalibrate[0].CPINC6,
                    CPINC7 = dataSetCalibrate[0].CPINC7,
                    CPDEC1 = dataSetCalibrate[0].CPDEC1,
                    CPDEC2 = dataSetCalibrate[0].CPDEC2,
                    CPDEC3 = dataSetCalibrate[0].CPDEC3,
                    CPDEC4 = dataSetCalibrate[0].CPDEC4,
                    CPDEC5 = dataSetCalibrate[0].CPDEC5,
                    CPDEC6 = dataSetCalibrate[0].CPDEC6,
                    CPDEC7 = dataSetCalibrate[0].CPDEC7,
                    ATMN = dataSetCalibrate[0].ATMN,
                    CALTIME = dataSetCalibrate[0].CALTIME,
                    ZEROR = dataSetCalibrate[0].ZEROR,
                    SPANR = dataSetCalibrate[0].SPANR,
                    ADJUNIT = dataSetCalibrate[0].ADJUNIT,
                    WTMATL = dataSetCalibrate[0].WTMATL,
                    FLSIZE = dataSetCalibrate[0].FLSIZE,
                    ACC2 = dataSetCalibrate[0].ACC2,
                    TUSER = dataSetCalibrate[0].TUSER} };
            }
        }

        private static void CheckHipotDataTable(DeviceModel deviceModel,
                                                Data.Database.HipotDataTable.HipotDataTableDataTable dataSetHipot)
        {
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
                    TUser = "No Data" } };
            }
            else
            {
                deviceModel.DeviceTestResults = new List<DeviceTestResult> { new DeviceTestResult {
                    SerialNumberHipot = dataSetHipot[0].SERIAL,
                    Result = dataSetHipot[0].RESULT,
                    IsolationV = dataSetHipot[0].ISOLATION_V.ToString(CultureInfo.InvariantCulture),
                    IsolationR = dataSetHipot[0].ISOLATION_R.ToString(CultureInfo.InvariantCulture),
                    IsolationT = dataSetHipot[0].ISOLATION_T.ToString(CultureInfo.InvariantCulture),
                    IResult = dataSetHipot[0].IRESULT,
                    WithStandV = dataSetHipot[0].WITHSTAND_V.ToString(CultureInfo.InvariantCulture),
                    WithStandI = dataSetHipot[0].WITHSTAND_I.ToString(CultureInfo.InvariantCulture),
                    WithStandT = dataSetHipot[0].WITHSTAND_T.ToString(CultureInfo.InvariantCulture),
                    WResult = dataSetHipot[0].WRESULT,
                    TestDate = dataSetHipot[0].TEST_DATE,
                    TestTime = dataSetHipot[0].TEST_TIME,
                    TUser = dataSetHipot[0].TUSER } };
            }
        }



 
    }
}
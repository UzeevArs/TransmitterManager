using ReportManager.DataModel;
using ReportManager.NifudaDataSetTableAdapters;
using System.Collections.Generic;

namespace ReportManager
{
    public static class DataModelCreator
    {
        public static DeviceModel GetDeviceBySerial(SerialNumber serialNumber)
        {
            ReportDataTableAdapter dataTable1TableAdapter = new ReportDataTableAdapter();
            var deviceModel = new DeviceModel() { SerialNumber = new List<SerialNumber> { serialNumber } };
            var dataSet = dataTable1TableAdapter.GetDataBy(serialNumber.Serial);

            if (dataSet.Count == 0) return null;

            deviceModel.InputData = new List<InputData> { new InputData {
                AllowanceSign = dataSet[0].ALLOWANCE_SIGN,
                CompNumber = dataSet[0].COMP_NO,
                CrpGroupNumber = dataSet[0].CRP_GR_NO,
                DocumentationLangType = dataSet[0].DOC_LANG_TYPE,
                EndUserCustNJ = dataSet[0].END_USER_CUST_N_J,
                Features_500 = dataSet[0].FEATURES_500,
                FinishScheduleD = dataSet[0].FINISH_SCHDULE_D,
                InstFinishD = dataSet[0].INST_FINISH_D,
                ItemNumber = dataSet[0].ITEM_NO,
                LineNumber = dataSet[0].LINE_NO,
                Model = dataSet[0].MODEL,
                MsCode = dataSet[0].MSCODE,
                OrderInstContect1H46 = dataSet[0].ORD_INST_CONTECT1_H46,
                OrderInstContect1W35 = dataSet[0].ORD_INST_CONTECT1_W35,
                OrderInstContect1W69 = dataSet[0].ORD_INST_CONTECT1_W69,
                OrderInstContect1X72 = dataSet[0].ORD_INST_CONTECT1_X72,
                OrderInstContect1X78 = dataSet[0].ORD_INST_CONTECT1_X78,
                OrderInstContect1X91 = dataSet[0].ORD_INST_CONTECT1_X91,
                OrderInstContect1X92 = dataSet[0].ORD_INST_CONTECT1_X92,
                OrderInstContect1X94 = dataSet[0].ORD_INST_CONTECT1_X94,
                OrderInstContect1Y28 = dataSet[0].ORD_INST_CONTECT1_Y28,
                OrderInstContect1Z30 = dataSet[0].ORD_INST_CONTECT1_Z30,
                OrderInstMax_500 = dataSet[0].ORD_INST_MAX_500,
                OrderInstMax_502 = dataSet[0].ORD_INST_MAX_502,
                OrderInstMin_500 = dataSet[0].ORD_INST_MIN_500,
                OrderInstMin_502 = dataSet[0].ORD_INST_MIN_502,
                OrderNumber = dataSet[0].ORDER_NO,
                ProductionCareer = dataSet[0].PROD_CAREER,
                ProductionInstRevisionNumber = dataSet[0].PROD_INST_REV_NO,
                ProductionItemRevisionNumber = dataSet[0].PROD_ITEM_REV_NO,
                ProductionNumber = dataSet[0].PROD_NO,
                ProductionNumberEnglish = dataSet[0].PROD_N_E,
                ProductionNumberJapan = dataSet[0].PROD_N_J,
                ProductionNumberSuffix = dataSet[0].PROD_NO_SFIX,
                RangeInstSign_500 = dataSet[0].RANGE_INST_SIGN_500,
                RangeInstSign_502 = dataSet[0].RANGE_INST_SIGN_502,
                SapLinkageNumber = dataSet[0].SAP_LINKAGE_NO,
                SerialNumber = dataSet[0].SERIAL_NO,
                StartNumber = dataSet[0].START_NO,
                StartScheduleD = dataSet[0].START_SCHDULE_D,
                TagNumber_525 = dataSet[0].TAG_NO_525,
                TestCertSign = dataSet[0].TEST_CERT_SIGN,
                TestCertYn = dataSet[0].TEST_CERT_YN,
                TokuchuSpecificationSign = dataSet[0].TOKUCHU_SPEC_SIGN,
                Unit_500 = dataSet[0].UNIT_500,
                Unit_502 = dataSet[0].UNIT_502,
                XjNumber = dataSet[0].XJ_NO
            } };

            deviceModel.CalibrationResults = new List<CalibrationResults> { new CalibrationResults
            {
                AdjustScale_0 = dataSet[0].ADJ_V0,
                AdjustScale_100 = dataSet[0].ADJ_V100,
                AmplificationNumber = dataSet[0].AMPNO,
                AtmospherePressure = dataSet[0].ATMOSPHERE,
                Bar = dataSet[0].BAR,
                Sqrt = dataSet[0].SQRT,
                XjNumber = dataSet[0].XJNO,
                BhcomVersion = dataSet[0].BHCOM_VER,
                CalibrationDate = dataSet[0].CAL_DATE,
                CalibrationTime = dataSet[0].CAL_TIME,
                CapsuleNumber = dataSet[0].CAPNO,
                CrcxInitialisation = dataSet[0].CRCX_INI,
                Damping = dataSet[0].DAMPING,
                EjxMsCodeInitialisation = dataSet[0].EJXMSCODE_INI,
                EthercomVersion = dataSet[0].ETHERCOM_VER,
                Eui64adrs = dataSet[0].EUI64ADRS,
                HartSelection = dataSet[0].HARTSEL,
                Humd = dataSet[0].HUMD,
                KmSerial1 = dataSet[0].KMSERIAL1,
                KmSerial2 = dataSet[0].KMSERIAL2,
                LineName = dataSet[0].LINENAME,
                MessageDisplay = dataSet[0].MSGDISP,
                MsCode = dataSet[0].MSCODE,
                OrderNumber = dataSet[0].ORDERNO,
                PresscontVersion = dataSet[0].PRESSCONT_VER,
                PressInitialisation = dataSet[0].PRESS_INI,
                Qic = dataSet[0].QIC,
                Range = dataSet[0].RANGE,
                Result = dataSet[0].RESULT,
                Soft = dataSet[0].SOFT,
                StartNumber = dataSet[0].STARTNO,
                Stbl = dataSet[0].STBL,
                Stn = dataSet[0].STN,
                Style = dataSet[0].STYLE,
                Tag = dataSet[0].TAG,
                Temp = dataSet[0].TEMP,
                Version = dataSet[0].VERSION,
            }
            };

            deviceModel.DeviceTestResults = new List<DeviceTestResult> { new DeviceTestResult
            {
                Result = dataSet[0].RESULT
            }
            };

            return deviceModel;
        }
    }
}

namespace ReportManager.Data.DataModel
{
    public class AggregatedFieldsModel
    {
        private readonly SerialNumber _serialNumber;
        private readonly InputData _inputData;
        private readonly CalibrationResults _calibrationResults;
        private readonly DeviceTestResult _deviceTestResult;
        

        public AggregatedFieldsModel(SerialNumber serialNumber, 
                                     InputData inputData,
                                     CalibrationResults calibrationResults, 
                                     DeviceTestResult deviceTestResult)
        {
            _serialNumber = serialNumber;
            _inputData = inputData;
            _calibrationResults = calibrationResults;
            _deviceTestResult = deviceTestResult;
        }

        public string Serial
        {
            get
            {
                return _serialNumber.Serial;
            }

            set
            {
                _serialNumber.Serial = value;
            }
        }

        public string MsCode
        {
            get
            {
                return _inputData.MS_CODE;
            }

            set
            {
                _inputData.MS_CODE = value;
            }
        }

        public string Model
        {
            get
            {
                return _inputData.MODEL;
            }

            set
            {
                _inputData.MODEL = value;
            }
        }

        public string ProductionNumber
        {
            get
            {
                return _inputData.PROD_NO;
            }

            set
            {
                _inputData.PROD_NO = value;
            }
        }

        public string ProductionNumberSuffix
        {
            get
            {
                return _inputData.PROD_NO_SFIX;
            }

            set
            {
                _inputData.PROD_NO_SFIX = value;
            }
        }

        public string LineNumber
        {
            get
            {
                return _inputData.LINE_NO;
            }

            set
            {
                _inputData.LINE_NO = value;
            }
        }

        public string CrpGroupNumber
        {
            get
            {
                return _inputData.CRP_GR_NO;
            }

            set
            {
                _inputData.CRP_GR_NO = value;
            }
        }

        public string ProductionCareer
        {
            get
            {
                return _inputData.PROD_CAREER;
            }

            set
            {
                _inputData.PROD_CAREER = value;
            }
        }

        public string TestCertSign
        {
            get
            {
                return _inputData.TEST_CERT_SIGN;
            }

            set
            {
                _inputData.TEST_CERT_SIGN = value;
            }
        }

        public string DocumentationLangType
        {
            get
            {
                return _inputData.DOC_LANG_TYPE;
            }

            set
            {
                _inputData.DOC_LANG_TYPE = value;
            }
        }

        public string InstFinishD
        {
            get
            {
                return _inputData.INST_FINISH_D;
            }

            set
            {
                _inputData.INST_FINISH_D = value;
            }
        }

        public string TestCertYn
        {
            get
            {
                return _inputData.TEST_CERT_YN;
            }

            set
            {
                _inputData.TEST_CERT_YN = value;
            }
        }

        public string EndUserCustNJ
        {
            get
            {
                return _inputData.END_USER_CUST_N_J;
            }

            set
            {
                _inputData.END_USER_CUST_N_J = value;
            }
        }

        public string OrderNumber
        {
            get
            {
                return _inputData.ORDER_NO;
            }

            set
            {
                _inputData.ORDER_NO = value;
            }
        }

        public string ItemNumber
        {
            get
            {
                return _inputData.ITEM_NO;
            }

            set
            {
                _inputData.ITEM_NO = value;
            }
        }

        public string ProductionItemRevisionNumber
        {
            get
            {
                return _inputData.PROD_ITEM_REV_NO;
            }

            set
            {
                _inputData.PROD_ITEM_REV_NO = value;
            }
        }

        public string ProductionInstRevisionNumber
        {
            get
            {
                return _inputData.PROD_INST_REV_NO;
            }

            set
            {
                _inputData.PROD_INST_REV_NO = value;
            }
        }

        public string CompNumber
        {
            get
            {
                return _inputData.COMP_NO;
            }

            set
            {
                _inputData.COMP_NO = value;
            }
        }

        public string StartScheduleD
        {
            get
            {
                return _inputData.START_SCHDULE_D;
            }

            set
            {
                _inputData.START_SCHDULE_D = value;
            }
        }

        public string FinishScheduleD
        {
            get
            {
                return _inputData.FINISH_SCHDULE_D;
            }

            set
            {
                _inputData.FINISH_SCHDULE_D = value;
            }
        }

        public string StartNumber
        {
            get
            {
                return _inputData.START_NO;
            }

            set
            {
                _inputData.START_NO = value;
            }
        }

        public string SerialNumber
        {
            get
            {
                return _inputData.SERIAL_NO;
            }

            set
            {
                _inputData.SERIAL_NO = value;
            }
        }

        public string AllowanceSign
        {
            get
            {
                return _inputData.ALLOWANCE_SIGN;
            }

            set
            {
                _inputData.ALLOWANCE_SIGN = value;
            }
        }

        public string ProductionNumberJapan
        {
            get
            {
                return _inputData.PROD_N_J;
            }

            set
            {
                _inputData.PROD_N_J = value;
            }
        }

        public string ProductionNumberEnglish
        {
            get
            {
                return _inputData.PROD_N_E;
            }

            set
            {
                _inputData.PROD_N_E = value;
            }
        }

        public string TokuchuSpecificationSign
        {
            get
            {
                return _inputData.TOKUCHU_SPEC_SIGN;
            }

            set
            {
                _inputData.TOKUCHU_SPEC_SIGN = value;
            }
        }

        public string SapLinkageNumber
        {
            get
            {
                return _inputData.SAP_LINKAGE_NO;
            }

            set
            {
                _inputData.SAP_LINKAGE_NO = value;
            }
        }

        public string RangeInstSign_500
        {
            get
            {
                return _inputData.RANGE_INST_SIGN_500;
            }

            set
            {
                _inputData.RANGE_INST_SIGN_500 = value;
            }
        }

        public string OrderInstMax_500
        {
            get
            {
                return _inputData.ORD_INST_MAX_500;
            }

            set
            {
                _inputData.ORD_INST_MAX_500 = value;
            }
        }

        public string OrderInstMin_500
        {
            get
            {
                return _inputData.ORD_INST_MIN_500;
            }

            set
            {
                _inputData.ORD_INST_MIN_500 = value;
            }
        }

        public string Unit_500
        {
            get
            {
                return _inputData.UNIT_500;
            }

            set
            {
                _inputData.UNIT_500 = value;
            }
        }

        public string Features_500
        {
            get
            {
                return _inputData.FEATURES_500;
            }

            set
            {
                _inputData.FEATURES_500 = value;
            }
        }

        public string RangeInstSign_502
        {
            get
            {
                return _inputData.RANGE_INST_SIGN_502;
            }

            set
            {
                _inputData.RANGE_INST_SIGN_502 = value;
            }
        }

        public string OrderInstMax_502
        {
            get
            {
                return _inputData.ORD_INST_MAX_502;
            }

            set
            {
                _inputData.ORD_INST_MAX_502 = value;
            }
        }

        public string OrderInstMin_502
        {
            get
            {
                return _inputData.ORD_INST_MIN_502;
            }

            set
            {
                _inputData.ORD_INST_MIN_502 = value;
            }
        }

        public string Unit_502
        {
            get
            {
                return _inputData.UNIT_502;
            }

            set
            {
                _inputData.UNIT_502 = value;
            }
        }

        public string OrderInstContect1W69
        {
            get
            {
                return _inputData.ORD_INST_CONTECT1_W69;
            }

            set
            {
                _inputData.ORD_INST_CONTECT1_W69 = value;
            }
        }

        public string OrderInstContect1X72
        {
            get
            {
                return _inputData.ORD_INST_CONTECT1_X72;
            }

            set
            {
                _inputData.ORD_INST_CONTECT1_X72 = value;
            }
        }

        public string OrderInstContect1X91
        {
            get
            {
                return _inputData.ORD_INST_CONTECT1_X91;
            }

            set
            {
                _inputData.ORD_INST_CONTECT1_X91 = value;
            }
        }

        public string OrderInstContect1Z30
        {
            get
            {
                return _inputData.ORD_INST_CONTECT1_Z30;
            }

            set
            {
                _inputData.ORD_INST_CONTECT1_Z30 = value;
            }
        }

        public string TagNumber_525
        {
            get
            {
                return _inputData.TAG_NO_525;
            }

            set
            {
                _inputData.TAG_NO_525 = value;
            }
        }

        public string XjNumber
        {
            get
            {
                return _inputData.XJ_NO;
            }

            set
            {
                _inputData.XJ_NO = value;
            }
        }

        public string OrderInstContect1H46
        {
            get
            {
                return _inputData.ORD_INST_CONTECT1_H46;
            }

            set
            {
                _inputData.ORD_INST_CONTECT1_H46 = value;
            }
        }

        public string OrderInstContect1X92
        {
            get
            {
                return _inputData.ORD_INST_CONTECT1_X92;
            }

            set
            {
                _inputData.ORD_INST_CONTECT1_X92 = value;
            }
        }

        public string OrderInstContect1Y28
        {
            get
            {
                return _inputData.ORD_INST_CONTECT1_Y28;
            }

            set
            {
                _inputData.ORD_INST_CONTECT1_Y28 = value;
            }
        }

        public string OrderInstContect1W35
        {
            get
            {
                return _inputData.ORD_INST_CONTECT1_W35;
            }

            set
            {
                _inputData.ORD_INST_CONTECT1_W35 = value;
            }
        }

        public string OrderInstContect1X78
        {
            get
            {
                return _inputData.ORD_INST_CONTECT1_X78;
            }

            set
            {
                _inputData.ORD_INST_CONTECT1_X78 = value;
            }
        }

        public string OrderInstContect1X94
        {
            get
            {
                return _inputData.ORD_INST_CONTECT1_X94;
            }

            set
            {
                _inputData.ORD_INST_CONTECT1_X94 = value;
            }
        }
        public string IndexNumber
        {
            get
            {
                return _inputData.INDEX_NO;
            }

            set
            {
                _inputData.INDEX_NO = value;
            }
        }

        public string CapsuleNumberInput
        {
            get
            {
                return _inputData.CAP_NO;
            }

            set
            {
                _inputData.CAP_NO = value;
            }
        }


        public string SerialNumberCalibration
        {
            get
            {
                return _calibrationResults.SERIAL;
            }

            set
            {
                _calibrationResults.SERIAL = value;
            }
        }

        public string Result
        {
            get
            {
                return _calibrationResults.RESULT;
            }

            set
            {
                _calibrationResults.RESULT = value;
            }
        }

        public string CapsuleNumberCalibrate
        {
            get
            {
                return _calibrationResults.CAPNO;
            }

            set
            {
                _calibrationResults.CAPNO = value;
            }
        }

        public string AmplificationNumber
        {
            get
            {
                return _calibrationResults.AMPNO;
            }

            set
            {
                _calibrationResults.AMPNO = value;
            }
        }

        public string Style
        {
            get
            {
                return _calibrationResults.STYLE;
            }

            set
            {
                _calibrationResults.STYLE = value;
            }
        }
           
        public string Range
        {
            get
            {
                return _calibrationResults.RANGE;
            }

            set
            {
                _calibrationResults.RANGE = value;
            }
        }

        public string Tag
        {
            get
            {
                return _calibrationResults.TAG;
            }

            set
            {
                _calibrationResults.TAG = value;
            }
        }

        public string Sqrt
        {
            get
            {
                return _calibrationResults.SQRT;
            }

            set
            {
                _calibrationResults.SQRT = value;
            }
        }

        public string CalibrationXjNumber
        {
            get
            {
                return _calibrationResults.XJNO;
            }

            set
            {
                _calibrationResults.XJNO = value;
            }
        }

        public string Qic
        {
            get
            {
                return _calibrationResults.QIC;
            }

            set
            {
                _calibrationResults.QIC = value;
            }
        }

        public string Bar
        {
            get
            {
                return _calibrationResults.BAR;
            }

            set
            {
                _calibrationResults.BAR = value;
            }
        }

        public string Stn
        {
            get
            {
                return _calibrationResults.STN;
            }

            set
            {
                _calibrationResults.STN = value;
            }
        }

        public string KmSerial1
        {
            get
            {
                return _calibrationResults.KMSERIAL1;
            }

            set
            {
                _calibrationResults.KMSERIAL1 = value;
            }
        }

        public string KmSerial2
        {
            get
            {
                return _calibrationResults.KMSERIAL2;
            }

            set
            {
                _calibrationResults.KMSERIAL2 = value;
            }
        }

        public string LineName
        {
            get
            {
                return _calibrationResults.LINENAME;
            }

            set
            {
                _calibrationResults.LINENAME = value;
            }
        }

        public string Soft
        {
            get
            {
                return _calibrationResults.SOFT;
            }

            set
            {
                _calibrationResults.SOFT = value;
            }
        }

        public string Version
        {
            get
            {
                return _calibrationResults.VERSION;
            }

            set
            {
                _calibrationResults.VERSION = value;
            }
        }

        public string CalibrationDate
        {
            get
            {
                return _calibrationResults.CAL_DATE;
            }

            set
            {
                _calibrationResults.CAL_DATE = value;
            }
        }

        public string CalibrationTime
        {
            get
            {
                return _calibrationResults.CAL_TIME;
            }

            set
            {
                _calibrationResults.CAL_TIME = value;
            }
        }

        public string Temp
        {
            get
            {
                return _calibrationResults.TEMP;
            }

            set
            {
                _calibrationResults.TEMP = value;
            }
        }

        public string Humd
        {
            get
            {
                return _calibrationResults.HUMD;
            }

            set
            {
                _calibrationResults.HUMD = value;
            }
        }

        public string Damping
        {
            get
            {
                return _calibrationResults.DAMPING;
            }

            set
            {
                _calibrationResults.DAMPING = value;
            }
        }

        public string Stbl
        {
            get
            {
                return _calibrationResults.STBL;
            }

            set
            {
                _calibrationResults.STBL = value;
            }
        }

        public string EthercomVersion
        {
            get
            {
                return _calibrationResults.ETHERCOM_VER;
            }

            set
            {
                _calibrationResults.ETHERCOM_VER = value;
            }
        }

        public string BhcomVersion
        {
            get
            {
                return _calibrationResults.BHCOM_VER;
            }

            set
            {
                _calibrationResults.BHCOM_VER = value;
            }
        }

        public string PresscontVersion
        {
            get
            {
                return _calibrationResults.PRESSCONT_VER;
            }

            set
            {
                _calibrationResults.PRESSCONT_VER = value;
            }
        }

        public string PressInitialisation
        {
            get
            {
                return _calibrationResults.PRESS_INI;
            }

            set
            {
                _calibrationResults.PRESS_INI = value;
            }
        }

        public string CrcxInitialisation
        {
            get
            {
                return _calibrationResults.CRCX_INI;
            }

            set
            {
                _calibrationResults.CRCX_INI = value;
            }
        }

        public string EjxMsCodeInitialisation
        {
            get
            {
                return _calibrationResults.EJXMSCODE_INI;
            }

            set
            {
                _calibrationResults.EJXMSCODE_INI = value;
            }
        }

        public string AtmospherePressure
        {
            get
            {
                return _calibrationResults.ATMOSPHERE;
            }

            set
            {
                _calibrationResults.ATMOSPHERE = value;
            }
        }

        public string CalibrationStartNumber
        {
            get
            {
                return _calibrationResults.STARTNO;
            }

            set
            {
                _calibrationResults.STARTNO = value;
            }
        }

        public string AdjustScale_0
        {
            get
            {
                return _calibrationResults.ADJ_V0;
            }

            set
            {
                _calibrationResults.ADJ_V0 = value;
            }
        }

        public string AdjustScale_100
        {
            get
            {
                return _calibrationResults.ADJ_V100;
            }

            set
            {
                _calibrationResults.ADJ_V100 = value;
            }
        }

        public string HartSelection
        {
            get
            {
                return _calibrationResults.HARTSEL;
            }

            set
            {
                _calibrationResults.HARTSEL = value;
            }
        }

        public string MessageDisplay
        {
            get
            {
                return _calibrationResults.MSGDISP;
            }

            set
            {
                _calibrationResults.MSGDISP = value;
            }
        }

        public string Eui64adrs
        {
            get
            {
                return _calibrationResults.EUI64ADRS;
            }

            set
            {
                _calibrationResults.EUI64ADRS = value;
            }
        }

        public string Acc
        {
            get
            {
                return _calibrationResults.ACC;
            }

            set
            {
                _calibrationResults.ACC = value;
            }
        }

        public string Calut
        {
            get
            {
                return _calibrationResults.CALUT;
            }

            set
            {
                _calibrationResults.CALUT = value;
            }
        }
        public string Cal1
        {
            get
            {
                return _calibrationResults.CAL1;
            }

            set
            {
                _calibrationResults.CAL1 = value;
            }
        }

        public string Cal2
        {
            get
            {
                return _calibrationResults.CAL2;
            }

            set
            {
                _calibrationResults.CAL2 = value;
            }
        }

        public string Cal3
        {
            get
            {
                return _calibrationResults.CAL3;
            }

            set
            {
                _calibrationResults.CAL3 = value;
            }
        }

        public string Cal4
        {
            get
            {
                return _calibrationResults.CAL4;
            }

            set
            {
                _calibrationResults.CAL4 = value;
            }
        }

        public string Cal5
        {
            get
            {
                return _calibrationResults.CAL5;
            }

            set
            {
                _calibrationResults.CAL5 = value;
            }
        }

        public string Cal6
        {
            get
            {
                return _calibrationResults.CAL6;
            }

            set
            {
                _calibrationResults.CAL6 = value;
            }
        }

        public string Cal7
        {
            get
            {
                return _calibrationResults.CAL7;
            }

            set
            {
                _calibrationResults.CAL7 = value;
            }
        }



        public string Desut
        {
            get
            {
                return _calibrationResults.DESUT;
            }

            set
            {
                _calibrationResults.DESUT = value;
            }
        }

        public string Des1
        {
            get
            {
                return _calibrationResults.DES1;
            }

            set
            {
                _calibrationResults.DES1 = value;
            }
        }

        public string Des2
        {
            get
            {
                return _calibrationResults.DES2;
            }

            set
            {
                _calibrationResults.DES2 = value;
            }
        }

        public string Des3
        {
            get
            {
                return _calibrationResults.DES3;
            }

            set
            {
                _calibrationResults.DES3 = value;
            }
        }

        public string Des4
        {
            get
            {
                return _calibrationResults.DES4;
            }

            set
            {
                _calibrationResults.DES4 = value;
            }
        }
        public string Des5
        {
            get
            {
                return _calibrationResults.DES5;
            }

            set
            {
                _calibrationResults.DES5 = value;
            }
        }

        public string Des6
        {
            get
            {
                return _calibrationResults.DES6;
            }

            set
            {
                _calibrationResults.DES6 = value;
            }
        }

        public string Des7
        {
            get
            {
                return _calibrationResults.DES7;
            }

            set
            {
                _calibrationResults.DES7 = value;
            }
        }

        public string Dtinc1
        {
            get
            {
                return _calibrationResults.DTINC1;
            }

            set
            {
                _calibrationResults.DTINC1 = value;
            }
        }

        public string Dtinc2
        {
            get
            {
                return _calibrationResults.DTINC2;
            }

            set
            {
                _calibrationResults.DTINC2 = value;
            }
        }

        public string Dtinc3
        {
            get
            {
                return _calibrationResults.DTINC3;
            }

            set
            {
                _calibrationResults.DTINC3 = value;
            }
        }

        public string Dtinc4
        {
            get
            {
                return _calibrationResults.DTINC4;
            }

            set
            {
                _calibrationResults.DTINC4 = value;
            }
        }

        public string Dtinc5
        {
            get
            {
                return _calibrationResults.DTINC5;
            }

            set
            {
                _calibrationResults.DTINC5 = value;
            }
        }

        public string Dtinc6
        {
            get
            {
                return _calibrationResults.DTINC6;
            }

            set
            {
                _calibrationResults.DTINC6 = value;
            }
        }

        public string Dtinc7
        {
            get
            {
                return _calibrationResults.DTINC7;
            }

            set
            {
                _calibrationResults.DTINC7 = value;
            }
        }

        public string Dtdec1
        {
            get
            {
                return _calibrationResults.DTDEC1;
            }

            set
            {
                _calibrationResults.DTDEC1 = value;
            }
        }

        public string Dtdec2
        {
            get
            {
                return _calibrationResults.DTDEC2;
            }

            set
            {
                _calibrationResults.DTDEC2 = value;
            }
        }

        public string Dtdec3
        {
            get
            {
                return _calibrationResults.DTDEC3;
            }

            set
            {
                _calibrationResults.DTDEC3 = value;
            }
        }

        public string Dtdec4
        {
            get
            {
                return _calibrationResults.DTDEC4;
            }

            set
            {
                _calibrationResults.DTDEC4 = value;
            }
        }

        public string Dtdec5
        {
            get
            {
                return _calibrationResults.DTDEC5;
            }

            set
            {
                _calibrationResults.DTDEC5 = value;
            }
        }

        public string Dtdec6
        {
            get
            {
                return _calibrationResults.DTDEC6;
            }

            set
            {
                _calibrationResults.DTDEC6 = value;
            }
        }

        public string Dtdec7
        {
            get
            {
                return _calibrationResults.DTDEC7;
            }

            set
            {
                _calibrationResults.DTDEC7 = value;
            }
        }


        public string Convtut
        {
            get
            {
                return _calibrationResults.CONVTUT;
            }

            set
            {
                _calibrationResults.CONVTUT = value;
            }
        }


        public string Convt1
        {
            get
            {
                return _calibrationResults.CONVT1;
            }

            set
            {
                _calibrationResults.CONVT1 = value;
            }
        }

        public string Convt2
        {
            get
            {
                return _calibrationResults.CONVT2;
            }

            set
            {
                _calibrationResults.CONVT2 = value;
            }
        }

        public string Convt3
        {
            get
            {
                return _calibrationResults.CONVT3;
            }

            set
            {
                _calibrationResults.CONVT3 = value;
            }
        }

        public string Convt4
        {
            get
            {
                return _calibrationResults.CONVT4;
            }

            set
            {
                _calibrationResults.CONVT4 = value;
            }
        }

        public string Convt5
        {
            get
            {
                return _calibrationResults.CONVT5;
            }

            set
            {
                _calibrationResults.CONVT5 = value;
            }
        }

        public string Convt6
        {
            get
            {
                return _calibrationResults.CONVT6;
            }

            set
            {
                _calibrationResults.CONVT6 = value;
            }
        }

        public string Convt7
        {
            get
            {
                return _calibrationResults.CONVT7;
            }

            set
            {
                _calibrationResults.CONVT7 = value;
            }
        }


        public string Kmnic1
        {
            get
            {
                return _calibrationResults.KMINC1;
            }

            set
            {
                _calibrationResults.KMINC1 = value;
            }
        }

        public string Kmnic2
        {
            get
            {
                return _calibrationResults.KMINC2;
            }

            set
            {
                _calibrationResults.KMINC2 = value;
            }
        }

        public string Kmnic3
        {
            get
            {
                return _calibrationResults.KMINC3;
            }

            set
            {
                _calibrationResults.KMINC3 = value;
            }
        }

        public string Kmnic4
        {
            get
            {
                return _calibrationResults.KMINC4;
            }

            set
            {
                _calibrationResults.KMINC4 = value;
            }
        }

        public string Kmnic5
        {
            get
            {
                return _calibrationResults.KMINC5;
            }

            set
            {
                _calibrationResults.KMINC5 = value;
            }
        }

        public string Kmnic6
        {
            get
            {
                return _calibrationResults.KMINC6;
            }

            set
            {
                _calibrationResults.KMINC6 = value;
            }
        }

        public string Kmnic7
        {
            get
            {
                return _calibrationResults.KMINC7;
            }

            set
            {
                _calibrationResults.KMINC7 = value;
            }
        }

        public string Kmdec1
        {
            get
            {
                return _calibrationResults.KMDEC1;
            }

            set
            {
                _calibrationResults.KMDEC1 = value;
            }
        }

        public string Kmdec2
        {
            get
            {
                return _calibrationResults.KMDEC2;
            }

            set
            {
                _calibrationResults.KMDEC2 = value;
            }
        }

        public string Kmdec3
        {
            get
            {
                return _calibrationResults.KMDEC3;
            }

            set
            {
                _calibrationResults.KMDEC3 = value;
            }
        }

        public string Kmdec4
        {
            get
            {
                return _calibrationResults.KMDEC4;
            }

            set
            {
                _calibrationResults.KMDEC4 = value;
            }
        }
        public string Kmdec5
        {
            get
            {
                return _calibrationResults.KMDEC5;
            }

            set
            {
                _calibrationResults.KMDEC5 = value;
            }
        }

        public string Kmdec6
        {
            get
            {
                return _calibrationResults.KMDEC6;
            }

            set
            {
                _calibrationResults.KMDEC6 = value;
            }
        }
        public string Kmdec7
        {
            get
            {
                return _calibrationResults.KMDEC7;
            }

            set
            {
                _calibrationResults.KMDEC7 = value;
            }
        }

        public string Cpinc1
        {
            get
            {
                return _calibrationResults.CPINC1;
            }

            set
            {
                _calibrationResults.CPINC1 = value;
            }
        }

        public string Cpinc2
        {
            get
            {
                return _calibrationResults.CPINC2;
            }

            set
            {
                _calibrationResults.CPINC2 = value;
            }
        }

        public string Cpinc3
        {
            get
            {
                return _calibrationResults.CPINC3;
            }

            set
            {
                _calibrationResults.CPINC3 = value;
            }
        }

        public string Cpinc4
        {
            get
            {
                return _calibrationResults.CPINC4;
            }

            set
            {
                _calibrationResults.CPINC4 = value;
            }
        }

        public string Cpinc5
        {
            get
            {
                return _calibrationResults.CPINC5;
            }

            set
            {
                _calibrationResults.CPINC5 = value;
            }
        }
        public string Cpinc6
        {
            get
            {
                return _calibrationResults.CPINC6;
            }

            set
            {
                _calibrationResults.CPINC6 = value;
            }
        }
        public string Cpinc7
        {
            get
            {
                return _calibrationResults.CPINC7;
            }

            set
            {
                _calibrationResults.CPINC7 = value;
            }
        }

        public string Cpdec1
        {
            get
            {
                return _calibrationResults.CPDEC1;
            }

            set
            {
                _calibrationResults.CPDEC1 = value;
            }
        }

        public string Cpdec2
        {
            get
            {
                return _calibrationResults.CPDEC2;
            }

            set
            {
                _calibrationResults.CPDEC2 = value;
            }
        }

        public string Cpdec3
        {
            get
            {
                return _calibrationResults.CPDEC3;
            }

            set
            {
                _calibrationResults.CPDEC3 = value;
            }
        }

        public string Cpdec4
        {
            get
            {
                return _calibrationResults.CPDEC4;
            }

            set
            {
                _calibrationResults.CPDEC4 = value;
            }
        }
        public string Cpdec5
        {
            get
            {
                return _calibrationResults.CPDEC5;
            }

            set
            {
                _calibrationResults.CPDEC5 = value;
            }
        }

        public string Cpdec6
        {
            get
            {
                return _calibrationResults.CPDEC6;
            }

            set
            {
                _calibrationResults.CPDEC6 = value;
            }
        }

        public string Cpdec7
        {
            get
            {
                return _calibrationResults.CPDEC7;
            }

            set
            {
                _calibrationResults.CPDEC7 = value;
            }
        }


        public string Atmn
        {
            get
            {
                return _calibrationResults.ATMN;
            }

            set
            {
                _calibrationResults.ATMN = value;
            }
        }

        public string Caltime
        {
            get
            {
                return _calibrationResults.CALTIME;
            }

            set
            {
                _calibrationResults.CALTIME = value;
            }
        }

        public string Zeror
        {
            get
            {
                return _calibrationResults.ZEROR;
            }

            set
            {
                _calibrationResults.ZEROR = value;
            }
        }

        public string Spanr
        {
            get
            {
                return _calibrationResults.SPANR;
            }

            set
            {
                _calibrationResults.SPANR = value;
            }
        }

        public string AdjUnit
        {
            get
            {
                return _calibrationResults.ADJUNIT;
            }

            set
            {
                _calibrationResults.ADJUNIT = value;
            }
        }

        public string WtMatl
        {
            get
            {
                return _calibrationResults.WTMATL;
            }

            set
            {
                _calibrationResults.WTMATL = value;
            }
        }

        public string FlSize
        {
            get
            {
                return _calibrationResults.FLSIZE;
            }

            set
            {
                _calibrationResults.FLSIZE = value;
            }
        }

        public string Acc2
        {
            get
            {
                return _calibrationResults.ACC2;
            }

            set
            {
                _calibrationResults.ACC2 = value;
            }
        }

        public string TUserCalibrate
        {
            get
            {
                return _calibrationResults.TUSER;
            }

            set
            {
                _calibrationResults.TUSER = value;
            }
        }


        public string SerialNumberHipot
        {
            get
            {
                return _deviceTestResult.SerialNumberHipot;
            }

            set
            {
                _deviceTestResult.SerialNumberHipot = value;
            }
        }

        public string DeviceTestResult
        {
            get
            {
                return _deviceTestResult.Result;
            }

            set
            {
                _deviceTestResult.Result = value;
            }
        }

        public string IsolationV
        {
            get
            {
                return _deviceTestResult.IsolationV;
            }

            set
            {
                _deviceTestResult.IsolationV = value;
            }
        }

        public string IsolationR
        {
            get
            {
                return _deviceTestResult.IsolationR;
            }

            set
            {
                _deviceTestResult.IsolationR = value;
            }
        }

        public string IsolationT
        {
            get
            {
                return _deviceTestResult.IsolationT;
            }

            set
            {
                _deviceTestResult.IsolationT = value;
            }
        }

        public string IResult
        {
            get
            {
                return _deviceTestResult.IResult;
            }

            set
            {
                _deviceTestResult.IResult = value;
            }
        }

        public string WithStandV
        {
            get
            {
                return _deviceTestResult.WithStandV;
            }

            set
            {
                _deviceTestResult.WithStandV = value;
            }
        }

        public string WithStandI
        {
            get
            {
                return _deviceTestResult.WithStandI;
            }

            set
            {
                _deviceTestResult.WithStandI = value;
            }
        }

        public string WithStandT
        {
            get
            {
                return _deviceTestResult.WithStandT;
            }

            set
            {
                _deviceTestResult.WithStandT = value;
            }
        }


        public string WResult
        {
            get
            {
                return _deviceTestResult.WResult;
            }

            set
            {
                _deviceTestResult.WResult = value;
            }
        }

        public string TestDate
        {
            get
            {
                return _deviceTestResult.TestDate;
            }

            set
            {
                _deviceTestResult.TestDate = value;
            }
        }

        public string TestTime
        {
            get
            {
                return _deviceTestResult.TestTime;
            }

            set
            {
                _deviceTestResult.TestTime = value;
            }
        }

        public string TUser
        {
            get
            {
                return _deviceTestResult.TUser;
            }

            set
            {
                _deviceTestResult.TUser = value;
            }
        }

    }
}

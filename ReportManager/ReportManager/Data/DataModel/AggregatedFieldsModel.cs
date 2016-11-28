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
                return _inputData.MsCode;
            }

            set
            {
                _inputData.MsCode = value;
            }
        }

        public string Model
        {
            get
            {
                return _inputData.Model;
            }

            set
            {
                _inputData.Model = value;
            }
        }

        public string ProductionNumber
        {
            get
            {
                return _inputData.ProductionNumber;
            }

            set
            {
                _inputData.ProductionNumber = value;
            }
        }

        public string ProductionNumberSuffix
        {
            get
            {
                return _inputData.ProductionNumberSuffix;
            }

            set
            {
                _inputData.ProductionNumberSuffix = value;
            }
        }

        public string LineNumber
        {
            get
            {
                return _inputData.LineNumber;
            }

            set
            {
                _inputData.LineNumber = value;
            }
        }

        public string CrpGroupNumber
        {
            get
            {
                return _inputData.CrpGroupNumber;
            }

            set
            {
                _inputData.CrpGroupNumber = value;
            }
        }

        public string ProductionCareer
        {
            get
            {
                return _inputData.ProductionCareer;
            }

            set
            {
                _inputData.ProductionCareer = value;
            }
        }

        public string TestCertSign
        {
            get
            {
                return _inputData.TestCertSign;
            }

            set
            {
                _inputData.TestCertSign = value;
            }
        }

        public string DocumentationLangType
        {
            get
            {
                return _inputData.DocumentationLangType;
            }

            set
            {
                _inputData.DocumentationLangType = value;
            }
        }

        public string InstFinishD
        {
            get
            {
                return _inputData.InstFinishD;
            }

            set
            {
                _inputData.InstFinishD = value;
            }
        }

        public string TestCertYn
        {
            get
            {
                return _inputData.TestCertYn;
            }

            set
            {
                _inputData.TestCertYn = value;
            }
        }

        public string EndUserCustNJ
        {
            get
            {
                return _inputData.EndUserCustNJ;
            }

            set
            {
                _inputData.EndUserCustNJ = value;
            }
        }

        public string OrderNumber
        {
            get
            {
                return _inputData.OrderNumber;
            }

            set
            {
                _inputData.OrderNumber = value;
            }
        }

        public string ItemNumber
        {
            get
            {
                return _inputData.ItemNumber;
            }

            set
            {
                _inputData.ItemNumber = value;
            }
        }

        public string ProductionItemRevisionNumber
        {
            get
            {
                return _inputData.ProductionItemRevisionNumber;
            }

            set
            {
                _inputData.ProductionItemRevisionNumber = value;
            }
        }

        public string ProductionInstRevisionNumber
        {
            get
            {
                return _inputData.ProductionInstRevisionNumber;
            }

            set
            {
                _inputData.ProductionInstRevisionNumber = value;
            }
        }

        public string CompNumber
        {
            get
            {
                return _inputData.CompNumber;
            }

            set
            {
                _inputData.CompNumber = value;
            }
        }

        public string StartScheduleD
        {
            get
            {
                return _inputData.StartScheduleD;
            }

            set
            {
                _inputData.StartScheduleD = value;
            }
        }

        public string FinishScheduleD
        {
            get
            {
                return _inputData.FinishScheduleD;
            }

            set
            {
                _inputData.FinishScheduleD = value;
            }
        }

        public string StartNumber
        {
            get
            {
                return _inputData.StartNumber;
            }

            set
            {
                _inputData.StartNumber = value;
            }
        }

        public string SerialNumber
        {
            get
            {
                return _inputData.SerialNumber;
            }

            set
            {
                _inputData.SerialNumber = value;
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
                return _inputData.ProductionNumberJapan;
            }

            set
            {
                _inputData.ProductionNumberJapan = value;
            }
        }

        public string ProductionNumberEnglish
        {
            get
            {
                return _inputData.ProductionNumberEnglish;
            }

            set
            {
                _inputData.ProductionNumberEnglish = value;
            }
        }

        public string TokuchuSpecificationSign
        {
            get
            {
                return _inputData.TokuchuSpecificationSign;
            }

            set
            {
                _inputData.TokuchuSpecificationSign = value;
            }
        }

        public string SapLinkageNumber
        {
            get
            {
                return _inputData.SapLinkageNumber;
            }

            set
            {
                _inputData.SapLinkageNumber = value;
            }
        }

        public string RangeInstSign_500
        {
            get
            {
                return _inputData.RangeInstSign_500;
            }

            set
            {
                _inputData.RangeInstSign_500 = value;
            }
        }

        public string OrderInstMax_500
        {
            get
            {
                return _inputData.OrderInstMax_500;
            }

            set
            {
                _inputData.OrderInstMax_500 = value;
            }
        }

        public string OrderInstMin_500
        {
            get
            {
                return _inputData.OrderInstMin_500;
            }

            set
            {
                _inputData.OrderInstMin_500 = value;
            }
        }

        public string Unit_500
        {
            get
            {
                return _inputData.Unit_500;
            }

            set
            {
                _inputData.Unit_500 = value;
            }
        }

        public string Features_500
        {
            get
            {
                return _inputData.Features_500;
            }

            set
            {
                _inputData.Features_500 = value;
            }
        }

        public string RangeInstSign_502
        {
            get
            {
                return _inputData.RangeInstSign_502;
            }

            set
            {
                _inputData.RangeInstSign_502 = value;
            }
        }

        public string OrderInstMax_502
        {
            get
            {
                return _inputData.OrderInstMax_502;
            }

            set
            {
                _inputData.OrderInstMax_502 = value;
            }
        }

        public string OrderInstMin_502
        {
            get
            {
                return _inputData.OrderInstMin_502;
            }

            set
            {
                _inputData.OrderInstMin_502 = value;
            }
        }

        public string Unit_502
        {
            get
            {
                return _inputData.Unit_502;
            }

            set
            {
                _inputData.Unit_502 = value;
            }
        }

        public string OrderInstContect1W69
        {
            get
            {
                return _inputData.OrderInstContect1W69;
            }

            set
            {
                _inputData.OrderInstContect1W69 = value;
            }
        }

        public string OrderInstContect1X72
        {
            get
            {
                return _inputData.OrderInstContect1X72;
            }

            set
            {
                _inputData.OrderInstContect1X72 = value;
            }
        }

        public string OrderInstContect1X91
        {
            get
            {
                return _inputData.OrderInstContect1X91;
            }

            set
            {
                _inputData.OrderInstContect1X91 = value;
            }
        }

        public string OrderInstContect1Z30
        {
            get
            {
                return _inputData.OrderInstContect1Z30;
            }

            set
            {
                _inputData.OrderInstContect1Z30 = value;
            }
        }

        public string TagNumber_525
        {
            get
            {
                return _inputData.TagNumber_525;
            }

            set
            {
                _inputData.TagNumber_525 = value;
            }
        }

        public string XjNumber
        {
            get
            {
                return _inputData.XjNumber;
            }

            set
            {
                _inputData.XjNumber = value;
            }
        }

        public string OrderInstContect1H46
        {
            get
            {
                return _inputData.OrderInstContect1H46;
            }

            set
            {
                _inputData.OrderInstContect1H46 = value;
            }
        }

        public string OrderInstContect1X92
        {
            get
            {
                return _inputData.OrderInstContect1X92;
            }

            set
            {
                _inputData.OrderInstContect1X92 = value;
            }
        }

        public string OrderInstContect1Y28
        {
            get
            {
                return _inputData.OrderInstContect1Y28;
            }

            set
            {
                _inputData.OrderInstContect1Y28 = value;
            }
        }

        public string OrderInstContect1W35
        {
            get
            {
                return _inputData.OrderInstContect1W35;
            }

            set
            {
                _inputData.OrderInstContect1W35 = value;
            }
        }

        public string OrderInstContect1X78
        {
            get
            {
                return _inputData.OrderInstContect1X78;
            }

            set
            {
                _inputData.OrderInstContect1X78 = value;
            }
        }

        public string OrderInstContect1X94
        {
            get
            {
                return _inputData.OrderInstContect1X94;
            }

            set
            {
                _inputData.OrderInstContect1X94 = value;
            }
        }
        public string IndexNumber
        {
            get
            {
                return _inputData.IndexNumber;
            }

            set
            {
                _inputData.IndexNumber = value;
            }
        }

        public string CapsuleNumberInput
        {
            get
            {
                return _inputData.CapsuleNumber;
            }

            set
            {
                _inputData.CapsuleNumber = value;
            }
        }


        public string SerialNumberCalibration
        {
            get
            {
                return _calibrationResults.SerialNumberCalibration;
            }

            set
            {
                _calibrationResults.SerialNumberCalibration = value;
            }
        }

        public string Result
        {
            get
            {
                return _calibrationResults.Result;
            }

            set
            {
                _calibrationResults.Result = value;
            }
        }

        public string CapsuleNumberCalibrate
        {
            get
            {
                return _calibrationResults.CapsuleNumber;
            }

            set
            {
                _calibrationResults.CapsuleNumber = value;
            }
        }

        public string AmplificationNumber
        {
            get
            {
                return _calibrationResults.AmplificationNumber;
            }

            set
            {
                _calibrationResults.AmplificationNumber = value;
            }
        }

        public string Style
        {
            get
            {
                return _calibrationResults.Style;
            }

            set
            {
                _calibrationResults.Style = value;
            }
        }
           
        public string Range
        {
            get
            {
                return _calibrationResults.Range;
            }

            set
            {
                _calibrationResults.Range = value;
            }
        }

        public string Tag
        {
            get
            {
                return _calibrationResults.Tag;
            }

            set
            {
                _calibrationResults.Tag = value;
            }
        }

        public string Sqrt
        {
            get
            {
                return _calibrationResults.Sqrt;
            }

            set
            {
                _calibrationResults.Sqrt = value;
            }
        }

        public string CalibrationXjNumber
        {
            get
            {
                return _calibrationResults.XjNumber;
            }

            set
            {
                _calibrationResults.XjNumber = value;
            }
        }

        public string Qic
        {
            get
            {
                return _calibrationResults.Qic;
            }

            set
            {
                _calibrationResults.Qic = value;
            }
        }

        public string Bar
        {
            get
            {
                return _calibrationResults.Bar;
            }

            set
            {
                _calibrationResults.Bar = value;
            }
        }

        public string Stn
        {
            get
            {
                return _calibrationResults.Stn;
            }

            set
            {
                _calibrationResults.Stn = value;
            }
        }

        public string KmSerial1
        {
            get
            {
                return _calibrationResults.KmSerial1;
            }

            set
            {
                _calibrationResults.KmSerial1 = value;
            }
        }

        public string KmSerial2
        {
            get
            {
                return _calibrationResults.KmSerial2;
            }

            set
            {
                _calibrationResults.KmSerial2 = value;
            }
        }

        public string LineName
        {
            get
            {
                return _calibrationResults.LineName;
            }

            set
            {
                _calibrationResults.LineName = value;
            }
        }

        public string Soft
        {
            get
            {
                return _calibrationResults.Soft;
            }

            set
            {
                _calibrationResults.Soft = value;
            }
        }

        public string Version
        {
            get
            {
                return _calibrationResults.Version;
            }

            set
            {
                _calibrationResults.Version = value;
            }
        }

        public string CalibrationDate
        {
            get
            {
                return _calibrationResults.CalibrationDate;
            }

            set
            {
                _calibrationResults.CalibrationDate = value;
            }
        }

        public string CalibrationTime
        {
            get
            {
                return _calibrationResults.CalibrationTime;
            }

            set
            {
                _calibrationResults.CalibrationTime = value;
            }
        }

        public string Temp
        {
            get
            {
                return _calibrationResults.Temp;
            }

            set
            {
                _calibrationResults.Temp = value;
            }
        }

        public string Humd
        {
            get
            {
                return _calibrationResults.Humd;
            }

            set
            {
                _calibrationResults.Humd = value;
            }
        }

        public string Damping
        {
            get
            {
                return _calibrationResults.Damping;
            }

            set
            {
                _calibrationResults.Damping = value;
            }
        }

        public string Stbl
        {
            get
            {
                return _calibrationResults.Stbl;
            }

            set
            {
                _calibrationResults.Stbl = value;
            }
        }

        public string EthercomVersion
        {
            get
            {
                return _calibrationResults.EthercomVersion;
            }

            set
            {
                _calibrationResults.EthercomVersion = value;
            }
        }

        public string BhcomVersion
        {
            get
            {
                return _calibrationResults.BhcomVersion;
            }

            set
            {
                _calibrationResults.BhcomVersion = value;
            }
        }

        public string PresscontVersion
        {
            get
            {
                return _calibrationResults.PresscontVersion;
            }

            set
            {
                _calibrationResults.PresscontVersion = value;
            }
        }

        public string PressInitialisation
        {
            get
            {
                return _calibrationResults.PressInitialisation;
            }

            set
            {
                _calibrationResults.PressInitialisation = value;
            }
        }

        public string CrcxInitialisation
        {
            get
            {
                return _calibrationResults.CrcxInitialisation;
            }

            set
            {
                _calibrationResults.CrcxInitialisation = value;
            }
        }

        public string EjxMsCodeInitialisation
        {
            get
            {
                return _calibrationResults.EjxMsCodeInitialisation;
            }

            set
            {
                _calibrationResults.EjxMsCodeInitialisation = value;
            }
        }

        public string AtmospherePressure
        {
            get
            {
                return _calibrationResults.AtmospherePressure;
            }

            set
            {
                _calibrationResults.AtmospherePressure = value;
            }
        }

        public string CalibrationStartNumber
        {
            get
            {
                return _calibrationResults.StartNumber;
            }

            set
            {
                _calibrationResults.StartNumber = value;
            }
        }

        public string AdjustScale_0
        {
            get
            {
                return _calibrationResults.AdjustScale_0;
            }

            set
            {
                _calibrationResults.AdjustScale_0 = value;
            }
        }

        public string AdjustScale_100
        {
            get
            {
                return _calibrationResults.AdjustScale_100;
            }

            set
            {
                _calibrationResults.AdjustScale_100 = value;
            }
        }

        public string HartSelection
        {
            get
            {
                return _calibrationResults.HartSelection;
            }

            set
            {
                _calibrationResults.HartSelection = value;
            }
        }

        public string MessageDisplay
        {
            get
            {
                return _calibrationResults.MessageDisplay;
            }

            set
            {
                _calibrationResults.MessageDisplay = value;
            }
        }

        public string Eui64adrs
        {
            get
            {
                return _calibrationResults.Eui64adrs;
            }

            set
            {
                _calibrationResults.Eui64adrs = value;
            }
        }

        public string Acc
        {
            get
            {
                return _calibrationResults.Acc;
            }

            set
            {
                _calibrationResults.Acc = value;
            }
        }

        public string Calut
        {
            get
            {
                return _calibrationResults.Calut;
            }

            set
            {
                _calibrationResults.Calut = value;
            }
        }
        public string Cal1
        {
            get
            {
                return _calibrationResults.Cal1;
            }

            set
            {
                _calibrationResults.Cal1 = value;
            }
        }

        public string Cal2
        {
            get
            {
                return _calibrationResults.Cal2;
            }

            set
            {
                _calibrationResults.Cal2 = value;
            }
        }

        public string Cal3
        {
            get
            {
                return _calibrationResults.Cal3;
            }

            set
            {
                _calibrationResults.Cal3 = value;
            }
        }

        public string Cal4
        {
            get
            {
                return _calibrationResults.Cal4;
            }

            set
            {
                _calibrationResults.Cal4 = value;
            }
        }

        public string Cal5
        {
            get
            {
                return _calibrationResults.Cal5;
            }

            set
            {
                _calibrationResults.Cal5 = value;
            }
        }

        public string Cal6
        {
            get
            {
                return _calibrationResults.Cal6;
            }

            set
            {
                _calibrationResults.Cal6 = value;
            }
        }

        public string Cal7
        {
            get
            {
                return _calibrationResults.Cal7;
            }

            set
            {
                _calibrationResults.Cal7 = value;
            }
        }



        public string Desut
        {
            get
            {
                return _calibrationResults.Desut;
            }

            set
            {
                _calibrationResults.Desut = value;
            }
        }

        public string Des1
        {
            get
            {
                return _calibrationResults.Des1;
            }

            set
            {
                _calibrationResults.Des1 = value;
            }
        }

        public string Des2
        {
            get
            {
                return _calibrationResults.Des2;
            }

            set
            {
                _calibrationResults.Des2 = value;
            }
        }

        public string Des3
        {
            get
            {
                return _calibrationResults.Des3;
            }

            set
            {
                _calibrationResults.Des3 = value;
            }
        }

        public string Des4
        {
            get
            {
                return _calibrationResults.Des4;
            }

            set
            {
                _calibrationResults.Des4 = value;
            }
        }
        public string Des5
        {
            get
            {
                return _calibrationResults.Des5;
            }

            set
            {
                _calibrationResults.Des5 = value;
            }
        }

        public string Des6
        {
            get
            {
                return _calibrationResults.Des6;
            }

            set
            {
                _calibrationResults.Des6 = value;
            }
        }

        public string Des7
        {
            get
            {
                return _calibrationResults.Des7;
            }

            set
            {
                _calibrationResults.Des7 = value;
            }
        }

        public string Dtinc1
        {
            get
            {
                return _calibrationResults.Dtinc1;
            }

            set
            {
                _calibrationResults.Dtinc1 = value;
            }
        }

        public string Dtinc2
        {
            get
            {
                return _calibrationResults.Dtinc2;
            }

            set
            {
                _calibrationResults.Dtinc2 = value;
            }
        }

        public string Dtinc3
        {
            get
            {
                return _calibrationResults.Dtinc3;
            }

            set
            {
                _calibrationResults.Dtinc3 = value;
            }
        }

        public string Dtinc4
        {
            get
            {
                return _calibrationResults.Dtinc4;
            }

            set
            {
                _calibrationResults.Dtinc4 = value;
            }
        }

        public string Dtinc5
        {
            get
            {
                return _calibrationResults.Dtinc5;
            }

            set
            {
                _calibrationResults.Dtinc5 = value;
            }
        }

        public string Dtinc6
        {
            get
            {
                return _calibrationResults.Dtinc6;
            }

            set
            {
                _calibrationResults.Dtinc6 = value;
            }
        }

        public string Dtinc7
        {
            get
            {
                return _calibrationResults.Dtinc7;
            }

            set
            {
                _calibrationResults.Dtinc7 = value;
            }
        }

        public string Dtdec1
        {
            get
            {
                return _calibrationResults.Dtdec1;
            }

            set
            {
                _calibrationResults.Dtdec1 = value;
            }
        }

        public string Dtdec2
        {
            get
            {
                return _calibrationResults.Dtdec2;
            }

            set
            {
                _calibrationResults.Dtdec2 = value;
            }
        }

        public string Dtdec3
        {
            get
            {
                return _calibrationResults.Dtdec3;
            }

            set
            {
                _calibrationResults.Dtdec3 = value;
            }
        }

        public string Dtdec4
        {
            get
            {
                return _calibrationResults.Dtdec4;
            }

            set
            {
                _calibrationResults.Dtdec4 = value;
            }
        }

        public string Dtdec5
        {
            get
            {
                return _calibrationResults.Dtdec5;
            }

            set
            {
                _calibrationResults.Dtdec5 = value;
            }
        }

        public string Dtdec6
        {
            get
            {
                return _calibrationResults.Dtdec6;
            }

            set
            {
                _calibrationResults.Dtdec6 = value;
            }
        }

        public string Dtdec7
        {
            get
            {
                return _calibrationResults.Dtdec7;
            }

            set
            {
                _calibrationResults.Dtdec7 = value;
            }
        }


        public string Convtut
        {
            get
            {
                return _calibrationResults.Convtut;
            }

            set
            {
                _calibrationResults.Convtut = value;
            }
        }


        public string Convt1
        {
            get
            {
                return _calibrationResults.Convt1;
            }

            set
            {
                _calibrationResults.Convt1 = value;
            }
        }

        public string Convt2
        {
            get
            {
                return _calibrationResults.Convt2;
            }

            set
            {
                _calibrationResults.Convt2 = value;
            }
        }

        public string Convt3
        {
            get
            {
                return _calibrationResults.Convt3;
            }

            set
            {
                _calibrationResults.Convt3 = value;
            }
        }

        public string Convt4
        {
            get
            {
                return _calibrationResults.Convt4;
            }

            set
            {
                _calibrationResults.Convt4 = value;
            }
        }

        public string Convt5
        {
            get
            {
                return _calibrationResults.Convt5;
            }

            set
            {
                _calibrationResults.Convt5 = value;
            }
        }

        public string Convt6
        {
            get
            {
                return _calibrationResults.Convt6;
            }

            set
            {
                _calibrationResults.Convt6 = value;
            }
        }

        public string Convt7
        {
            get
            {
                return _calibrationResults.Convt7;
            }

            set
            {
                _calibrationResults.Convt7 = value;
            }
        }


        public string Kmnic1
        {
            get
            {
                return _calibrationResults.Kminc1;
            }

            set
            {
                _calibrationResults.Kminc1 = value;
            }
        }

        public string Kmnic2
        {
            get
            {
                return _calibrationResults.Kminc2;
            }

            set
            {
                _calibrationResults.Kminc2 = value;
            }
        }

        public string Kmnic3
        {
            get
            {
                return _calibrationResults.Kminc3;
            }

            set
            {
                _calibrationResults.Kminc3 = value;
            }
        }

        public string Kmnic4
        {
            get
            {
                return _calibrationResults.Kminc4;
            }

            set
            {
                _calibrationResults.Kminc4 = value;
            }
        }

        public string Kmnic5
        {
            get
            {
                return _calibrationResults.Kminc5;
            }

            set
            {
                _calibrationResults.Kminc5 = value;
            }
        }

        public string Kmnic6
        {
            get
            {
                return _calibrationResults.Kminc6;
            }

            set
            {
                _calibrationResults.Kminc6 = value;
            }
        }

        public string Kmnic7
        {
            get
            {
                return _calibrationResults.Kminc7;
            }

            set
            {
                _calibrationResults.Kminc7 = value;
            }
        }

        public string Kmdec1
        {
            get
            {
                return _calibrationResults.Kmdec1;
            }

            set
            {
                _calibrationResults.Kmdec1 = value;
            }
        }

        public string Kmdec2
        {
            get
            {
                return _calibrationResults.Kmdec2;
            }

            set
            {
                _calibrationResults.Kmdec2 = value;
            }
        }

        public string Kmdec3
        {
            get
            {
                return _calibrationResults.Kmdec3;
            }

            set
            {
                _calibrationResults.Kmdec3 = value;
            }
        }

        public string Kmdec4
        {
            get
            {
                return _calibrationResults.Kmdec4;
            }

            set
            {
                _calibrationResults.Kmdec4 = value;
            }
        }
        public string Kmdec5
        {
            get
            {
                return _calibrationResults.Kmdec5;
            }

            set
            {
                _calibrationResults.Kmdec5 = value;
            }
        }

        public string Kmdec6
        {
            get
            {
                return _calibrationResults.Kmdec6;
            }

            set
            {
                _calibrationResults.Kmdec6 = value;
            }
        }
        public string Kmdec7
        {
            get
            {
                return _calibrationResults.Kmdec7;
            }

            set
            {
                _calibrationResults.Kmdec7 = value;
            }
        }

        public string Cpinc1
        {
            get
            {
                return _calibrationResults.Cpinc1;
            }

            set
            {
                _calibrationResults.Cpinc1 = value;
            }
        }

        public string Cpinc2
        {
            get
            {
                return _calibrationResults.Cpinc2;
            }

            set
            {
                _calibrationResults.Cpinc2 = value;
            }
        }

        public string Cpinc3
        {
            get
            {
                return _calibrationResults.Cpinc3;
            }

            set
            {
                _calibrationResults.Cpinc3 = value;
            }
        }

        public string Cpinc4
        {
            get
            {
                return _calibrationResults.Cpinc4;
            }

            set
            {
                _calibrationResults.Cpinc4 = value;
            }
        }

        public string Cpinc5
        {
            get
            {
                return _calibrationResults.Cpinc5;
            }

            set
            {
                _calibrationResults.Cpinc5 = value;
            }
        }
        public string Cpinc6
        {
            get
            {
                return _calibrationResults.Cpinc6;
            }

            set
            {
                _calibrationResults.Cpinc6 = value;
            }
        }
        public string Cpinc7
        {
            get
            {
                return _calibrationResults.Cpinc7;
            }

            set
            {
                _calibrationResults.Cpinc7 = value;
            }
        }

        public string Cpdec1
        {
            get
            {
                return _calibrationResults.Cpdec1;
            }

            set
            {
                _calibrationResults.Cpdec1 = value;
            }
        }

        public string Cpdec2
        {
            get
            {
                return _calibrationResults.Cpdec2;
            }

            set
            {
                _calibrationResults.Cpdec2 = value;
            }
        }

        public string Cpdec3
        {
            get
            {
                return _calibrationResults.Cpdec3;
            }

            set
            {
                _calibrationResults.Cpdec3 = value;
            }
        }

        public string Cpdec4
        {
            get
            {
                return _calibrationResults.Cpdec4;
            }

            set
            {
                _calibrationResults.Cpdec4 = value;
            }
        }
        public string Cpdec5
        {
            get
            {
                return _calibrationResults.Cpdec5;
            }

            set
            {
                _calibrationResults.Cpdec5 = value;
            }
        }

        public string Cpdec6
        {
            get
            {
                return _calibrationResults.Cpdec6;
            }

            set
            {
                _calibrationResults.Cpdec6 = value;
            }
        }

        public string Cpdec7
        {
            get
            {
                return _calibrationResults.Cpdec7;
            }

            set
            {
                _calibrationResults.Cpdec7 = value;
            }
        }


        public string Atmn
        {
            get
            {
                return _calibrationResults.Atmn;
            }

            set
            {
                _calibrationResults.Atmn = value;
            }
        }

        public string Caltime
        {
            get
            {
                return _calibrationResults.Caltime;
            }

            set
            {
                _calibrationResults.Caltime = value;
            }
        }

        public string Zeror
        {
            get
            {
                return _calibrationResults.Zeror;
            }

            set
            {
                _calibrationResults.Zeror = value;
            }
        }

        public string Spanr
        {
            get
            {
                return _calibrationResults.Spanr;
            }

            set
            {
                _calibrationResults.Spanr = value;
            }
        }

        public string AdjUnit
        {
            get
            {
                return _calibrationResults.AdjUnit;
            }

            set
            {
                _calibrationResults.AdjUnit = value;
            }
        }

        public string WtMatl
        {
            get
            {
                return _calibrationResults.WtMatl;
            }

            set
            {
                _calibrationResults.WtMatl = value;
            }
        }

        public string FlSize
        {
            get
            {
                return _calibrationResults.FlSize;
            }

            set
            {
                _calibrationResults.FlSize = value;
            }
        }

        public string Acc2
        {
            get
            {
                return _calibrationResults.Acc2;
            }

            set
            {
                _calibrationResults.Acc2 = value;
            }
        }

        public string TUserCalibrate
        {
            get
            {
                return _calibrationResults.TUser;
            }

            set
            {
                _calibrationResults.TUser = value;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.DataModel
{
    public class AggregatedFieldsModel
    {
        private SerialNumber serialNumber;
        private InputData inputData;
        private CalibrationResults calibrationResults;
        private DeviceTestResult deviceTestResult;

        public AggregatedFieldsModel(SerialNumber serialNumber, InputData inputData,
            CalibrationResults calibrationResults, DeviceTestResult deviceTestResult)
        {
            this.serialNumber = serialNumber;
            this.inputData = inputData;
            this.calibrationResults = calibrationResults;
            this.deviceTestResult = deviceTestResult;
        }

        public string Serial
        {
            get
            {
                return serialNumber.Serial;
            }

            set
            {
                serialNumber.Serial = value;
            }
        }

        public string MsCode
        {
            get
            {
                return inputData.MsCode;
            }

            set
            {
                inputData.MsCode = value;
            }
        }

        public string Model
        {
            get
            {
                return inputData.Model;
            }

            set
            {
                inputData.Model = value;
            }
        }

        public string ProductionNumber
        {
            get
            {
                return inputData.ProductionNumber;
            }

            set
            {
                inputData.ProductionNumber = value;
            }
        }

        public string ProductionNumberSuffix
        {
            get
            {
                return inputData.ProductionNumberSuffix;
            }

            set
            {
                inputData.ProductionNumberSuffix = value;
            }
        }

        public string LineNumber
        {
            get
            {
                return inputData.LineNumber;
            }

            set
            {
                inputData.LineNumber = value;
            }
        }

        public string CrpGroupNumber
        {
            get
            {
                return inputData.CrpGroupNumber;
            }

            set
            {
                inputData.CrpGroupNumber = value;
            }
        }

        public string ProductionCareer
        {
            get
            {
                return inputData.ProductionCareer;
            }

            set
            {
                inputData.ProductionCareer = value;
            }
        }

        public string TestCertSign
        {
            get
            {
                return inputData.TestCertSign;
            }

            set
            {
                inputData.TestCertSign = value;
            }
        }

        public string DocumentationLangType
        {
            get
            {
                return inputData.DocumentationLangType;
            }

            set
            {
                inputData.DocumentationLangType = value;
            }
        }

        public string InstFinishD
        {
            get
            {
                return inputData.InstFinishD;
            }

            set
            {
                inputData.InstFinishD = value;
            }
        }

        public string TestCertYn
        {
            get
            {
                return inputData.TestCertYn;
            }

            set
            {
                inputData.TestCertYn = value;
            }
        }

        public string EndUserCustNJ
        {
            get
            {
                return inputData.EndUserCustNJ;
            }

            set
            {
                inputData.EndUserCustNJ = value;
            }
        }

        public string OrderNumber
        {
            get
            {
                return inputData.OrderNumber;
            }

            set
            {
                inputData.OrderNumber = value;
            }
        }

        public string ItemNumber
        {
            get
            {
                return inputData.ItemNumber;
            }

            set
            {
                inputData.ItemNumber = value;
            }
        }

        public string ProductionItemRevisionNumber
        {
            get
            {
                return inputData.ProductionItemRevisionNumber;
            }

            set
            {
                inputData.ProductionItemRevisionNumber = value;
            }
        }

        public string ProductionInstRevisionNumber
        {
            get
            {
                return inputData.ProductionInstRevisionNumber;
            }

            set
            {
                inputData.ProductionInstRevisionNumber = value;
            }
        }

        public string CompNumber
        {
            get
            {
                return inputData.CompNumber;
            }

            set
            {
                inputData.CompNumber = value;
            }
        }

        public string StartScheduleD
        {
            get
            {
                return inputData.StartScheduleD;
            }

            set
            {
                inputData.StartScheduleD = value;
            }
        }

        public string FinishScheduleD
        {
            get
            {
                return inputData.FinishScheduleD;
            }

            set
            {
                inputData.FinishScheduleD = value;
            }
        }

        public string StartNumber
        {
            get
            {
                return inputData.StartNumber;
            }

            set
            {
                inputData.StartNumber = value;
            }
        }

        public string SerialNumber
        {
            get
            {
                return inputData.SerialNumber;
            }

            set
            {
                inputData.SerialNumber = value;
            }
        }

        public string AllowanceSign
        {
            get
            {
                return inputData.AllowanceSign;
            }

            set
            {
                inputData.AllowanceSign = value;
            }
        }

        public string ProductionNumberJapan
        {
            get
            {
                return inputData.ProductionNumberJapan;
            }

            set
            {
                inputData.ProductionNumberJapan = value;
            }
        }

        public string ProductionNumberEnglish
        {
            get
            {
                return inputData.ProductionNumberEnglish;
            }

            set
            {
                inputData.ProductionNumberEnglish = value;
            }
        }

        public string TokuchuSpecificationSign
        {
            get
            {
                return inputData.TokuchuSpecificationSign;
            }

            set
            {
                inputData.TokuchuSpecificationSign = value;
            }
        }

        public string SapLinkageNumber
        {
            get
            {
                return inputData.SapLinkageNumber;
            }

            set
            {
                inputData.SapLinkageNumber = value;
            }
        }

        public string RangeInstSign_500
        {
            get
            {
                return inputData.RangeInstSign_500;
            }

            set
            {
                inputData.RangeInstSign_500 = value;
            }
        }

        public string OrderInstMax_500
        {
            get
            {
                return inputData.OrderInstMax_500;
            }

            set
            {
                inputData.OrderInstMax_500 = value;
            }
        }

        public string OrderInstMin_500
        {
            get
            {
                return inputData.OrderInstMin_500;
            }

            set
            {
                inputData.OrderInstMin_500 = value;
            }
        }

        public string Unit_500
        {
            get
            {
                return inputData.Unit_500;
            }

            set
            {
                inputData.Unit_500 = value;
            }
        }

        public string Features_500
        {
            get
            {
                return inputData.Features_500;
            }

            set
            {
                inputData.Features_500 = value;
            }
        }

        public string RangeInstSign_502
        {
            get
            {
                return inputData.RangeInstSign_502;
            }

            set
            {
                inputData.RangeInstSign_502 = value;
            }
        }

        public string OrderInstMax_502
        {
            get
            {
                return inputData.OrderInstMax_502;
            }

            set
            {
                inputData.OrderInstMax_502 = value;
            }
        }

        public string OrderInstMin_502
        {
            get
            {
                return inputData.OrderInstMin_502;
            }

            set
            {
                inputData.OrderInstMin_502 = value;
            }
        }

        public string Unit_502
        {
            get
            {
                return inputData.Unit_502;
            }

            set
            {
                inputData.Unit_502 = value;
            }
        }

        public string OrderInstContect1W69
        {
            get
            {
                return inputData.OrderInstContect1W69;
            }

            set
            {
                inputData.OrderInstContect1W69 = value;
            }
        }

        public string OrderInstContect1X72
        {
            get
            {
                return inputData.OrderInstContect1X72;
            }

            set
            {
                inputData.OrderInstContect1X72 = value;
            }
        }

        public string OrderInstContect1X91
        {
            get
            {
                return inputData.OrderInstContect1X91;
            }

            set
            {
                inputData.OrderInstContect1X91 = value;
            }
        }

        public string OrderInstContect1Z30
        {
            get
            {
                return inputData.OrderInstContect1Z30;
            }

            set
            {
                inputData.OrderInstContect1Z30 = value;
            }
        }

        public string TagNumber_525
        {
            get
            {
                return inputData.TagNumber_525;
            }

            set
            {
                inputData.TagNumber_525 = value;
            }
        }

        public string XjNumber
        {
            get
            {
                return inputData.XjNumber;
            }

            set
            {
                inputData.XjNumber = value;
            }
        }

        public string OrderInstContect1H46
        {
            get
            {
                return inputData.OrderInstContect1H46;
            }

            set
            {
                inputData.OrderInstContect1H46 = value;
            }
        }

        public string OrderInstContect1X92
        {
            get
            {
                return inputData.OrderInstContect1X92;
            }

            set
            {
                inputData.OrderInstContect1X92 = value;
            }
        }

        public string OrderInstContect1Y28
        {
            get
            {
                return inputData.OrderInstContect1Y28;
            }

            set
            {
                inputData.OrderInstContect1Y28 = value;
            }
        }

        public string OrderInstContect1W35
        {
            get
            {
                return inputData.OrderInstContect1W35;
            }

            set
            {
                inputData.OrderInstContect1W35 = value;
            }
        }

        public string OrderInstContect1X78
        {
            get
            {
                return inputData.OrderInstContect1X78;
            }

            set
            {
                inputData.OrderInstContect1X78 = value;
            }
        }

        public string OrderInstContect1X94
        {
            get
            {
                return inputData.OrderInstContect1X94;
            }

            set
            {
                inputData.OrderInstContect1X94 = value;
            }
        }
        public string IndexNumber
        {
            get
            {
                return inputData.IndexNumber;
            }

            set
            {
                inputData.IndexNumber = value;
            }
        }

        public string CapsuleNumberInput
        {
            get
            {
                return inputData.CapsuleNumber;
            }

            set
            {
                inputData.CapsuleNumber = value;
            }
        }


        public string SerialNumberCalibration
        {
            get
            {
                return calibrationResults.SerialNumberCalibration;
            }

            set
            {
                calibrationResults.SerialNumberCalibration = value;
            }
        }

        public string Result
        {
            get
            {
                return calibrationResults.Result;
            }

            set
            {
                calibrationResults.Result = value;
            }
        }

        public string CapsuleNumberCalibrate
        {
            get
            {
                return calibrationResults.CapsuleNumber;
            }

            set
            {
                calibrationResults.CapsuleNumber = value;
            }
        }

        public string AmplificationNumber
        {
            get
            {
                return calibrationResults.AmplificationNumber;
            }

            set
            {
                calibrationResults.AmplificationNumber = value;
            }
        }

        public string Style
        {
            get
            {
                return calibrationResults.Style;
            }

            set
            {
                calibrationResults.Style = value;
            }
        }
           
        public string Range
        {
            get
            {
                return calibrationResults.Range;
            }

            set
            {
                calibrationResults.Range = value;
            }
        }

        public string Tag
        {
            get
            {
                return calibrationResults.Tag;
            }

            set
            {
                calibrationResults.Tag = value;
            }
        }

        public string Sqrt
        {
            get
            {
                return calibrationResults.Sqrt;
            }

            set
            {
                calibrationResults.Sqrt = value;
            }
        }

        public string CalibrationXjNumber
        {
            get
            {
                return calibrationResults.XjNumber;
            }

            set
            {
                calibrationResults.XjNumber = value;
            }
        }

        public string Qic
        {
            get
            {
                return calibrationResults.Qic;
            }

            set
            {
                calibrationResults.Qic = value;
            }
        }

        public string Bar
        {
            get
            {
                return calibrationResults.Bar;
            }

            set
            {
                calibrationResults.Bar = value;
            }
        }

        public string Stn
        {
            get
            {
                return calibrationResults.Stn;
            }

            set
            {
                calibrationResults.Stn = value;
            }
        }

        public string KmSerial1
        {
            get
            {
                return calibrationResults.KmSerial1;
            }

            set
            {
                calibrationResults.KmSerial1 = value;
            }
        }

        public string KmSerial2
        {
            get
            {
                return calibrationResults.KmSerial2;
            }

            set
            {
                calibrationResults.KmSerial2 = value;
            }
        }

        public string LineName
        {
            get
            {
                return calibrationResults.LineName;
            }

            set
            {
                calibrationResults.LineName = value;
            }
        }

        public string Soft
        {
            get
            {
                return calibrationResults.Soft;
            }

            set
            {
                calibrationResults.Soft = value;
            }
        }

        public string Version
        {
            get
            {
                return calibrationResults.Version;
            }

            set
            {
                calibrationResults.Version = value;
            }
        }

        public string CalibrationDate
        {
            get
            {
                return calibrationResults.CalibrationDate;
            }

            set
            {
                calibrationResults.CalibrationDate = value;
            }
        }

        public string CalibrationTime
        {
            get
            {
                return calibrationResults.CalibrationTime;
            }

            set
            {
                calibrationResults.CalibrationTime = value;
            }
        }

        public string Temp
        {
            get
            {
                return calibrationResults.Temp;
            }

            set
            {
                calibrationResults.Temp = value;
            }
        }

        public string Humd
        {
            get
            {
                return calibrationResults.Humd;
            }

            set
            {
                calibrationResults.Humd = value;
            }
        }

        public string Damping
        {
            get
            {
                return calibrationResults.Damping;
            }

            set
            {
                calibrationResults.Damping = value;
            }
        }

        public string Stbl
        {
            get
            {
                return calibrationResults.Stbl;
            }

            set
            {
                calibrationResults.Stbl = value;
            }
        }

        public string EthercomVersion
        {
            get
            {
                return calibrationResults.EthercomVersion;
            }

            set
            {
                calibrationResults.EthercomVersion = value;
            }
        }

        public string BhcomVersion
        {
            get
            {
                return calibrationResults.BhcomVersion;
            }

            set
            {
                calibrationResults.BhcomVersion = value;
            }
        }

        public string PresscontVersion
        {
            get
            {
                return calibrationResults.PresscontVersion;
            }

            set
            {
                calibrationResults.PresscontVersion = value;
            }
        }

        public string PressInitialisation
        {
            get
            {
                return calibrationResults.PressInitialisation;
            }

            set
            {
                calibrationResults.PressInitialisation = value;
            }
        }

        public string CrcxInitialisation
        {
            get
            {
                return calibrationResults.CrcxInitialisation;
            }

            set
            {
                calibrationResults.CrcxInitialisation = value;
            }
        }

        public string EjxMsCodeInitialisation
        {
            get
            {
                return calibrationResults.EjxMsCodeInitialisation;
            }

            set
            {
                calibrationResults.EjxMsCodeInitialisation = value;
            }
        }

        public string AtmospherePressure
        {
            get
            {
                return calibrationResults.AtmospherePressure;
            }

            set
            {
                calibrationResults.AtmospherePressure = value;
            }
        }

        public string CalibrationStartNumber
        {
            get
            {
                return calibrationResults.StartNumber;
            }

            set
            {
                calibrationResults.StartNumber = value;
            }
        }

        public string AdjustScale_0
        {
            get
            {
                return calibrationResults.AdjustScale_0;
            }

            set
            {
                calibrationResults.AdjustScale_0 = value;
            }
        }

        public string AdjustScale_100
        {
            get
            {
                return calibrationResults.AdjustScale_100;
            }

            set
            {
                calibrationResults.AdjustScale_100 = value;
            }
        }

        public string HartSelection
        {
            get
            {
                return calibrationResults.HartSelection;
            }

            set
            {
                calibrationResults.HartSelection = value;
            }
        }

        public string MessageDisplay
        {
            get
            {
                return calibrationResults.MessageDisplay;
            }

            set
            {
                calibrationResults.MessageDisplay = value;
            }
        }

        public string Eui64adrs
        {
            get
            {
                return calibrationResults.Eui64adrs;
            }

            set
            {
                calibrationResults.Eui64adrs = value;
            }
        }

        public string Acc
        {
            get
            {
                return calibrationResults.Acc;
            }

            set
            {
                calibrationResults.Acc = value;
            }
        }

        public string Calut
        {
            get
            {
                return calibrationResults.Calut;
            }

            set
            {
                calibrationResults.Calut = value;
            }
        }
        public string Cal1
        {
            get
            {
                return calibrationResults.Cal1;
            }

            set
            {
                calibrationResults.Cal1 = value;
            }
        }

        public string Cal2
        {
            get
            {
                return calibrationResults.Cal2;
            }

            set
            {
                calibrationResults.Cal2 = value;
            }
        }

        public string Cal3
        {
            get
            {
                return calibrationResults.Cal3;
            }

            set
            {
                calibrationResults.Cal3 = value;
            }
        }

        public string Desut
        {
            get
            {
                return calibrationResults.Desut;
            }

            set
            {
                calibrationResults.Desut = value;
            }
        }

        public string Des1
        {
            get
            {
                return calibrationResults.Des1;
            }

            set
            {
                calibrationResults.Des1 = value;
            }
        }

        public string Des2
        {
            get
            {
                return calibrationResults.Des2;
            }

            set
            {
                calibrationResults.Des2 = value;
            }
        }

        public string Des3
        {
            get
            {
                return calibrationResults.Des3;
            }

            set
            {
                calibrationResults.Des3 = value;
            }
        }

        public string Dtinc1
        {
            get
            {
                return calibrationResults.Dtinc1;
            }

            set
            {
                calibrationResults.Dtinc1 = value;
            }
        }

        public string Dtinc2
        {
            get
            {
                return calibrationResults.Dtinc2;
            }

            set
            {
                calibrationResults.Dtinc2 = value;
            }
        }

        public string Dtinc3
        {
            get
            {
                return calibrationResults.Dtinc3;
            }

            set
            {
                calibrationResults.Dtinc3 = value;
            }
        }

        public string Dtdec1
        {
            get
            {
                return calibrationResults.Dtdec1;
            }

            set
            {
                calibrationResults.Dtdec1 = value;
            }
        }

        public string Dtdec2
        {
            get
            {
                return calibrationResults.Dtdec2;
            }

            set
            {
                calibrationResults.Dtdec2 = value;
            }
        }

        public string Dtdec3
        {
            get
            {
                return calibrationResults.Dtdec3;
            }

            set
            {
                calibrationResults.Dtdec3 = value;
            }
        }

        public string Convtut
        {
            get
            {
                return calibrationResults.Convtut;
            }

            set
            {
                calibrationResults.Convtut = value;
            }
        }


        public string Convt1
        {
            get
            {
                return calibrationResults.Convt1;
            }

            set
            {
                calibrationResults.Convt1 = value;
            }
        }

        public string Convt2
        {
            get
            {
                return calibrationResults.Convt2;
            }

            set
            {
                calibrationResults.Convt2 = value;
            }
        }

        public string Convt3
        {
            get
            {
                return calibrationResults.Convt3;
            }

            set
            {
                calibrationResults.Convt3 = value;
            }
        }

        public string Kmnic1
        {
            get
            {
                return calibrationResults.Kminc1;
            }

            set
            {
                calibrationResults.Kminc1 = value;
            }
        }

        public string Kmnic2
        {
            get
            {
                return calibrationResults.Kminc2;
            }

            set
            {
                calibrationResults.Kminc2 = value;
            }
        }

        public string Kmnic3
        {
            get
            {
                return calibrationResults.Kminc3;
            }

            set
            {
                calibrationResults.Kminc3 = value;
            }
        }

        public string Kmdec1
        {
            get
            {
                return calibrationResults.Kmdec1;
            }

            set
            {
                calibrationResults.Kmdec1 = value;
            }
        }

        public string Kmdec2
        {
            get
            {
                return calibrationResults.Kmdec2;
            }

            set
            {
                calibrationResults.Kmdec2 = value;
            }
        }

        public string Kmdec3
        {
            get
            {
                return calibrationResults.Kmdec3;
            }

            set
            {
                calibrationResults.Kmdec3 = value;
            }
        }

        public string Cpinc1
        {
            get
            {
                return calibrationResults.Cpinc1;
            }

            set
            {
                calibrationResults.Cpinc1 = value;
            }
        }

        public string Cpinc2
        {
            get
            {
                return calibrationResults.Cpinc2;
            }

            set
            {
                calibrationResults.Cpinc2 = value;
            }
        }

        public string Cpinc3
        {
            get
            {
                return calibrationResults.Cpinc3;
            }

            set
            {
                calibrationResults.Cpinc3 = value;
            }
        }

        public string Cpdec1
        {
            get
            {
                return calibrationResults.Cpdec1;
            }

            set
            {
                calibrationResults.Cpdec1 = value;
            }
        }

        public string Cpdec2
        {
            get
            {
                return calibrationResults.Cpdec2;
            }

            set
            {
                calibrationResults.Cpdec2 = value;
            }
        }

        public string Cpdec3
        {
            get
            {
                return calibrationResults.Cpdec3;
            }

            set
            {
                calibrationResults.Cpdec3 = value;
            }
        }

        public string Atmn
        {
            get
            {
                return calibrationResults.Atmn;
            }

            set
            {
                calibrationResults.Atmn = value;
            }
        }

        public string Caltime
        {
            get
            {
                return calibrationResults.Caltime;
            }

            set
            {
                calibrationResults.Caltime = value;
            }
        }

        public string Zeror
        {
            get
            {
                return calibrationResults.Zeror;
            }

            set
            {
                calibrationResults.Zeror = value;
            }
        }

        public string Spanr
        {
            get
            {
                return calibrationResults.Spanr;
            }

            set
            {
                calibrationResults.Spanr = value;
            }
        }

        public string AdjUnit
        {
            get
            {
                return calibrationResults.AdjUnit;
            }

            set
            {
                calibrationResults.AdjUnit = value;
            }
        }

        public string WtMatl
        {
            get
            {
                return calibrationResults.WtMatl;
            }

            set
            {
                calibrationResults.WtMatl = value;
            }
        }

        public string FlSize
        {
            get
            {
                return calibrationResults.FlSize;
            }

            set
            {
                calibrationResults.FlSize = value;
            }
        }

        public string SerialNumberHipot
        {
            get
            {
                return deviceTestResult.SerialNumberHipot;
            }

            set
            {
                deviceTestResult.SerialNumberHipot = value;
            }
        }

        public string DeviceTestResult
        {
            get
            {
                return deviceTestResult.Result;
            }

            set
            {
                deviceTestResult.Result = value;
            }
        }

        public string IsolationV
        {
            get
            {
                return deviceTestResult.IsolationV;
            }

            set
            {
                deviceTestResult.IsolationV = value;
            }
        }

        public string IsolationR
        {
            get
            {
                return deviceTestResult.IsolationR;
            }

            set
            {
                deviceTestResult.IsolationR = value;
            }
        }

        public string IsolationT
        {
            get
            {
                return deviceTestResult.IsolationT;
            }

            set
            {
                deviceTestResult.IsolationT = value;
            }
        }

        public string IResult
        {
            get
            {
                return deviceTestResult.IResult;
            }

            set
            {
                deviceTestResult.IResult = value;
            }
        }

        public string WithStandV
        {
            get
            {
                return deviceTestResult.WithStandV;
            }

            set
            {
                deviceTestResult.WithStandV = value;
            }
        }

        public string WithStandI
        {
            get
            {
                return deviceTestResult.WithStandI;
            }

            set
            {
                deviceTestResult.WithStandI = value;
            }
        }

        public string WithStandT
        {
            get
            {
                return deviceTestResult.WithStandT;
            }

            set
            {
                deviceTestResult.WithStandT = value;
            }
        }


        public string WResult
        {
            get
            {
                return deviceTestResult.WResult;
            }

            set
            {
                deviceTestResult.WResult = value;
            }
        }

        public string TestDate
        {
            get
            {
                return deviceTestResult.TestDate;
            }

            set
            {
                deviceTestResult.TestDate = value;
            }
        }

        public string TestTime
        {
            get
            {
                return deviceTestResult.TestTime;
            }

            set
            {
                deviceTestResult.TestTime = value;
            }
        }

        public string TUser
        {
            get
            {
                return deviceTestResult.TUser;
            }

            set
            {
                deviceTestResult.TUser = value;
            }
        }

    }
}

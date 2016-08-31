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

        public string CapsuleNumber
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
    }
}

using System.Collections.Generic;

namespace ReportManager.Data.DataModel
{
    public class DeviceModel
    {
        private List<CalibrationResults> _calibrationResults;
        private List<DeviceTestResult> _deviceTestResults;
        private List<InputData> _inputData;
        private List<SerialNumber> _serialNumber;

        internal List<CalibrationResults> CalibrationResults
        {
            get
            {
                return _calibrationResults;
            }

            set
            {
                _calibrationResults = value;
            }
        }

        internal List<DeviceTestResult> DeviceTestResults
        {
            get
            {
                return _deviceTestResults;
            }

            set
            {
                _deviceTestResults = value;
            }
        }

        internal List<InputData> InputData
        {
            get
            {
                return _inputData;
            }

            set
            {
                _inputData = value;
            }
        }

        internal List<SerialNumber> SerialNumber
        {
            get
            {
                return _serialNumber;
            }

            set
            {
                _serialNumber = value;
            }
        }
    }
}

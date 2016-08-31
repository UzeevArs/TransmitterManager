using ReportManager.DataModel;

namespace ReportManager
{
    class ReportManagerContext
    {
        private static ReportManagerContext _instance;
        private DeviceModel currentDeviceModel;

        public DeviceModel CurrentDeviceModel
        {
            get
            {
                return currentDeviceModel;
            }
        }

        public static ReportManagerContext GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ReportManagerContext();
            }
            return _instance;
        }

        public void SetDeviceModel(DeviceModel model)
        {
            currentDeviceModel = model;
        }
    }
}

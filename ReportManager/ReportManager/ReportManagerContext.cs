using ReportManager.DataModel;

namespace ReportManager
{
    class ReportManagerContext
    {
        private static ReportManagerContext _instance;
        private DeviceModel currentDeviceModel;

        public DeviceModel CurrentDeviceModel => currentDeviceModel;

        public static ReportManagerContext GetInstance()
        {
            return _instance ?? (_instance = new ReportManagerContext());
        }

        public void SetDeviceModel(DeviceModel model)
        {
            currentDeviceModel = model;
        }
    }
}

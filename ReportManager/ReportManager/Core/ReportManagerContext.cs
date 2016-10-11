using System;
using System.Collections.Generic;
using ReportManager.Core.Functional;
using ReportManager.Core.Stages;
using ReportManager.Core.Utility;
using ReportManager.Data.DataModel;
using ReportManager.Data.Settings;
using ReportManager.Data.Database.NifudaDataSetTableAdapters;

namespace ReportManager.Core
{
    public class ReportManagerContext
    {
        private static ReportManagerContext _instance;
        private NifudaDataTableAdapter nifudaDataTableAdapter = new NifudaDataTableAdapter();

        private ReportManagerContext()
        {
            SettingsContext.SettingsLoadingEvent += SettingsContextOnSettingsLoadingEvent;
        }

        public void Dispose()
        {
            Functionals.ForEach(functional => functional?.Stop());
            Functionals.Clear();

            Stages.ForEach(stage => stage?.Dispose());
            Stages.Clear();
        }

        public event DeviceModelHandler DeviceModelCreatedStatus;

        private void SettingsContextOnSettingsLoadingEvent(object sender,
            Tuple<Settings, SettingsStatus, string> status)
        {
            if (status.Item2 == SettingsStatus.Changed
                || status.Item2 == SettingsStatus.SuccessLoaded)
            {
                Fill();
                Start();
            }
        }

        public void Fill()
        {
            Functionals.ForEach(functional => functional?.Stop());
            Functionals.Clear();

            Stages.ForEach(stage => stage?.Dispose());
            Stages.Clear();

            nifudaDataTableAdapter.Connection.ConnectionString = 
                SettingsContext.GlobalSettings.NifudaConnectionString;

            if (SettingsContext.GlobalSettings.Functionals != null)
                foreach (var function in SettingsContext.GlobalSettings.Functionals)
                    Functionals.Add(function);

            if (SettingsContext.GlobalSettings.Stages != null)
                foreach (var stage in SettingsContext.GlobalSettings.Stages)
                    Stages.Add(stage);
        }

        public void Start()
        {
            if (SettingsContext.GlobalSettings.Functionals != null)
                SettingsContext.GlobalSettings.Functionals.ForEach(functional => functional.Start());
        }

        public Tuple<DeviceModelStatus, DeviceModel> FillCurrentDeviceByMsCode(string msCode)
        {
            try
            {
                var dataBySerial = nifudaDataTableAdapter.GetDataBySerial(msCode);
                if (dataBySerial.Count == 0)
                {
                    DeviceModelCreatedStatus?.Invoke(this,
                        new Tuple<DeviceModelStatus, DeviceModel>(DeviceModelStatus.CreatedError, null));
                    return new Tuple<DeviceModelStatus, DeviceModel>(DeviceModelStatus.CreatedError, null);
                }

                CurrentDeviceModel =
                    DataModelCreator.GetDeviceBySerial(new SerialNumber { Serial = dataBySerial[0].SERIAL_NO });
                DeviceModelCreatedStatus?.Invoke(this,
                        new Tuple<DeviceModelStatus, DeviceModel>(DeviceModelStatus.CreatedSuccess, CurrentDeviceModel));
                return new Tuple<DeviceModelStatus, DeviceModel>(DeviceModelStatus.CreatedSuccess, CurrentDeviceModel);
            }
            catch
            {
                DeviceModelCreatedStatus?.Invoke(this,
                                        new Tuple<DeviceModelStatus, DeviceModel>(DeviceModelStatus.CreatedError, null));
                return new Tuple<DeviceModelStatus, DeviceModel>(DeviceModelStatus.CreatedError, null);
            }
        }

        public DeviceModel CurrentDeviceModel { get; private set; }

        public List<AbstractFunctional> Functionals { get; set; } = new List<AbstractFunctional>();
        public List<AbstractStage> Stages { get; set; } = new List<AbstractStage>();

        public static ReportManagerContext GetInstance()
        {
            return _instance ?? (_instance = new ReportManagerContext());
        }
    }

    public delegate void DeviceModelHandler(object sender, Tuple<DeviceModelStatus, DeviceModel> data);
    public enum DeviceModelStatus { CreatedSuccess, CreatedError }
}

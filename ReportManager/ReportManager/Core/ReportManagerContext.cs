using System;
using System.Collections.Generic;
using ReportManager.Core.Stages;
using ReportManager.Data.DataModel;
using ReportManager.Data.Settings;
using ReportManager.Data.Database.ConcreteAdapters;
using ReportManager.Data.SAP.ConcreteAdapters;
using System.Linq;
using ReportManager.TemperatureLogger.Modbus;
using ReportManager.Data.AbstractAdapters.Generic;

namespace ReportManager.Core
{
    internal class ReportManagerContext
    {
        private static ReportManagerContext _instance;
        private ISelectBySerialAdapter<InputData> inputDataAdapter = new SapResultDatabaseAdapter();

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

        public event EventHandler<(DeviceModelStatus, InputData)> InputDataCreatedStatus;

        private void SettingsContextOnSettingsLoadingEvent(object sender, (Settings, SettingsStatus, string) status)
        {
            var (settings, settingStatus, message) = status;
            if (settingStatus == SettingsStatus.Changed 
                || settingStatus == SettingsStatus.SuccessLoaded)
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

            Functionals.AddRange(SettingsContext.CurrentUser.UserExtraFunction);
            Stages.AddRange(SettingsContext.CurrentUser.UserStages);
        }

        public void Start()
        {
            Functionals.ForEach(functional => functional.Start());
        }

        public (DeviceModelStatus status, InputData input) FillCurrentDeviceByMsCode(string msCode)
        {
            try
            {
                //TODO: CHANGED 
                //var dataBySerial = inputDataAdapter.SelectDataByIndex(msCode).ToList();

                var dataBySerial = inputDataAdapter.SelectBySerial(msCode).ToList();
                if (dataBySerial.Count() == 0)
                {
                    InputDataCreatedStatus?.Invoke(this, (DeviceModelStatus.CreatedError, null));
                    return (DeviceModelStatus.CreatedError, null);
                }
                //dataBySerial[0].SERIAL_NO
                CurrentInput = inputDataAdapter.SelectBySerial(msCode).FirstOrDefault();
                if (CurrentInput == null)
                {
                    InputDataCreatedStatus?.Invoke(this, (DeviceModelStatus.CreatedError, null));
                    return (DeviceModelStatus.CreatedError, null);
                }

                InputDataCreatedStatus?.Invoke(this, (DeviceModelStatus.CreatedSuccess, CurrentInput));
                return (DeviceModelStatus.CreatedSuccess, CurrentInput);
            }
            catch (Exception ex)
            {

                InputDataCreatedStatus?.Invoke(this, (DeviceModelStatus.CreatedError, null));
                return (DeviceModelStatus.CreatedError, null);
            }
        }
        //public (DeviceModelStatus status, InputData input) FillCurrentDeviceByMsCode(string msCode)
        //{
        //    try
        //    {
        //        var dataBySerial = inputDataAdapter.SelectBySerial(msCode).ToList();
        //        if (dataBySerial.Count() == 0)
        //        {
        //            InputDataCreatedStatus?.Invoke(this, (DeviceModelStatus.CreatedError, null));
        //            return (DeviceModelStatus.CreatedError, null);
        //        }

        //        CurrentInput = inputDataAdapter.SelectBySerial(dataBySerial[0].SERIAL_NO).FirstOrDefault();
        //        if (CurrentInput == null)
        //        {
        //            InputDataCreatedStatus?.Invoke(this, (DeviceModelStatus.CreatedError, null));
        //            return (DeviceModelStatus.CreatedError, null);
        //        }

        //        InputDataCreatedStatus?.Invoke(this, (DeviceModelStatus.CreatedSuccess, CurrentInput));
        //        return (DeviceModelStatus.CreatedSuccess, CurrentInput);
        //    }
        //    catch
        //    {
        //        InputDataCreatedStatus?.Invoke(this, (DeviceModelStatus.CreatedError, null));
        //        return (DeviceModelStatus.CreatedError, null);
        //    }
        //}

        public InputData CurrentInput { get; private set; }
        public TemperatureDevice Device { get; private set; } = new TemperatureDevice();

        public List<Functional.Functional> Functionals { get; set; } = new List<Functional.Functional>();
        public List<Stage> Stages { get; set; } = new List<Stage>();

        public static ReportManagerContext GetInstance()
        {
            return _instance ?? (_instance = new ReportManagerContext());
        }
    }

    public enum DeviceModelStatus { CreatedSuccess, CreatedError }
}

using System;
using System.Collections.Generic;
using ReportManager.Core.Stages;
using ReportManager.Data.DataModel;
using ReportManager.Data.Settings;
using ReportManager.Data.Database.ConcreteAdapters;
using ReportManager.Data.SAP.ConcreteAdapters;
using System.Linq;
using ReportManager.TemperatureLogger.Modbus;
using Stateless;

namespace ReportManager.Core
{
    internal class ReportManagerContext
    {
        private enum InputDataStates
        {
            Initial,
            NifudaRequest, NifudaCheckData, NifudaConnectionError,
            SapRequest, SapCheckData, SapErrorConnection, SapErrorNoData,
            NifudaInsert, NifudaInsertCheckData, NifudaInsertError,
            SuccessNifuda, SuccessSap
        }

        private enum InputDataTriggers
        {
            Start,
            ToErrorNifudaConnection,
            ToCheckNifudaData,
            Reset,
            ToSapRequest,
            ToSuccessNifuda,
            ToSapCheckData,
            ToErrorSapConnection,
            ToNifudaInsert,
            ToSapErrorNoData,
            ToNifudaInsertCheckData,
            ToNifudaInsertError,
            ToSuccessSap

        }

        private static ReportManagerContext _instance;
        private SapResultDatabaseAdapter sapDataAdapter = new SapResultDatabaseAdapter();
        private NifudaInputDataDatabaseAdapter nifudaDataAdapter = new NifudaInputDataDatabaseAdapter();
        private StateMachine<InputDataStates, InputDataTriggers> InputDataStateMachine =
            new StateMachine<InputDataStates, InputDataTriggers>(InputDataStates.Initial);

        private ReportManagerContext()
        {
            SettingsContext.SettingsLoadingEvent += SettingsContextOnSettingsLoadingEvent;

            InputDataStateMachine.Configure(InputDataStates.Initial)
                                 .Permit(InputDataTriggers.Start, InputDataStates.NifudaRequest);

            InputDataStateMachine.Configure(InputDataStates.NifudaRequest)
                                 .OnEntry(NifudaRequest)
                                 .Permit(InputDataTriggers.ToCheckNifudaData, InputDataStates.NifudaCheckData)
                                 .Permit(InputDataTriggers.ToErrorNifudaConnection, InputDataStates.NifudaConnectionError);

            InputDataStateMachine.Configure(InputDataStates.NifudaConnectionError)
                                 .OnEntry(NifudaConnectionError)
                                 .Permit(InputDataTriggers.Reset, InputDataStates.Initial);

            InputDataStateMachine.Configure(InputDataStates.NifudaCheckData)
                                 .OnEntry(NifudaCheckData)
                                 .Permit(InputDataTriggers.ToSapRequest, InputDataStates.SapRequest)
                                 .Permit(InputDataTriggers.ToSuccessNifuda, InputDataStates.SuccessNifuda);

            InputDataStateMachine.Configure(InputDataStates.SuccessNifuda)
                                 .OnEntry(SuccessNifuda)
                                 .Permit(InputDataTriggers.Reset, InputDataStates.Initial);

            InputDataStateMachine.Configure(InputDataStates.SapRequest)
                                 .OnEntry(SapRequest)
                                 .Permit(InputDataTriggers.ToSapCheckData, InputDataStates.SapCheckData)
                                 .Permit(InputDataTriggers.ToErrorSapConnection, InputDataStates.SapErrorConnection);

            InputDataStateMachine.Configure(InputDataStates.SapErrorConnection)
                                 .OnEntry(SapErrorConnection)
                                 .Permit(InputDataTriggers.Reset, InputDataStates.Initial);

            InputDataStateMachine.Configure(InputDataStates.SapCheckData)
                                .OnEntry(SapCheckData)
                                .Permit(InputDataTriggers.ToNifudaInsert, InputDataStates.NifudaInsert)
                                .Permit(InputDataTriggers.ToSapErrorNoData, InputDataStates.SapErrorNoData);

            InputDataStateMachine.Configure(InputDataStates.SapErrorNoData)
                                 .OnEntry(SapErrorNoData)
                                 .Permit(InputDataTriggers.Reset, InputDataStates.Initial);

            InputDataStateMachine.Configure(InputDataStates.NifudaInsert)
                                 .OnEntry(NifudaInsert)
                                 .Permit(InputDataTriggers.ToNifudaInsertCheckData, InputDataStates.NifudaInsertCheckData)
                                 .Permit(InputDataTriggers.ToNifudaInsertError, InputDataStates.NifudaInsertError);

            InputDataStateMachine.Configure(InputDataStates.NifudaInsertCheckData)
                                 .OnEntry(NifudaInsertCheckData)
                                 .Permit(InputDataTriggers.ToSuccessSap, InputDataStates.SuccessSap)
                                 .Permit(InputDataTriggers.ToNifudaInsertError, InputDataStates.NifudaInsertError);

            InputDataStateMachine.Configure(InputDataStates.NifudaInsertError)
                                 .OnEntry(NifudaInsertError)
                                 .Permit(InputDataTriggers.Reset, InputDataStates.Initial);

            InputDataStateMachine.Configure(InputDataStates.SuccessSap)
                                 .OnEntry(SuccessSap)
                                 .Permit(InputDataTriggers.Reset, InputDataStates.Initial);
        }

        public void Dispose()
        {
            Functionals.ForEach(functional => functional?.Stop());
            Functionals.Clear();

            Stages.ForEach(stage => stage?.Dispose());
            Stages.Clear();
        }

        public event EventHandler<(DeviceModelStatus Status,
                                   string ErrorMessage,
                                   InputData data)> InputDataCreatedStatus;

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
            // Без автостарта 
            // Functionals.ForEach(functional => functional.Start());
        }

        public void FillCurrentDeviceByMsCode(string msCode)
        {
            MsCode = msCode;
            InputDataStateMachine.Fire(InputDataTriggers.Start);
        }

        #region InputDataStateMachine methods
        private string Error { get; set; } = "";
        private string MsCode { get; set; } = "";
        private IEnumerable<InputData> FromNifudaRequest { get; set; }
        private IEnumerable<InputData> FromSapRequest { get; set; }

        private void NifudaRequest()
        {
            try
            {
                FromNifudaRequest = nifudaDataAdapter.SelectBySerial(MsCode);
                InputDataStateMachine.Fire(InputDataTriggers.ToCheckNifudaData);
            }
            catch (Exception ex)
            {
                InputDataStateMachine.Fire(InputDataTriggers.ToErrorNifudaConnection);
                Error = ex.Message;
            }
        }

        private void NifudaConnectionError()
        {
            InputDataCreatedStatus?.Invoke(this, (DeviceModelStatus.ErrorNifudaConnection, Error, null));
            InputDataStateMachine.Fire(InputDataTriggers.Reset);
        }

        private void NifudaCheckData()
        {
            if (FromNifudaRequest.Count() == 0)
                InputDataStateMachine.Fire(InputDataTriggers.ToSapRequest);
            else
                InputDataStateMachine.Fire(InputDataTriggers.ToSuccessNifuda);
        }

        private void SuccessNifuda()
        {
            InputDataCreatedStatus?.Invoke(this, (DeviceModelStatus.SuccessNifuda, "", FromNifudaRequest.First()));
            InputDataStateMachine.Fire(InputDataTriggers.Reset);
        }

        private void SapRequest()
        {
            try
            {
                FromSapRequest = sapDataAdapter.SelectBySerial(MsCode);
                InputDataStateMachine.Fire(InputDataTriggers.ToSapCheckData);
            }
            catch (Exception ex)
            {
                InputDataStateMachine.Fire(InputDataTriggers.ToErrorSapConnection);
                Error = ex.Message;
            }
        }

        private void SapErrorConnection()
        {
            InputDataCreatedStatus?.Invoke(this, (DeviceModelStatus.ErrorSapConnection, Error, null));
            InputDataStateMachine.Fire(InputDataTriggers.Reset);
        }

        private void SapCheckData()
        {
            if (FromSapRequest.Count() > 0
                && !FromSapRequest.First().SERIAL_NO.Equals(string.Empty))
                InputDataStateMachine.Fire(InputDataTriggers.ToNifudaInsert);
            else
                InputDataStateMachine.Fire(InputDataTriggers.ToSapErrorNoData);
        }

        private void SapErrorNoData()
        {
            InputDataCreatedStatus?.Invoke(this, (DeviceModelStatus.ErrorSapNoData, "", null));
            InputDataStateMachine.Fire(InputDataTriggers.Reset);
        }

        private void NifudaInsert()
        {
            try
            {
                nifudaDataAdapter.Insert(FromSapRequest);
                InputDataStateMachine.Fire(InputDataTriggers.ToNifudaInsertCheckData);
            }
            catch (Exception ex)
            {
                InputDataStateMachine.Fire(InputDataTriggers.ToNifudaInsertError);
                Error = ex.Message;
            }
        }

        private void NifudaInsertCheckData()
        {
            try
            {
                var NifudaRequest = nifudaDataAdapter.SelectBySerial(MsCode);
                if (NifudaRequest.Count() > 0)
                {
                    InputDataStateMachine.Fire(InputDataTriggers.ToSuccessSap);
                }
                else
                {
                    throw new Exception("No Inserted Data");
                }
            }
            catch (Exception ex)
            {
                InputDataStateMachine.Fire(InputDataTriggers.ToNifudaInsertError);
                Error = ex.Message;
            }

        }

        private void NifudaInsertError()
        {
            InputDataCreatedStatus?.Invoke(this, (DeviceModelStatus.NifudaInsertError, Error, null));
            InputDataStateMachine.Fire(InputDataTriggers.Reset);

        }

        private void SuccessSap()
        {
            InputDataCreatedStatus?.Invoke(this, (DeviceModelStatus.SuccessSap, "", FromSapRequest.First()));
            InputDataStateMachine.Fire(InputDataTriggers.Reset);
        }

        #endregion

        public InputData CurrentInput { get; private set; }
        public TemperatureDevice Device { get; private set; } = new TemperatureDevice();

        public List<Functional.Functional> Functionals { get; set; } = new List<Functional.Functional>();
        public List<Stage> Stages { get; set; } = new List<Stage>();

        public static ReportManagerContext GetInstance()
        {
            return _instance ?? (_instance = new ReportManagerContext());
        }
    }



    public enum DeviceModelStatus
    {
        ErrorNifudaConnection, SuccessNifuda, ErrorSapConnection,
        ErrorSapNoData, NifudaInsertError, SuccessSap
    }
}

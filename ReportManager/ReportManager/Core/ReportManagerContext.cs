using System;
using System.Collections.Generic;
using ReportManager.Core.Stages;
using ReportManager.Data.DataModel;
using ReportManager.Data.Settings;
using ReportManager.Data.SAP.ConcreteAdapters;
using System.Linq;
using ReportManager.TemperatureLogger.Modbus;
using Stateless;
using System.Threading.Tasks;
using ReportManager.Data.Database.DataSet1TableAdapters;
using ReportManager.Core.Utility;
using ReportManager.Data.Database.ConcreteAdapters;

namespace ReportManager.Core
{
    internal class ReportManagerContext
    {
        private enum InputDataStates
        {
            Initial, NifudaRequestBySapIndexNo,
            NifudaRequestByIndexNo, NifudaConnectionError,
            SapRequest, SapCheckData, SapErrorConnection, SapErrorNoData,
            IndexNoGenerattion, IndexNoGenerationError, IndexNODatabaseConnectionError,
            NifudaInsert, NifudaInsertCheckData, NifudaInsertError,
            SuccessNifuda, SuccessSap
        }

        private enum InputDataTriggers
        {
            Start,
            ToErrorNifudaConnection,
            Reset,
            ToSapRequest,
            ToSuccessNifuda,
            ToSapCheckData,
            ToErrorIndexNODatabaseConnection,
            ToErrorIndexNOGeneration,
            ToErrorSapConnection,
            ToIndexNoGeneration,
            ToNifudaInsert,
            ToSapErrorNoData,
            ToNifudaRequestBySapIndexNo,
            ToNifudaInsertCheckData,
            ToNifudaInsertError,
            ToSuccessSap
        }

        private static ReportManagerContext _instance;
        private SapResultDatabaseAdapter sapDataAdapter = new SapResultDatabaseAdapter();
        private NifudaInputDataDatabaseAdapter nifudaDataAdapter = new NifudaInputDataDatabaseAdapter();
        private IndexNODataAdapter indexNODataAdapter = new IndexNODataAdapter();
        private StateMachine<InputDataStates, InputDataTriggers> InputDataStateMachine =
            new StateMachine<InputDataStates, InputDataTriggers>(InputDataStates.Initial);

        private ReportManagerContext()
        {
            SettingsContext.SettingsLoadingEvent += SettingsContextOnSettingsLoadingEvent;

            InputDataStateMachine.Configure(InputDataStates.Initial)
                                 .Permit(InputDataTriggers.Start, InputDataStates.NifudaRequestByIndexNo);

            InputDataStateMachine.Configure(InputDataStates.NifudaRequestByIndexNo)
                                 .OnEntry(NifudaRequestByIndexNo)
                                 .Permit(InputDataTriggers.ToNifudaRequestBySapIndexNo, InputDataStates.NifudaRequestBySapIndexNo)
                                 .Permit(InputDataTriggers.ToSuccessNifuda, InputDataStates.SuccessNifuda)
                                 .Permit(InputDataTriggers.ToErrorIndexNODatabaseConnection, InputDataStates.IndexNODatabaseConnectionError);

            InputDataStateMachine.Configure(InputDataStates.NifudaRequestBySapIndexNo)
                                 .OnEntry(NifudaRequestBySapIndexNo)
                                 .Permit(InputDataTriggers.ToSapRequest, InputDataStates.SapRequest)
                                 .Permit(InputDataTriggers.ToSuccessNifuda, InputDataStates.SuccessNifuda)
                                 .Permit(InputDataTriggers.ToErrorIndexNODatabaseConnection, InputDataStates.IndexNODatabaseConnectionError);

            InputDataStateMachine.Configure(InputDataStates.IndexNODatabaseConnectionError)
                                 .OnEntry(IndexNODatabaseConnectionError)
                                 .Permit(InputDataTriggers.Reset, InputDataStates.Initial);

            InputDataStateMachine.Configure(InputDataStates.NifudaConnectionError)
                                 .OnEntry(NifudaConnectionError)
                                 .Permit(InputDataTriggers.Reset, InputDataStates.Initial);

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
                                 .Permit(InputDataTriggers.ToIndexNoGeneration, InputDataStates.IndexNoGenerattion)
                                 .Permit(InputDataTriggers.ToSapErrorNoData, InputDataStates.SapErrorNoData);

            InputDataStateMachine.Configure(InputDataStates.IndexNoGenerattion)
                                 .OnEntry(IndexNoGeneration)
                                 .Permit(InputDataTriggers.ToNifudaInsert, InputDataStates.NifudaInsert)
                                 .Permit(InputDataTriggers.ToErrorIndexNOGeneration, InputDataStates.IndexNoGenerationError);

            InputDataStateMachine.Configure(InputDataStates.IndexNoGenerationError)
                                 .OnEntry(IndexNoGenerattionError)
                                 .Permit(InputDataTriggers.Reset, InputDataStates.Initial);

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

        public async Task FillCurrentDeviceByMsCodeAsync(string msCode)
        {
            await Task.Run(() =>
            {
                RequestNo = msCode;
                InputDataStateMachine.Fire(InputDataTriggers.Start);
            });
        }

        #region InputDataStateMachine methods
        private string Error { get; set; } = "";
        private string RequestNo { get; set; } = "";
        private IEnumerable<IndexNOResult> ToIndexNORequest { get; set; }
        private IEnumerable<IndexNOResult> FromIndexNORequest { get; set; }
        private IEnumerable<InputData> FromNifudaRequest { get; set; }
        private IEnumerable<InputData> FromSapRequest { get; set; }

        private void NifudaRequestByIndexNo()
        {
            try
            {
                FromNifudaRequest = nifudaDataAdapter.SelectDataByIndexNo(RequestNo).ToList();
                if (FromNifudaRequest.Count() == 0)
                {
                    InputDataStateMachine.Fire(InputDataTriggers.ToNifudaRequestBySapIndexNo);
                }
                else
                {
                    FromNifudaRequest = nifudaDataAdapter.SelectDataByIndexNo(RequestNo).ToList();
                    InputDataStateMachine.Fire(InputDataTriggers.ToSuccessNifuda);
                }
            }
            catch (Exception ex)
            {
                InputDataStateMachine.Fire(InputDataTriggers.ToErrorIndexNODatabaseConnection);
                Error = ex.Message;
            }
        }
        private void NifudaRequestBySapIndexNo()
        {
            try
            {
                FromIndexNORequest =  indexNODataAdapter.SelectDataByIndex(RequestNo, null).ToList();
                if (FromIndexNORequest.Count() == 0)
                {
                    InputDataStateMachine.Fire(InputDataTriggers.ToSapRequest);
                }
                else
                {
                   
                    FromNifudaRequest = nifudaDataAdapter.SelectDataByIndexNo(FromIndexNORequest.First().INDEX_NO).ToList();
                    InputDataStateMachine.Fire(InputDataTriggers.ToSuccessNifuda);
                }
            }
            catch (Exception ex)
            {
                InputDataStateMachine.Fire(InputDataTriggers.ToErrorIndexNODatabaseConnection);
                Error = ex.Message;
            }
        }

        private void IndexNODatabaseConnectionError()
        {
            InputDataCreatedStatus?.Invoke(this, (DeviceModelStatus.ErrorIndexNoDatabaseConnection, Error, null));
            InputDataStateMachine.Fire(InputDataTriggers.Reset);
        }

        private void NifudaConnectionError()
        {
            InputDataCreatedStatus?.Invoke(this, (DeviceModelStatus.ErrorNifudaConnection, Error, null));
            InputDataStateMachine.Fire(InputDataTriggers.Reset);
        }

       
        private void SuccessNifuda()
        {
            CurrentInput = FromNifudaRequest.First();
            InputDataCreatedStatus?.Invoke(this, (DeviceModelStatus.SuccessNifuda, RequestNo , FromNifudaRequest.First()));
            InputDataStateMachine.Fire(InputDataTriggers.Reset);
        }

        private void SapRequest()
        {
            try
            {
                FromSapRequest = sapDataAdapter.SelectBySerial(RequestNo).ToList();
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
            try
            {
                if (FromSapRequest.Count() > 0
                && !(FromSapRequest.First().SERIAL_NO == string.Empty))
                    InputDataStateMachine.Fire(InputDataTriggers.ToIndexNoGeneration);
                else
                    InputDataStateMachine.Fire(InputDataTriggers.ToSapErrorNoData);
            }
            catch (Exception ex)
            {
                InputDataStateMachine.Fire(InputDataTriggers.ToSapErrorNoData);
                Error = ex.Message;
            }
        }

        private void SapErrorNoData()
        {
            InputDataCreatedStatus?.Invoke(this, (DeviceModelStatus.ErrorSapNoData, RequestNo, null));
            InputDataStateMachine.Fire(InputDataTriggers.Reset);
        }

        private void IndexNoGeneration()
        {
            

            try
            {
                var result = new IndexNOResult
                {
                    INDEX_NO = IndexNOGenerator.IndexNoLastNumber().ToString(),
                    SAP_INDEX_NO = FromSapRequest.First().INDEX_NO
                };
                indexNODataAdapter.Insert(new List<IndexNOResult> { result } ,null);
                FromSapRequest.First().INDEX_NO = result.INDEX_NO;
                InputDataStateMachine.Fire(InputDataTriggers.ToNifudaInsert);
            }
            catch(Exception ex)
            {
                InputDataStateMachine.Fire(InputDataTriggers.ToErrorIndexNOGeneration);
                Error = ex.Message;
            }
        }

        private void IndexNoGenerattionError()
        {
            InputDataCreatedStatus?.Invoke(this, (DeviceModelStatus.ErrorIndexNOGeneration, RequestNo, null));
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
                var NifudaRequest = nifudaDataAdapter.SelectBySerial(FromSapRequest.First().SERIAL_NO);
                if (NifudaRequest.Count() > 0)
                    InputDataStateMachine.Fire(InputDataTriggers.ToSuccessSap);
                else
                    throw new Exception("No Inserted Data");
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
            CurrentInput = FromSapRequest.First();
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

    internal enum DeviceModelStatus
    {
        ErrorNifudaConnection, SuccessNifuda, ErrorSapConnection,
        ErrorSapNoData, NifudaInsertError, SuccessSap, ErrorIndexNOGeneration, ErrorIndexNoDatabaseConnection
    }
}

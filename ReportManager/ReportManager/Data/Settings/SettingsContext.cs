using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using ReportManager.Core.Functional;
using ReportManager.Core.Stages;

namespace ReportManager.Data.Settings
{
    public static class SettingsContext
    {
        private static readonly string SettingsPath =
            $@"{Environment.GetEnvironmentVariable("AllUsersProfile")}\ReportManagerSettings\Settings.xml";

        public static event EventHandler<Tuple<Settings, SettingsStatus, string>> SettingsLoadingEvent;

        public static Settings GlobalSettings { get; private set; } = new Settings();

        public static string UserName { get; set; }
        public static string UserPassword { get; set; }

        public static Tuple<SettingsStatus, string> SaveSettings()
        {
            try
            {
                CreateSettingsFolder();

                var xs = new XmlSerializer(typeof(Settings));
                using (Stream writer = new FileStream(SettingsPath, FileMode.Create))
                {
                    xs.Serialize(writer, GlobalSettings);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                SettingsLoadingEvent?.Invoke(GlobalSettings,
                    new Tuple<Settings, SettingsStatus, string>(GlobalSettings, SettingsStatus.ErrorSaved, ex.Message));
                return new Tuple<SettingsStatus, string>(SettingsStatus.ErrorSaved, ex.Message);
            }

            SettingsLoadingEvent?.Invoke(GlobalSettings,
                new Tuple<Settings, SettingsStatus, string>(GlobalSettings, SettingsStatus.SuccessSaved, ""));
            return new Tuple<SettingsStatus, string>(SettingsStatus.SuccessSaved, "");
        }

        public static Tuple<SettingsStatus, string> LoadGlobalSettings()
        {
            try
            {
                CreateSettingsFolder();

                var xs = new XmlSerializer(typeof(Settings));
                using (Stream reader = new FileStream(SettingsPath, FileMode.Open))
                {
                    GlobalSettings = (Settings)xs.Deserialize(reader);
                    reader.Close();
                }

                SettingsLoadingEvent?.Invoke(GlobalSettings,
                   new Tuple<Settings, SettingsStatus, string>(GlobalSettings, SettingsStatus.SuccessLoaded, ""));
                return new Tuple<SettingsStatus, string>(SettingsStatus.SuccessLoaded, "");
            }
            catch (Exception ex)
            {
                SettingsLoadingEvent?.Invoke(GlobalSettings,
                   new Tuple<Settings, SettingsStatus, string>(GlobalSettings, SettingsStatus.ErrorLoaded, ex.Message));
                return new Tuple<SettingsStatus, string>(SettingsStatus.ErrorLoaded, ex.Message);
            }
        }

        public static void NotifyChanged()
        {
            SettingsLoadingEvent?.Invoke(GlobalSettings,
                  new Tuple<Settings, SettingsStatus, string>(GlobalSettings, SettingsStatus.Changed, ""));
        }

        public static Tuple<SettingsStatus, string> LoadDefaultSettings()
        {
            GlobalSettings = new Settings
            {
                IsupConnectionString = "Data Source=10.26.0.35;Initial Catalog=yru_v2;Persist Security Info=True;User ID=yru_operator;Password=yru_operator",
                NifudaConnectionString = "Data Source=HIS0555\\;Initial Catalog=YruPCIassembling;User ID=YruPCItestUser; Password=YruPCItestUser",
                ReportSavePath = "C:\\",
                UpdateTimeout = 1000,
                Stages = new List<AbstractStage>(),
                Functionals = new List<AbstractFunctional>()
            };

            SettingsLoadingEvent?.Invoke(GlobalSettings,
                   new Tuple<Settings, SettingsStatus, string>(GlobalSettings, SettingsStatus.SuccessLoaded, ""));
            return new Tuple<SettingsStatus, string>(SettingsStatus.SuccessLoaded, "");
        }

        private static void CreateSettingsFolder()
        {
            var directoryPath = $@"{Environment.GetEnvironmentVariable("AllUsersProfile")}\ReportManagerSettings";
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
        }
    }

    public enum SettingsStatus
    {
        SuccessLoaded, ErrorLoaded, SuccessSaved, ErrorSaved, Changed
    }
}

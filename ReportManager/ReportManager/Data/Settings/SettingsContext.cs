using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using ReportManager.Core.Functional;
using ReportManager.Core.Stages;
using ReportManager.Data.DataModel;

namespace ReportManager.Data.Settings
{
    internal static class SettingsContext
    {
        private static readonly string SettingsPath =
            $@"{Environment.GetEnvironmentVariable("AllUsersProfile")}\ReportManagerSettings\Settings.xml";

        public static event EventHandler<(Settings settings, SettingsStatus status, string error)> SettingsLoadingEvent;

        public static Settings GlobalSettings { get; private set; } = new Settings();

        public static User CurrentUser { get; set; } = new User();

        public static (SettingsStatus status, string message) SaveSettings()
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
                SettingsLoadingEvent?.Invoke(GlobalSettings, (GlobalSettings, SettingsStatus.ErrorSaved, ex.Message));
                return (SettingsStatus.ErrorSaved, ex.Message);
            }

            SettingsLoadingEvent?.Invoke(GlobalSettings, (GlobalSettings, SettingsStatus.SuccessSaved, ""));
            return (SettingsStatus.SuccessSaved, "");
        }

        public static (SettingsStatus status, string message) LoadGlobalSettings()
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

                SettingsLoadingEvent?.Invoke(GlobalSettings, (GlobalSettings, SettingsStatus.SuccessLoaded, ""));
                return (SettingsStatus.SuccessLoaded, "");
            }
            catch (Exception ex)
            {
                SettingsLoadingEvent?.Invoke(GlobalSettings, (GlobalSettings, SettingsStatus.ErrorLoaded, ex.Message));
                return (SettingsStatus.ErrorLoaded, ex.Message);
            }
        }

        public static void NotifyChanged()
        {
            SettingsLoadingEvent?.Invoke(GlobalSettings, (GlobalSettings, SettingsStatus.Changed, ""));
        }

        public static (SettingsStatus status, string message) LoadDefaultSettings()
        {
            GlobalSettings = new Settings
            {
                IsupConnectionString = "Data Source=10.26.0.35;Initial Catalog=yru_v2;Persist Security Info=True;User ID=yru_operator;Password=yru_operator",
                NifudaConnectionString = "Data Source=HIS0555\\;Initial Catalog=YruPCIassembling;User ID=YruPCItestUser; Password=YruPCItestUser",
                ReportSavePath = "C:\\",
                UpdateTimeout = 1000,
            };

            SettingsLoadingEvent?.Invoke(GlobalSettings, (GlobalSettings, SettingsStatus.SuccessLoaded, ""));
            return (SettingsStatus.SuccessLoaded, "");
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

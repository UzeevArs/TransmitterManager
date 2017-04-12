using System;
using System.IO;
using ReportManager.Data.Settings;

namespace ReportManager.Core.Utility
{
    public class FolderUtility
    {
        public static (FolderUtilityStatus Status, string Extra) CheckAndCreateCurrentPath(string stageName)
        {
            var path = SettingsContext.GlobalSettings.ReportSavePath;
            var time = DateTime.Now;

            if (!Directory.Exists($"{path}"))
            {
                try
                {
                    Directory.CreateDirectory($"{path}");
                }
                catch (Exception ex)
                {
                    return (FolderUtilityStatus.Error, ex.Message);
                }
            }

            if (!Directory.Exists($"{path}\\{stageName}"))
            {
                try
                {
                    Directory.CreateDirectory($"{path}\\{stageName}");
                }
                catch (Exception ex)
                {
                    return (FolderUtilityStatus.Error, ex.Message);
                }
            }

            if (!Directory.Exists($"{path}\\{stageName}\\{time.Year}"))
            {
                try
                {
                    Directory.CreateDirectory($"{path}\\{stageName}\\{time.Year}");
                }
                catch (Exception ex)
                {
                    return (FolderUtilityStatus.Error, ex.Message);
                }
            }

            if (!Directory.Exists($"{path}\\{stageName}\\{time.Year}\\{time.Month}"))
            {
                try
                {
                    Directory.CreateDirectory($"{path}\\{stageName}\\{time.Year}\\{time.Month}");
                }
                catch (Exception ex)
                {
                    return (FolderUtilityStatus.Error, ex.Message);
                }
            }

            if (!Directory.Exists($"{path}\\{stageName}\\{time.Year}\\{time.Month}\\{time.Day}"))
            {
                try
                {
                    Directory.CreateDirectory($"{path}\\{stageName}\\{time.Year}\\{time.Month}\\{time.Day}");
                }
                catch (Exception ex)
                {
                    return (FolderUtilityStatus.Error, ex.Message);
                }
            }

            return (FolderUtilityStatus.Success, $"{path}\\{stageName}\\{time.Year}\\{time.Month}\\{time.Day}\\");
        }
    }

    public enum FolderUtilityStatus { Success, Error }
}

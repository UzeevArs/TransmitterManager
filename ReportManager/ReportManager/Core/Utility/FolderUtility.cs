using System;
using System.IO;
using ReportManager.Data.Settings;

namespace ReportManager.Core.Utility
{
    public class FolderUtility
    {
        public static Tuple<FolderUtilityStatus, string> CheckAndCreateCurrentPath()
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
                    return new Tuple<FolderUtilityStatus,
                        string>(FolderUtilityStatus.Error, ex.Message);
                }
            }

            if (!Directory.Exists($"{path}\\{time.Year}"))
            {
                try
                {
                    Directory.CreateDirectory($"{path}\\{time.Year}");
                }
                catch (Exception ex)
                {
                    return new Tuple<FolderUtilityStatus,
                        string>(FolderUtilityStatus.Error, ex.Message);
                }
            }

            if (!Directory.Exists($"{path}\\{time.Year}\\{time.Month}"))
            {
                try
                {
                    Directory.CreateDirectory($"{path}\\{time.Year}\\{time.Month}");
                }
                catch (Exception ex)
                {
                    return new Tuple<FolderUtilityStatus,
                        string>(FolderUtilityStatus.Error, ex.Message);
                }
            }

            if (!Directory.Exists($"{path}\\{time.Year}\\{time.Month}\\{time.Day}"))
            {
                try
                {
                    Directory.CreateDirectory($"{path}\\{time.Year}\\{time.Month}\\{time.Day}");
                }
                catch (Exception ex)
                {
                    return new Tuple<FolderUtilityStatus,
                        string>(FolderUtilityStatus.Error, ex.Message);
                }
            }

            return new Tuple<FolderUtilityStatus, string>(FolderUtilityStatus.Success, 
                $"{path}\\{time.Year}\\{time.Month}\\{time.Day}\\");
        }
    }

    public enum FolderUtilityStatus { Success, Error }
}

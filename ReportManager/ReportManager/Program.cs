using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Skins;
using ReportManager.Core;
using ReportManager.Core.Logger;
using ReportManager.Data.Settings;
using ReportManager.Forms;

namespace ReportManager
{
    static class Program
    {
        private static readonly Mutex mutex = new Mutex(true, "{49d5ce46-ac41-4baa-8c03-82798ec2c81e}");

        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
                SkinManager.EnableFormSkins();
                DevExpress.UserSkins.BonusSkins.Register();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                LoadSettings();
                Application.Run(new StagesForm());
                mutex.ReleaseMutex();
            }
            else
            {
                NativeMethods.PostMessage(
                    (IntPtr)NativeMethods.HWND_BROADCAST,
                    NativeMethods.WM_SHOWME,
                    IntPtr.Zero,
                    IntPtr.Zero);
            }
        }

        private static void CurrentDomainOnUnhandledException(object sender, 
            UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
            Log.UE(unhandledExceptionEventArgs.ExceptionObject.ToString());
        }

        private static void LoadSettings()
        {
            if (SettingsContext.LoadGlobalSettings().Item1 == SettingsStatus.ErrorLoaded)
            {
                SettingsContext.LoadDefaultSettings();
                SettingsContext.SaveSettings();
            }
        }
    }

    internal static class NativeMethods
    {
        public const int HWND_BROADCAST = 0xffff;

        public static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME");
        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);
    }
}

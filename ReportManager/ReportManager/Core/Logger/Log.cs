using System;
using System.IO;

namespace ReportManager.Core.Logger
{
    public static class Log
    {
        public static void L(string message)
        {
            Console.Write(message);
        }

        public static void E(string message)
        {
            Console.Write(message);
        }

        public static void UE(string exception)
        {
            using (var ueFile = new StreamWriter("undefined_exceptions_log.log", true))
            {
                ueFile.Write($"Exception datetime: {DateTime.Now}. Exception: \n{exception}\n\n");
            }
        }
    }
}

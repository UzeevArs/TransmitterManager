namespace ReportManager.Core.Utility
{
    public static class FlagsHelper
    {
        public static bool IsSet<T>(this T flags, T flag) where T : struct
        {
            long flagsValue = (long)(object)flags;
            long flagValue = (long)(object)flag;

            return (flagsValue & flagValue) != 0;
        }

        public static void Set<T>(ref T flags, T flag) where T : struct
        {
            long flagsValue = (long)(object)flags;
            long flagValue = (long)(object)flag;

            flags = (T)(object)(flagsValue | flagValue);
        }

        public static void Unset<T>(ref T flags, T flag) where T : struct
        {
            long flagsValue = (long)(object)flags;
            long flagValue = (long)(object)flag;

            flags = (T)(object)(flagsValue & (~flagValue));
        }
    }
}

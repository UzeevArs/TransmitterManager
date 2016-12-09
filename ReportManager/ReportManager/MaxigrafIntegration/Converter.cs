using System.Text;

namespace ReportManager.MaxigrafIntegration
{
    internal static class Converter
    {
        public static string ToAsciiString(byte[] bytes)
        {
            return Encoding.ASCII.GetString(bytes);
        }

        public static byte[] ToAsciiBytes(string command)
        {
            var bytes = Encoding.ASCII.GetBytes(command);
            if (bytes.Length >= 256) return bytes;

            var newbytes = new byte[256];
            for (var i = 0; i < bytes.Length; ++i)
            {
                newbytes[i] = bytes[i];
            }
            return newbytes;
        }
    }
}

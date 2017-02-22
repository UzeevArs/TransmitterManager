using System.Data;
using System.Data.SqlClient;

namespace ReportManager.Data.SAP
{
    internal static class SafeCheck
    {
        public static bool IsValidConnection(SqlConnection connection)
        {
            if (connection.State == ConnectionState.Open) return true;
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open) return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}

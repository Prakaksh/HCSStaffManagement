using System.Configuration;
using System.Data.SqlClient;

namespace HCS.StaffManagement.AppUtility
{
    public class SqlUtility
    {
        private static readonly string StaffManagementConnectionString = SqlUtility.GetConnectionStringValue("StaffManagementConnectionString");

        public static SqlConnection GetConnection()
        {
            var connection = new SqlConnection(StaffManagementConnectionString);

            connection.Open();
            return connection;
        }

        public static string GetConnectionStringValue(string key)
        {
            return ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }
    }
}
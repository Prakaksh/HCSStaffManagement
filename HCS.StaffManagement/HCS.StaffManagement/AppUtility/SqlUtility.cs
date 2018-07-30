using System;
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

        public static string ResponseStatusGet(int key)
        {
            string result = string.Empty;
            try
            {
                switch (key)
                {
                    case 1:
                        result = "success";
                        break;
                    case 0:
                        result = "failure";
                        break;
                    default:
                        result = string.Empty;
                        break;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
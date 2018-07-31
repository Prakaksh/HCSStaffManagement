using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using HCS.StaffManagement.AppUtility;
using HCS.StaffManagement.Models;

namespace HCS.StaffManagement.Repositories
{
    public class LoginContext
    {
        private SqlConnection sqlConnection;

        public string GetLogin(Login obj)
        {
            string result = "";
            try
            {
                using (sqlConnection = SqlUtility.GetConnection())
                {
                    var com = new DynamicParameters();
                        com.Add("@EmailID", obj.EmailID);
                        com.Add("@Password", obj.Password);
                    result = sqlConnection.Query<string>("usp_UserAuthenticate", com, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
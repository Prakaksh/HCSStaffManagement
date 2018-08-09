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

        public UserInfo GetLogin(Login obj)
        {
            //string result = "";
            UserInfo objUser = new UserInfo();
            try
            {
                using (sqlConnection = SqlUtility.GetConnection())
                {
                    var com = new DynamicParameters();
                        com.Add("@EmailID", obj.EmailID);
                        com.Add("@Password", obj.Password);
                    objUser = sqlConnection.Query<UserInfo>("usp_UserAuthenticate", com, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    return objUser;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
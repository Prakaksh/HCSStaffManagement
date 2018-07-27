using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using HCS.StaffManagement.AppUtility;
using HCS.StaffManagement.Models;

namespace HCS.StaffManagement.Repositories.V1
{
    public class LoginContext
    {
        private SqlConnection sqlConnection;

        public IEnumerable<Login> GetLogin(Login obj)
        {
            try
            {
                using (sqlConnection = SqlUtility.GetConnection())
                {
                    IEnumerable<Login> GetRoleType = sqlConnection.Query<Login>("Usp_GetMstStateList", commandType: CommandType.StoredProcedure).ToList();
                    return GetRoleType;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
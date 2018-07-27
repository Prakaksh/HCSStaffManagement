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
    public class MaritalStatusContext
    {
        private SqlConnection sqlConnection;

        public IEnumerable<MasterMaritalStatus> GetMaritalStatus(MasterMaritalStatus objStatus)
        {
            try
            {
                using (sqlConnection = SqlUtility.GetConnection())
                {
                    IEnumerable<MasterMaritalStatus> GetMaritalStatus = sqlConnection.Query<MasterMaritalStatus>("Usp_GetMstStateList", commandType: CommandType.StoredProcedure).ToList();
                    return GetMaritalStatus;
                }
            }
            catch(Exception ex) {
                throw ex;
            }
        }

    }
}
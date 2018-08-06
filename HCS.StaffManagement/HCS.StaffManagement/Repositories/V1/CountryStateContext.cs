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
    public class CountryStateContext
    {
        private SqlConnection sqlConnection;

        public IEnumerable<MasterCountryState> GetCountryState(MasterCountryState objStatus)
        {
            try
            {
                using (sqlConnection = SqlUtility.GetConnection())
                {
                    IEnumerable<MasterCountryState> GetCountryState = sqlConnection.Query<MasterCountryState>("usp_CountryStateGet", commandType: CommandType.StoredProcedure).ToList();
                    return GetCountryState;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
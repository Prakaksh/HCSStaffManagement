using Dapper;
using HCS.StaffManagement.AppUtility;
using HCS.StaffManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HCS.StaffManagement.Repositories
{
    public class AddressCategoryContext
    {
        private SqlConnection sqlConnection;

        public IEnumerable<MasterAddressCategory> GetAddressCategory(MasterAddressCategory objStatus)
        {
            try
            {
                using (sqlConnection = SqlUtility.GetConnection())
                {
                    IEnumerable<MasterAddressCategory> GetCategory = sqlConnection.Query<MasterAddressCategory>("Usp_GetMstStateList", commandType: CommandType.StoredProcedure).ToList();
                    return GetCategory;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
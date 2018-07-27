using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HCS.StaffManagement.Models;
using HCS.StaffManagement.AppUtility;
using Dapper;
using System.Data;

namespace HCS.StaffManagement.Repositories
{
    public class QualificationContext
    {
        private SqlConnection sqlConnection;

        public IEnumerable<MasterQualification> GetQualifications(MasterQualification objStatus)
        {
            try
            {
                using (sqlConnection = SqlUtility.GetConnection())
                {
                    IEnumerable<MasterQualification> GetQualifications = sqlConnection.Query<MasterQualification>("Usp_GetMstStateList", commandType: CommandType.StoredProcedure).ToList();
                    return GetQualifications;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
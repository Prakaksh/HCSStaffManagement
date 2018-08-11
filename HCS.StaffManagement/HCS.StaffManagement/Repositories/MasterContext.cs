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
    public class MasterContext
    {
        private SqlConnection sqlConnection;

        public IEnumerable<MasterCountryState> CountryStateGet(MasterCountryState objStatus)
        {
            try
            {
                var pm = new DynamicParameters();
                pm.Add("CountryID", objStatus.CountryID);
                using (sqlConnection = SqlUtility.GetConnection())
                {
                    IEnumerable<MasterCountryState> objRes = sqlConnection.Query<MasterCountryState>("usp_CountryStateGet", commandType: CommandType.StoredProcedure).ToList();
                    return objRes;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<MasterMaritalStatus> MaritalStatusGet(MasterMaritalStatus objStatus)
        {
            try
            {
                using (sqlConnection = SqlUtility.GetConnection())
                {
                    IEnumerable<MasterMaritalStatus> objRes = sqlConnection.Query<MasterMaritalStatus>("usp_MaritalStatusGet", commandType: CommandType.StoredProcedure).ToList();
                    return objRes;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<MasterMaritalStatus> QualificationGet(MasterQualification objQua)
        {
            try
            {
                using (sqlConnection = SqlUtility.GetConnection())
                {
                    IEnumerable<MasterMaritalStatus> objRes = sqlConnection.Query<MasterMaritalStatus>("usp_QualificationGet", commandType: CommandType.StoredProcedure).ToList();
                    return objRes;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<MasterMaritalStatus> RelationshipGet(MasterRelationship objRelationship)
        {
            try
            {
                using (sqlConnection = SqlUtility.GetConnection())
                {
                    IEnumerable<MasterMaritalStatus> objRes = sqlConnection.Query<MasterMaritalStatus>("usp_RelationshipGet", commandType: CommandType.StoredProcedure).ToList();
                    return objRes;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
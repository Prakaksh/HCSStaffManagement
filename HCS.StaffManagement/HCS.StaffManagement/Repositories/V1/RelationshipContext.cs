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
    public class RelationshipContext
    {
       
            private SqlConnection sqlConnection;

            public IEnumerable<MasterRelationship> GetRelationship(MasterRelationship objStatus)
            {
                try
                {
                    using (sqlConnection = SqlUtility.GetConnection())
                    {
                        IEnumerable<MasterRelationship> GetRelationship = sqlConnection.Query<MasterRelationship>("Usp_GetMstStateList", commandType: CommandType.StoredProcedure).ToList();
                        return GetRelationship;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }

using Dapper;
using HCS.StaffManagement.AppUtility;
using HCS.StaffManagement.Models;
using HCS.StaffManagement.Repositories.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HCS.StaffManagement.Repositories.V1
{
    public class EmployeeContext
    {
        private SqlConnection sqlConnection;

        public IEnumerable<EmployeeDto> GetEmployee()
        {
            IEnumerable<EmployeeDto> ResultGetEmployee = new List<EmployeeDto>();

            try
            {
                using (sqlConnection = SqlUtility.GetConnection())
                {
                   // IEnumerable<EmployeeDto> ResultGetEmployee = sqlConnection.Query<EmployeeDto>("usp_GetEmployee", commandType: CommandType.StoredProcedure).ToList();
                    return ResultGetEmployee;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //  return ResultGetClient;
        }

        

    }
}
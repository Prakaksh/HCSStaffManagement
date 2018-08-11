using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using HCS.StaffManagement.Repositories.DTO;
using System.Web;
using HCS.StaffManagement.AppUtility;
using Dapper;
using System.Data;
using HCS.StaffManagement.Models;

namespace HCS.StaffManagement.Repositories.V1
{
    public class ClientContext
    {
        private SqlConnection sqlConnection;

        public IEnumerable<ClientDto> ClientGet(Client objClient, UserInfo objUser)
        {
            IEnumerable<ClientDto> ResultGetClient = new List<ClientDto>();
            try
            {               
                using (sqlConnection = SqlUtility.GetConnection())
                {
                    var com = new DynamicParameters();
                    com.Add("@OrganizationID", objUser.OrganizationID);
                    com.Add("@OrganizationClientID", objClient.OrganizationClientID);
                    ResultGetClient = sqlConnection.Query<ClientDto>("usp_OrganizationClientGet",com, commandType: CommandType.StoredProcedure).ToList();
                    return ResultGetClient;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
          //  return ResultGetClient;
        }


        public string EmployeeInsertUpdate(Client objClient)
        {
            string Result = "";
            try
            {
                var com = new DynamicParameters();
                com.Add("@OrganizationID", objClient.OrganizationID);
                com.Add("@ClientName", objClient.ClientName);
                com.Add("@ClientGSTIN", objClient.ClientGSTIN);
                com.Add("@ClientAddress1", objClient.ClientAddress1);
                com.Add("@ClientAddress2", objClient.ClientAddress2);
                com.Add("@CountryID", objClient.CountryID);
                com.Add("@CountryStateID", objClient.CountryStateID);
                com.Add("@City", objClient.City);
                com.Add("@PinCode", objClient.PinCode);
                com.Add("@MobileNo", objClient.MobileNo);
                com.Add("@ContactNo", objClient.ContactNo);
                com.Add("@EmailID", objClient.EmailID);
               

                using (sqlConnection = SqlUtility.GetConnection())
                {
                    Result = sqlConnection.Query<string>("usp_ClientInsertUpdate",com, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    return Result;
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
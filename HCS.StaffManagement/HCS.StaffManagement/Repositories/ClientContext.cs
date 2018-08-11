using Dapper;
using HCS.StaffManagement.AppUtility;
using HCS.StaffManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using HCS.StaffManagement.Repositories.DTO;

namespace HCS.StaffManagement.Repositories
{
    public class ClientContext
    {
        private SqlConnection sqlConnection;

        public List<ClientDto> ClientGet(Client objClient, UserInfo objUser)
        {
            List<ClientDto> ResultGetClient = new List<ClientDto>();
            try
            {
                using (sqlConnection = SqlUtility.GetConnection())
                {
                    var com = new DynamicParameters();
                    com.Add("@OrganizationID", objUser.OrganizationID);
                    com.Add("@OrganizationClientID", objClient.OrganizationClientID);
                    ResultGetClient = sqlConnection.Query<ClientDto>("usp_OrganizationClientGet", com, commandType: CommandType.StoredProcedure).ToList();
                    return ResultGetClient;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ClientInsertUpdate(Client objClient, UserInfo objUser)
        {
            string result = "";
            try
            {
                using (sqlConnection = SqlUtility.GetConnection())
                {
                    var com = new DynamicParameters();
                    com.Add("OrganizationID", objUser.OrganizationID);
                    com.Add("OrganizationClientID", objClient.OrganizationClientID);
                    com.Add("ClientCode", objClient.ClientCode);
                    com.Add("ClientName", objClient.ClientName);
                    com.Add("ClientGSTIN", objClient.ClientGSTIN);
                    com.Add("CountryID", objClient.CountryID);
                    com.Add("StateID", objClient.CountryStateID);
                    //com.Add("CountryStateID", objClient.CountryStateID);
                    com.Add("ClientAddress1", objClient.ClientAddress1);
                    com.Add("ClientAddress2", objClient.ClientAddress2);
                    com.Add("City", objClient.City);
                    com.Add("PinCode", objClient.PinCode);
                    com.Add("MobileNo", objClient.MobileNo);
                    com.Add("ContactNo", objClient.ContactNo);
                    com.Add("EmailID", objClient.EmailID);
                    com.Add("By", objUser.UserID);
                    result = sqlConnection.Query<string>("usp_OrganizationClientInsertUpdate", com, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    result= AppUtility.AppUtility.getStatus(Convert.ToInt32(result));
                    return result;
                }              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ClientDelete(Client objClient, UserInfo objUser)
        {
            string result = "";
            try
            {
                using (sqlConnection = SqlUtility.GetConnection())
                {
                    var com = new DynamicParameters();
                    com.Add("OrganizationID", objUser.OrganizationID);
                    com.Add("OrganizationClientID", objClient.OrganizationClientID);
                    com.Add("By", objUser.UserID);
                    result = sqlConnection.Query<string>("usp_OrganizationClientDelete", com, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    result = AppUtility.AppUtility.getStatus(Convert.ToInt32(result));
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

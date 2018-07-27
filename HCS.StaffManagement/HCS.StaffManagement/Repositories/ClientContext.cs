using Dapper;
using HCS.StaffManagement.AppUtility;
using HCS.StaffManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace HCS.StaffManagement.Repositories
{
    public class ClientContext
    {
        private SqlConnection sqlConnection;

        public string ClientInsertUpdate(Client objClient)
        {
            string result = "";
            using (sqlConnection = SqlUtility.GetConnection())
            {
                var com = new DynamicParameters();

                com.Add("@ClientName", objClient.ClientName);
                com.Add("@ClientGSTIN", objClient.ClientGSTIN);
                com.Add("@CountryID", objClient.CountryID);
                com.Add("@CountryStateID", objClient.CountryStateID);
                com.Add("@ClientAddress1", objClient.ClientAddress1);
                com.Add("@ClientAddress", objClient.ClientAddress2);
                com.Add("@City", objClient.City);
                com.Add("@PinCode", objClient.PinCode);
                com.Add("@MobileNo", objClient.MobileNo);
                com.Add("@ContactNo", objClient.ContactNo);
                com.Add("@EmailID", objClient.EmailID);


                result = sqlConnection.Query<string>("usp_ClientInsertUpdate", commandType: CommandType.StoredProcedure).SingleOrDefault();
                return result;
            }

        }
    }
}

using Dapper;
using HCS.StaffManagement.AppUtility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HCS.StaffManagement.Models;
using System.Data;

namespace HCS.StaffManagement.Repositories
{
    public class DocumentUploadContext
    {
        private SqlConnection sqlConnection;

        public string DocumentUpload(DocumentDetail objDocument, UserInfo objUser)
        {
            string result = "";
            try
            {
                using (sqlConnection = SqlUtility.GetConnection())
                {
                    var com = new DynamicParameters();
                    com.Add("@OrganizationID", objUser.OrganizationID);
                    com.Add("@EmployeeID", null);
                    com.Add("@EmployeeDocumentID", objDocument.DocumentDetailID);
                    com.Add("@IsEmployeeLink", false);
                    com.Add("@DocumentName", objDocument.FileName);
                    com.Add("@DocumentContentType", objDocument.ContentType);
                    com.Add("@DocumentImageSize", objDocument.FileSize);
                    com.Add("@Extension", objDocument.FileExtension);
                    com.Add("@DocumentURL", objDocument.FileURL);
                    com.Add("@By", objUser.UserID);
                    result = sqlConnection.Query<string>("usp_EmployeeDocumentUpload", com, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    // result = AppUtility.AppUtility.getStatus(Convert.ToInt32(result));
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
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
    public class UploadImageContext
    {
        private SqlConnection sqlConnection;

        public string ImageUploadSave(ImageDetail objImg)
        {
            string result = "";
            try
            {
                using (sqlConnection = SqlUtility.GetConnection())
                {
                    var com = new DynamicParameters();
                    com.Add("@EmployeeDocumentID", objImg.ID);
                    com.Add("@DocumentName", objImg.ImageName);
                    com.Add("@DocumentContentType", objImg.ContentType);
                    com.Add("@DocumentImageSize", objImg.ImageSize);
                    com.Add("@Extension", objImg.Extension);
                    result = sqlConnection.Query<string>("usp_UploadDocument", com, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
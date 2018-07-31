using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HCS.StaffManagement.Models;
using Dapper;
using System.Data;

namespace HCS.StaffManagement.Repositories
{
    internal class PayslipContext
    {
        private System.Data.SqlClient.SqlConnection sqlConnection;
        internal ResponseModel PayslipInsertUpdate(Payslip objPayslip, UserInfo objUser)
        {
            ResponseModel objResponse = new ResponseModel();
            try
            {
                var com = new DynamicParameters();
                com.Add("OrganizationID", objUser.OrganizationID);
                com.Add("EmployeeNo", objPayslip.EmployeeNo);
                com.Add("EmployeeID", objPayslip.EmployeeID);
                com.Add("EmployeePaymentID", objPayslip.EmployeePaymentID);
                com.Add("Year", objPayslip.Year);
                com.Add("Month", objPayslip.Month);
                com.Add("MonthName", objPayslip.MonthName);
                com.Add("DaysInMonth", objPayslip.DaysInMonth);
                com.Add("WorkingDays", objPayslip.WorkingDays);
                com.Add("BasicPerDay", objPayslip.BasicPerDay);
                com.Add("BasicPerMonth", objPayslip.BasicPerMonth);
                com.Add("WagesDAPerDay", objPayslip.WagesDAPerDay);
                com.Add("WagesDAPerMonth", objPayslip.WagesDAPerMonth);
                com.Add("IncentivePerDay", objPayslip.IncentivePerDay);
                com.Add("IncentivePerMonth", objPayslip.IncentivePerMonth);
                com.Add("Bonus", objPayslip.Bonus);
                com.Add("Advance", objPayslip.Advance);
                com.Add("FutureAdvance", objPayslip.FutureAdvance);
                com.Add("PF", objPayslip.PF);
                com.Add("ESI", objPayslip.ESI);
                com.Add("LIC", objPayslip.LIC);
                com.Add("PT", objPayslip.PT);
                com.Add("WWF", objPayslip.WWF);
                com.Add("Remarks", objPayslip.Remarks);
                com.Add("By", objUser.UserID);
                using (sqlConnection = AppUtility.SqlUtility.GetConnection())
                {
                    objResponse.Status = sqlConnection.Query<int>("usp_EmployeePaymentInsertUpdate",com,  commandType: CommandType.StoredProcedure).SingleOrDefault();
                    objResponse.StatusText = AppUtility.SqlUtility.ResponseStatusGet(objResponse.Status);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objResponse;
        }
    }
}
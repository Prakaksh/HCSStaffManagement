using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HCS.StaffManagement.Models;
using Dapper;
using System.Data;
using System.Globalization;

namespace HCS.StaffManagement.Repositories
{
    internal class PayslipContext
    {
        private System.Data.SqlClient.SqlConnection sqlConnection;
        internal PayScale PayScaleGet(Employee objEmp, UserInfo objUser)
        {
            PayScale objPayScale = new PayScale();
            try
            {
                var pmt = new DynamicParameters();
                pmt.Add("OrganizationID", "CDDBCAB3-DFB4-44A8-9F9C-871440862F8A"); // objUser.OrganizationID);
                pmt.Add("EmployeeNo", objEmp.EmployeeNo);
                pmt.Add("EmployeeID", objEmp.EmployeeID);  //"CA3AEBEB-2A0A-40F9-A6F7-17EDC8B43F04");
                using (sqlConnection = AppUtility.SqlUtility.GetConnection())
                {
                    objPayScale = sqlConnection.Query<PayScale>("usp_EmployeePayScaleGet", pmt, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objPayScale;
        }

        internal ResponseModel PayslipInsertUpdate(Payslip objPayslip, UserInfo objUser)
        {
            ResponseModel objResponse = new ResponseModel();
            try
            {
                var pmt = new DynamicParameters();
                pmt.Add("OrganizationID", objUser.OrganizationID);
                pmt.Add("EmployeeNo", objPayslip.EmployeeNo);
                pmt.Add("EmployeeID", objPayslip.EmployeeID);
                pmt.Add("EmployeePaymentID", objPayslip.EmployeePaymentID);
                pmt.Add("Year", objPayslip.Year);
                pmt.Add("Month", objPayslip.Month);
                pmt.Add("MonthName", objPayslip.MonthName);
                pmt.Add("DaysInMonth", objPayslip.DaysInMonth);
                pmt.Add("WorkingDays", objPayslip.WorkingDays);
                pmt.Add("BasicPerDay", objPayslip.BasicPerDay);
                pmt.Add("BasicPerMonth", objPayslip.BasicPerMonth);
                pmt.Add("WagesDAPerDay", objPayslip.WagesDAPerDay);
                pmt.Add("WagesDAPerMonth", objPayslip.WagesDAPerMonth);
                pmt.Add("IncentivePerDay", objPayslip.IncentivePerDay);
                pmt.Add("IncentivePerMonth", objPayslip.IncentivePerMonth);
                pmt.Add("Bonus", objPayslip.Bonus);
                pmt.Add("Advance", objPayslip.Advance);
                pmt.Add("FutureAdvance", objPayslip.FutureAdvance);
                pmt.Add("PF", objPayslip.PF);
                pmt.Add("ESI", objPayslip.ESI);
                pmt.Add("LIC", objPayslip.LIC);
                pmt.Add("PT", objPayslip.PT);
                pmt.Add("WWF", objPayslip.WWF);
                pmt.Add("Remarks", objPayslip.Remarks);
                pmt.Add("By", objUser.UserID);
                using (sqlConnection = AppUtility.SqlUtility.GetConnection())
                {
                    objResponse.Status = sqlConnection.Query<int>("usp_EmployeePaymentInsertUpdate", pmt, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    objResponse.StatusText = AppUtility.SqlUtility.ResponseStatusGet(objResponse.Status);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objResponse;
        }

        internal OrganizationPayslip PayslipGeneration(PayslipRequestList objPayslip, UserInfo objUser)
        {
            //List<Payslip> objResult = new List<Payslip>();
            OrganizationPayslip objResult = new OrganizationPayslip();
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("EmployeeID", typeof(Guid)));
                dt.Columns.Add(new DataColumn("EmployeeNo", typeof(string)));
                if (objPayslip != null)
                {
                    foreach (var item in objPayslip.EmployeeList)
                    {
                        //dt.Rows.Add(item.EmployeeID, item.EmployeeNo);
                        dt.Rows.Add("CA3AEBEB-2A0A-40F9-A6F7-17EDC8B43F04", "");
                    }

                }

                var pmt = new DynamicParameters();
                pmt.Add("OrganizationID", objPayslip.OrganizationID);  //objUser.OrganizationID);
                pmt.Add("EmployeeList", dt.AsTableValuedParameter("udt_Employee"));
                pmt.Add("Year", objPayslip.Year);
                pmt.Add("Month", objPayslip.Month);
                pmt.Add("MonthName", objPayslip.MonthName);
                pmt.Add("By", objUser.UserID);
                using (sqlConnection = AppUtility.SqlUtility.GetConnection())
                {
                    var res = sqlConnection.QueryMultiple("usp_EmployeePayslipGet", pmt, commandType: CommandType.StoredProcedure);
                    objResult.OrganizationProp = res.Read<Organization>().First();
                    objResult.PayslipList = res.Read<PayslipData>().ToList();
                    objResult.Month = objPayslip.Month;
                    // fullMonthName = new DateTime(2015, objPayslip.Month, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));
                    objResult.MonthName = ((string.IsNullOrEmpty(objPayslip.MonthName)) == false ? objPayslip.MonthName : AppUtility.AppConstant.MonthNameGet(objPayslip.Month));
                    objResult.Year = objPayslip.Year;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objResult;
        }
    }
}
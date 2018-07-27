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
    public class EmployeeInsertUpdateContext
    {
        private SqlConnection sqlConnection;

        public string EmployeeInsertUpdate(Employee objEmp)
        {
            string result = "";
            using (sqlConnection = SqlUtility.GetConnection())
            {
                var com = new DynamicParameters();
                com.Add("@AadharNo", objEmp.AadharNo);
                com.Add("@EmployeeFirstName", objEmp.EmployeeFirstName);
                com.Add("@EmployeeLastName", objEmp.EmployeeLastName);
                com.Add("@DOB", objEmp.DOB);
                com.Add("@MobileNo", objEmp.MobileNo);
                com.Add("@PanNo", objEmp.PanNo);
                com.Add("@RationCardNo", objEmp.RationCardNo);
                com.Add("@DrivingLicenseNo", objEmp.DrivingLicenseNo);
                com.Add("@VoterCardNo", objEmp.VoterCardNo);
                com.Add("@EmailID", objEmp.EmailID);
                com.Add("@EmployeeFirstName", objEmp.objBankAccount.AccountNo);
                com.Add("@EmployeeFirstName", objEmp.objBankAccount.AccountType);
                com.Add("@EmployeeFirstName", objEmp.objBankAccount.BankName);
                com.Add("@EmployeeFirstName", objEmp.objBankAccount.BankAddress);

                com.Add("@AddressCategoryCode", objEmp.CurrentAddress.AddressCategoryCode);
                com.Add("@Address1", objEmp.CurrentAddress.Address1);
                com.Add("@CountryID", objEmp.CurrentAddress.CountryID);
                com.Add("@CountryID", objEmp.CurrentAddress.CountryID);
                com.Add("@CountryStateID", objEmp.CurrentAddress.CountryStateID);
                com.Add("@City", objEmp.CurrentAddress.City);

                com.Add("@EmployeeFirstName", objEmp.PermanentAddress.AddressCategoryCode);
                com.Add("@Address1", objEmp.PermanentAddress.Address1);
                com.Add("@CountryID", objEmp.PermanentAddress.CountryID);
                com.Add("@CountryID", objEmp.PermanentAddress.CountryID);
                com.Add("@CountryStateID", objEmp.PermanentAddress.CountryStateID);
                com.Add("@City", objEmp.PermanentAddress.City);

                result = sqlConnection.Query<string>("Usp_GetMstStateList", commandType: CommandType.StoredProcedure).SingleOrDefault();
                return result;
            }
        }
    }
}
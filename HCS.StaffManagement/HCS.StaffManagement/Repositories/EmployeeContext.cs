using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using HCS.StaffManagement.AppUtility;
using HCS.StaffManagement.Models;
using System.Globalization;

namespace HCS.StaffManagement.Repositories
{
    public class EmployeeContext
    {
        private SqlConnection sqlConnection;
        internal List<Employee> EmployeeGet(string EmployeeID, UserInfo objUser)
        {
            List<Employee> objResult = new List<Employee>();
            Employee objEmp = new Employee();
            try
            {
                var pm = new DynamicParameters();
                pm.Add("@OrganizationID", objUser.OrganizationID);
                pm.Add("@EmployeeID", EmployeeID);
                using (sqlConnection = SqlUtility.GetConnection())
                {
                    //objResult = sqlConnection.Query<Employee>("usp_EmployeeGet", pm, commandType: CommandType.StoredProcedure).ToList();

                    var res = sqlConnection.QueryMultiple("usp_EmployeeGet", pm, commandType: CommandType.StoredProcedure);
                    if (!string.IsNullOrEmpty(EmployeeID)){
                        objEmp = res.Read<Employee>().FirstOrDefault();
                    }
                    else
                    {
                        objResult = res.Read<Employee>().ToList();
                    }
                    List<Address> objAddress = res.Read<Address>().ToList();

                    if (!string.IsNullOrEmpty(EmployeeID))
                    {
                        Address objCurAdd = objAddress.Where(x => x.AddressCategoryCode == "C").FirstOrDefault();
                        Address objPerAdd = objAddress.Where(x => x.AddressCategoryCode == "P").FirstOrDefault();
                        objEmp.CurrentAddress = objCurAdd;
                        objEmp.PermanentAddress = objPerAdd;

                        if(objResult.Count == 0)
                            objResult.Add(objEmp);
                        else
                        {
                            objResult = null;
                            objResult = new List<Employee>();
                            objResult.Add(objEmp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objResult;
        }

        internal string EmployeeInsertUpdate(Employee objEmp, UserInfo objUser)
        {
            try
            {
                string result = "";
                using (sqlConnection = SqlUtility.GetConnection())
                {
                    var com = new DynamicParameters();
                    com.Add("OrganizationID", objUser.OrganizationID);                    
                    com.Add("EmployeeID", objEmp.EmployeeID);
                    com.Add("EmployeeNo", objEmp.EmployeeNo);                    
                    com.Add("EmployeeFirstName", objEmp.EmployeeFirstName);
                    com.Add("EmployeeLastName", objEmp.EmployeeLastName);
                    
                    com.Add("DOB", AppUtility.AppUtility.getSqlDate(objEmp.DOB, "dd-MM-yyyy"));
                    com.Add("DateofJoin", AppUtility.AppUtility.getSqlDate(objEmp.DateofJoin, "dd-MM-yyyy"));
                    com.Add("Gender", objEmp.Gender);
                    //com.Add("FatherOrHusbandName", objEmp.FatherOrHusbandName);
                    //com.Add("RelatioinshipCode", objEmp.RelatioinshiopCode);
                    com.Add("MobileNo", objEmp.MobileNo);
                    com.Add("ContactNo", objEmp.ContactNo);
                    com.Add("EmailID", objEmp.EmailID);
                    com.Add("Nationality", objEmp.Nationality);
                    com.Add("QualificationCode", objEmp.QualificationCode);
                    com.Add("MaritalStatusCode", objEmp.MaritalStatusCode);
                    
                    com.Add("IsInternationalWorker", objEmp.IsInternationalWorker);
                    com.Add("IsPhisicalHandicap", objEmp.IsPhisicalHandicap);
                    com.Add("PanNo", objEmp.PanNo);
                    com.Add("AadharNo", objEmp.AadharNo);
                    com.Add("VoterCardNo", objEmp.VoterCardNo);
                    com.Add("RationCardNo", objEmp.RationCardNo );
                    com.Add("DrivingLicenseNo", objEmp.DrivingLicenseNo);
                    com.Add("PFNo", objEmp.PFNo);
                    com.Add("ESINo", objEmp.ESINo);

                    //com.Add("CountryOfOrigin", objEmp. );
                    //com.Add("PassportNo", objEmp. );
                    //com.Add("ValidFrom", objEmp. );
                    //com.Add("ValidTo", objEmp. );
                    //com.Add("Iocomotive", objEmp. );
                    //com.Add("Hearing", objEmp. );
                    //com.Add("Visual", objEmp. );

                    com.Add("IsCurrentAddress", true);
                    com.Add("CurrentAddress1", objEmp.CurrentAddress.Address1);
                    com.Add("CurrentAddress2", objEmp.CurrentAddress.Address2);
                    com.Add("CurrentCountryID", objEmp.CurrentAddress.CountryID);
                    com.Add("CurrentCountryStateID", objEmp.CurrentAddress.CountryStateID);
                    com.Add("CurrentCity", objEmp.CurrentAddress.City);
                    com.Add("CurrentPinCode", objEmp.CurrentAddress.PinCode);

                    com.Add("IsPermanentAddress", true);
                    com.Add("PermanentAddress1", objEmp.PermanentAddress.Address1);
                    com.Add("PermanentAddress2", objEmp.PermanentAddress.Address2);
                    com.Add("PermanentCountryID", objEmp.PermanentAddress.CountryID);
                    com.Add("PermanentCountryStateID", objEmp.PermanentAddress.CountryStateID);
                    com.Add("PermanentCity", objEmp.PermanentAddress.City);
                    com.Add("PermanentPinCode", objEmp.PermanentAddress.PinCode);

                    com.Add("EmployeeProfilePictureID", objEmp.EmployeeProfilePictureID);
                    com.Add("By", objUser.UserID);

                    int res= sqlConnection.Query<int>("usp_EmployeeInsertUpdate",com, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    result = AppUtility.AppUtility.getStatus(res);
                    return result;
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal string EmployeeDelete(string EmployeeID, UserInfo objUser)
        {
            try
            {
                var pm = new DynamicParameters();
                pm.Add("OrganizationID", objUser.OrganizationID);
                pm.Add("EmployeeID", EmployeeID);
                pm.Add("By", objUser.UserID);
                using (sqlConnection = SqlUtility.GetConnection())
                {
                    int res = sqlConnection.Query<int>("usp_EmployeeDelete", pm, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    return AppUtility.AppUtility.getStatus(res);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal PayScale EmployeePayScaleGet(string EmployeeID, UserInfo objUser)
        {
            PayScale objResult = new PayScale();
            try
            {
                var pm = new DynamicParameters();
                pm.Add("@OrganizationID", objUser.OrganizationID);
                pm.Add("@EmployeeID", EmployeeID);
                using (sqlConnection = SqlUtility.GetConnection())
                {
                    objResult = sqlConnection.Query<PayScale>("usp_EmployeePayScaleGet", pm, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objResult;
        }

        internal string EmployeePayScaleInsertUpdate(PayScale objPayScale, UserInfo objUser)
        {
            string strResult = string.Empty;
            try
            {
                var pm = new DynamicParameters();
                pm.Add("@OrganizationID", objUser.OrganizationID);
                pm.Add("@EmployeeID", objPayScale.EmployeeID);
                pm.Add("@BasicPerMonth", objPayScale.BasicPerMonth);
                pm.Add("@WagesDAPerMonth", objPayScale.WagesDAPerMonth);
                pm.Add("@BonusPercentage", objPayScale.BonusPercentage);
                pm.Add("@IncentivePerMonth", objPayScale.IncentivePerMonth);
                //pm.Add("@EmployeeID", objPayScale.EmployeeID);
                pm.Add("@By", objUser.UserID);
                using (sqlConnection = SqlUtility.GetConnection())
                {
                    int res = sqlConnection.Query<int>("usp_EmployeePayScaleInsertUpdate", pm, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    strResult = AppUtility.AppUtility.getStatus(res);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strResult;
        }
    }
}
using HCS.StaffManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCS.StaffManagement.Repositories.DTO
{
    public class EmployeeDto
    {
        public string _employeeName { get; set; }
        public string EmployeeID { get; set; }
        public string OrganizationID { get; set; }
        public string EmployeeNo { get; set; }
        public int EmployeeSequence { get; set; }
        public string AadharNo { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeName { get { return (!string.IsNullOrEmpty(EmployeeFirstName) ? EmployeeFirstName + " " : "") + EmployeeLastName; } set { _employeeName = (!string.IsNullOrEmpty(EmployeeFirstName) ? EmployeeFirstName + " " : "") + EmployeeLastName; ; } }
        public string DOB { get; set; }
        public string DateofJoin { get; set; }
        public string Gender { get; set; }
        public string FatherOrHusbandName { get; set; }
        public string RelatioinshiopCode { get; set; }
        public string MobileNo { get; set; }
        public string ContactNo { get; set; }
        public string EmailID { get; set; }
        public string Nationality { get; set; }
        public string QualificationCode { get; set; }
        public string MaritalStatusCode { get; set; }
        public bool IsInternationalWorker { get; set; }
        public bool IsPhisicalHandicap { get; set; }
        public string PanNo { get; set; }
        public string PFNo { get; set; }
        public string ESINo { get; set; }
        public string VoterCardNo { get; set; }
        public string RationCardNo { get; set; }
        public string DrivingLicenseNo { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        //Wages
        public int BasicSalary { get; set; }
        public int BonusPercentage { get; set; }
        public int IncentivePerDay { get; set; }
        
        ////CurrentAddress
        //public string EmployeeCurrentAddressID { get; set; }
        //public string CurrentAddressCategoryCode { get; set; }
        //public string CurrentAddress1 { get; set; }
        //public string CurrentAddress2 { get; set; }
        //public string CurrentCountryID { get; set; }
        //public string CurrentCountryStateID { get; set; }
        //public string CurrentCity { get; set; }
        //public string CurrentPinCode { get; set; }
        //public bool IsSameAsCurrentAddress { get; set; }

        ////PermanentAddress
        //public string EmployeePermanentAddressID { get; set; }
        //public string PermanentAddressCategoryCode { get; set; }
        //public string PermanentAddress1 { get; set; }
        //public string PermanentAddress2 { get; set; }
        //public string PermanentCountryID { get; set; }
        //public string PermanentCountryStateID { get; set; }
        //public string PermanentCity { get; set; }
        //public string PermanentPinCode { get; set; }
        //public bool IsSameAsPermanentAddress { get; set; }

        public Address CurrentAddress { get; set; }
        public Address PermanentAddress { get; set; }

        public string ClientLocation { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
    }    
}
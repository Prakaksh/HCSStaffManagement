using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HCS.StaffManagement.Models
{
    public class Employee
    {
        public string _employeeName { get; set; }

        public string EmployeeID { get; set; }
        public string OrganizationID { get; set; }
        public string EmployeeNo { get; set; }
        public int EmployeeSequence { get; set; }
        [Required]
        public string AadharNo { get; set; }
        [Required]
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }

        public string EmployeeName { get { return (!string.IsNullOrEmpty(EmployeeFirstName) ? EmployeeFirstName + " " : "") + EmployeeLastName; }  set { _employeeName = (!string.IsNullOrEmpty(EmployeeFirstName) ? EmployeeFirstName + " " : "") + EmployeeLastName; ; } }

        [Required]
        public string DOB { get; set; }
        public string DateofJoin { get; set; }
        public string Gender { get; set; }
        public string FatherOrHusbandName { get; set; }
        public string RelatioinshiopCode { get; set; }

        [StringLength(13, MinimumLength = 10)]
        public string MobileNo { get; set; }

        [StringLength(13, MinimumLength = 10)]
        public string ContactNo { get; set; }


        [DataType(DataType.EmailAddress)]
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

        public string EmployeeProfilePictureID { get; set; }

        //public string CurrentAddress_CountryStateID { get; set; }
        //public string PermanentAddress_CountryID { get; set; }



        //Employee Address
        //public string AddressCategoryCode { get; set; }
        //public string Address1 { get; set; }
        //public string Address2 { get; set; }
        //public string CountryID { get; set; }
        //public string CountryStateID { get; set; }
        //public string City { get; set; }
        //public string PinCode { get; set; }

        public EmployeeBankAccount objBankAccount { get; set; }
        public BasicWages BasicWages { get; set; }


        public Address CurrentAddress { get; set; }
        public Address PermanentAddress { get; set; }
        //public List<EmployeeAddress> EmployeeAddress { get; set; }

        public string ClientLocation { get; set; }

        public string Designation { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
    }

    public class BasicWages {
        public float BasicSalary { get; set; }
        public float BonusPercentage { get; set; }
        public float IncentivePercentage { get; set; }
        public float Wages { get; set; }
    }
}


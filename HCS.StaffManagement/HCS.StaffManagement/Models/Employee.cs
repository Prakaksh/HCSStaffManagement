using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HCS.StaffManagement.Models
{
    public class Employee
    {
        public string EmployeeID { get; set; }
        public string OrganizationID { get; set; }
        public string EmployeeNo { get; set; }
        public int EmployeeSequence { get; set; }
        [Required]
        public string AadharNo { get; set; }
        [Required]
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        [Required]
        public string DOB { get; set; }
        public string DateofJoin { get; set; }
        public string Gender { get; set; }
        public string FatherOrHusbandName { get; set; }
        public string RelatioinshiopCode { get; set; }

        [StringLength(13,MinimumLength =10)]
        public string MobileNo { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }
        public string Natioality { get; set; }
        public int QualificationCode { get; set; }
        public int MaritalStatusCode { get; set; }
        public bool IsInternationalWorker { get; set; }
        public bool IsPhisicalHandicap { get; set; }
        public string PanNo { get; set; }
        public string VoterCardNo { get; set; }
        public string RationCardNo { get; set; }
        public string DrivingLicenseNo { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }

    }
}
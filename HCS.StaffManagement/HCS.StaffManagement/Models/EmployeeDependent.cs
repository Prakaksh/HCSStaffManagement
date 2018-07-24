using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HCS.StaffManagement.Models
{
    public class EmployeeDependent
    {
        public string EmployeeID { get; set; }
        public string OrganizationID { get; set; }
        public string EmployeeNo { get; set; }
        public string EmployeeDependentID { get; set; }
       
        public int EmployeeDependentNo { get; set; }
        public string DependentFirstName { get; set; }
        public string DependentLastName { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string RelationshipCode { get; set; }

        [StringLength(13,MinimumLength=10)]
        public string MobileNo { get; set; }
        public string AadharNo { get; set; }
    }
}
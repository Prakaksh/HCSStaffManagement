using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCS.StaffManagement.Models
{
    public class EmployeeInternationalWork
    {
        public string EmployeeID { get; set; }
        public string OrganizationID { get; set; }
        public string EmployeeNo { get; set; }
        public string EmployeeInternationalWorkID { get; set; }
        public string CountryOfOrigin { get; set; }
        public string PassportNo { get; set; }
        public bool ValidFrom { get; set; }
        public string ValidTo { get; set; }
       
    }
}
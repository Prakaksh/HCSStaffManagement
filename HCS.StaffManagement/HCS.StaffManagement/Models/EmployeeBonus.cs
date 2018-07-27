using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCS.StaffManagement.Models
{
    public class EmployeeBonus
    {
        public string EmployeeID { get; set; }
        public string OrganizationID { get; set; }
        public string EmployeeNo { get; set; }
        public string EmployeeBonusID { get; set; }
        public decimal Percentage { get; set; }
        public int MyProperty { get; set; }
        public string FromDate { get; set; }
        public string ToDate{ get; set; }
    }
}
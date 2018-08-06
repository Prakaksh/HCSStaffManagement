using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCS.StaffManagement.Models
{
    public class PayScale
    {
        public string OrganizationID { get; set; }
        public string EmployeeNo { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeePayScaleID { get; set; }
        public float BasicPerDay { get; set; }
        public float BasicPerMonth { get; set; }
        public float WagesDAPerDay { get; set; }
        public float WagesDAPerMonth { get; set; }
        public float IncentivePercentage { get; set; }
        public float BonusPercentage { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
    }
}
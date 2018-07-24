using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCS.StaffManagement.Models
{
    public class EmployeePhisicalDisability
    {
        public string EmployeeID { get; set; }
        public string OrganizationID { get; set; }
        public string EmployeeNo { get; set; }
        public string EmployeePhisicalDisabilityID { get; set; }
        public bool Iocomotive { get; set; }
        public bool Hearing { get; set; }
        public bool Visual { get; set; }
    }
}
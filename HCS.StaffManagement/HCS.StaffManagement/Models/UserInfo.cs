using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCS.StaffManagement.Models
{
    public class UserInfo
    {
        public Guid OrganizationID { get; set; }
        public Guid EmployeeID { get; set; }
        public string EmployeeNo { get; set; }
        public Guid UserID { get; set; }
        public string EmailID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RoleName { get; set; }
        public Guid RoleTypeID { get; set; }
        public string Status { get; set; }
    }
}
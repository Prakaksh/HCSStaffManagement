using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCS.StaffManagement.Repositories.DTO
{
    public class EmployeeDto
    {
        public string OrganizationID { get; set; }
        public int SlNo { get; set; }
        public string EmployeeNo { get; set; }
        public string EmployeeName { get; set; }
        public int MobileNo { get; set; }
        public string ClientLocation { get; set; }
        public string JoiningDate { get; set; }
        public string Action { get; set; }
    }
}
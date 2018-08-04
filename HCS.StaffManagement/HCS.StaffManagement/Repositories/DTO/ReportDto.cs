using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCS.StaffManagement.Repositories.DTO
{
    public class ReportDto
    {
        public string OrganizationID { get; set; }
        public string SlNo { get; set; }
        public string EmpNo { get; set; }
        public string EmployeeName { get; set; }
        public string MyProperty { get; set; }
        public string DaysPaid { get; set; }
        public string WagesDA { get; set; }
        public string EarnedBasic { get; set; }
        public string TotalWagesDA { get; set; }
        public string TotalWages { get; set; }
        public string Incentive { get; set; }
        public string GrossPayable { get; set; }
        public string Adv { get; set; }
        public string FAdv { get; set; }
        public string PF { get; set; }
        public string ESI { get; set; }
        public string LIC { get; set; }
        public string PT { get; set; }
        public string WWF { get; set; }
        public string TotalDeduction { get; set; }
        public string NetPaid { get; set; }

    }
}
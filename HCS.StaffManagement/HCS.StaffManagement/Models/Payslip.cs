using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCS.StaffManagement.Models
{
    public class Payslip
    {
        public string OrganizationID { get; set; }        
        public string EmployeeNo { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeePaymentID { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string MonthName { get; set; }
        public int DaysInMonth { get; set; }
        public int WorkingDays { get; set; }
        public float BasicPerDay { get; set; }
        public float BasicPerMonth { get; set; }
        public float WagesDAPerDay { get; set; }
        public float WagesDAPerMonth { get; set; }
        public float IncentivePerDay { get; set; }
        public float IncentivePerMonth { get; set; }
        public float Bonus { get; set; }    
        public float Advance { get; set; }
        public float FutureAdvance { get; set; }
        public float PF  { get; set; }
        public float ESI { get; set; }
        public float LIC { get; set; }
        public float PT  { get; set; }
        public float WWF { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }        
    }
}
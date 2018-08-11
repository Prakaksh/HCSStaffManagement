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
        public float FlexibleAllowance { get; set; }
        public float Bonus { get; set; }    
        public float Advance { get; set; }
        public float FutureAdvance { get; set; }
        public float PF  { get; set; }
        public float ESI { get; set; }
        public float LIC { get; set; }
        public float PT  { get; set; }
        public float WWF { get; set; }
        public float Earnings { get; set; }
        public float Deductions { get; set; }
        public float NetAmount { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }        
    }

    public class PayslipRequestList
    {
        public int Month { get; set; }
        public string MonthName { get; set; }
        public int Year { get; set; }
        public string OrganizationID { get; set; }
        public List<Employee> EmployeeList { get; set; }
        
    }

    public class OrganizationPayslip
    {
        public Organization OrganizationProp { get; set; }
        public List<PayslipData> PayslipList { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string MonthName { get; set; }
    }

    public class PayslipData
    {
        //public Payslip PayslipDataObj { get; set; }
        //public Employee EmployeeDataObj { get; set; }
        //public EmployeeBankAccount EmployeeBankDataObj { get; set; }

        //Payslisp
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
        public float FlexibleAllowance { get; set; }
        public float Bonus { get; set; }
        public float Advance { get; set; }
        public float FutureAdvance { get; set; }
        public float PF { get; set; }
        public float ESI { get; set; }
        public float LIC { get; set; }
        public float PT { get; set; }
        public float WWF { get; set; }
        public float Earnings { get; set; }
        public float Deductions { get; set; }
        public float NetAmount { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }

        //Employee
        public int EmployeeSequence { get; set; }
        public string AadharNo { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string DOB { get; set; }
        public string DateofJoin { get; set; }
        public string Gender { get; set; }
        public string FatherOrHusbandName { get; set; }
        public string RelatioinshiopCode { get; set; }
        public string MobileNo { get; set; }
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
        public string Designation { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }

        //Bank Details
        public string EmployeeBankAccountID { get; set; }
        public int AccountNo { get; set; }
        public int MyProperty { get; set; }
        public string NameAsPerAccount { get; set; }
        public string BankName { get; set; }
        public string AccountType { get; set; }
        public string IFSCCode { get; set; }
        public string MICRCode { get; set; }
        public string BankAddress { get; set; }
        public int PinCode { get; set; }
        public string LinkedMobileNo { get; set; }
        public string LinkedEmailID { get; set; }
    }
}
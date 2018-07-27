using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HCS.StaffManagement.Models
{
    public class EmployeeBankAccount
    {
        public string EmployeeID { get; set; }
        public string OrganizationID { get; set; }
        public string EmployeeNo { get; set; }
        public string EmployeeBankAccountID { get; set; }
        public int AccountNo { get; set; }
        public int MyProperty { get; set; }
        public string NameAsPerAccount { get; set; }
        public string BankName { get; set; }
        public string AccountType { get; set; }
        public string IFSCCode { get; set; }
        public string MICRCode { get; set; }
        public string BankAddress { get; set; }

        [DataType(DataType.PostalCode)]
        public int PinCode { get; set; }
        [StringLength(13, MinimumLength = 10)]
        public string LinkedMobileNo { get; set; }
        [DataType(DataType.EmailAddress)]
        public string LinkedEmailID { get; set; }


    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCS.StaffManagement.Models
{
    public class EmployeeAddress
    {
        public string EmployeeID { get; set; }
        public string OrganizationID { get; set; }
        public string EmployeeNo { get; set; }
        public string EmployeeAddressID { get; set; }
        public string AddressCategoryCode { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string CountryID { get; set; }
        public string CountryStateID { get; set; }
        public string City { get; set; }

    }
}
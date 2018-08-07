using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCS.StaffManagement.Repositories.DTO
{
    public class ClientDto
    {
        public Guid OrganizationClientID { get; set; }
        public string ClientName { get; set; }
        public string ClientCode { get; set; }
        public string ClientGSTIN { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
        public string ClientAddress1 { get; set; }
        public string ClientAddress2 { get; set; }
        public string CountryID { get; set; }
        public string CountryStateID { get; set; }
        public string City { get; set; }
        public string ContactNo { get; set; }
        public string PinCode { get; set; }

        public string Action { get; set; }

    }
}
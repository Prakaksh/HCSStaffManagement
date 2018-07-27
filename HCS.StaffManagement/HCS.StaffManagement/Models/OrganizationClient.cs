using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HCS.StaffManagement.Models
{
    public class OrganizationClient
    {
        public string OrganizationClientID { get; set; }
        public string OrganizationID { get; set; }
        [Required]
        public string ClientName { get; set; }

        [Required]
        public string ClientGSTIN { get; set; }
        public string ClientCode { get; set; }


        public string ClientAddress1 { get; set; }
        public string ClientAddress2 { get; set; }
        public int CountryID { get; set; }
        public int CountryStateID { get; set; }
        public string City { get; set; }

        [DataType(DataType.PostalCode)]
        public int PinCode { get; set; }
        public string ContactNO { get; set; }
        [StringLength(13,MinimumLength =10)]
        public string MobileNO { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }
        public string DeactivatedDate { get; set; }
    }
}
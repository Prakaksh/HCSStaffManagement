using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HCS.StaffManagement.Models
{
    public class Client
    {
        public Guid OrganizationClientID { get; set; }
        public Guid OrganizationID { get; set; }
        [Required]
        public string ClientName { get; set; }
        public string ClientGSTIN { get; set; }
        public string ClientCode { get; set; }
        public string ClientAddress1 { get; set; }
        public string ClientAddress2 { get; set; }
        public string CountryID { get; set; }
        
        
        public string CountryStateID { get; set; }
        public string City { get; set; }
        [DataType(DataType.PostalCode)]
        public string PinCode { get; set; }
        [StringLength(13, MinimumLength = 10)]
        public string MobileNo { get; set; }
        [StringLength(13,MinimumLength =10)]
        public string ContactNo { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HCS.StaffManagement.Models
{
    public class Client
    {
        [Required]
        public string ClientName { get; set; }

        [Required]
        public string GSTIN { get; set; }
        public string ClientAddress1 { get; set; }
        public string ClientAddress2 { get; set; }
        public string CountryStateID { get; set; }
        public string City { get; set; }

        public string ContactNO { get; set; }
        [StringLength(13,MinimumLength =10)]
        public string MobileNO { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }
    }
}
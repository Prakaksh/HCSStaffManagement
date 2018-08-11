using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HCS.StaffManagement.Models
{
    public class Organization
    {
        public string OrganizationID { get; set; }

        [Required]
        public string OrganizationName { get; set; }
        [Required]
        public string GSTIN { get; set; }
        public string Code { get; set; }

        public string ESCINO { get; set; }
        public string EPFNO { get; set; }
        public string LabourLicenseNo { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }

        public int CountryID { get; set; }
        public int StateID { get; set; }
        public string City { get; set; }

        [StringLength(13,MinimumLength =10)]
        public string ContactNO { get; set; }

        [StringLength(13,MinimumLength =10)]
        public string MobileNO { get; set; }

        [DataType(DataType.PostalCode)]
        public string PinCode { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }

        public string PanNo { get; set; }

      
        
        public string InvoicePrefix { get; set; }
        public string OrganizationPrefix { get; set; }
        public string Logo { get; set; }
        public string LogoPath { get; set; }
        public bool IsLockedOut { get; set; }
        public string DeactivatedDate { get; set; }
        //public string Logo { get; set; }
        //public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate{ get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
    }
}
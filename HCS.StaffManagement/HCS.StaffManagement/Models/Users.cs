using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HCS.StaffManagement.Models
{
    public class Users
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string OrganizationID { get; set; }
        [Required]
        public string RoleID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
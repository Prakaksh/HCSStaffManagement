using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HCS.StaffManagement.Models
{
    public class Login
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailID{ get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password{ get; set; }
    }
}
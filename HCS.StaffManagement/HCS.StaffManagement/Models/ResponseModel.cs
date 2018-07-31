using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCS.StaffManagement.Models
{
    public class ResponseModel
    {
        public int Status {get; set;}
        public string StatusText { get; set; }
        //public List<T> ReturlList { get; set; }
    }
}
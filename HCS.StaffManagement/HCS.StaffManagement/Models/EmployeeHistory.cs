using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCS.StaffManagement.Models
{
    public class EmployeeHistory
    {
        public string EmployeeID { get; set; }
        public string OrganizationID { get; set; }
        public string EmployeeNo { get; set; }
        public string EmployeeHistoryID { get; set; }
        public string DateofJoin { get; set; }
        public string DateofResign { get; set; }
        public bool IsRejoin { get; set; }
        public string ReasonForResign { get; set; }
        public string Remarks { get; set; }
        public int SizeInBytes { get; set; }
        public string MimeType { get; set; }
        public string FolderPath { get; set; }
    }
}
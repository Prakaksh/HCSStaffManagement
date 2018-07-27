using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCS.StaffManagement.Models
{
    public class EmployeeDocument
    {
        public string EmployeeID { get; set; }
        public string OrganizationID { get; set; }
        public string EmployeeNo { get; set; }
        public string EmployeeDocumentID { get; set; }
        public string DocumentCategoryCode { get; set; }
        public string DocumentName { get; set; }
        public int ContentLength { get; set; }
        public string ContentType { get; set; }
        public string Extension { get; set; }
        public int SizeInBytes { get; set; }
        public string MimeType { get; set; }
        public string FolderPath { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCS.StaffManagement.Models
{
    public class DocumentDetail
    {
        public string DocumentDetailID { get; set; }
        public string FileURL { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public int FileSize { get; set; }
        public string FileExtension { get; set; }
    }
}
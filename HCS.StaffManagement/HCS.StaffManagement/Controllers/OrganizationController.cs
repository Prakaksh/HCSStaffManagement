using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HCS.StaffManagement.Filter;

namespace HCS.StaffManagement.Controllers
{
    [SessionTimeout]
    public class OrganizationController : Controller
    {
        // GET: Organization
        public ActionResult CreateOrganization()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HCS.StaffManagement.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        [HttpGet]
        public ActionResult GetClient()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ClientInsertUpdate()
        {
            return View();
        }
    }
}
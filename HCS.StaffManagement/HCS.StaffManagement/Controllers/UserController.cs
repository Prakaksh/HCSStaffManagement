using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HCS.StaffManagement.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult UserCreate()
        {
            return View();
        }
    }
}
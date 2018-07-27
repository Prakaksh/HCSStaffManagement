using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HCS.StaffManagement.Filter;
using HCS.StaffManagement.Models;

namespace HCS.StaffManagement.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        //[SessionTimeout]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        //[SessionTimeout]
        public ActionResult Login(Login objlogin)
        {

            return RedirectToAction("Home","AdminDashboard");
        }
    }
}
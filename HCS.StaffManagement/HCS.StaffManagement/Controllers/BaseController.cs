using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HCS.StaffManagement.Controllers
{
    public class BaseController : Controller
    {
        public ActionResult GetRoleType(string RoleName)
        {
            switch (RoleName)
            {
                case "Admin":
                    return RedirectToAction("AdminDashboard", "Home");

                case "Manager":
                    return RedirectToAction("AdminDashboard", "Home");

                case "SuperAdmin":
                    return RedirectToAction("SuperAdminDashboard", "Home");
                case "0":
                    ViewBag.Message = "Please enter valid credentials!";
                    return View();
                default:
                    return RedirectToAction("Login", "Login");
            }

        }
    }
}
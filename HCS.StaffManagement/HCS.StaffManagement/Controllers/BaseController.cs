using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HCS.StaffManagement.Filter;
using HCS.StaffManagement.Models;


namespace HCS.StaffManagement.Controllers
{
    
    public class BaseController : Controller
    {
        public ActionResult GetRoleType(string RoleName,Login objSession)
        {

            Session["UserID"] = objSession.EmailID.ToString();
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
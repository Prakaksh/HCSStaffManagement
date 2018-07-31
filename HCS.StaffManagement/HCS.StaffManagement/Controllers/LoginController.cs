using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HCS.StaffManagement.Filter;
using HCS.StaffManagement.Models;
using HCS.StaffManagement.Repositories;

namespace HCS.StaffManagement.Controllers
{
    public class LoginController : BaseController
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
            if (ModelState.IsValid)
            {
                try
                {
                    LoginContext obj = new LoginContext();
                 
                    string result = obj.GetLogin(objlogin);

                    //Redirecting to screen based on role..
                    return GetRoleType(result);
                }
                catch (Exception ex)
                {
                }
                //return RedirectToAction("AdminDashboard", "Home");

            }
            else
            {
                return View();
            }

            return RedirectToAction("Home","AdminDashboard");
        }

        //[HttpPost]
        //public ActionResult Login(Login objlogin)
        //{

        //    return RedirectToAction("Home", "AdminDashboard");
        //}

    }
}
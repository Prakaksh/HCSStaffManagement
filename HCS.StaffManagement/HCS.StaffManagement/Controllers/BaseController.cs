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
        public ActionResult GetRoleType(UserInfo objUser, Login objSession)
        {
            try
            {

                Session["UserID"] = objUser.EmailID.ToString();
                Session["OrganizationId"] = objUser.OrganizationID;
                Session["UserName"] = objUser.FirstName + " " + objUser.LastName;
                Session["RoleName"] = objUser.RoleName;
                Session["RoleTypeID"] = objUser.RoleTypeID;

                switch (objUser.RoleName)
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
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

                Session["UserID"] = objUser.UserID.ToString();
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

        public UserInfo UserInfoGet()
        {
            try
            {
                UserInfo obj = new UserInfo();
                if (Session != null)
                {
                    obj.UserID = new Guid(Session["UserID"].ToString());
                    obj.OrganizationID = new Guid(Session["OrganizationID"].ToString());
                    obj.UserName = (string)Session["UserName"];
                    obj.RoleName = (string)Session["RoleName"];
                    obj.RoleTypeID = new Guid(Session["RoleTypeID"].ToString());
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
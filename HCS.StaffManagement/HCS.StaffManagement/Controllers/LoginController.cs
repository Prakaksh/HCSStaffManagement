﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
                 
                    UserInfo objUser = obj.GetLogin(objlogin);
                    if (objUser != null && objUser.Status != "0")
                    {
                        
                        //Redirecting to screen based on role..
                        GetRoleType(objUser, objlogin);
                    }
                    else {
                        ViewBag.Message = "Please enter valid credentials!";
                    }
                    return View();
                   
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

            return View();
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            Session.Abandon();
            Session.Clear();
            Response.Cookies.Clear();
            Session.RemoveAll();
            Session["UserID"] = null;

            //If you hit backbutton of browser, page loads from cache..So Label and other controls will dispaly previous values.

            //HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //HttpContext.Current.Response.Cache.SetNoServerCaching();
            //HttpContext.Current.Response.Cache.SetNoStore();

            return RedirectToAction("Login", "Login");
        }

    }
}
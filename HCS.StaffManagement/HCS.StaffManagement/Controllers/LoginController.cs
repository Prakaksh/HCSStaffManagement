﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HCS.StaffManagement.Filter;

namespace HCS.StaffManagement.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        //[SessionTimeout]
        public ActionResult LoginPage()
        {
            return View();
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HCS.StaffManagement.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult GetReport()
        {
            return View();
        }
    }
}
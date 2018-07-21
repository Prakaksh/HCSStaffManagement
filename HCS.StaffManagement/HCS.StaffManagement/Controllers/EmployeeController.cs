using HCS.StaffManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HCS.StaffManagement.Controllers
{
    public class EmployeeController : BaseController
    {
        // GET: Employee
        [HttpGet]
        public ActionResult Employee()
        {
            return View();
        }
        [HttpPost]
        //--this is for add
        public ActionResult EmployeeInsertUpdate(Employee objEmployee)
        {
            return View();
        }
        //--this is for edit
        [HttpPost]
        public ActionResult EmployeeDelete (Employee objEmployee)
        {
            return View();
        }


    }
}
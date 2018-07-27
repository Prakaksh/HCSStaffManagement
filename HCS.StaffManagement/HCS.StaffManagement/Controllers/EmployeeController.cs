using HCS.StaffManagement.Models;
using HCS.StaffManagement.Repositories;
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
        public ActionResult CreateEmployee()
        {
            return View();
        }
        [HttpPost]
        //--this is for add
        public ActionResult EmployeeInsertUpdate(Employee objEmployee)
        {
            try
            {
                EmployeeInsertUpdateContext objEmp = new EmployeeInsertUpdateContext();

                string result= objEmp.EmployeeInsertUpdate(objEmployee);
                TempData["Success"] = "Added Successfully!";
                
                return RedirectToAction("Employee", "Employee");
                //return Request.CreateResponse(HttpStatusCode.OK, maritalStatuses);
            }
            catch(Exception ex) { }
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
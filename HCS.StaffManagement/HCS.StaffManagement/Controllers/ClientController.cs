using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HCS.StaffManagement.Models;
using HCS.StaffManagement.Repositories;

namespace HCS.StaffManagement.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        [HttpGet]
        public ActionResult Client()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ClientInsertUpdate(Client objClient)
        {
            try
            {
                ClientContext objEmp = new ClientContext();

                //string result = objEmp.EmployeeInsertUpdate(objEmployee);
                TempData["Success"] = "Added Successfully!"; 

                return RedirectToAction("Employee", "Employee");
                //return Request.CreateResponse(HttpStatusCode.OK, maritalStatuses);
            }
            catch (Exception ex) { }
            return View();
        }
        
    }
}
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
        public ActionResult GetClient()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateClient()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ClientInsertUpdate(Client objClient)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ClientContext objEmp = new ClientContext();

                    //string result = objEmp.EmployeeInsertUpdate(objEmployee);
                    TempData["Success"] = "Added Successfully!";


                    return RedirectToAction("GetClient", "Client");
                    //return Request.CreateResponse(HttpStatusCode.OK, maritalStatuses);
                }
                catch (Exception ex) {
                }
                return RedirectToAction("GetClient", "Client");

            }
            else {
                return View();
            }
            
        }
        
    }
}
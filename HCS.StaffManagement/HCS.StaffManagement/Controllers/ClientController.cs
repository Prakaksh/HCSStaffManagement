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
    [SessionTimeout]
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
        public JsonResult ClientInsertUpdate(Client objClient)
        {
                try
                {
                    ClientContext objEmp = new ClientContext();

                    var result = objEmp.ClientInsertUpdate(objClient);
                
                    TempData["Success"] = "Added Successfully!";

                return Json(new{result}, JsonRequestBehavior.AllowGet);
            }
                catch (Exception ex) {
                }
            
            return Json("GetClient", "Client");

            
        }
        
    }
}
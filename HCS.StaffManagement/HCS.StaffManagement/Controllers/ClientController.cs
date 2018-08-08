using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HCS.StaffManagement.Filter;
using HCS.StaffManagement.Models;
using HCS.StaffManagement.Repositories;
using HCS.StaffManagement.Repositories.DTO;

namespace HCS.StaffManagement.Controllers
{
    [SessionTimeout]
    public class ClientController : Controller
    {
        // GET: Client
        [HttpGet]
        public ActionResult GetClient(Client objclient)
        {
            //if (objclient.OrganizationClientID != null)
            //{
            //    ClientContext obj = new ClientContext();

            //    //IEnumerable<ClientDto> objResult = obj.GetClient(objClient);
            //}
            return View();
        }

        [HttpGet]
        public ActionResult CreateClient(Client objclient)
        {
            if (objclient.OrganizationClientID != null)
            {
                ClientContext obj = new ClientContext();

               // IEnumerable<ClientDto> objResult = obj.GetClient(objclient);
            }
            return View(objclient);
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
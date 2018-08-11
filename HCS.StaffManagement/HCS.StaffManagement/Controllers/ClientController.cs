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
    public class ClientController : BaseController
    {
        ClientContext obj;
        // GET: Client
        [HttpGet]
        public ActionResult Client()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ClientGet(Client objClient)
        {
            obj = new ClientContext();
            List<ClientDto> objResult = new List<ClientDto>();
            try
            {
                objResult = obj.ClientGet(objClient, UserInfoGet());                
            }
            catch (Exception ex)
            {
                return Json("[]");
            }
            return Json(objResult,JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult ClientInsertUpdate(Client objClient)
        {
                try
                {
                    ClientContext objEmp = new ClientContext();

                    var result = objEmp.ClientInsertUpdate(objClient, UserInfoGet());
                
                    TempData["Success"] = "Added Successfully!";

                return Json(new{result}, JsonRequestBehavior.AllowGet);
            }
                catch (Exception ex) {
                }
            
            return Json("GetClient", "Client");

            
        }
        
    }
}
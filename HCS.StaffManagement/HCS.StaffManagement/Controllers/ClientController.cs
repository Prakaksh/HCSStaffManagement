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
        ClientContext objdbContext;
        // GET: Client
        [HttpGet]
        public ActionResult Client()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ClientCreate()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ClientGet(Client objClient)
        {
            objdbContext = new ClientContext();
            List<ClientDto> objResult = new List<ClientDto>();
            try
            {
                objResult = objdbContext.ClientGet(objClient, UserInfoGet());
            }
            catch (Exception ex)
            {
                return Json("[]");
            }
            return Json(objResult, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult ClientInsertUpdate(Client objClient)
        {
            try
            {
                objdbContext = new ClientContext();
                var result = objdbContext.ClientInsertUpdate(objClient, UserInfoGet());
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
            }
            return Json("");
        }

        [HttpDelete]
        public JsonResult ClientDelete(Client objClient)
        {
            try
            {
                objdbContext = new ClientContext();
                var result = objdbContext.ClientDelete(objClient, UserInfoGet());
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
            }
            return Json("");
        }
    }
}
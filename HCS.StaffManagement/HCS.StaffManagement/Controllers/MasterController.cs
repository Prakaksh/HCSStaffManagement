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
    public class MasterController : Controller
    {

        [HttpGet]
        public JsonResult CountryStateGet(MasterCountryState objstate)
        {
            try
            {
                CountryStateContext objStateContext = new CountryStateContext();
                IEnumerable<MasterCountryState> maritalStatuses = objStateContext.GetCountryState(objstate);
                return Json(maritalStatuses, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("[]");
            }
        }
    }
}
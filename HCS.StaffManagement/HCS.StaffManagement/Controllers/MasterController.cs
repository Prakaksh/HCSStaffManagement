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
        public JsonResult CountryStateGet(MasterCountryState objState)
        {
            try
            {
                MasterContext objStateContext = new MasterContext();
                IEnumerable<MasterCountryState> objResult = objStateContext.CountryStateGet(objState);
                return Json(objResult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("[]");
            }
        }

        [HttpGet]
        public JsonResult MaritalStatusGet(MasterMaritalStatus objMS)
        {
            try
            {
                MasterContext objStateContext = new MasterContext();
                IEnumerable<MasterMaritalStatus> objResult = objStateContext.MaritalStatusGet(objMS);
                return Json(objResult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("[]");
            }
        }

        public JsonResult QualificationGet(MasterQualification objQua)
        {
            try
            {
                MasterContext objStateContext = new MasterContext();
                IEnumerable<MasterMaritalStatus> objResult = objStateContext.QualificationGet(objQua);
                return Json(objResult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("[]");
            }
        }


        public JsonResult RelationshipGet(MasterRelationship objRs)
        {
            try
            {
                MasterContext objStateContext = new MasterContext();
                IEnumerable<MasterMaritalStatus> objResult = objStateContext.RelationshipGet(objRs);
                return Json(objResult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("[]");
            }
        }
    }
}
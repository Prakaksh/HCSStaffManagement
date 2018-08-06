using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HCS.StaffManagement.Models;
using HCS.StaffManagement.Repositories;

namespace HCS.StaffManagement.Controllers
{
    public class PayslipController : Controller
    {
        PayslipContext objContext;
        // GET: Payslip
        public ActionResult Payslip()
        {
            return View();
        }

        [HttpGet]
        public JsonResult PayslipGet(Employee objEmp)
        {
            PayScale objPayScale= new PayScale();
            try
            {
                objContext = new PayslipContext();
                objPayScale = objContext.PayScaleGet(objEmp, new UserInfo());
            }
            catch (Exception ex)
            {

            }
            return Json(objPayScale, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult PayslipInsertUpdate(Payslip objPayslip)
        {
            string strResult = string.Empty;
            try
            {
                objContext = new PayslipContext();
                ResponseModel objRes = objContext.PayslipInsertUpdate(objPayslip, new UserInfo());
                strResult = objRes.StatusText;
            }
            catch(Exception ex)
            {

            }
            return Json("Success", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult PayslipGeneration(PayslipRequestList objPayslip)
        {
            string strResult = string.Empty;
            OrganizationPayslip objResult = new OrganizationPayslip();
            try
            {
                objContext = new PayslipContext();
                objResult = objContext.PayslipGeneration(objPayslip, new UserInfo());
                if(objResult != null && objResult.PayslipList != null && objResult.PayslipList.Count > 0)
                {
                    PayslipGeneration obj = new Models.PayslipGeneration();
                    obj.PayslipPDFGeneration(objResult, Server.MapPath("~/Temp/"));
                }
            }
            catch (Exception ex)
            {

            }
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
    }
}
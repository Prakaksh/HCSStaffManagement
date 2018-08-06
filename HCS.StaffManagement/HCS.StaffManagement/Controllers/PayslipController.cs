using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HCS.StaffManagement.Models;
using HCS.StaffManagement.Repositories;
using HCS.StaffManagement.Filter;

namespace HCS.StaffManagement.Controllers
{
   // [SessionTimeout]
    public class PayslipController : Controller
    {
        PayslipContext objContext;
        // GET: Payslip
        public ActionResult Payslip()
        {
            return View();
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
        public ActionResult PayslipDownload()
        {
            return View();
        }

    }
}
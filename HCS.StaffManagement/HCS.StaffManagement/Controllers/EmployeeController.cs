using HCS.StaffManagement.Models;
using HCS.StaffManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HCS.StaffManagement.Filter;
using System.IO;
using HCS.StaffManagement.Repositories.DTO;

namespace HCS.StaffManagement.Controllers
{
    [SessionTimeout]
    public class EmployeeController : BaseController
    {
        EmployeeContext objEmp;
        // GET: Employee
        [HttpGet]
        public ActionResult Employee()
        {
            return View();
        }
        public ActionResult EmployeeCreate(string employeeID)
        {
            try
            {
                objEmp = new EmployeeContext();
                List<Employee> objResult = objEmp.EmployeeGet(employeeID, UserInfoGet());
                if (!string.IsNullOrEmpty(employeeID))
                {
                    Employee objEmployee = objResult.FirstOrDefault();
                    return View(objEmployee);
                }
            }
            catch(Exception ex)
            {
                return View();
            }
            return View();
        }

        public JsonResult EmployeeGet(string employeeID)
        {
            try
            {
                objEmp = new EmployeeContext();
                List<Employee> objResult = objEmp.EmployeeGet(employeeID, UserInfoGet());
                return Json(objResult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("[]", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        //--this is for add
        public ActionResult EmployeeInsertUpdate(Employee objEmployee)
        {
            try
            {
                objEmp = new EmployeeContext();
                string result= objEmp.EmployeeInsertUpdate(objEmployee, UserInfoGet());
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex) {
                return Json("failure", JsonRequestBehavior.AllowGet);
            }
            
        }
        //--this is for edit
        [HttpDelete]
        public JsonResult EmployeeDelete (string EmployeeID)
        {
            try
            {
                objEmp = new EmployeeContext();
                string result = objEmp.EmployeeDelete(EmployeeID, UserInfoGet());
               return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
               return Json("failure", JsonRequestBehavior.AllowGet);
            }            
        }


        [HttpPost]
        public ActionResult ProfileImageUpload()
        {
            UploadImageContext objImage = new UploadImageContext();
            ImageDetail objimageModel = new ImageDetail();
                     
            if (Request.Files.Count > 0)
            {

                try
                {
                //  Get all files from Request object  
                HttpFileCollectionBase files = Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                    //string filename = Path.GetFileName(Request.Files[i].FileName);  

                    HttpPostedFileBase file = files[i];
                    string fname;

                    // Checking for Internet Explorer  
                    if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                    {
                        string[] testfiles = file.FileName.Split(new char[] { '\\' });
                        fname = testfiles[testfiles.Length - 1];
                    }
                    else
                    {
                            fname = objImage.ImageUploadSave(objimageModel);
                            objimageModel.ID = fname;
                            // fname = file.FileName;
                        }

                        // Get the complete folder path and store the file inside it.  
                        // If directory does not exist, don't even try 
                        
                        fname = Path.Combine(Server.MapPath("~/ProfileImage/"), fname+".jpeg");
                        if (Directory.Exists(fname))
                        {
                            file.SaveAs(fname);
                        }
                        else {
                            Directory.CreateDirectory(Server.MapPath("~/ProfileImage"));
                            file.SaveAs(fname);
                        }

                     
                }
                // Returns message that successfully uploaded  
                return Json(objimageModel);
            }
            catch (Exception ex)
            {
                return Json("Error occurred. Error details: " + ex.Message);
            }
        }  
    else  
    {  
        return Json("No files selected.");
    }
}


    }
}
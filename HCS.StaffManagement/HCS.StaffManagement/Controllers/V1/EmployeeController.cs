using HCS.StaffManagement.Repositories.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HCS.StaffManagement.Models;
using HCS.StaffManagement.Repositories.V1;
using HCS.StaffManagement.Repositories.DTO;
using NLog;

namespace HCS.StaffManagement.Controllers.V1
{
    [RoutePrefix("Api/V1")]
    public class EmployeeController : ApiController
    {
        Logger logger = LogManager.GetCurrentClassLogger();

        [Route("GetEmployee")]
        [HttpGet]
        public HttpResponseMessage EmployeeGet([FromBody]EmployeeDto objEmp)
        {
            try
            {
                EmployeeContext obj = new EmployeeContext();

                IEnumerable<EmployeeDto> objResult = obj.GetEmployee();

                return Request.CreateResponse(HttpStatusCode.OK, objResult);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, "test");
                            
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Internal Server Error");
            }

        }
    }
}
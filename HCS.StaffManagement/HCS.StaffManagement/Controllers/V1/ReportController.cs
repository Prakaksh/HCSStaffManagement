using HCS.StaffManagement.Models;
using HCS.StaffManagement.Repositories.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HCS.StaffManagement.Controllers.V1
{
    [RoutePrefix("api/V1")]
    public class ReportController : ApiController
    {
        [Route("ReportSearchEmpty")]
        [HttpGet]
        public HttpResponseMessage ReportSearchEmpty([FromBody]Client objClient)
        {
            try
            {
                List<ReportDto> objResult = new List<ReportDto>();

                return Request.CreateResponse(HttpStatusCode.OK, objResult);
            }
            catch (Exception ex)
            {
                //objErrorLogServices.LogError("Client", "GetClient", "", "", ex.Message.ToString());
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Internal Server Error");
            }

        }
    }
}

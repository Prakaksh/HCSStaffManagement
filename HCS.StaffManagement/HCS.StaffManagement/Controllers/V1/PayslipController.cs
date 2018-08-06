using HCS.StaffManagement.Models;
using HCS.StaffManagement.Repositories;
using HCS.StaffManagement.Repositories.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HCS.StaffManagement.Controllers.V1
{
   [RoutePrefix("Api/V1")]
    public class PayslipController : ApiController
    {
        [Route("PayslipDownloadSearchEmpty")]
        [HttpGet]
        public HttpResponseMessage PayslipDownloadSearchEmpty([FromBody]Client objClient)
        {
            try
            {
                List<PayslipDownloadDto> objResult = new List<PayslipDownloadDto>();

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
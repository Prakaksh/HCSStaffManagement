using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HCS.StaffManagement.Models;
using HCS.StaffManagement.Repositories;

namespace HCS.StaffManagement.Controllers.V1

{
    [RoutePrefix("V1")]
    public class MaritalStatusController : ApiController
    {
        [Route("GetMaritalStatus")]
        [HttpGet]
        public HttpResponseMessage GetMaritalStatus([FromBody]MasterMaritalStatus objstatus)
        {
            try
            {
                MaritalStatusContext objStateContext = new MaritalStatusContext();

                IEnumerable<MasterMaritalStatus> maritalStatuses = objStateContext.GetMaritalStatus(objstatus);

                return Request.CreateResponse(HttpStatusCode.OK, maritalStatuses);
            }
            catch (Exception ex)
            {
                //objErrorLogServices.LogError("Client", "GetClient", "", "", ex.Message.ToString());
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Internal Server Error");
            }

        }
    }
}

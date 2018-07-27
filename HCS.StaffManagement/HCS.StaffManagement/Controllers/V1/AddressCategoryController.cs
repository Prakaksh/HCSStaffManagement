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
    public class AddressCategoryController : ApiController
    {
        [Route("GetAddressCategory")]
        [HttpGet]
        public HttpResponseMessage GetAddressCategory([FromBody]MasterAddressCategory objstatus)
        {
            try
            {
                AddressCategoryContext objStateContext = new AddressCategoryContext();
                IEnumerable<MasterAddressCategory> maritalStatuses = objStateContext.GetAddressCategory(objstatus);
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

using HCS.StaffManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HCS.StaffManagement.Repositories.V1;
using HCS.StaffManagement.Repositories.DTO;

namespace HCS.StaffManagement.Controllers.V1
{
    [RoutePrefix("Api/V1")]
    public class ClientController : ApiController
    {
        //[Route("GetClient")]
        //[HttpGet]
        //public HttpResponseMessage GetMaritalStatus([FromBody]MasterMaritalStatus objstatus)
        //{
        //    //try
        //    //{
        //    //     objStateContext = new MaritalStatusContext();

        //    //    IEnumerable<MasterMaritalStatus> maritalStatuses = objStateContext.GetMaritalStatus(objstatus);

        //    //    return Request.CreateResponse(HttpStatusCode.OK, maritalStatuses);
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    //objErrorLogServices.LogError("Client", "GetClient", "", "", ex.Message.ToString());
        //    //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Internal Server Error");
        //    //}

        //}

        [Route("GetClient")]
        [HttpGet]
        public HttpResponseMessage GetClient([FromBody]Client objClient)
        {
            try
            {
                ClientContext obj = new ClientContext();

                IEnumerable<ClientDto> objResult = obj.GetClient(objClient);

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

using HCS.StaffManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HCS.StaffManagement.Repositories.V1;
using HCS.StaffManagement.Repositories.DTO;
using HCS.StaffManagement.Repositories;

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

        [Route("ClientGet")]
        [HttpGet]
        public HttpResponseMessage ClientGet([FromUri]Client objClient)
        {
            try
            {
                Repositories.V1.ClientContext obj = new Repositories.V1.ClientContext();

                IEnumerable<ClientDto> objResult = obj.ClientGet(objClient);

                return Request.CreateResponse(HttpStatusCode.OK, objResult);
            }
            catch (Exception ex)
            {
                //objErrorLogServices.LogError("Client", "GetClient", "", "", ex.Message.ToString());
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Internal Server Error");
            }

        }


        [Route("ClientUpdate")]
        [HttpPost]
        public HttpResponseMessage ClientUpdate([FromBody]Client objClient)
        {
            try
            {
                Repositories.ClientContext obj = new Repositories.ClientContext();

              var result= obj.ClientInsertUpdate(objClient);

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                //objErrorLogServices.LogError("Client", "GetClient", "", "", ex.Message.ToString());
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Internal Server Error");
            }

        }


    }
}

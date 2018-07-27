using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HCS.StaffManagement.Models;
using HCS.StaffManagement.Repositories.V1;

namespace HCS.StaffManagement.Controllers.V1
{
    [RoutePrefix("V1")]
    public class LoginController : ApiController
    {
        [Route("GetLogin")]
        [HttpGet]
        public HttpResponseMessage GetLogin([FromBody]Login objlogin)
        {
            try
            {
                LoginContext objLogin = new LoginContext();
                IEnumerable<Login> RoleType = objLogin.GetLogin(objlogin);
                return Request.CreateResponse(HttpStatusCode.OK, RoleType);
            }
            catch (Exception ex)
            {
                //objErrorLogServices.LogError("Client", "GetClient", "", "", ex.Message.ToString());
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HCS.StaffManagement.Models;
using HCS.StaffManagement.Repositories;

namespace HCS.StaffManagement.Controllers.V1
{
    [RoutePrefix("api/V1")]
    public class CountryStateController : ApiController
    {
        [Route("CountryStateGet")]
        [HttpGet]
        public HttpResponseMessage CountryStateGet([FromBody]MasterCountryState objstate)
        {
            try
            {
                CountryStateContext objStateContext = new CountryStateContext();
                IEnumerable<MasterCountryState> maritalStatuses = objStateContext.GetCountryState(objstate);
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

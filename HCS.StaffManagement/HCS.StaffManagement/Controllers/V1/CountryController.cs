using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace HCS.StaffManagement.Controllers.V1
{
    [RoutePrefix("V1")]
    public class CountryController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Country()
        {
            return Ok("Success");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Singular.Web.Ui.ApiControllers
{
    public class SystemApiController : ApiController
    {
        [Route("api/ping")]
        [AcceptVerbs("GET")]
        public string Ping()
        {
            return "Pinged";
        }
    }
}

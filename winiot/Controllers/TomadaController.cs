using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace winiot.Controllers
{
    public class TomadaController : ApiController
    {
        // GET: api/Tomada
        public int Get()
        {
            return WebApiApplication.TomadaStatus;
        }

        // POST: api/Tomada
        public string Post()
        {
            if (WebApiApplication.TomadaStatus == 0)
            {
                WebApiApplication.TomadaStatus = 1;
                WebApiApplication.TomadaStatus_Count++;
            }
            else
                WebApiApplication.TomadaStatus = 0;

            return WebApiApplication.TomadaStatus.ToString();
        }

        [HttpGet]
        [Route("api/Tomada/Count")]
        public int Count()
        {
            return WebApiApplication.TomadaStatus_Count;
        }
    }
}

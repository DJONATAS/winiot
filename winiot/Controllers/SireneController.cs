using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace winiot.Controllers
{
    public class SireneController : ApiController
    {
        // GET: api/Sirene
        public int Get()
        {
            return WebApiApplication.SireneStatus;
        }

        // POST: api/Sirene
        public string Post()
        {
            if (WebApiApplication.SireneStatus == 0)
            {
                WebApiApplication.SireneStatus = 1;
                WebApiApplication.SireneStatus_Count++;
            }           
            else
                WebApiApplication.SireneStatus = 0;

            return WebApiApplication.SireneStatus.ToString();
        }

        [HttpGet]
        [Route("api/Sirene/Count")]
        public int Count()
        {
            return WebApiApplication.SireneStatus_Count;
        }
    }
}

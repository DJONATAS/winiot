using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace winiot.Controllers
{
    public class LampadaController : ApiController
    {
        // GET: api/Lampada
        public int Get()
        {
            return WebApiApplication.LampadaStatus;
        }

        // POST: api/Lampada
        public string Post()
        {
            if (WebApiApplication.LampadaStatus == 0)
            {
                WebApiApplication.LampadaStatus = 1;
                WebApiApplication.LampadaStatus_Count++;
            }
            else
                WebApiApplication.LampadaStatus = 0;

            return WebApiApplication.LampadaStatus.ToString();
        }

        [HttpGet]
        [Route("api/Lampada/Count")]
        public int Count()
        {
            return WebApiApplication.LampadaStatus_Count;
        }
    }
}

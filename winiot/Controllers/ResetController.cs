using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace winiot.Controllers
{
    public class ResetController : ApiController
    {
        // GET: api/Lampada
        public void Get()
        {
            WebApiApplication.LampadaStatus_Count = 0;
            WebApiApplication.LampadaStatus = 0;
            WebApiApplication.SireneStatus_Count = 0;
            WebApiApplication.SireneStatus = 0;
            WebApiApplication.TomadaStatus_Count = 0;
            WebApiApplication.TomadaStatus = 0;
        }
    }
}

using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace winiot
{
    public class WebApiApplication : System.Web.HttpApplication
    {

        public static int TomadaStatus;
        public static int LampadaStatus;
        public static int SireneStatus;

        public static int TomadaStatus_Count;
        public static int LampadaStatus_Count;
        public static int SireneStatus_Count;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}

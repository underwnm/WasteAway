using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WasteAway.Jobs;

namespace WasteAway
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var start = new RouteJob();
            start.AssignTruckToPickupList();

            JobScheduler.Start();
            
        }
    }
}

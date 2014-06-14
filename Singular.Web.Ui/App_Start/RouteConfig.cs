using System.Web.Mvc;
using System.Web.Routing;

namespace Singular.Web.Ui
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{*catchall}",
            //    defaults: new { controller = "System", action = "Error", id = UrlParameter.Optional },
            //    namespaces: new[] { "Singular.Web.Ui.Controllers" }
            //);
        }
    }
}
using System.Net.Http.Formatting;
using System.Web.Http;

namespace Singular.Web.Admin
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "Singular.Admin.Api",
            //    routeTemplate: "singular/api/*"
            //);

            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
        }
    }
}
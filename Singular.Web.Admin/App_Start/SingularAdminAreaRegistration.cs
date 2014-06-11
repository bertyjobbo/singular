using System.Web.Mvc;

namespace Singular.Web.Admin
{
    public class SingularAdminAreaRegistration : AreaRegistration
    {
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Singular.Web.Admin.DefaultRoute",
                "Singular/{controller}/{action}/{id}",
                new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                }, new []
                {
                    "Singular.Web.Admin.Controllers"
                });
        }

        public override string AreaName
        {
            get { return "Singular.Web.Admin"; }
        }
    }
}
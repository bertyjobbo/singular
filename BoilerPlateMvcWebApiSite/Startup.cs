using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BoilerPlateMvcWebApiSite.Startup))]
namespace BoilerPlateMvcWebApiSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

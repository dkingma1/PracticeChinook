using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChinookWebSite.Startup))]
namespace ChinookWebSite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

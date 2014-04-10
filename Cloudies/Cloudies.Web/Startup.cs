using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cloudies.Web.Startup))]
namespace Cloudies.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

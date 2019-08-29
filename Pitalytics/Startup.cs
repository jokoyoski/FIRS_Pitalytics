using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pitalytics.Startup))]
namespace Pitalytics
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

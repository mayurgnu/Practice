using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DefaultIdentityApp.Startup))]
namespace DefaultIdentityApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

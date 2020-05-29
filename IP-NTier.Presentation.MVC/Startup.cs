using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IP_NTier.Presentation.MVC.Startup))]
namespace IP_NTier.Presentation.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

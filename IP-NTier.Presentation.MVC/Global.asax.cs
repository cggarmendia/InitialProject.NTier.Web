using IP_NTier.Common.Core.Config;
using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using IP_NTier.Common.Core.Context;
using IP_NTier.Common.Core.IoC;
using IP_NTier.Common.InitializeDatabase;

namespace IP_NTier.Presentation.MVC
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_AuthorizeRequest(Object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                if (cookie != null)
                {
                    var ticket = FormsAuthentication.Decrypt(cookie.Value);
                    if (ticket != null) AppConfig.SetUserName(ticket.Name);
                }
            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            NinjectWebCommon.RegisterNinject(GlobalConfiguration.Configuration);
            InitDatabase();
        }

        private void InitDatabase()
        {
            var domain = DependencyManager.Instance().Resolve<IIpNTierInitializer>();
            var security = DependencyManager.Instance().Resolve<IIpNTierSecurityInitializer>();
            security.InitializeDatabase();
            domain.InitializeDatabase();
        }
    }
}

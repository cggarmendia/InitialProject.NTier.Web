using System.Web;
using System.Web.Mvc;

namespace IP_NTier.Presentation.API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

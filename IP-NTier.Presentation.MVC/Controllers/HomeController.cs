using IP_NTier.Business.DomainServices.Modules.Security;
using IP_NTier.Common.Presentation.MVC.Controller;
using System.Web.Mvc;

namespace IP_NTier.Presentation.MVC.Controllers
{
    public class HomeController : ControllerMvcBase
    {
        private readonly IRoleDomainServices _roleServices;

        public HomeController(IRoleDomainServices roleServices)
        {
            _roleServices = roleServices;
        }
        public ActionResult Index()
        {
            var all = _roleServices.GetAll();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
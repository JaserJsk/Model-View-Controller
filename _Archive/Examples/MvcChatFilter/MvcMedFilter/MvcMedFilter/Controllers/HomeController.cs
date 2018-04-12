using System.Web.Mvc;
using MvcMedFilter.Filters;

namespace MvcMedFilter.Controllers
{
    [CustomAuthorizationFilter]
    [CustomActionFilter]
    [CustomResultFilter]
    [CustomExceptionFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Error()
        {
            return Content("Fel!");
        }
    }
}
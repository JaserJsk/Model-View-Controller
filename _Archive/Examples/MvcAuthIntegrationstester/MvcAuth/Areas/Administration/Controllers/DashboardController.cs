using System.Web.Mvc;
using MvcAuth.Filters;

namespace MvcAuth.Areas.Administration.Controllers
{
    [AdministratorAuthorization]
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
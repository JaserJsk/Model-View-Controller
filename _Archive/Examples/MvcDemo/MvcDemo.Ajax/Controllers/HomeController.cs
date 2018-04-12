using System.Web.Mvc;

namespace MvcDemo.Ajax.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Gör en automatisk redirect till /Gallery/Index
            return RedirectToAction("Index", "Gallery");
        }
    }
}
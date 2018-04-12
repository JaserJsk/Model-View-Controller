using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AddressBookApp.Controllers
{
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            ViewData["SubTitle"] = "Inspinia SeedProject";
            ViewData["Message"] = "This is an application skeleton for a typical MVC 5 project";

            return View();
        }

        public ActionResult Minor()
        {
            ViewData["SubTitle"] = "Second View";
            ViewData["Message"] = "Data are passing to view by ViewData from controller";

            return View();
        }
    }
}
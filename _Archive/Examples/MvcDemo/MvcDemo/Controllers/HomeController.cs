﻿using System.Web.Mvc;

namespace MvcDemo.Controllers
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
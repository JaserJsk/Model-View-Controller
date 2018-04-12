using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAuth.Data;

namespace MvcAuth.Controllers
{
    [Authorize]
    public class AuthenticatedController : Controller
    {
    }


    public class HomeController : AuthenticatedController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
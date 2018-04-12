using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MvcChat.Models;

namespace MvcChat.Controllers
{

    public class MessageController : Controller
    {
        private static IList<MessageModel> messages = new List<MessageModel>();

        public ActionResult List()
        {
            HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");

            return Json(messages, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View(messages);
        }

        [Route("Date/{type}")]
        [OutputCache(Duration = 10)]
        public ActionResult Date(int type)
        {
            switch (type)
            {
                case 0:
                    return Content(DateTime.Now.ToShortTimeString());
                case 1:
                    return Content(DateTime.Now.ToUniversalTime().ToLongTimeString());
                default:
                    return Content(DateTime.Now.ToLongTimeString());
            }
        }

        [HttpPost]
        public ActionResult Add(MessageModel model)
        {
            HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");

            model.Sent = DateTime.Now;

            messages.Add(model);

            return List();
        }

        public void DeleteAll()
        {
            messages.Clear();
        }

    }
}
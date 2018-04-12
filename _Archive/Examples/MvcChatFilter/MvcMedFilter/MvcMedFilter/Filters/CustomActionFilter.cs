using System;
using System.Web.Mvc;

namespace MvcMedFilter.Filters
{
    public class CustomActionFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {

            filterContext.HttpContext.Response.Write($"Action Start: {DateTime.Now.ToLongTimeString()}\n\n");
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write($"Action Stop: {DateTime.Now.ToLongTimeString()}\n\n");
        }
    }
}
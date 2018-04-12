using System;
using System.Web.Mvc;

namespace MvcMedFilter.Filters
{
    public class CustomResultFilter : FilterAttribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write($"View Start: {DateTime.Now.ToLongTimeString()}\n\n");
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write($"View Stop: {DateTime.Now.ToLongTimeString()}\n\n");
        }
    }
}
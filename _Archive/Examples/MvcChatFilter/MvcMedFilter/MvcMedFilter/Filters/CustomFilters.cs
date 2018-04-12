using System.Web.Mvc;

namespace MvcMedFilter.Filters
{
    public class CustomExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.HttpContext.Response.Redirect("/Home/Error");
        }
    }
}
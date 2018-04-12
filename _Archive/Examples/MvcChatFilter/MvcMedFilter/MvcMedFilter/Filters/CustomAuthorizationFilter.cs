using System.Security.Claims;
using System.Web.Mvc;

namespace MvcMedFilter.Filters
{
    public class CustomAuthorizationFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            // filterContext.Result = new HttpUnauthorizedResult();

            /*
             * var principal = 
             *     filterContext.HttpContext.User.Identity as ClaimsPrincipal
             * 
             * if(!principal.HasClaim("Administrator", "true")) filterContext.Result = new HttpUnauthorizedResult();
             * 
             */
        }
    }
}
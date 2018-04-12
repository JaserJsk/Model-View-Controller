using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace MvcAuth.Filters
{
    //public class AdministratorAuthorizationAttribute
    //    : FilterAttribute, IAuthorizationFilter
    //{
    //    public void OnAuthorization(AuthorizationContext 
    //        filterContext)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    public class AdministratorAuthorizationAttribute
        : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            var principal = filterContext.HttpContext.User 
                as ClaimsPrincipal;

            if (principal == null || !principal.HasClaim("IsAdministrator", "True"))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }


}
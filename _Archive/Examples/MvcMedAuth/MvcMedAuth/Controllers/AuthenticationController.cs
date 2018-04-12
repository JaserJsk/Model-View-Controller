using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace MvcMedAuth.Controllers
{
    public class AuthenticationController : Controller
    {
        private UserManager<IdentityUser> userManager;
        public AuthenticationController()
        {
            var context = new MyIdentityDbContext();
            var store = new UserStore<IdentityUser>(context);

            userManager = new UserManager<IdentityUser>(store);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(string username, 
            string password, 
            string email)
        {
            var user = new IdentityUser
            {
                UserName = username,
                Email = email
            };
            
            var result = await userManager.CreateAsync(user, password);
            
            if (result.Succeeded)
            {
                var identity = await userManager.CreateIdentityAsync(user, 
                    DefaultAuthenticationTypes.ApplicationCookie);
                
                identity.AddClaim(new Claim("gender", "Male"));

                var authenticationManager =
                    HttpContext.GetOwinContext().Authentication;
               
                authenticationManager.SignIn(identity);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(
            string username,
            string password)
        {
            var user = await userManager.FindAsync(username, password);

            if (user == null) return View();
            
            var identity = await userManager.CreateIdentityAsync(user,
                DefaultAuthenticationTypes.ApplicationCookie
            );
            
            var authenticationManager = HttpContext.GetOwinContext().Authentication;

            authenticationManager.SignIn(identity);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;

            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction("Login");
        }
    }
}
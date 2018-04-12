﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(MvcMedAuth.Startup))]

namespace MvcMedAuth
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            app.UseCookieAuthentication(
                new CookieAuthenticationOptions
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/Authentication/Login")
                }
            );





        }
    }
}

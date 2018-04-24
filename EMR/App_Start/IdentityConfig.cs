using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Owin;
using Owin;

using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using EMR.DAL2.Identity;
using EMR.DAL2.EF;

[assembly: OwinStartup(typeof(EMR.App_Start.IdentityConfig))]
namespace EMR.App_Start
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<EMRContext>(() => EMRContext.Create());
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Login/SignIn"),
            });
        }
    }
}
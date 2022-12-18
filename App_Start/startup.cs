using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;


[assembly: OwinStartup(typeof(ProjetoASP.App_Start.startup))]


namespace ProjetoASP.App_Start
{
    public class startup
    {
        public void Configuration(IAppBuilder app)

        {

            app.UseCookieAuthentication(new CookieAuthenticationOptions

            {

                AuthenticationType = "AppAplicationCookie",

                LoginPath = new PathString("/CadastroLogin/LoginForm")

            });

        }
    }
}
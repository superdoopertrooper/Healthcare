 
using Microsoft.AspNet.Identity;
using Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;


namespace Hospital.WebUI
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions()
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new Microsoft.Owin.PathString("/account/login")
            });
     
            app.Use(async (ctx, next) =>
                    {
                        //var identity = new ClaimsIdentity("ApplicationCookie");
                        //identity.AddClaims(new List<Claim>()
                        //{ 
                        //new Claim(ClaimTypes.NameIdentifier, "remzyId"),
                        //new Claim(ClaimTypes.Name, "remzy"),
                        //new Claim(ClaimTypes.Email, "remzymoen@hot")

                        ////identityprovider

                        //});

                        //HttpContext.Current.GetOwinContext().Authentication.SignIn(identity);

                        Debug.WriteLine("outgoing " + ctx.Request.Path);
                        await next();
                    });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            //app.UseFacebookAuthentication(
            //   appId: "1234",
            //   appSecret: "1234");

           // app.USSSAuthentication();


            //app.UseUSSS(new USSSOptions()
            //{
            //    OnIncomingRequest = (ctx) => ctx.Response.WriteAsync("from UseUSSS")

            //});

            //app.Use(async (ctx, next) =>
            //        {
            //            await ctx.Response.WriteAsync("mw from startup");
            //    //Debug.WriteLine("outgoing " + ctx.Request.Path);
            //});

 

            
        }
    }
}
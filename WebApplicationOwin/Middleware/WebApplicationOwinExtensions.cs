using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationOwin.Security;

namespace WebApplicationOwin.Middleware
{
    public static class WebApplicationOwinExtensions
    {
        public static void UseUSSS(this IAppBuilder app, USSSOptions options = null)
        {
            if (options == null)
            {
                options = new USSSOptions();
            }

            app.Use<USSS>(options);
        }
    }
}

using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital.Middleware.Security.USSS
{
    public static class USSSAuthenticationExtensions
    {
        public static void UseUSSS(this IAppBuilder app, USSSAuthenticationOptions options = null)
        {
            if (options == null)
            {
                options = new USSSAuthenticationOptions();
            }

            app.Use<USSSAuthentication>(options);
        }
    }
}
using Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplicationOwin.Middleware;
using WebApplicationOwin.Security;

namespace WebApplicationOwin
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {

            app.UseUSSS(new USSSOptions()
            {
                OnIncomingRequest = (ctx) => ctx.Response.WriteAsync("from UseUSSS")

            });

    app.Use(async (ctx, next) =>
            {
                await ctx.Response.WriteAsync("mw from startup");
    //Debug.WriteLine("outgoing " + ctx.Request.Path);
});

        }
    }
}
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital.Middleware.Security
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class USSSAuthentication
    {
        private AppFunc _next;
        private USSSAuthenticationOptions _options;

        public USSSAuthentication(AppFunc next, USSSAuthenticationOptions options)
        {
            _next = next;
            _options = options;
            if (_options.OnIncomingRequest == null)
            {
                _options.OnIncomingRequest = (ctx) => { ctx.Response.WriteAsync("OnIncomingRequest"); };
            }

        }

        private void Process(IDictionary<string, object> environment)
        {

        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var ctx = new OwinContext(environment);
            await ctx.Response.WriteAsync("OnIncomingRequest");
            // _options.OnIncomingRequest(ctx);
           // Process(environment);

            await _next(environment);
            //await ctx.Response.WriteAsync("xxxxxxxxxxxx");

        }

    }
}

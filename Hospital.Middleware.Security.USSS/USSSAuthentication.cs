using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

namespace Hospital.Middleware.Security
{
    public class USSSAuthentication
    {
        private AppFunc _next;
        private USSSAuthenticationOptions _options;

        public USSSAuthentication(Func<IDictionary<string, object>, Task> next, USSSAuthenticationOptions options)
        {
            _next = next;
            _options = options;
            if (_options.OnIncomingRequest == null)
            {
                _options.OnIncomingRequest = (ctx) => { ctx.Response.WriteAsync("OnIncomingRequest"); };
            }

        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var ctx = new OwinContext(environment);

            _options.OnIncomingRequest(ctx);
            await _next(environment);
            await ctx.Response.WriteAsync("xxxxxxxxxxxx");

        }

    }
}

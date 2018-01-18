using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

namespace WebApplicationIndividualAccount.Security
{
    public class USSS
    {
        private AppFunc _next;
        private USSSOptions _options;

        public   USSS(Func<IDictionary<string, object>, Task> next, USSSOptions options)
        {
            _next = next;
            _options = options;
            if (_options.OnIncomingRequest==null)
            {
                _options.OnIncomingRequest = (ctx) => {   ctx.Response.WriteAsync("OnIncomingRequest"); };
            }

        }

        public async Task  Invoke(IDictionary<string, object> environment)
        {
            var ctx = new OwinContext(environment);

            _options.OnIncomingRequest(ctx);
            await _next(environment);
            await ctx.Response.WriteAsync("xxxxxxxxxxxx");
            
        }

    }
}
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital.Middleware.Security
{
    public class USSSAuthenticationOptions
    {
        public Action<IOwinContext> OnIncomingRequest { get; set; }
        public Action<IOwinContext> OnOutGoingRequest { get; set; }

    }

    public class USSSAuthenticationProvider
    {
        public Action<IOwinContext> OnIncomingRequest { get; set; }
        public Action<IOwinContext> OnOutGoingRequest { get; set; }

    }


}
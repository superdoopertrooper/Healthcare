using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationOwin.Security
{
    public class USSSOptions
    {
        public Action<IOwinContext> OnIncomingRequest { get; set; }
        public Action<IOwinContext> OnOutGoingRequest { get; set; }

    }
}
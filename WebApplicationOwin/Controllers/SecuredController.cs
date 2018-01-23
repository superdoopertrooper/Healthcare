using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationOwin.Controllers
{
    public class SecuredController : Controller
    {
        
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebApplicationOwin.Models;

namespace WebApplicationOwin.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(ExternalLoginListViewModel vm)
        {
            // Request a redirect to the external login provider
            //  return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
            var identity = new ClaimsIdentity("ApplicationCookie");
            identity.AddClaims(new List<Claim>()
                        {
                        new Claim(ClaimTypes.NameIdentifier, "remzyId"),
                        new Claim(ClaimTypes.Name, "remzy"),
                        new Claim(ClaimTypes.Email, "remzymoen@usss")
                        });

            HttpContext.GetOwinContext().Authentication.SignIn(identity);
            return Redirect(vm.ReturnUrl);
        }

        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return Redirect("/");
        }
    }
}
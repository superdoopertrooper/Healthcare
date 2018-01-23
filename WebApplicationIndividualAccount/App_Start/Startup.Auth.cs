﻿using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;
using Owin;
using WebApplicationIndividualAccount.Facebook;
using WebApplicationIndividualAccount.Models;

namespace WebApplicationIndividualAccount
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            //  app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            //  app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //     clientId: "57ce5af9-196a-40e1-86c8-5a68d434e5c3",
            //     clientSecret: "tztFD80~_rpjuYYYMF503$~");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication( 
            //   appId: "432322080518585",
            //   appSecret: "ff42b9081a4a8d52581fdc1843be8026");

            var facebookOptions = new FacebookAuthenticationOptions()
            {
                AppId = "432322080518585",
                AppSecret = "ff42b9081a4a8d52581fdc1843be8026",
                BackchannelHttpHandler = new FacebookBackChannelHandler(),
                UserInformationEndpoint = "https://graph.facebook.com/v2.4/me?fields=id,email"
            };

            facebookOptions.Scope.Add("email");

            app.UseFacebookAuthentication(facebookOptions);

            app.UseSamlAuthentication(new Owin.Security.Saml.SamlAuthenticationOptions()
            { 
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active, 
                 LoginPath="http://www.loginpath.com",
                  LogoutPath= "http://www.logoutpath.com",
                    Configuration =new SAML2.Config.Saml2Configuration()
                    {
                        Metadata = new SAML2.Config.Metadata()
                    {
                         
                    },
                         
                    }, Notifications =new Owin.Security.Saml.SamlAuthenticationNotifications()
                    {
                         
                    },
                      Description= new Microsoft.Owin.Security.AuthenticationDescription()
                      { 
                           AuthenticationType="SAML",
                            Caption= "saml"                            
                      }
            });

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Vnsf.WebHost.Providers;

namespace Vnsf.WebHost
{
    public partial class Startup
    {
        static Startup()
        {
        }

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Cheetah/UserAccount/Login")
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "0000000044101607",
            //    clientSecret: "CHfsN46nyXCEWAhB8LkJc3fLPSfg7uJh");

            //app.UseTwitterAuthentication(
            //    consumerKey: "76a8dqXzLrKEaAYP9AmdfnD5l",
            //    consumerSecret: "gnHfZQIXjcAIqDf5AxC3gslD3dIgjHeuEpA1RBgAvcSfQ4uRd3");

            app.UseFacebookAuthentication(
                appId: "600065163358974",
                appSecret: "71438dd894d191bd161a69720fbf10e1");

            app.UseGoogleAuthentication(clientId: "212507878610-9jd5t3vggkc8soi27ou449foi2cropau.apps.googleusercontent.com", clientSecret: "UiJxJI83jTt1XWpYZvxDxd0I");
        }
    }
}

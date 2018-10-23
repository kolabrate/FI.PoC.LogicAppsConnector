using Microsoft.Owin;
using Microsoft.Owin.Security;
using Owin;


[assembly: OwinStartup(typeof(FI.PoC.CustomerPortal.Startup))]
namespace FI.PoC.CustomerPortal
{
    public class Startup
    {
        string Authority = "https://login.microsoftonline.com/common/";
        public void Configuration(IAppBuilder app)
        {

            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

        }
    }
}

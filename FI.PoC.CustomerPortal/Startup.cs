using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.Owin.Security.Cookies;
using System.Configuration;
using System.IdentityModel;
using System.IdentityModel.Claims;
using System.IdentityModel.Tokens;
using System.Threading.Tasks;
using Owin;

[assembly: OwinStartup(typeof(FI.PoC.CustomerPortal.Startup))]
namespace FI.PoC.CustomerPortal
{
    public class Startup
    {
        private readonly string Authority = "https://login.microsoftonline.com/common/";
        public void Configuration(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType (CookieAuthenticationDefaults.AuthenticationType);
            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions {
                ClientId = ConfigurationManager.AppSettings[""],
                Authority = Authority,
                ClientSecret = ConfigurationManager.AppSettings[""],
                Notifications = new OpenIdConnectAuthenticationNotifications()
                {
                    RedirectToIdentityProvider = (context) =>
                    {
                        // This ensures that the address used for sign in and sign out is picked up dynamically from the request
                        // this allows you to deploy your app (to Azure Web Sites, for example)without having to change settings
                        // Remember that the base URL of the address used here must be provisioned in Azure AD beforehand.
                        string appBaseUrl = context.Request.Scheme + "://" + context.Request.Host + context.Request.PathBase;
                        context.ProtocolMessage.RedirectUri = appBaseUrl;
                        context.ProtocolMessage.PostLogoutRedirectUri = appBaseUrl;
                        return Task.FromResult(0);
                    },
                    // we use this notification for injecting our custom logic
                    SecurityTokenValidated = (context) =>
                    {
                        // retriever caller data from the incoming principal
                        string issuer = context.AuthenticationTicket.Identity.FindFirst("iss").Value;
                        string UPN = context.AuthenticationTicket.Identity.FindFirst(ClaimTypes.Name).Value;
                        string tenantID = context.AuthenticationTicket.Identity.FindFirst("http://schemas.microsoft.com/identity/claims/tenantid").Value;
                        // Code - Anand Maran - Use entity framework
                        // the caller was neither from a trusted issuer or a registered user - throw to block the authentication flow
                        throw new SecurityTokenValidationException();
                        return Task.FromResult(0);
                    },
                    AuthenticationFailed = (context) =>
                    {
                        context.OwinContext.Response.Redirect("/Home/Error?message=" + context.Exception.Message);
                        context.HandleResponse(); // Suppress the exception
                        return Task.FromResult(0);
                    }
                }



                });

        }
    }
}

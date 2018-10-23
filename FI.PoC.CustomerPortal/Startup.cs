using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(FI.PoC.CustomerPortal.Startup))]
namespace FI.PoC.CustomerPortal
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}

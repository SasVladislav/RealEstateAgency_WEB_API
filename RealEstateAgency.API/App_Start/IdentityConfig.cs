using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Ninject;
using Owin;
using RealEstateAgency.API.Infrastructure;

[assembly: OwinStartup(typeof(RealEstateAgency.API.IdentityConfig))]

namespace RealEstateAgency.API
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {     
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
            }
         

    }
    

}
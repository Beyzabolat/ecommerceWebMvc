using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(ecommerceWebMvc.IdentityConfig_))]

namespace ecommerceWebMvc
{
    public class IdentityConfig_
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"), // Doğru Login sayfası yolunu burada belirtin

                // Diğer ayarlarınızı ekleyebilirsiniz.
            });

            // İlerideki diğer yapılandırmaları buraya ekleyebilirsiniz.
        }
    }
}
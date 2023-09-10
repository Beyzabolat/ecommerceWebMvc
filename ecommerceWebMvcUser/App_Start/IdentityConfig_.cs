﻿using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(ecommerceWebMvcUser.IdentityConfig_))]

namespace ecommerceWebMvcUser
{
    public class IdentityConfig_
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType= DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath= new PathString("/Account/Login")



            });
            
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}

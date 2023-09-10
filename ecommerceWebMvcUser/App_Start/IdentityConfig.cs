//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace ecommerceWebMvcUser.App_Start
//{
//    public class IdentityConfig
//    {
//    }
//}

//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using Microsoft.AspNet.Identity.Owin;
//using Microsoft.Owin;
//using Owin;
//using ecommerceWebMvcUser.Models; // Projede kullanılan model namespace'i
//using ecommerceWebMvcUser.Models;

//namespace YourProjectNamespace
//{
//    public class ApplicationUserManager : UserManager<ecommerceWebMvcUser.Models.ApplicationUser>
//    {
//        public ApplicationUserManager(IUserStore<ecommerceWebMvcUser.Models.ApplicationUser> store)
//            : base(store)
//        {
//        }

//        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
//        {
//            var manager = new ApplicationUserManager(new UserStore<ecommerceWebMvcUser.Models.ApplicationUser>(context.Get<ApplicationDbContext>()));
//            // Diğer ayarları ekleyin

//            return manager;
//        }
//    }

//    // Diğer sınıfları ekleyin: ApplicationSignInManager, ApplicationRoleManager, vs.
//}

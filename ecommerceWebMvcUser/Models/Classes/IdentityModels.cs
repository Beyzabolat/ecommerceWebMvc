//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace ecommerceWebMvcUser.Models.Classes
//{
//    public class IdentityModels
//    {
//    }
//}

//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using System.Security.Claims;
//using System.Threading.Tasks;

//namespace ecommerceWebMvcUser.Models.Classes
//{
//    public class ApplicationUser : IdentityUser
//    {
//        // Kullanıcıya özgü özellikleri buraya ekleyebilirsiniz.

//        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
//        {
//            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
//            // Kullanıcıya özel talepleri buraya ekleyebilirsiniz.
//            return userIdentity;
//        }
//    }

//    // Bu sınıfı projenizin gereksinimlerine göre özelleştirebilirsiniz.

//    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
//    {
//        public ApplicationDbContext()
//            : base("DefaultConnection", throwIfV1Schema: false)
//        {
//        }

//        public static ApplicationDbContext Create()
//        {
//            return new ApplicationDbContext();
//        }
//    }
//}

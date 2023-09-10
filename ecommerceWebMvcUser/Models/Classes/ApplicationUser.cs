using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;


namespace ecommerceWebMvcUser.Models.Classes
{
    public class ApplicationUser : IdentityUser
    {
        public string İsim { get; set; }
    }
}
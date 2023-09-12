using ecommerceWebMvcUser.Models;
using ecommerceWebMvcUser.Models.Classes;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecommerceWebMvcUser.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        private UserManager<ApplicationUser> userManager;
        public AdminController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            userManager = new UserManager<ApplicationUser>(userStore);
        }
        public ActionResult Index()
        {
            return View(userManager.Users);
        }
      
        
    }
}
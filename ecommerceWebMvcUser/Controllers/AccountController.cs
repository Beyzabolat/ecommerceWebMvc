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
    public class AccountController : Controller
    {
        // GET: Account
        private UserManager<ApplicationUser> userManager;
        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            userManager = new UserManager<ApplicationUser>(userStore);
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        { if(ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user.UserName = model.KullaniciAdi;
                user.Email = model.mail;

                var result = userManager.Create(user, model.Sifre);
                if(result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach( var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

            }
            return View(model);
        }
    }
}
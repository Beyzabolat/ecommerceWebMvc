﻿using ecommerceWebMvcUser.Models;
using ecommerceWebMvcUser.Models.Classes;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
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
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {


                var user = userManager.Find(model.KullaniciAdi, model.Sifre);
                if (user == null)
                {
                    ModelState.AddModelError("", "Yanlış kullanıcı adı veya şifre");
                }
                else
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identity = userManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties()
                    {
                        IsPersistent = true
                    };
                    authManager.SignOut();
                    authManager.SignIn(authProperties, identity);

                    return Redirect(returnUrl ?? "/");



                }

            }

            ViewBag.returnUrl = returnUrl;
            return View(model);
        }
        public ActionResult LogOut()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(Register model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user.UserName = model.KullaniciAdi;
                user.Email = model.mail;

                var result = userManager.Create(user, model.Sifre);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

            }
            return View(model);
        }
    }
}
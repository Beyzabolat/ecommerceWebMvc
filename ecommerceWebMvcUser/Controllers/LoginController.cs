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
    //public class LoginController : Controller
    //{
    //    // GET: Account
    //    private UserManager<ApplicationUser> userManager;

    //    public LoginController(SignInManager<AppUser> signInManager)
    //    {
    //        _signInManager = signInManager;
    //    }

    //    [HttpGet]
    //    public IActionResult Index()
    //    {
    //        return View();
    //    }
    //    [HttpPost]
    //    public async Task<IActionResult> Index(LoginUserDto loginUserDto)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            var result = await _signInManager.PasswordSignInAsync(loginUserDto.Username,
    //                loginUserDto.Password, false, false);
    //            if (result.Succeeded)
    //            {
    //                return RedirectToAction("Index", "Staff");
    //            }
    //            else
    //            {
    //                return View();
    //            }
    //        }
    //        return View();
    //    }
    //}
}
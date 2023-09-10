using ecommerceWebMvcUser.dtos.registerdto;
using ecommerceWebMvcUser.Models.Classes;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ecommerceWebMvcUser.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Account
        private UserManager<ApplicationUser> _userManager;

        public RegisterController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Index(CreateNewUserDto createNewUserDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var appUser = new ApplicationUser()
            {
                İsim = createNewUserDto.Name,
                Email = createNewUserDto.Mail,
                UserName = createNewUserDto.UserName,
            };
            var result = await _userManager.CreateAsync(appUser, createNewUserDto.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
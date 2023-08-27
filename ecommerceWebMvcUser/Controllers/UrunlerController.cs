using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ecommerceWebMvcUser.Models.Classes;

namespace ecommerceWebMvcUser.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler
        Context q = new Context();
        public ActionResult Index()
        {

            var urunler =q.Urunlers.ToList();
            return View(urunler);
           
        }
    }
}
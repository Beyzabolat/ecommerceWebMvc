using ecommerceWebMvc.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecommerceWebMvc.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        Context q = new Context();
        public ActionResult Index()
        {
            var urunler = q.Urunlers.Where(x => x.Durum == true && x.Kategoriid == 1).ToList();
            var degeer4 = q.Urunlers.Sum(x => x.Stok).ToString();
            ViewBag.d4 = degeer4;
            return View(urunler);
           
        }
       


    }
}

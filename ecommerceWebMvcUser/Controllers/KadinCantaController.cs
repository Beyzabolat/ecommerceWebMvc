using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ecommerceWebMvcUser.Models.Classes;

namespace ecommerceWebMvcUser.Controllers
{
    public class KadinCantaController : Controller
    {
        private Context db = new Context();


        public ActionResult Index()
        {
            var urunler = db.Urunlers.Where(x => x.Durum == true && x.Kategoriid == 8).ToList();
            int urunSayisi = urunler.Count;
            ViewBag.UrunSayisi = urunSayisi;
            return View(urunler);

        }
    }
}


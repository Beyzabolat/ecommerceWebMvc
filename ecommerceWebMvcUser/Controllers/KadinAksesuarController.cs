using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ecommerceWebMvcUser.Models.Classes;

namespace ecommerceWebMvcUser.Controllers
{
    public class KadinAksesuarController : Controller
    {
        // GET: KadinAksesuar
        private Context db = new Context();
        public ActionResult Index()
        {
            var urunler = db.Urunlers.Where(x => x.Durum == true && x.Kategoriid == 5).ToList();
            int urunSayisi = urunler.Count;
            ViewBag.UrunSayisi = urunSayisi;
            return View(urunler);
            //var urunler = _context.Urunlers.Where(x => x.Durum == true).ToList();
            //int urunSayisi = urunler.Count;

            //ViewBag.UrunSayisi = urunSayisi;




            //var kategori = _context.Urunlers.Where(k => k.Kategoriid == 5).ToList();

            //return View(kategori);

        }
    }
}
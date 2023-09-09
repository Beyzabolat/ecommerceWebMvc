using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ecommerceWebMvcUser.Models.Classes;

namespace ecommerceWebMvcUser.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private Context q = new Context();
        public ActionResult UrunSepeteEkle(int urunId)
        {
            // Ürün sepete eklenecek işlemleri burada yapabilirsiniz
            // Örneğin, sepete ürünü eklemek ve ardından sepet sayfasına yönlendirmek için aşağıdaki gibi bir işlem yapabilirsiniz:

            // Sepete ürünü ekleme işlemi burada gerçekleştirilir

            return RedirectToAction("Sepet"); // Sepet sayfasına yönlendirme
        }
        public ActionResult Index()
        {
            var urunler = q.Urunlers.Where(x => x.Durum == true).ToList();
            int urunSayisi = urunler.Count;

            ViewBag.UrunSayisi = urunSayisi;

            return View(urunler);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ecommerceWebMvcUser.Models.Classes;
using System.IO;


namespace ecommerceWebMvcUser.Controllers
{
    public class UrunlerController : Controller
    {
        private Context q = new Context();

        public ActionResult Index()
        {
           
                var urunler = q.Urunlers.Where(x => x.Durum == true).ToList();
                int urunSayisi = urunler.Count;

                ViewBag.UrunSayisi = urunSayisi;

                return View(urunler);
            

        }
        public ActionResult UrunDetay(int urunId)
        {
            // id parametresini kullanarak ürün detaylarını çekin
            var urunDetay = q.Urunlers.FirstOrDefault(u => u.UrunID == urunId);

            // Eğer urunDetay null ise, uygun bir hata işleme mekanizması kullanabilirsiniz.

            return View(urunDetay);
        }
       
        

        
    }

}

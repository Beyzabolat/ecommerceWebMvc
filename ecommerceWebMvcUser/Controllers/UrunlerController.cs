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
        //private readonly FavoriService _favoriService; // Favori işlemlerini yönetecek servis sınıfı

        public ActionResult Index()
        {
            //_favoriService = new FavoriService();
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
        //public ActionResult FavoriyeEkle(int urunId)
        //{
        //    if (User.Identity.IsAuthenticated) // Kullanıcı giriş yapmış mı kontrolü
        //    {
        //        _favoriService.FavoriyeEkle(User.Identity.Name, urunId); // Kullanıcının favori ürünlerine ekle
        //        return RedirectToAction("Index", "Urun"); // Ürünlerin listesine yönlendir
        //    }
        //    else
        //    {
        //        // Kullanıcı giriş yapmamışsa, giriş yapma sayfasına yönlendir
        //        return RedirectToAction("Login", "Account");
        //    }
        //}
        //public ActionResult FavoridenKaldir(int urunId)
        //{
        //    if (User.Identity.IsAuthenticated) // Kullanıcı giriş yapmış mı kontrolü
        //    {
        //        _favoriService.FavoridenKaldir(User.Identity.Name, urunId); // Kullanıcının favori ürünlerinden kaldır
        //        return RedirectToAction("Favorilerim", "Urun"); // Favori ürünlerin listesine yönlendir
        //    }
        //    else
        //    {
        //        // Kullanıcı giriş yapmamışsa, giriş yapma sayfasına yönlendir
        //        return RedirectToAction("Login", "Account");
        //    }
        //}



    }

}

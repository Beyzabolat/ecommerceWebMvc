﻿////using ecommerceWebMvcUser.Models.Classes;
////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Web.Mvc;
////using ecommerceWebMvcUser.Models;
////namespace ecommerceWebMvcUser.Controllers
////{

////    public class SepetController : Controller
////    {
////        Context q = new Context();
////        // Sepet görüntülemek için eylem
////        public ActionResult Index()
////        {
////            // Sepeti al
////            Sepet sepet = Session["Sepet"] as Sepet;

////            // Eğer sepet boşsa, yeni bir sepet oluştur
////            if (sepet == null)
////            {
////                sepet = new Sepet();
////                Session["Sepet"] = sepet;
////            }

////            // Sepet öğelerini görüntüleme sayfasına gönder
////            return View(sepet.SepetOgeleriniGetir());
////        }
////        [HttpPost]
////        public ActionResult UrunSepeteEkle(int urunId, int adet)
////        {
////            // Sepeti al
////            Sepet sepet = Session["Sepet"] as Sepet;

////            // Eğer sepet boşsa, yeni bir sepet oluştur
////            if (sepet == null)
////            {
////                sepet = new Sepet();
////                Session["Sepet"] = sepet;
////            }

////            // Ürünü veritabanından alın (örneğin Entity Framework kullanarak)
////            Urunler urun = GetUrunById(urunId);

////            // Ürünü sepete ekle
////            sepet.UrunEkle(urun, adet);

////            // Sepetin güncellenmiş halini göstermek için sepet sayfasına yönlendir
////            return RedirectToAction("Index");
////        }


////        private Urunler GetUrunById(int urunId)
////        {
////            using (var context = new Context()) // YourDbContext, projenizdeki DbContext sınıfının adı olmalıdır.
////            {
////                var urun = context.Urunlers.FirstOrDefault(u => u.UrunID == urunId);
////                return urun;
////            }
////        }
////        [HttpPost]
////        public ActionResult Boşalt()
////        {
////            // Sepeti boşaltma kodunu burada yazın
////            // Örneğin, sepeti boş bir liste ile değiştirebilirsiniz:
////            Session["Sepet"] = new List<SepetOgesi>();

////            // Kullanıcıyı sepet sayfasına yönlendirebilirsiniz veya başka bir işlem yapabilirsiniz.
////            return RedirectToAction("Index"); // Bu, "Index" eylemine yönlendirir.
////        }



////    }

////}
//using ecommerceWebMvcUser.Models.Classes;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web.Mvc;

//namespace ecommerceWebMvcUser.Controllers
//{
//    public class SepetController : Controller
//    {
//        // Sepet görüntülemek için eylem
//        public ActionResult Index()
//        {
//            // Sepeti al
//            Sepet sepet = Session["Sepet"] as Sepet;

//            // Eğer sepet boşsa, yeni bir sepet oluştur
//            if (sepet == null)
//            {
//                sepet = new Sepet();
//                Session["Sepet"] = sepet;
//            }

//            // Sepet öğelerini görüntüleme sayfasına gönder
//            return View(sepet.SepetOgeleriniGetir());
//        }

//        [HttpPost]
//        public ActionResult UrunSepeteEkle(int urunId, int adet)
//        {
//            // Sepeti al
//            Sepet sepet = Session["Sepet"] as Sepet;

//            // Eğer sepet boşsa, yeni bir sepet oluştur
//            if (sepet == null)
//            {
//                sepet = new Sepet();
//                Session["Sepet"] = sepet;
//            }

//            // Ürünü veritabanından alın (örneğin Entity Framework kullanarak)
//            Urunler urun = GetUrunById(urunId);

//            // Ürünü sepete ekle
//            sepet.UrunEkle(urun, adet);

//            // Sepetin güncellenmiş halini göstermek için sepet sayfasına yönlendir
//            return RedirectToAction("Index");
//        }
//        public void UrunuSil(int urunId)
//        {
//            SepetOgesi silinecekUrun = SepetOgeleri.FirstOrDefault(u => u.UrunID == urunId);

//            if (silinecekUrun != null)
//            {
//                SepetOgeleri.Remove(silinecekUrun);
//            }
//        }

//        [HttpPost]
//        public ActionResult UrunSepettenSil(int urunId)
//        {
//            // Sepeti al
//            Sepet sepet = Session["Sepet"] as Sepet;

//            // Eğer sepet boşsa, yeni bir sepet oluştur
//            if (sepet == null)
//            {
//                sepet = new Sepet();
//                Session["Sepet"] = sepet;
//            }

//            // Ürünü sepetten sil
//            sepet.UrunuSil(urunId);

//            // Sepetin güncellenmiş halini göstermek için sepet sayfasına yönlendir
//            return RedirectToAction("Index");
//        }

//        private Urunler GetUrunById(int urunId)
//        {
//            using (var context = new Context()) // YourDbContext, projenizdeki DbContext sınıfının adı olmalıdır.
//            {
//                var urun = context.Urunlers.FirstOrDefault(u => u.UrunID == urunId);
//                return urun;
//            }
//        }
//    }
//}
using ecommerceWebMvcUser.Models.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ecommerceWebMvcUser.Controllers
{
    public class SepetController : Controller
    {
        // Sepet görüntülemek için eylem
        public ActionResult Index()
        {
            // Sepeti al
            Sepet sepet = Session["Sepet"] as Sepet;

            // Eğer sepet boşsa, yeni bir sepet oluştur
            if (sepet == null)
            {
                sepet = new Sepet();
                Session["Sepet"] = sepet;
            }

            // Sepet öğelerini görüntüleme sayfasına gönder
            return View(sepet.SepetOgeleriniGetir());
        }

        [HttpPost]
        public ActionResult UrunSepeteEkle(int urunId, int adet)
        {
            // Sepeti al
            Sepet sepet = Session["Sepet"] as Sepet;

            // Eğer sepet boşsa, yeni bir sepet oluştur
            if (sepet == null)
            {
                sepet = new Sepet();
                Session["Sepet"] = sepet;
            }

            // Ürünü veritabanından alın (örneğin Entity Framework kullanarak)
            Urunler urun = GetUrunById(urunId);

            // Ürünü sepete ekle
            sepet.UrunEkle(urun, adet);

            // Sepetin güncellenmiş halini göstermek için sepet sayfasına yönlendir
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UrunSepettenSil(int urunId)
        {
            // Sepeti al
            Sepet sepet = Session["Sepet"] as Sepet;

            // Eğer sepet boşsa, yeni bir sepet oluştur
            if (sepet == null)
            {
                sepet = new Sepet();
                Session["Sepet"] = sepet;
            }

            // Ürünü sepetten sil
            sepet.UrunuSil(urunId);

            // Sepetin güncellenmiş halini göstermek için sepet sayfasına yönlendir
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult UrunuSil(int urunId)
        {
            Sepet sepet = Session["Sepet"] as Sepet;
            // Sepetten ürünü silmek için Sepet sınıfını kullanabilirsiniz
            sepet.UrunuSil(urunId);

            // Sepet sayfasına yönlendir
            return RedirectToAction("Index");
        }

        private Urunler GetUrunById(int urunId)
        {
            using (var context = new Context()) // YourDbContext, projenizdeki DbContext sınıfının adı olmalıdır.
            {
                var urun = context.Urunlers.FirstOrDefault(u => u.UrunID == urunId);
                return urun;
            }
        }
    }
}


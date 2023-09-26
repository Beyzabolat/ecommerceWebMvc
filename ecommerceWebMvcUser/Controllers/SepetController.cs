using ecommerceWebMvcUser.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web;

namespace ecommerceWebMvcUser.Controllers
{
    [Authorize]
    public class SepetController : Controller
    {
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
           
            decimal toplamsepet = sepet.ToplamSepet();
            int toplamAdet = sepet.ToplamAdet();
            decimal toplamTutar = sepet.ToplamTutar();
            ViewBag.ToplamAdet = toplamAdet;
            ViewBag.ToplamTutar = toplamTutar;
            ViewBag.ToplamSepet = toplamsepet;
            return View(sepet.SepetOgeleriniGetir());
        }
        public ActionResult SiparisOnay()
        {
            Sepet sepet = Session["Sepet"] as Sepet;
            //decimal kargoUcreti = 50.00M; // Kargo ücreti


            return View(new SiparisViewModel());

            //decimal toplamOdenecek = sepet.ToplamTutar() + kargoUcreti;
            //ViewBag.ToplamOdenecek = sepet.ToplamTutar() + kargoUcreti;

            //decimal toplamsepet = sepet.ToplamSepet();
            //int toplamAdet = sepet.ToplamAdet();
            //decimal toplamTutar = sepet.ToplamTutar();
            //ViewBag.ToplamAdet = toplamAdet;
            //ViewBag.ToplamTutar = toplamTutar;
            //ViewBag.ToplamSepet = toplamsepet;

            ////ViewBag.ToplamOdenecek = toplamOdenecek; // Yeni değişkeni ViewBag ile görünüme aktarın
            //// Sepet ögelerini ve kullanıcı bilgilerini SiparisOreturn View("SiparisDetay", siparisViewModel);
            //return View(sepet.SepetOgeleriniGetir());
        }
        [HttpPost]
        public ActionResult SiparisOnay(SiparisViewModel siparisViewModel)
        {
            // Sepeti al
            Sepet sepet = Session["Sepet"] as Sepet;

            // Eğer sepet boşsa, yeni bir sepet oluştur
            if (sepet == null)
            {
                ModelState.AddModelError("Error", "Sepetinizde ürün bulunmamaktadır.");
            }

            if (ModelState.IsValid)
            {
                // TempData kullanarak sipariş bilgilerini geçici bir saklama alanına yerleştirin
                TempData["SiparisViewModel"] = siparisViewModel;

                sepet.SepetiBosalt();
                return RedirectToAction("SiparisDetay");
            }
            else
            {
                return View(siparisViewModel);
            }
        }

        //[HttpPost]
        //public ActionResult SiparisOnay(SepetOgesi sepetOgesi)
        //{
        //    // Sepeti al
        //    Sepet sepet = Session["Sepet"] as Sepet;

        //    // Eğer sepet boşsa, yeni bir sepet oluştur
        //    if (sepet == null)
        //    {
        //        ModelState.AddModelError("Error","Sepetinizde ürün bulunmamaktadır.");
        //    }
        //    if(ModelState.IsValid)
        //    {
        //        sepet.SepetiBosalt();
        //        return View("/Siparis/SiparisDetay");
        //    }
        //    else
        //    {
        //        return View(sepetOgesi);
        //    }

        //}

        [HttpPost]
        public ActionResult UrunSepeteEkle(int urunId, int adet)
        {
            // Sepeti al
            if (!User.Identity.IsAuthenticated)
            {
                // Kullanıcı oturum açmamışsa, favorilere eklemeye izin vermeyin.
                return RedirectToAction("Login", "Account"); // Giriş sayfasına yönlendirme yapabilirsiniz.
            }
            Sepet sepet = Session["Sepet"] as Sepet;

            // Eğer sepet boşsa, yeni bir sepet oluştur
            if (sepet == null)
            {
                sepet = new Sepet();
                Session["Sepet"] = sepet;
            }

            // Ürünü veritabanından alın (örneğin Entity Framework kullanarak)
            Urunler urun = GetUrunById(urunId);

            // Adet sayısını JavaScript kodundan alın
            int urunAdeti = adet;

            // Ürünü sepete ekle
            sepet.UrunEkle(urun, urunAdeti);

            // Sepetin güncellenmiş halini göstermek için sepet sayfasına yönlendir
            return RedirectToAction("Index");
        }
        public ActionResult UrunFavorilereEkle(int urunId, int adet)
        {

            // Sepeti al
            if (!User.Identity.IsAuthenticated)
            {
                // Kullanıcı oturum açmamışsa, favorilere eklemeye izin vermeyin.
                return RedirectToAction("Login", "Account"); // Giriş sayfasına yönlendirme yapabilirsiniz.
            }
            Sepet sepet = Session["Sepet"] as Sepet;

            // Eğer sepet boşsa, yeni bir sepet oluştur
            if (sepet == null)
            {
                sepet = new Sepet();
                Session["Sepet"] = sepet;
            }

            // Ürünü veritabanından alın (örneğin Entity Framework kullanarak)
            Urunler urun = GetUrunById(urunId);

            // Adet sayısını JavaScript kodundan alın
            int urunAdeti = adet;

            // Ürünü sepete ekle
            sepet.UrunEkle(urun, urunAdeti);


            // Sepetin güncellenmiş halini göstermek için sepet sayfasına yönlendir
            return RedirectToAction("AddToWishlist");
        }
        public ActionResult AddToWishlist()
        {
            Sepet sepet = Session["Sepet"] as Sepet;

            // Eğer sepet boşsa, yeni bir sepet oluştur
            if (sepet == null)
            {
                sepet = new Sepet();
                Session["Sepet"] = sepet;
            }
            int toplamAdet = sepet.ToplamAdet();
            
            ViewBag.ToplamAdet = toplamAdet;
            
            return View(sepet.SepetOgeleriniGetir());
          
        }
            public ActionResult SepetiGoruntule()
        {
            List<SepetOgesi> sepet = Session["Sepet"] as List<SepetOgesi>;

            // Toplam tutarı hesaplayın
            decimal toplamTutar = 0;
            if (sepet != null)
            {
                foreach (var sepetItem in sepet)
                {
                    toplamTutar += sepetItem.ToplamFiyat;
                }
            }

            // Hesaplanan toplam tutarı ViewBag veya Model üzerinden View'e iletebilirsiniz
            ViewBag.ToplamTutar = toplamTutar;

            return View();
        }


        public ActionResult Bosalt()
        {
            Session["Sepet"] = new List<SepetOgesi>();
            return RedirectToAction("Index");
        }
        public ActionResult BosaltFavori()
        {
            Session["Sepet"] = new List<SepetOgesi>();
            return RedirectToAction("AddToWishlist");
        }
        public ActionResult DevamEt()
        {
            // Önceki sayfanın URL'sini al
            string returnUrl = Request.UrlReferrer?.ToString();

            // Eğer önceki sayfanın URL'si null ise veya ana sayfaya yönlendirilmek isteniyorsa varsayılan URL'i ayarla
            if (string.IsNullOrEmpty(returnUrl))
            {
                returnUrl = Url.Action("Index", "Home"); // Varsayılan olarak ana sayfaya yönlendir
            }

            return Redirect(returnUrl);
        }

        public ActionResult UrunSil(int urunId)
        {
            try
            {
                // Sepeti al
                Sepet sepet = Session["Sepet"] as Sepet;

                // Eğer sepet boşsa veya ürün ID'si hatalıysa, Index sayfasına yönlendir
                if (sepet == null || urunId <= 0)
                {
                    return RedirectToAction("Index");
                }

                // Ürünü sepetten kaldır
                sepet.UrunuSil(urunId);

                // Ürünü başarıyla kaldırdıktan sonra, sepetin ana sayfasına yönlendir
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Hata ayıklama için hatayı göster
                Console.WriteLine(ex.Message);
                // Hata durumunda yapılacak işlemi burada belirleyebilirsiniz.
                return RedirectToAction("Index");
            }


        }


        public ActionResult UrunFavoriSil(int urunId)
        {
            try
            {
                // Sepeti al
                Sepet sepet = Session["Sepet"] as Sepet;

                // Eğer sepet boşsa veya ürün ID'si hatalıysa, Index sayfasına yönlendir
                if (sepet == null || urunId <= 0)
                {
                    return RedirectToAction("AddToWishlist");
                }

                // Ürünü sepetten kaldır
                sepet.UrunuSil(urunId);

                // Ürünü başarıyla kaldırdıktan sonra, sepetin ana sayfasına yönlendir
                return RedirectToAction("AddToWishlist");
            }
            catch (Exception ex)
            {
                // Hata ayıklama için hatayı göster
                Console.WriteLine(ex.Message);
                // Hata durumunda yapılacak işlemi burada belirleyebilirsiniz.
                return RedirectToAction("AddToWishlist");
            }


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

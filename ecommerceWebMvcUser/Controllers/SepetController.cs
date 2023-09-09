using ecommerceWebMvcUser.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ecommerceWebMvcUser.Controllers
{

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
            int toplamAdet = sepet.ToplamAdet();
            decimal toplamTutar = sepet.ToplamTutar();
            ViewBag.ToplamAdet = toplamAdet;
            ViewBag.ToplamTutar = toplamTutar;
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

            // Adet sayısını JavaScript kodundan alın
            int urunAdeti = adet;

            // Ürünü sepete ekle
            sepet.UrunEkle(urun, urunAdeti);

            // Sepetin güncellenmiş halini göstermek için sepet sayfasına yönlendir
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public ActionResult UrunSepeteEkle(int urunId)
        //{
        //    // Sepeti al
        //    Sepet sepet = Session["Sepet"] as Sepet;

        //    // Eğer sepet boşsa, yeni bir sepet oluştur
        //    if (sepet == null)
        //    {
        //        sepet = new Sepet();
        //        Session["Sepet"] = sepet;
        //    }

        //    // Ürünü veritabanından alın (örneğin Entity Framework kullanarak)
        //    Urunler urun = GetUrunById(urunId);
        //    int adet = Convert.ToInt32(Request.Form["quantity"]);
        //    // Ürünü sepete ekle
        //    sepet.UrunEkle(urun, adet);

        //    // Sepetin güncellenmiş halini göstermek için sepet sayfasına yönlendir
        //    return RedirectToAction("Index");
        //}
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

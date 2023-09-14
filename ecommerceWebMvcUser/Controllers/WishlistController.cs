using ecommerceWebMvcUser.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecommerceWebMvcUser.Controllers
{
    public class WishlistController : Controller
    {

        public ActionResult Index()
        {
            // Sepeti al
            Wishlist wishlist = Session["Wishlist"] as Wishlist;

            // Eğer sepet boşsa, yeni bir sepet oluştur
            if (wishlist == null)
            {
                wishlist = new Wishlist();
                Session["Wishlist"] = wishlist;
            }


            return View(wishlist.FavOgeleriniGetir());
        }
        [HttpPost]
        public ActionResult UrunSepeteEkle(int urunId, int adet)
        {
            // Sepeti al
            Wishlist wishlist = Session["Wishlist"] as Wishlist;

            // Eğer sepet boşsa, yeni bir sepet oluştur
            if (wishlist == null)
            {
                wishlist = new Wishlist();
                Session["Sepet"] = wishlist;
            }

            // Ürünü veritabanından alın (örneğin Entity Framework kullanarak)
            Urunler urun = GetUrunById(urunId);

            // Adet sayısını JavaScript kodundan alın
            int urunAdeti = adet;

            // Ürünü sepete ekle
            wishlist.UrunEkle(urun, urunAdeti);

            // Sepetin güncellenmiş halini göstermek için sepet sayfasına yönlendir
            return RedirectToAction("Index");
        }





        public ActionResult Bosalt()
        {
            Session["Wishlist"] = new List<FavOgesi>();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int urunId)
        {
            try
            {
                // Sepeti al
                Wishlist wishlist = Session["Wishlist"] as Wishlist;

                // Eğer sepet boşsa veya ürün ID'si hatalıysa, Index sayfasına yönlendir
                if (wishlist == null || urunId <= 0)
                {
                    return RedirectToAction("Index");
                }

                // Ürünü sepetten kaldır
                wishlist.UrunuSil(urunId);

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

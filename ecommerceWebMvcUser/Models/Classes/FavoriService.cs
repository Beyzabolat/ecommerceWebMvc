//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.Remoting.Contexts;
//using ecommerceWebMvcUser.Models; // Kullanacağınız veritabanı modeli ve DbContext sınıfına göre namespace'i ayarlayın.

//namespace ecommerceWebMvcUser.Services
//{
//    public class FavoriService
//    {
//        private readonly Context _context; // Veritabanı bağlantısı için DbContext sınıfı

//        public FavoriService()
//        {
//            _context = new Context(); // DbContext sınıfını başlatın
//        }

//        // Kullanıcının favori ürünlerini getir
//        public List<Urun> GetKullaniciFavorileri(string kullaniciAdi)
//        {
//            return _context.Favoriler
//                .Where(f => f.KullaniciAdi == kullaniciAdi)
//                .Select(f => f.Urun)
//                .ToList();
//        }

//        // Ürünü favorilere ekle
//        public void FavoriyeEkle(string kullaniciAdi, int urunId)
//        {
//            var favori = new Favori
//            {
//                KullaniciAdi = kullaniciAdi,
//                UrunId = urunId
//            };
//            _context.Favoriler.Add(favori);
//            _context.SaveChanges();
//        }

//        // Ürünü favorilerden kaldır
//        public void FavoridenKaldir(string kullaniciAdi, int urunId)
//        {
//            var favori = _context.Favoriler
//                .SingleOrDefault(f => f.KullaniciAdi == kullaniciAdi && f.UrunId == urunId);

//            if (favori != null)
//            {
//                _context.Favoriler.Remove(favori);
//                _context.SaveChanges();
//            }
//        }
//    }
//}

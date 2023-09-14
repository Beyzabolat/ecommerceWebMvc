//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Web;
//using ecommerceWebMvcUser.Models.Classes;

//namespace ecommerceWebMvcUser.Models.Classes
//{
//    namespace ecommerceWebMvcUser.Models.Classes
//    {


//        public class FavOgesi
//        {
//            //[Key]
//            public int favID { get; set; }
//            public int UrunID { get; set; }
//            public string UrunAdi { get; set; }
//            public decimal Fiyat { get; set; }
//            public int Adet { get; set; }
//            public string UrunGorseli { get; set; }
//            public string Kategori { get; set; }

//        }
//        public class FavDbContext : DbContext
//        {
//            public DbSet<FavOgesi> FavOgeleri { get; set; }

//        }
//        public class Wishlist
//        {
//            private List<FavOgesi> FavOgeleri = new List<FavOgesi>();

//            public void UrunEkle(Urunler urun, int adet)
//            {
//                // Sepet öğesini bellekteki koleksiyona ekle
//                FavOgesi favOgesi = new FavOgesi
//                {
//                    UrunGorseli = urun.UrunGorsel,
//                    UrunID = urun.UrunID,
//                    UrunAdi = urun.UrunAdi,
//                    Fiyat = urun.SatisFiyati,
//                    Kategori = urun.Kategori.KategoriAd,
//                    Adet = adet

//                };

//                FavOgeleri.Add(favOgesi);
//            }
//            public void SepetiBosalt()
//            {
//                FavOgeleri.Clear();

//            }
//            public void UrunuSil(int urunId)
//            {
//                // Sepet öğesini bellekteki koleksiyondan kaldır
//                FavOgesi silinecekUrun = FavOgeleri.FirstOrDefault(u => u.UrunID == urunId);

//                if (silinecekUrun != null)
//                {
//                    FavOgeleri.Remove(silinecekUrun);
//                }
//            }
//            public class FavViewModel
//            {
//                public List<FavOgesi> FavOgeleri { get; set; }

//            }



//            public List<FavOgesi> FavOgeleriniGetir()
//            {
//                return FavOgeleri;
//            }
//        }



//    }




//}


using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace ecommerceWebMvcUser.Models.Classes
{
    public class FavOgesi
    {
        [Key]
        public int SepetID { get; set; }
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public decimal Fiyat { get; set; }
        public int Adet { get; set; }
        public string UrunGorseli { get; set; }
        public string Kategori { get; set; }
        

    }

    public class FavDbContext : DbContext
    {
        public DbSet<FavOgesi> FavOgeleri { get; set; }

    }
    public class Wishlist
    {
        private List<FavOgesi> favOgeleri = new List<FavOgesi>();
        
        public int ToplamAdet()
        {
            return favOgeleri.Sum(item => item.Adet);
        }

       
        public void UrunEkle(Urunler urun, int adet)
        {
            // Sepet öğesini bellekteki koleksiyona ekle
            FavOgesi favOgesi = new FavOgesi
            {
                UrunGorseli = urun.UrunGorsel,
                UrunID = urun.UrunID,
                UrunAdi = urun.UrunAdi,
                Fiyat = urun.SatisFiyati,
                Adet = adet,
                Kategori=urun.Kategori.KategoriAd
            };

            favOgeleri.Add(favOgesi);
        }
        public void SepetiBosalt()
        {
            favOgeleri.Clear();

        }
        public void UrunuSil(int urunId)
        {
            // Sepet öğesini bellekteki koleksiyondan kaldır
            FavOgesi silinecekUrun = favOgeleri.FirstOrDefault(u => u.UrunID == urunId);

            if (silinecekUrun != null)
            {
                favOgeleri.Remove(silinecekUrun);
            }
        }
        public class SepetViewModel
        {
            public List<FavOgesi> FavOgeleri { get; set; }
            
        }

       
       
        public List<FavOgesi> FavOgeleriniGetir()
        {
            return favOgeleri;
        }
    }
}


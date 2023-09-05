//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;


//namespace ecommerceWebMvcUser.Models.Classes
//{
//    // Sepet öğesi sınıfı
//    public class SepetOgesi
//    {
//        public int UrunID { get; set; }
//        public string UrunAdi { get; set; }
//        public decimal Fiyat { get; set; }
//        public int Adet { get; set; }
//        public string UrunGorseli { get; set; }
//    }

//    // Sepet sınıfı
//    public class Sepet
//    {
//        private List<SepetOgesi> sepetOgeleri = new List<SepetOgesi>();

//        // Sepete ürün eklemek için metot
//        public void UrunEkle(Urunler urun, int adet)
//        {
//            // Sepet öğesi oluştur
//            SepetOgesi sepetOgesi = new SepetOgesi
//            {
//                UrunGorseli=urun.UrunGorsel,
//                UrunID = urun.UrunID,
//                UrunAdi = urun.UrunAdi,
//                Fiyat = urun.SatisFiyati,
//                Adet = adet
//            };

//            // Sepet öğesini sepete ekle
//            sepetOgeleri.Add(sepetOgesi);
//        }

//        // Sepet öğelerini getiren metot
//        public List<SepetOgesi> SepetOgeleriniGetir()
//        {
//            return sepetOgeleri;
//        }
//    }



////}
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;

//namespace ecommerceWebMvcUser.Models.Classes
//{
//    public class SepetOgesi
//    {
//        public int UrunID { get; set; }
//        public string UrunAdi { get; set; }
//        public decimal Fiyat { get; set; }
//        public int Adet { get; set; }
//        public string UrunGorseli { get; set; }
//    }

//    public class SepetDbContext : DbContext
//    {
//        public DbSet<SepetOgesi> SepetOgeleri { get; set; }
//    }

//    public class Sepet
//    {
//        private readonly SepetDbContext dbContext = new SepetDbContext();

//        public void UrunEkle(Urunler urun, int adet)
//        {
//            SepetOgesi sepetOgesi = new SepetOgesi
//            {
//                UrunGorseli = urun.UrunGorsel,
//                UrunID = urun.UrunID,
//                UrunAdi = urun.UrunAdi,
//                Fiyat = urun.SatisFiyati,
//                Adet = adet
//            };

//            dbContext.SepetOgeleri.Add(sepetOgesi);
//            dbContext.SaveChanges();
//        }

//        public List<SepetOgesi> SepetOgeleriniGetir()
//        {
//            return dbContext.SepetOgeleri.ToList();
//        }
//    }
//}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace ecommerceWebMvcUser.Models.Classes
{
    public class SepetOgesi
    {
        [Key]
        public int SepetID { get; set; }
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public decimal Fiyat { get; set; }
        public int Adet { get; set; }
        public string UrunGorseli { get; set; }
        //public string Rengi { get; set; }
        //public string Marka { get; set; }
    }

    public class SepetDbContext : DbContext
    {
        public DbSet<SepetOgesi> SepetOgeleri { get; set; }
    }

    public class Sepet
    {
        private readonly SepetDbContext dbContext = new SepetDbContext();

        public void UrunEkle(Urunler urun, int adet)
        {
            SepetOgesi sepetOgesi = new SepetOgesi
            {
                UrunGorseli = urun.UrunGorsel,
                UrunID = urun.UrunID,
                UrunAdi = urun.UrunAdi,
                Fiyat = urun.SatisFiyati,
                Adet = adet,
                //Rengi= urun.Renk,
                //Marka=urun.Marka,
            };

            dbContext.SepetOgeleri.Add(sepetOgesi);
            dbContext.SaveChanges();
        }

        public List<SepetOgesi> SepetOgeleriniGetir()
        {
            return dbContext.SepetOgeleri.ToList();
        }
    }
}

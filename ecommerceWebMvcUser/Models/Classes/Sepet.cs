﻿

////////}
//////using System.Collections.Generic;
//////using System.Data.Entity;
//////using System.Linq;

//////namespace ecommerceWebMvcUser.Models.Classes
//////{
//////    public class SepetOgesi
//////    {
//////        public int UrunID { get; set; }
//////        public string UrunAdi { get; set; }
//////        public decimal Fiyat { get; set; }
//////        public int Adet { get; set; }
//////        public string UrunGorseli { get; set; }
//////    }

//////    public class SepetDbContext : DbContext
//////    {
//////        public DbSet<SepetOgesi> SepetOgeleri { get; set; }
//////    }

//////    public class Sepet
//////    {
//////        private readonly SepetDbContext dbContext = new SepetDbContext();

//////        public void UrunEkle(Urunler urun, int adet)
//////        {
//////            SepetOgesi sepetOgesi = new SepetOgesi
//////            {
//////                UrunGorseli = urun.UrunGorsel,
//////                UrunID = urun.UrunID,
//////                UrunAdi = urun.UrunAdi,
//////                Fiyat = urun.SatisFiyati,
//////                Adet = adet
//////            };

//////            dbContext.SepetOgeleri.Add(sepetOgesi);
//////            dbContext.SaveChanges();
//////        }

//////        public List<SepetOgesi> SepetOgeleriniGetir()
//////        {
//////            return dbContext.SepetOgeleri.ToList();
//////        }
//////    }
//////}
////using System.Collections.Generic;
////using System.ComponentModel.DataAnnotations;
////using System.Data.Entity;
////using System.Linq;

////namespace ecommerceWebMvcUser.Models.Classes
////{
////    public class SepetOgesi
////    {
////        [Key]
////        public int SepetID { get; set; }
////        public int UrunID { get; set; }
////        public string UrunAdi { get; set; }
////        public decimal Fiyat { get; set; }
////        public int Adet { get; set; }
////        public string UrunGorseli { get; set; }
////        //public string Rengi { get; set; }
////        //public string Marka { get; set; }
////    }

////    public class SepetDbContext : Context
////    {
////        public DbSet<SepetOgesi> SepetOgeleri { get; set; }
////    }

////    public class Sepet
////    {
////        private readonly SepetDbContext dbContext = new SepetDbContext();

////        public void UrunEkle(Urunler urun, int adet)
////        {
////            SepetOgesi sepetOgesi = new SepetOgesi
////            {
////                UrunGorseli = urun.UrunGorsel,
////                UrunID = urun.UrunID,
////                UrunAdi = urun.UrunAdi,
////                Fiyat = urun.SatisFiyati,
////                Adet = adet,
////                //Rengi= urun.Renk,
////                //Marka=urun.Marka,
////            };

////            dbContext.SepetOgeleri.Add(sepetOgesi);
////            dbContext.SaveChanges();
////        }
////        public void UrunuSil(int urunId)
////        {
////            SepetOgesi silinecekUrun = SepetOgeleri.FirstOrDefault(u => u.UrunID == urunId);

////            if (silinecekUrun != null)
////            {
////                SepetOgeleri.Remove(silinecekUrun);
////            }
////        }

////        public List<SepetOgesi> SepetOgeleriniGetir()
////        {
////            return dbContext.SepetOgeleri.ToList();
////        }
////    }
////}
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Data.Entity;
//using System.Linq;

//namespace ecommerceWebMvcUser.Models.Classes
//{
//    public class SepetOgesi
//    {
//        [Key]
//        public int SepetID { get; set; }
//        public int UrunID { get; set; }
//        public string UrunAdi { get; set; }
//        public decimal Fiyat { get; set; }
//        public int Adet { get; set; }
//        public string UrunGorseli { get; set; }
//    }
//    public class SepetDbContext : Context
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
//                Adet = adet,
//            };

//            dbContext.SepetOgeleri.Add(sepetOgesi);
//            dbContext.SaveChanges();
//        }

//        public void UrunuSil(int urunId)
//        {
//            SepetOgesi silinecekUrun = dbContext.SepetOgeleri.FirstOrDefault(u => u.UrunID == urunId);

//            if (silinecekUrun != null)
//            {
//                dbContext.SepetOgeleri.Remove(silinecekUrun);
//                dbContext.SaveChanges(); // Silme işlemini kaydet
//            }
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
        //[Key]
        //public int SepetOgesiID { get; set; }
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public decimal Fiyat { get; set; }
        public int Adet { get; set; }
        public string UrunGorseli { get; set; }
    }

    public class SepetDbContext : Context
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
            };

            dbContext.SepetOgeleri.Add(sepetOgesi);
            dbContext.SaveChanges();
        }

        public void UrunuSil(int urunId)
        {
            SepetOgesi silinecekUrun = dbContext.SepetOgeleri.FirstOrDefault(u => u.UrunID == urunId);

            if (silinecekUrun != null)
            {
                dbContext.SepetOgeleri.Remove(silinecekUrun);
                dbContext.SaveChanges(); // Silme işlemini kaydet
            }
        }

        public List<SepetOgesi> SepetOgeleriniGetir()
        {
            return dbContext.SepetOgeleri.ToList();
        }
    }
}
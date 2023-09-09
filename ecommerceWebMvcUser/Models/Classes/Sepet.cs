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
        public decimal ToplamFiyat => Fiyat * Adet;
     
    }

    public class SepetDbContext : DbContext
    {
        public DbSet<SepetOgesi> SepetOgeleri { get; set; }

    }
    public class Sepet
    {
        private List<SepetOgesi> sepetOgeleri = new List<SepetOgesi>();
        public decimal ToplamFiyatHesapla()
        {
            return sepetOgeleri.Sum(o => o.ToplamFiyat);
        }
        public int ToplamAdet()
        {
            return sepetOgeleri.Sum(item => item.Adet);
        }

        public decimal ToplamTutar()
        {
            return sepetOgeleri.Sum(item => item.ToplamFiyat);
        }
        public void UrunEkle(Urunler urun, int adet)
        {
            // Sepet öğesini bellekteki koleksiyona ekle
            SepetOgesi sepetOgesi = new SepetOgesi
            {
                UrunGorseli = urun.UrunGorsel,
                UrunID = urun.UrunID,
                UrunAdi = urun.UrunAdi,
                Fiyat = urun.SatisFiyati,
                Adet = adet
            };

            sepetOgeleri.Add(sepetOgesi);
        }
        public void SepetiBosalt()
        {
            sepetOgeleri.Clear();
            
        }
        public void UrunuSil(int urunId)
        {
            // Sepet öğesini bellekteki koleksiyondan kaldır
            SepetOgesi silinecekUrun = sepetOgeleri.FirstOrDefault(u => u.UrunID == urunId);

            if (silinecekUrun != null)
            {
                sepetOgeleri.Remove(silinecekUrun);
            }
        }
        public class SepetViewModel
        {
            public List<SepetOgesi> SepetOgeleri { get; set; }
            public decimal ToplamTutar { get; set; }
        }

        //public decimal ToplamTutarHesapla()
        //{
        //    decimal toplamTutar = 0;

        //    foreach (var sepetOgesi in sepetOgeleri)
        //    {
        //        // Her ürünün adet ve fiyatını çarpıp toplam tutara ekleyin
        //        toplamTutar += (sepetOgesi.Fiyat * sepetOgesi.Adet);
        //    }

        //    return toplamTutar;
        //}
        public decimal ToplamTutarHesapla()
        {
            decimal toplam = 0;

            foreach (var urun in sepetOgeleri)
            {
                toplam += urun.Fiyat * urun.Adet;
            }

            return toplam;
        }

        public List<SepetOgesi> SepetOgeleriniGetir()
        {
            return sepetOgeleri;
        }
    }
}

 
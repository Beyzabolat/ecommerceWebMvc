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
       public decimal kargoUcreti { get; set; }
        public decimal ToplamFiyat => Fiyat * Adet;
        //public string siparisAdi { get; set; }
        //public string siparisSoyadi { get; set; }
        //public string siparisMail { get; set; }
        //public string siparisTelefon { get; set; }
        //public string siparisİl { get; set; }
        //public string siparisİlce { get; set; }
        //public string siparisAdres { get; set; }
        //public string siparisNot { get; set; }
        [Required(ErrorMessage = "İsim alanı gereklidir.")]
        public string Isim { get; set; }

        [Required(ErrorMessage = "Soyisim alanı gereklidir.")]
        public string Soyisim { get; set; }

        [Required(ErrorMessage = "E-Mail alanı gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon alanı gereklidir.")]
        public string Telefon { get; set; }

        [Required(ErrorMessage = "İl alanı gereklidir.")]
        public string Il { get; set; }

        [Required(ErrorMessage = "İlçe alanı gereklidir.")]
        public string Ilce { get; set; }

        [Required(ErrorMessage = "Adres alanı gereklidir.")]
        public string Adres { get; set; }
        [Required(ErrorMessage = "İsim alanı gereklidir.")]
        public string kartisim { get; set; }
        [Required(ErrorMessage = "Kart alanı gereklidir.")]
        public string kkarti { get; set; }
        [Required(ErrorMessage = "Numara alanı gereklidir.")]
        public string kknumara { get; set; }
        [Required(ErrorMessage = "Cvv alanı gereklidir.")]
        public string kkcvv { get; set; }
        [Required(ErrorMessage = "Tarih alanı gereklidir.")]
        public string kkskk { get; set; }
        public string SiparisNotu { get; set; }

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
        public decimal ToplamSepet()
        {
            decimal toplam = 0;
            foreach (var urun in sepetOgeleri)
            {
                toplam += urun.ToplamFiyat;
            }
            return toplam;
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
                Adet = adet,
               kargoUcreti = 50.00M
                
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

 
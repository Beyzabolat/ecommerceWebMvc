using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ecommerceWebMvcUser.Models.Classes
{
    public class FavOgesi
    {
        //[Key]
        public int favID { get; set; }
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public decimal Fiyat { get; set; }

        public string UrunGorseli { get; set; }

    }
    public class FavDbContext : DbContext
    {
        public DbSet<FavOgesi> FavOgeleri { get; set; }

    }
    public class Wishlist
    {
        private List<FavOgesi> FavOgeleri = new List<FavOgesi>();

        public void UrunEkle(Urunler urun, int adet)
        {
            // Sepet öğesini bellekteki koleksiyona ekle
            FavOgesi favOgesi = new FavOgesi
            {
                UrunGorseli = urun.UrunGorsel,
                UrunID = urun.UrunID,
                UrunAdi = urun.UrunAdi,
                Fiyat = urun.SatisFiyati,

            };

            FavOgeleri.Add(favOgesi);
        }
        public void SepetiBosalt()
        {
            FavOgeleri.Clear();

        }
        public void UrunuSil(int urunId)
        {
            // Sepet öğesini bellekteki koleksiyondan kaldır
            FavOgesi silinecekUrun = FavOgeleri.FirstOrDefault(u => u.UrunID == urunId);

            if (silinecekUrun != null)
            {
                FavOgeleri.Remove(silinecekUrun);
            }
        }
        public class FavViewModel
        {
            public List<FavOgesi> FavOgeleri { get; set; }
            
        }



        public List<FavOgesi> FavOgeleriniGetir()
        {
            return FavOgeleri;
        }
    }


}

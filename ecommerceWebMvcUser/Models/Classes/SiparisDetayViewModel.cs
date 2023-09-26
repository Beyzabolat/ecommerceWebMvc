using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecommerceWebMvcUser.Models.Classes
{
    public class SiparisDetayViewModel
    {
      
            public List<Siparis> Siparisler { get; set; }
            public Musteri MusteriBilgileri { get; set; }
        

        public class Siparis
        {
            public int SiparisID { get; set; }
            public DateTime SiparisTarihi { get; set; }
            public List<SepetOgesi> SepetOgeleri { get; set; }
        }

        public class Musteri
        {
            public string Isim { get; set; }
            public string Soyisim { get; set; }
            public string Email { get; set; }
            public string Telefon { get; set; }
            public string Il { get; set; }
            public string Ilce { get; set; }
            public string Adres { get; set; }
            public string kartisim { get; set; }
            public string kkarti { get; set; }
            public string kknumara { get; set; }
            public string kkcvv { get; set; }
            public string kkskk { get; set; }
            public string SiparisNotu { get; set; }
        }

    }
}
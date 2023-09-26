using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ecommerceWebMvcUser.Models.Classes
{
    public class SiparisViewModel
    {
        
            // Sipariş ViewModel'inin diğer özellikleri
            public List<SepetOgesi> sepetOgesis { get; set; }
        

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

        public string SiparisNotu { get; set; }
        public List<SepetOgesi> SepetOgeleri { get; set; }
    }
}




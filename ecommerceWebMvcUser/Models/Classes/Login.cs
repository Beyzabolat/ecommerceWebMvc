using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ecommerceWebMvcUser.Models.Classes
{
    public class Login
    {

        [Required(ErrorMessage = "Kullanıcı adını giriniz")]
        public string KullaniciAdi { get; set; }
        [Required(ErrorMessage = "Şifrenizi giriniz")]
        public string Sifre { get; set; }
    }
}
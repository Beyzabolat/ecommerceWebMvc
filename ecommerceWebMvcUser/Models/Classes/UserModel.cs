using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ecommerceWebMvcUser.Models.Classes
{
    public class Register
    {
        [Required]
        public string İsim { get; set; }
        [Required]
        public string Soyisim { get; set; }
        [Required]
        public string mail { get; set; }
        [Required]
        public string KullaniciAdi { get; set; }
        [Required]
        public string Sifre { get; set; }

    }
}
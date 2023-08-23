﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ecommerceWebMvc.Models.Classes
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(10)]
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        [Display(Name = "Şifre")]
        public string Sifre { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]
        
        public string Yetki { get; set; }
        public bool Durum { get; set; }
    }
}
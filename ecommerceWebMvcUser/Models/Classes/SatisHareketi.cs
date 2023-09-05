﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ecommerceWebMvcUser.Models.Classes
{
    public class SatisHareketi
    {
        [Key]

        //urun, cari, personel
        public int SatisID { get; set; }
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public int EskiAdet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }

        public int Urunid { get; set; }
        public int Cariid { get; set; }
        public int Personelid { get; set; }
        public virtual Urunler Urunler { get; set; }
     

       

    }
}
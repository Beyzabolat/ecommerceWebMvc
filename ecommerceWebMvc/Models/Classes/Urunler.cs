using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ecommerceWebMvc.Models.Classes
{
    public class Urunler
    {
        [Key]
        public int UrunID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        [Display(Name = "Ürün Adı")]
        public string UrunAdi { get; set; }

        public short Stok { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string Marka { get; set; }
        [Display(Name = "Alış Fiyatı")]
        public decimal AlisFiyati { get; set; }
        [Display(Name = "Satış Fiyatı")]
        public decimal SatisFiyati { get; set; }
        public bool Durum { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(250)]
        [Display(Name = "Ürün Görseli")]
        public string UrunGorsel { get; set; }
        [Display(Name = "Renk")]
        public string Renk { get; set; }
        [Display(Name = "Beden")]
        public string Beden { get; set; }
        [Display(Name = "Numara")]
        public string Numara { get; set; }
        [Display(Name = "Cinsiyet")]
        public string Cinsiyet { get; set; }
        [Display(Name = "Kategori")]
        public int Kategoriid { get; set; }
        //public string ImageURL { get; set; } // IFormFile yerine string

        public virtual Kategori Kategori { get; set; }
        public ICollection<SatisHareketi> SatisHareketis { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ecommerceWebMvc.Models.Classes
{
    public class Kategori
    {
        [Key]
        public int KategoriID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string KategoriAd { get; set; }
        public bool Durum { get; set; }
        public ICollection<Urunler> Uruns { get; set; }

    }
}
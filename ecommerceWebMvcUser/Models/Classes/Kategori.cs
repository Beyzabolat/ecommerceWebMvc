using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ecommerceWebMvcUser.Models.Classes
{
    public class Kategori
    {

        [Key]
        public int KategoriID { get; set; }
       
        public string KategoriAd { get; set; }
 
        public ICollection<Urunler> Uruns { get; set; }
    }
}
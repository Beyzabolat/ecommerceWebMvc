using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ecommerceWebMvcUser.Models.Classes
{
    public class UrunDetay
    {
        [Key]
        public int DetayID { get; set; }
       
        public string Urunad { get; set; }
       
        public string Urunbilgi { get; set; }
    }
}
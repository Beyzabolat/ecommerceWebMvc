using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ecommerceWebMvcUser.Models.Classes
{
    public class ShippingDetails
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        //public virtual ShippingDetails ShippingDetails { get; set; }
        public int Adet { get; set; }
        public double Fiyat { get; set; }
        public int adet { get; set; }
        public int urunId { get; set; }
        public virtual Urunler Urunler { get; set; }
    }
}
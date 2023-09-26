using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecommerceWebMvcUser.Models.Classes
{
    public class UserOrderModel
    {

        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public double total { get; set; }
      public DateTime Orderdate { get; set; }
    }
}
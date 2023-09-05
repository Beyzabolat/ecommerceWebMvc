﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ecommerceWebMvcUser.Models;
using ecommerceWebMvcUser.Models.Classes;

//namespace ecommerceWebMvcUser.Logic
//{
//    public class ShoppingCartActions:IDisposable
//    {
//        public string ShoppingCartId { get; set; }

//        private Context _db = new Context();

//        public const string CartSessionKey = "CartId";
//        public void AddToCart(int id)
//        {
//            // Retrieve the product from the database.           
//            ShoppingCartId = GetCartId();

//            var cartItem = _db.ShoppingCartItems.SingleOrDefault(
//                c => c.SatisID == ShoppingCartId
//                && c.Urunid == id);
//            if (cartItem == null)
//            {
//                // Create a new cart item if no cart item exists.                 
//                cartItem = new SatisHareketi
//                {
//                    ItemId = Guid.NewGuid().ToString(),
//                    Urunid = id,
//                    SatisID = ShoppingCartId,
//                    Urunler = _db.Urunlers.SingleOrDefault(
//                   p => p.UrunID == id),
//                    Adet = 1,
                  
//                };

//                _db.ShoppingCartItems.Add(cartItem);
//            }
//            else
//            {
//                // If the item does exist in the cart,                  
//                // then add one to the quantity.                 
//                cartItem.Quantity++;
//            }
//            _db.SaveChanges();
//        }

//        public void Dispose()
//        {
//            if (_db != null)
//            {
//                _db.Dispose();
//                _db = null;
//            }
//        }

//        public string GetCartId()
//        {
//            if (HttpContext.Current.Session[CartSessionKey] == null)
//            {
//                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
//                {
//                    HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
//                }
//                else
//                {
//                    // Generate a new random GUID using System.Guid class.     
//                    Guid tempCartId = Guid.NewGuid();
//                    HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
//                }
//            }
//            return HttpContext.Current.Session[CartSessionKey].ToString();
//        }

//        public List<SatisHareketi> GetCartItems()
//        {
//            ShoppingCartId = GetCartId();

//            return _db.ShoppingCartItems.Where(
//                c => c.CartId == ShoppingCartId).ToList();
//        }
//    }
//}
//    }
//}





   
       
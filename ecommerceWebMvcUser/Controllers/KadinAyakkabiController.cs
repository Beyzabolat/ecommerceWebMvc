﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ecommerceWebMvcUser.Models.Classes;


namespace ecommerceWebMvcUser.Controllers
{
    public class KadinAyakkabiController : Controller
    {

        private Context _context = new Context();


        public ActionResult Index()
        {

            var kategori = _context.Urunlers.Where(k => k.Kategoriid == 3).ToList();

            return View(kategori);

        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Models.Classes;

namespace WebApplication2.Controllers
{
    public class UrunlerController : Controller
    {



        Context q = new Context();
            public UrunlerController(Context context)
            {
                q = context;
            }

            public ActionResult Index()
            {
                var urunler = q.Urunlers.ToList(); // Urun modeline ait DbSet'ten ürünleri çekiyoruz.
                return View(urunler);
            }
        }
}
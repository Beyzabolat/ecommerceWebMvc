using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ecommerceWebMvcUser.Models.Classes;

namespace ecommerceWebMvcUser.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context q = new Context();
        public ActionResult Index()
        {
            return View();


            //Class1 cs = new Class1();
            //// var degerler = c.Uruns.Where(x => x.Urunid == 1).ToList();
            //cs.Deger1 = q.Urunlers.Where(x => x.UrunID == 1).ToList();
            //cs.Deger2 = q.UrunDetays.Where(y => y.DetayID == 1).ToList();
            //return View(cs);

        }
    }
}

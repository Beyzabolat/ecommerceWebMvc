using ecommerceWebMvc.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecommerceWebMvc.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
       private readonly Context q = new Context();
        public ActionResult Index()
        {

            var kategoriler = q.Kategoris.Where(x => x.Durum == true).ToList();
            return View(kategoriler);
           
        }
        [HttpGet]  //sayfa çalıştığında boş olarak bunu açacak
        public ActionResult KategoriEkleme()
        {
            return View();

        }
       
        [HttpPost]
        public ActionResult KategoriEkleme(Kategori model)
        {
            if (ModelState.IsValid)
            {
               

                q.Kategoris.Add(model);
                q.SaveChanges();

               
                TempData["kategoriekleme"] = "Kayıt başarılı ";
                return RedirectToAction("Index");
              
            }

            return View(model);
        }
      

        public ActionResult KategoriGetirme(int id)
        {
            var kategori = q.Kategoris.Find(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            TempData["kategoriguncelleme"] = "Güncelleme başarılı ";
            return View("KategoriGuncelleme", kategori);
        }
        [HttpPost]
        public ActionResult KategoriGuncelleme(Kategori model)
        {
            if (ModelState.IsValid)
            {
                var kategori = q.Kategoris.Find(model.KategoriID);
                if (kategori != null)
                {
                    kategori.KategoriAd = model.KategoriAd;
                    kategori.Durum = model.Durum;
                    q.SaveChanges();

                    TempData["kategoriguncelleme"] = "Kayıt başarıyla güncellendi";
                    return RedirectToAction("Index");
                }
            }

            return View("KategoriGuncelleme", model);
        }

    }
}

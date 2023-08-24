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
        //[HttpPost] //butona tıklandığında çalışacak
        //public ActionResult KategoriEkleme(Kategori b)
        //{

        //    q.Kategoris.Add(b);
        //    q.SaveChanges();

        //    TempData["kategoriekleme"] = "kayıt başarılı ";
        //    return RedirectToAction("Index");

        //}
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
        //public ActionResult KategoriGetirme(int id)
        //{
        //    var kategorii = q.Kategoris.Find(id);
        //    return View("KategoriGetirme", kategorii);
        //}

        public ActionResult KategoriGetirme(int id)
        {
            var kategori = q.Kategoris.Find(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            TempData["kategoriekleme"] = "Kayıt başarılı ";
            return View("KategoriGuncelleme", kategori);
        }



        //public ActionResult KategoriGuncelleme(Kategori b)
        //{
        //    var kategor = q.Kategoris.Find(b.KategoriID);
        //    kategor.KategoriAd = b.KategoriAd;
        //    q.SaveChanges();

        //    TempData["kategoriguncelleme"] = "kayıt başarılı ";
        //    return RedirectToAction("Index");

        //}

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

        //public ActionResult KategoriGetirme(int id)
        //{
        //    var kategori = q.Kategoris.Find(id);
        //    return View("KategoriGetirme", kategori);
        //}

        //public ActionResult KategoriGuncelleme(int id)
        //{
        //    var kategori = q.Kategoris.Find(id);
        //    if (kategori == null)
        //    {
        //        // Eğer kategori bulunamazsa, hata sayfasına yönlendirilebilir.
        //        return HttpNotFound();
        //    }

        //    return View("KategoriGuncelleme", kategori);
        //}

        //[HttpPost]
        //public ActionResult KategoriGuncelleme(Kategori model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var kategori = q.Kategoris.Find(model.KategoriID);
        //        if (kategori != null)
        //        {
        //            kategori.KategoriAd = model.KategoriAd;
        //            kategori.Durum = model.Durum;
        //            q.SaveChanges();

        //            TempData["kategoriguncelleme"] = "Kayıt başarıyla güncellendi";
        //            return RedirectToAction("Index");
        //        }
        //    }

        //    return View(model);
        //}


        //public ActionResult KategoriGuncelleme(int id)
        //{
        //    var kategori = q.Kategoris.Find(id);
        //    return View("KategoriGuncelleme", kategori);
        //}

        //[HttpPost]
        //public ActionResult KategoriGuncelleme(Kategori model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var kategori = q.Kategoris.Find(model.KategoriID);
        //        if (kategori != null)
        //        {
        //            kategori.KategoriAd = model.KategoriAd;
        //            kategori.Durum = model.Durum;
        //            q.SaveChanges();

        //            TempData["kategoriguncelleme"] = "Kayıt başarıyla güncellendi";
        //            return RedirectToAction("Index");
        //        }
        //    }

        //    return View(model);
        //}

        //public ActionResult KategoriGetirme(int id)
        //{
        //    var kategorii = q.Kategoris.Find(id);
        //    return View("KategoriGetirme", kategorii);
        //}


        //public ActionResult KategoriGuncelleme(Kategori b)
        //{
        //    var kategor = q.Kategoris.Find(b.KategoriID);
        //    kategor.KategoriAd = b.KategoriAd;
        //    q.SaveChanges();

        //    TempData["kategoriguncelleme"] = "kayıt başarılı ";
        //    return RedirectToAction("Index");

        //}
    }
}

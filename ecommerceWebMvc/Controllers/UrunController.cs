﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ecommerceWebMvc.Models.Classes;


namespace ecommerceWebMvc.Controllers
{
    public class UrunController : Controller
    {

        Context q = new Context();
        public ActionResult Index()
        {
            var urunler = q.Urunlers.Where(x => x.Durum == true).ToList();
            return View(urunler);
        }

        public ActionResult UrunList()
        {
            var urunler = q.Urunlers.Where(x => x.Durum == true).ToList();
            return View(urunler);

        }

        [HttpGet]  //sayfa çalıştığında boş olarak bunu açacak
        public ActionResult UrunEkleme()
        {

            List<SelectListItem> deger1 = (from x in q.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();

        }

        [HttpPost]
        public ActionResult UrunEkleme(Urunler m)
        {



            try
            {
                if (ModelState.IsValid)
                {
                    q.Urunlers.Add(m);
                    q.SaveChanges();
                    return RedirectToAction("Index");
                }

                // Model geçerli değilse, hata mesajlarıyla birlikte aynı sayfayı döndürün
                List<SelectListItem> deger1 = (from x in q.Kategoris.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.KategoriAd,
                                                   Value = x.KategoriID.ToString()
                                               }).ToList();
                ViewBag.dgr1 = deger1;
                return View(m);
            }
            catch (Exception ex)
            {
                // Hata ayıklama amacıyla hatayı yazdırabilirsiniz
                ViewBag.ErrorMessage = ex.Message;
                return View(m);
            }
        }

        //[HttpGet]
        public ActionResult UrunGetirme(int id)
        {
            List<SelectListItem> deger1 = (from x in q.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var uruun = q.Urunlers.Find(id);
            return View("UrunGuncelle", uruun);
            ;
        }
        [HttpPost]
        public ActionResult UrunGuncelle(Urunler p)
        {

            if (ModelState.IsValid)
            {
                var urunnnn = q.Urunlers.Find(p.UrunID);
                if (urunnnn != null)
                {
                    urunnnn.AlisFiyati = p.AlisFiyati;
                    urunnnn.SatisFiyati = p.SatisFiyati;
                    urunnnn.Durum = p.Durum;
                    urunnnn.Kategoriid = p.Kategoriid;
                    urunnnn.Marka = p.Marka;
                    urunnnn.Stok = p.Stok;
                    urunnnn.UrunAdi = p.UrunAdi;
                    urunnnn.UrunGorsel = p.UrunGorsel;
                    urunnnn.Renk = p.Renk;
                    urunnnn.Beden = p.Beden;
                    urunnnn.Numara = p.Numara;
                    urunnnn.Cinsiyet = p.Cinsiyet;
                    q.SaveChanges();

                    //TempData["kategoriguncelleme"] = "Kayıt başarıyla güncellendi";
                    return RedirectToAction("Index");
                }
            }

            return View("UrunGuncelle", p);

        }

        public ActionResult UrunDetay(int id)
        {
            // id parametresini kullanarak ürün detaylarını çekin
            var urunDetay = q.Urunlers.FirstOrDefault(u => u.UrunID == id);

            // Eğer urunDetay null ise, uygun bir hata işleme mekanizması kullanabilirsiniz.

            return View(urunDetay);
        }



        public ActionResult UrunListesi()
        {
            var deegerler = q.Urunlers.ToList();
            return View(deegerler);
        }



        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> deger2 = (from x in q.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            List<SelectListItem> deger4 = (from x in q.Caris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            var deger1 = q.Urunlers.Find(id);
            ViewBag.dgr1 = deger1.UrunID;
            ViewBag.dgr3 = deger1.SatisFiyati;
            ViewBag.dgr4 = deger4;
            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SatisHareketi p)
        {
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            q.SatisHareketis.Add(p);
            q.SaveChanges();
            return RedirectToAction("Index", "Satis");
        }

    }
}


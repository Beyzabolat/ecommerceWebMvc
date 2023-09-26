﻿using ecommerceWebMvc.Models.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecommerceWebMvc.Controllers
{
    public class PersonelController : Controller
    {
        Context q = new Context();
        public ActionResult Index()
        {
            var deger = q.Personels.ToList();
            return View(deger);
        }
        [HttpGet]  //sayfa çalıştığında boş olarak bunu açacak
        public ActionResult PersonelEkleme()
        {
            List<SelectListItem> deger = (from x in q.Departmen.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.DepartmanAd,
                                              Value = x.DepartmanID.ToString()
                                          }).ToList();
            ViewBag.dgr1 = deger;
            return View();

        }
        [HttpPost] //butona tıklandığında çalışacak
        public ActionResult PersonelEkleme(Personel m)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "/resimler/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                m.PersonelGorsel = "/resimler/" + dosyaadi + uzanti;

            }
            q.Personels.Add(m);
            q.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetirme(int id)
        {
            List<SelectListItem> deger1 = (from x in q.Departmen.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var prs = q.Personels.Find(id);
            return View("PersonelGetirme", prs);
        }
        public ActionResult PersonelGuncelleme(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "/resimler/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/resimler/" + dosyaadi + uzanti;

            }
            var pers = q.Personels.Find(p.PersonelID);
            pers.PersonelAd = p.PersonelAd;
            pers.PersonelSoyad = p.PersonelSoyad;
            pers.PersonelGorsel = p.PersonelGorsel;
            pers.Departmanid = p.Departmanid;
            q.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult PersonelListe()
        {
            var sorgu = q.Personels.ToList();
            return View(sorgu);

        }
    }
}
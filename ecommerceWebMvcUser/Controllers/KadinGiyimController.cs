﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ecommerceWebMvcUser.Models.Classes;

namespace ecommerceWebMvcUser.Controllers
{
    public class KadinGiyimController : Controller
    {
        private Context db = new Context();

        // GET: KadinGiysiler
        public ActionResult Index()
        {
            var urunler = db.Urunlers.Where(x => x.Durum == true && x.Kategoriid == 1).ToList();
            int urunSayisi = urunler.Count;
            ViewBag.UrunSayisi = urunSayisi;
            return View(urunler);
        }

        //public ActionResult Index()
        //{


        //    var urunler = db.Urunlers.Where(x => x.Durum == true).ToList();
        //    int urunSayisi = urunler.Count;

        //    ViewBag.UrunSayisi = urunSayisi;

        //    var kategori = db.Urunlers.Where(k => k.Kategoriid == 1).ToList();

        //    return View(kategori);

        //}

        // GET: KadinGiysiler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urunler urunler = db.Urunlers.Find(id);
            if (urunler == null)
            {
                return HttpNotFound();
            }
            return View(urunler);
        }

        // GET: KadinGiysiler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KadinGiysiler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UrunID,UrunAdi,Marka,UrunGorsel,Renk,Beden,Numara")] Urunler urunler)
        {
            if (ModelState.IsValid)
            {
                db.Urunlers.Add(urunler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(urunler);
        }

        // GET: KadinGiysiler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urunler urunler = db.Urunlers.Find(id);
            if (urunler == null)
            {
                return HttpNotFound();
            }
            return View(urunler);
        }

        // POST: KadinGiysiler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UrunID,UrunAdi,Marka,UrunGorsel,Renk,Beden,Numara")] Urunler urunler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(urunler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(urunler);
        }

        // GET: KadinGiysiler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urunler urunler = db.Urunlers.Find(id);
            if (urunler == null)
            {
                return HttpNotFound();
            }
            return View(urunler);
        }

        // POST: KadinGiysiler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Urunler urunler = db.Urunlers.Find(id);
            db.Urunlers.Remove(urunler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

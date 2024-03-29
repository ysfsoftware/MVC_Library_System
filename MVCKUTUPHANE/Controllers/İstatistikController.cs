﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKUTUPHANE.Models.Entity;

namespace MVCKUTUPHANE.Controllers
{
    public class İstatistikController : Controller
    {
        // GET: İstatistik
        MvcDbKutuphaneEntities db = new MvcDbKutuphaneEntities();
        public ActionResult Index()
        {
            var deger1 = db.TBLUYE.Count();
            var deger2 = db.TBLKITAP.Count();
            var deger3 = db.TBLKITAP.Where(x => x.DURUM == false).Count();
            var deger4 = db.TBLCEZA.Sum(x => x.PARA);
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            return View();
        }
        public ActionResult Hava()
        {
            return View();
        }
        public ActionResult HavaKart()
        {
            return View();
        }
        public ActionResult Galeri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ResimYukle(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength > 0)
            {
                string dosyayolu = Path.Combine(Server.MapPath("~/web2/resimler/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyayolu);

            }
            return RedirectToAction("Galeri");
        }
        public ActionResult LinqKart()
        {
            var deger1 = db.TBLKITAP.Count();
            var deger2 = db.TBLUYE.Count();
            var deger3 = db.TBLCEZA.Sum(x => x.PARA);
            var deger4 = db.TBLKITAP.Where(x => x.DURUM == false).Count();
            var deger5 = db.TBLKATEGORI.Count();
            var deger8 = db.EnFazlaKitapYazar().FirstOrDefault();
            var deger9 = db.TBLKITAP.GroupBy(x => x.YAYINEVI).OrderByDescending(z => z.Count()).Select(y => y.Key ).FirstOrDefault();
            var deger10 = db.EnAktifUye().FirstOrDefault();
            var deger11 = db.TBLİLETİSİM.Count();
            var deger12 = db.EnCokOkunanKitap().FirstOrDefault();
            var deger13 = db.EnBasariliPersonel().FirstOrDefault();
            var deger14 = db.TBLHAREKET.Where(x => x.UYEGETIRTARIH == DateTime.Now).Count();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            ViewBag.dgr5 = deger5;
            ViewBag.dgr8 = deger8;
            ViewBag.dgr9 = deger9;
            ViewBag.dgr10 = deger10;
            ViewBag.dgr11 = deger11;
            ViewBag.dgr12 = deger12;
            ViewBag.dgr13 = deger13;
            ViewBag.dgr14 = deger14;
            return View();
        }

    }
}
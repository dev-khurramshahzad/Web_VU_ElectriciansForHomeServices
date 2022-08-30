﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ElectriciansForHomeServices.Models;

namespace ElectriciansForHomeServices.Controllers
{
    public class Adm_CategoriesController : Controller
    {
        private dbModel db = new dbModel();

        // GET: Adm_Categories
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: Adm_Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Adm_Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Adm_Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category, HttpPostedFileBase pic)
        {

            if (pic != null)
            {
                var PicName = Path.GetFileName(pic.FileName);
                var PicExt = Path.GetExtension(PicName);
                if (PicExt != ".JPG" && PicExt != ".PNG" && PicExt != ".jpeg" && PicExt != ".bmp" && PicExt != ".png" && PicExt != ".jpg" && PicExt != ".JPEG" && PicExt != ".BMP")
                {
                    TempData["State"] = "error";
                    TempData["Message"] = "Please select a Valid Picure.";


                    return View(category);
                }

                category.Picture = Path.GetFileName(pic.FileName);
                pic.SaveAs(Path.Combine(Server.MapPath("~/Content/AppData"), category.Picture));
            }



            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Adm_Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Adm_Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category, HttpPostedFileBase pic)
        {
            if (pic != null)
            {
                var PicName = Path.GetFileName(pic.FileName);
                var PicExt = Path.GetExtension(PicName);
                if (PicExt != ".JPG" && PicExt != ".PNG" && PicExt != ".jpeg" && PicExt != ".bmp" && PicExt != ".png" && PicExt != ".jpg" && PicExt != ".JPEG" && PicExt != ".BMP")
                {
                    TempData["State"] = "error";
                    TempData["Message"] = "Please select a Valid Picure.";


                    return View(category);
                }
                category.Picture = Path.GetFileName(pic.FileName);
                pic.SaveAs(Path.Combine(Server.MapPath("~/Content/AppData"), category.Picture));
            }

            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Adm_Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Adm_Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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

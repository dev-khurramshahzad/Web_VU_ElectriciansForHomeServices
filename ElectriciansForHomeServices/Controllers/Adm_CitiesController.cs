using System;
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
    public class Adm_CitiesController : Controller
    {
        private dbModel db = new dbModel();

        // GET: Adm_Cities
        public ActionResult Index()
        {
            return View(db.Cities.ToList());
        }

        // GET: Adm_Cities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // GET: Adm_Cities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Adm_Cities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(City city, HttpPostedFileBase pic)
        {
            if (pic != null)
            {
                var PicName = Path.GetFileName(pic.FileName);
                var PicExt = Path.GetExtension(PicName);
                if (PicExt != ".JPG" && PicExt != ".PNG" && PicExt != ".jpeg" && PicExt != ".bmp" && PicExt != ".png" && PicExt != ".jpg" && PicExt != ".JPEG" && PicExt != ".BMP")
                {
                    TempData["State"] = "error";
                    TempData["Message"] = "Please select a Valid Picure.";


                    return View(city);
                }
                city.Picture = Path.GetFileName(pic.FileName);
                pic.SaveAs(Path.Combine(Server.MapPath("~/Content/AppData"), city.Picture));
            }

            if (ModelState.IsValid)
            {
                db.Cities.Add(city);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(city);
        }

        // GET: Adm_Cities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // POST: Adm_Cities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(City city, HttpPostedFileBase pic)
        {
            if (pic != null)
            {
                var PicName = Path.GetFileName(pic.FileName);
                var PicExt = Path.GetExtension(PicName);
                if (PicExt != ".JPG" && PicExt != ".PNG" && PicExt != ".jpeg" && PicExt != ".bmp" && PicExt != ".png" && PicExt != ".jpg" && PicExt != ".JPEG" && PicExt != ".BMP")
                {
                    TempData["State"] = "error";
                    TempData["Message"] = "Please select a Valid Picure.";


                    return View(city);
                }
                city.Picture = Path.GetFileName(pic.FileName);
                pic.SaveAs(Path.Combine(Server.MapPath("~/Content/AppData"), city.Picture));
            }

            if (ModelState.IsValid)
            {
                db.Entry(city).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(city);
        }

        // GET: Adm_Cities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // POST: Adm_Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            City city = db.Cities.Find(id);
            db.Cities.Remove(city);
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

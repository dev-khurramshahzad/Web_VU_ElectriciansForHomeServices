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
    public class Adm_ElectriciansController : Controller
    {
        private dbModel db = new dbModel();

        // GET: Adm_Electricians
        public ActionResult Index()
        {
            var electricians = db.Electricians.Include(e => e.Category).Include(e => e.City);
            return View(electricians.ToList());
        }

        // GET: Adm_Electricians/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Electrician electrician = db.Electricians.Find(id);
            if (electrician == null)
            {
                return HttpNotFound();
            }
            return View(electrician);
        }

        // GET: Adm_Electricians/Create
        public ActionResult Create()
        {
            ViewBag.CatFID = new SelectList(db.Categories, "CatID", "Name");
            ViewBag.CItyFID = new SelectList(db.Cities, "CityID", "Name");
            return View();
        }

        // POST: Adm_Electricians/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Electrician electrician,HttpPostedFileBase pic)
        {
            if (pic != null)
            {
                var PicName = Path.GetFileName(pic.FileName);
                var PicExt = Path.GetExtension(PicName);
                if (PicExt != ".JPG" && PicExt != ".PNG" && PicExt != ".jpeg" && PicExt != ".bmp" && PicExt != ".png" && PicExt != ".jpg" && PicExt != ".JPEG" && PicExt != ".BMP")
                {
                    TempData["State"] = "error";
                    TempData["Message"] = "Please select a Valid Picure.";


                    return View(electrician);
                }
                electrician.Picture = Path.GetFileName(pic.FileName);
                pic.SaveAs(Path.Combine(Server.MapPath("~/Content/AppData"), electrician.Picture));
            }

            if (ModelState.IsValid)
            {
                db.Electricians.Add(electrician);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CatFID = new SelectList(db.Categories, "CatID", "Name", electrician.CatFID);
            ViewBag.CItyFID = new SelectList(db.Cities, "CityID", "Name", electrician.CItyFID);
            return View(electrician);
        }

        // GET: Adm_Electricians/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Electrician electrician = db.Electricians.Find(id);
            if (electrician == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatFID = new SelectList(db.Categories, "CatID", "Name", electrician.CatFID);
            ViewBag.CItyFID = new SelectList(db.Cities, "CityID", "Name", electrician.CItyFID);
            return View(electrician);
        }

        // POST: Adm_Electricians/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Electrician electrician, HttpPostedFileBase pic)
        {
            if (pic != null)
            {
                var PicName = Path.GetFileName(pic.FileName);
                var PicExt = Path.GetExtension(PicName);
                if (PicExt != ".JPG" && PicExt != ".PNG" && PicExt != ".jpeg" && PicExt != ".bmp" && PicExt != ".png" && PicExt != ".jpg" && PicExt != ".JPEG" && PicExt != ".BMP")
                {
                    TempData["State"] = "error";
                    TempData["Message"] = "Please select a Valid Picure.";


                    return View(electrician);
                }
                electrician.Picture = Path.GetFileName(pic.FileName);
                pic.SaveAs(Path.Combine(Server.MapPath("~/Content/AppData"), electrician.Picture));
            }

            if (ModelState.IsValid)
            {
                db.Entry(electrician).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CatFID = new SelectList(db.Categories, "CatID", "Name", electrician.CatFID);
            ViewBag.CItyFID = new SelectList(db.Cities, "CityID", "Name", electrician.CItyFID);
            return View(electrician);
        }

        // GET: Adm_Electricians/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Electrician electrician = db.Electricians.Find(id);
            if (electrician == null)
            {
                return HttpNotFound();
            }
            return View(electrician);
        }

        // POST: Adm_Electricians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Electrician electrician = db.Electricians.Find(id);
            db.Electricians.Remove(electrician);
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

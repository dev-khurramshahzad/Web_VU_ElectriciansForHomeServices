using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ElectriciansForHomeServices.Models;

namespace ElectriciansForHomeServices.Controllers
{
    public class Adm_BookingsController : Controller
    {
        private dbModel db = new dbModel();

        // GET: Adm_Bookings
        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.Electrician).Include(b => b.User);
            return View(bookings.ToList());
        }

        public ActionResult Approve(int id)
        {
            db.Bookings.Find(id).Status = "Approved";
            db.SaveChanges();
            return Redirect("/Adm_Bookings/");
        }

        public ActionResult Reject(int id)
        {
            db.Bookings.Find(id).Status = "Rejected";
            db.SaveChanges();
            return Redirect("/Adm_Bookings/");
        }

        public ActionResult Postpone(int id)
        {
            db.Bookings.Find(id).Status = "Postponed";
            db.SaveChanges();
            return Redirect("/Adm_Bookings/");
        }



        // GET: Adm_Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Adm_Bookings/Create
        public ActionResult Create()
        {
            ViewBag.ElectricianFID = new SelectList(db.Electricians, "ElecID", "Name");
            ViewBag.UserFID = new SelectList(db.Users, "UserID", "Name");
            return View();
        }

        // POST: Adm_Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingID,UserFID,ElectricianFID,BookingDate,BookingTime,WorkStartDate,WorkEndDate,Status,Details")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ElectricianFID = new SelectList(db.Electricians, "ElecID", "Name", booking.ElectricianFID);
            ViewBag.UserFID = new SelectList(db.Users, "UserID", "Name", booking.UserFID);
            return View(booking);
        }

        // GET: Adm_Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.ElectricianFID = new SelectList(db.Electricians, "ElecID", "Name", booking.ElectricianFID);
            ViewBag.UserFID = new SelectList(db.Users, "UserID", "Name", booking.UserFID);
            return View(booking);
        }

        // POST: Adm_Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingID,UserFID,ElectricianFID,BookingDate,BookingTime,WorkStartDate,WorkEndDate,Status,Details")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ElectricianFID = new SelectList(db.Electricians, "ElecID", "Name", booking.ElectricianFID);
            ViewBag.UserFID = new SelectList(db.Users, "UserID", "Name", booking.UserFID);
            return View(booking);
        }

        // GET: Adm_Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Adm_Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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

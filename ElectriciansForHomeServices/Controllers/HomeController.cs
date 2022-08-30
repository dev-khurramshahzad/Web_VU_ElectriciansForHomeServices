using ElectriciansForHomeServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectriciansForHomeServices.Controllers
{
    public class HomeController : Controller
    {
        private dbModel db = new dbModel();

        public ActionResult Index()
        {
            return View(db.Electricians.ToList());
        }

        public ActionResult Categories()
        {
            return View(db.Categories.ToList());
        }

        public ActionResult Cities()
        {
            return View(db.Cities.ToList());
        }

        public ActionResult Electricians(int? id, string filter)
        {
            List<Electrician> elecs = null;

            if (id != null && filter == "category")
            {
                elecs = db.Electricians.Where(x => x.CatFID == id).ToList();
            }
            else if (id != null && filter == "city")
            {
                elecs = db.Electricians.Where(x => x.CItyFID == id).ToList();
            }
            else
            {
                elecs = db.Electricians.ToList();
            }

            return View(elecs);

        }

        public ActionResult ElectricianDetails(int id)
        {
            if (Session["LoggedinUser"] == null)
            {
                return Redirect("/Users/Login?return_url=" + this.Request.RawUrl);
            }


            return View(db.Electricians.Find(id));
        }

        public ActionResult Booking(int id, string StartDate, string EndDate)
        {
            if (Session["LoggedinUser"] == null)
            {
                return Redirect("/Users/Login?return_url" + this.Request.RawUrl);
            }


            if (string.IsNullOrEmpty(StartDate) || string.IsNullOrEmpty(EndDate))
            {
                return Content("<script>alert('Please select both of the dates.');window.history.back();</script>");
            }

            var Date_StartDate = DateTime.Parse(StartDate);
            var Date_EndDate = DateTime.Parse(EndDate);

            if (Date_StartDate <= DateTime.Now.Date || Date_EndDate <= DateTime.Now.Date || Date_StartDate > Date_EndDate)
            {
                return Content("<script>alert('Dates must be a future date, it cannot be current date or past date.');window.history.back();</script>");
            }


            var user = (User)Session["LoggedinUser"];
            var b = new Booking()
            {
                BookingDate = DateTime.Now,
                BookingTime = DateTime.Now.TimeOfDay,
                ElectricianFID = id,
                Status = "Pending",
                UserFID = user.UserID,
                WorkStartDate = Date_StartDate,
                WorkEndDate = Date_EndDate,
            };

            db.Bookings.Add(b);
            db.SaveChanges();

            int MaxID = db.Bookings.Max(x => x.BookingID);

            return Redirect("/Home/BookingConfirmed/" + MaxID);
        }


        public ActionResult BookingConfirmed(int id)
        {
            var booking = db.Bookings.Find(id);
            return View(booking);
        }

        public ActionResult Admin()
        {
            return View();
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
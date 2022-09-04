using ElectriciansForHomeServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectriciansForHomeServices.Controllers
{
    public class UsersController : Controller
    {
        private dbModel db = new dbModel();
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult ElectricianProfile(int? id)
        {
            ViewBag.CatFID = new SelectList(db.Categories, "CatID", "Name");
            ViewBag.CItyFID = new SelectList(db.Cities, "CityID", "Name");

            var elect = db.Electricians.Find(id);
            return View(elect);
        }
        public ActionResult UpdateProfile(int? id)
        {
            ViewBag.CatFID = new SelectList(db.Categories, "CatID", "Name");
            ViewBag.CItyFID = new SelectList(db.Cities, "CityID", "Name");

            var elect = db.Electricians.Find(id);
            return View(elect);
        }
        [HttpPost]
        public ActionResult Update(Electrician electrician, HttpPostedFileBase pic)
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
                return Redirect("/Users/ElectricianProfile/"+electrician.ElecID);
            }
            ViewBag.CatFID = new SelectList(db.Categories, "CatID", "Name", electrician.CatFID);
            ViewBag.CItyFID = new SelectList(db.Cities, "CityID", "Name", electrician.CItyFID);
            return View(electrician);
        }
        public ActionResult Logout()
        {
            Session["LoggedinUser"] = null;
            Session["LoggedinElectrician"] = null;
            return Redirect("/Home");
        }
        public ActionResult Login(string return_url)
        {
            ViewBag.return_url = return_url;
            return View();
        }
        public ActionResult LoginVerify(string email, string password, string type, string return_url)
        {
            if (type == "User")
            {
                var check = db.Users.FirstOrDefault(x => x.Email == email && x.Password == password && x.Type == type);
                if (check == null)
                {
                    return Content("<script>alert('Email or Password Incorrect....');window.history.back();</script>");
                }
                else
                {
                    Session["LoggedinUser"] = check;
                    if (string.IsNullOrEmpty(return_url))
                    {
                        return_url = "/Home";
                    }
                    return Redirect(return_url);
                }
            }

            else if (type == "Admin")
            {
                var check = db.Users.FirstOrDefault(x => x.Email == email && x.Password == password && x.Type == type);
                if (check == null)
                {
                    return Content("<script>alert('Email or Password Incorrect....');window.history.back();</script>");
                }
                else
                {
                    Session["LoggedinAdmin"] = check;
                    return Redirect("/Users/AdminHome");
                }
            }

            else
            {
                var check = db.Electricians.FirstOrDefault(x => x.Email == email && x.Password == password);
                if (check == null)
                {
                    return Content("<script>alert('Email or Password Incorrect....');window.history.back();</script>");
                }
                else
                {
                    Session["LoggedinElectrician"] = check;
                    return Redirect("/Users/ElectricianProfile/"+check.ElecID);
                }
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult CreateData(string name, string phone, string address, string email, string password, string cpassword, string cnic)
        {
            if (password != cpassword)
            {
                return Content("<script>alert('Passwords do not match...');window.history.back();</script>");
            }

            var check = db.Users.FirstOrDefault(x => x.Email == email);
            if (check != null)
            {
                return Content("<script>alert('This email is already registered....');window.history.back();</script>");

            }

            var c = new User()
            {
                Name = name,
                Phone = phone,
                Address = address,
                Email = email,
                Password = password,
                CNIC = password,
                Details = "Active"
            };

            db.Users.Add(c);
            db.SaveChanges();

            return Redirect("/Users/Login");


        }
        public ActionResult NewElectrician()
        {
            ViewBag.CatFID = new SelectList(db.Categories, "CatID", "Name");
            ViewBag.CItyFID = new SelectList(db.Cities, "CityID", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult SaveElectrician(Electrician electrician, HttpPostedFileBase pic)
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
                return RedirectToAction("Login");
            }

            ViewBag.CatFID = new SelectList(db.Categories, "CatID", "Name", electrician.CatFID);
            ViewBag.CItyFID = new SelectList(db.Cities, "CityID", "Name", electrician.CItyFID);
            return View(electrician);
        }
    }
}
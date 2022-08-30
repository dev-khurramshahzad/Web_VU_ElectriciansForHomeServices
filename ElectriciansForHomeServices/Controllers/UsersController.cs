using ElectriciansForHomeServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectriciansForHomeServices.Controllers
{
    public class UsersController : Controller
    {
        private dbModel db = new dbModel();
        // GET: Users
        public ActionResult Index()
        {
            return View();
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
                    Session["LoggedinUser"] = check;
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
                    Session["LoggedinUser"] = check;
                    return Redirect("/Users/ElectriciansHome");
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

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using chanchos.Models;

namespace chanchos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
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

        //[HttpGet]
        //public ActionResult viewProfile()
        //{
        //    ViewBag.Message = "Bawal to purchase:";

        //    return View("viewProfile");
        //}

        //[HttpPost]
        public ActionResult viewProfile(User c)
        {
            User cp = new User()
            {
                name = "Liyana",
                age = 19,
                address = "No.99, Jln Mawar",
                phoneNo = "012345678"

            };

            return View(cp);


        }
    }
}
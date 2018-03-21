using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using chanchos.Models;

namespace chanchos.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult viewProfile()
        {

            Customer C = new Customer();
            C.name = " GEE";
            C.age = 21;


            return View(C);
        }
    }
}
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

        public ActionResult addCustomer()
        {
            return View();
        }


        public ActionResult viewProfile(Customer C)
        {

            return View("viewProfile");
        }
    }
}
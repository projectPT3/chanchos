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
            C.phoneNo = "01123235315";
            C.address = " No 155, Felda Palong Tiga.";


            return View(C);
        }
    }
}
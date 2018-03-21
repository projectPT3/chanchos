using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using chanchos.Models;

namespace chanchos.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult makeOrder()
        {
            return View("OrderForm");
        }

        public ActionResult makeOrder(Order o)
        {
            Order O = new Order();
            return View(O);
        }
    }
}
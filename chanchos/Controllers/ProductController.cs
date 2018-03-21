using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using chanchos.Models;

namespace chanchos.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult addProduct()
        {
            return View("addProductForm");
        }


        public ActionResult addProduct(Product p)
        {
            Product pp = new Product()
            {
                pid = "p001",
                pname = "basikal",
                price = 30.00
            };

            return View(pp);

        }
    }
}
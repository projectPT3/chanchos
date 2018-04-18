﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using chanchos.Models;

namespace chanchos.Controllers
{
    public class ProductController : Controller
    {
        private string pid;
        private string pname;
        private double price;

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult addProduct()
        {
            return View("addProduct");
        }

        [HttpPost]
        public ActionResult ViewProduct(Product p)
        {
            


                pid = p.pid;
                pname = p.pname;
                price = p.price;
           

            return View(p);

        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.IO;
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
            return View("addProduct");
        }

        [HttpPost]
        public ActionResult addProduct(Product p)
        {
            string fileName = Path.GetFileNameWithoutExtension(p.ImageFile.FileName);
            string extension = Path.GetExtension(p.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            p.ProductImage = "~/image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/image/"), fileName);
            p.ImageFile.SaveAs(fileName);
            using (databaseChanchosEntities db = new databaseChanchosEntities())
            {
                db.Products.Add(p);
                db.SaveChanges();
            }
            ModelState.Clear();

            //    databaseChanchosEntities dbContext = new databaseChanchosEntities();
            //dbContext.Products.Add(p);
            //dbContext.SaveChanges();
            return View();

        }
    }
}
using System;
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
        [HttpGet]
        public ActionResult Index()
        {
            databaseChanchosEntities db = new databaseChanchosEntities();
            var productList = db.Products.ToList();
            var pList = db.Products.ToList();
            return View(pList);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
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
            using (databaseChanchosEntities dl = new databaseChanchosEntities())
            {
                dl.Products.Add(p);
                dl.SaveChanges();
            }
            ModelState.Clear();

            //    databaseChanchosEntities dbContext = new databaseChanchosEntities();
            //dbContext.Products.Add(p);
            //dbContext.SaveChanges();
            return View();

        }
    }
}
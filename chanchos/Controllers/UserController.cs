using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using chanchos.Models;

namespace chanchos.Controllers
{
    public class UserController : Controller
    {
        // GET: Customers
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {

            //for user management 
            databaseChanchosEntities db = new databaseChanchosEntities();
            var userList = db.ChanchosUsers.ToList();  
            var uList = db.ChanchosUsers.ToList();
            return View(uList);
          
        }

        [Authorize(Roles = "Admin,RegisteredUser")]
        public ActionResult ViewProfile()
        {

            return View();
        }



       



    }
}
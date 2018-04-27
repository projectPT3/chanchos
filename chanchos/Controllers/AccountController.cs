using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using chanchos.Models;
using System.Web.Security;

namespace chanchos.Controllers
{

    [AllowAnonymous]
    public class AccountController : Controller
    {
        //GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(ChanchosUser au)
        {
            //connect to database 
            //databaseChanchosEntities _dbContext = new databaseChanchosEntities();
            //compare CU vs chanchosUser Table
            //ChanchosUser match = (from a in _dbContext.ChanchosUsers
            //                      where (a.name == CU.name && a.passwords == a.passwords)
            //                      select a).SingleOrDefault();
            //check existent
            databaseChanchosEntities db = new databaseChanchosEntities();
            var match = (from x in db.ChanchosUsers
                         where (x.name == au.name && x.passwords == au.passwords)
                         select x).SingleOrDefault();

            if (match==null)
            {
                ViewBag.errMessage = "Invalid Login";
                return View();
            }

            else
            {
                FormsAuthentication.SetAuthCookie(au.name, false);
                return RedirectToAction("Index", "Home");
            }

          
        
     
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
            //  return View();
        }

    }
}
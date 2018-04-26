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
        public ActionResult Login(ChanchosUser CU)
        {
            //connect to database 
            databaseChanchosEntities _dbContext = new databaseChanchosEntities();
            //compare CU vs chanchosUser Table
            ChanchosUser match = (from x in _dbContext.ChanchosUsers
                                  where (x.name == CU.name && x.passwords == x.passwords)
                                  select x).SingleOrDefault();
            //check existent

            if(match==null)
            {
                ViewBag.errMessage = "Invalid Login";
                return View();
            }

            else
            {
                FormsAuthentication.SetAuthCookie(CU.name, false);
                return RedirectToAction("Index", "Home");
            }

            return View();
        
     
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
            //  return View();
        }

    }
}
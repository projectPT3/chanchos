using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorldMVC.Models;
using HelloWorldMVC.ViewModels;

namespace HelloWorldMVC.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult addPerson()
        {
            return View("FormAddPerson");
        }
        
        [HttpPost]
        public ActionResult addPerson(Person p, Employer e)
        {
            /*Person p = new Person()
            {
                name = ,
                yob = 1996

            };
            Employer e = new Employer
            {
                companyName = "Cemerlang Sdn Bhd",
                address = "Taman Universiti, Skudai",
                contactNum = 0123456789
            };*/

            p.calculate();

            PersonaddPersonViewModels pe = new PersonaddPersonViewModels
            {
                person = p,
                emp = e
            };
            return View(pe);
        }

        
      
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorldMVC.Models
{
    public class Employer
    {
        public string companyName { get; set; }
        public string address { get; set; }
        public int contactNum { get; set;  }

        public void display ()
        {

        }
    }
}
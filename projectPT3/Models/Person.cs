using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorldMVC.Models
{
    public class Person
    {
        public string name { get; set; }
        public int yob { get; set; }
        public int age { get; set; }
        public string category { get; set; }

        public void calculate()
        {
            age = DateTime.Today.Year - yob;

            if (age < 13)
            {
                category = "child";
            }
            else if (age > 12 && age < 20)
            {
                category = "teenager";
            }
           else if (age > 19 && age < 60)
            {
                category = "adult";
            }
            else if (age > 59)
            {
                category = "senior";
            }
            else { }
        }
    }
}
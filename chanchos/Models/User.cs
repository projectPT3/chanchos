﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chanchos.Models
{
    public class User
    {
     
        public int userId { get; set; }
        public string name { get; set; }
        public string passwords { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public string phoneNo { get; set; }
        public string Roles { get; set; }
    }
}


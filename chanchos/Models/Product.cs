using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace chanchos.Models
{
    public class Product
    {
        [Required]
        public string pid { get; set; }
        [Required]
        public string pname { get; set; }
        [Required]
        public double price { get; set; }


        
    }
}
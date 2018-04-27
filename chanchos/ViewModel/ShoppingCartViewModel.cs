using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using chanchos.Models;
namespace chanchos.ViewModel
{
    public class ShoppingCartViewModel
    {
        [Key]
        public List<cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}
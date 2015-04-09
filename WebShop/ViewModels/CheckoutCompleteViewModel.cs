using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop.Models;

namespace WebShop.ViewModels
{
    public class CheckoutCompleteViewModel
    {
        public Order Order { get; set; }
        public Product RecommendedProduct { get; set; }
        public List<Product> Products { get; set; }
        public bool IsWebOrder { get; set; }
    }
}
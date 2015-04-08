using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop.Models;

namespace WebShop.ViewModels
{
    public class CheckoutCompleteViewModel
    {
        public int OrderId { get; set; }
        public Product RecommendedProduct { get; set; }
    }
}
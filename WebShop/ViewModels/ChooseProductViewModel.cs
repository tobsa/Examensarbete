using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop.Models;

namespace WebShop.ViewModels
{
    public class ChooseProductViewModel
    {
        public Order Order { get; set; }
        public List<Product> Products { get; set; }
        public Product ItemRecommendedProduct { get; set; }

        public Product UserRecommendedProduct { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop.Models;

namespace WebShop.ViewModels
{
    public class StoreViewModel
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }

        public List<Product> GetProducts(int categoryId)
        {
            return Products.Where(x => x.CategoryId == categoryId).ToList();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebShop.Models;
using WebShop.ViewModels;

namespace WebShop.Controllers
{
    public class StoreController : Controller
    {
        ProductContext db = new ProductContext();

        // GET: /Store/
        public ActionResult Index()
        {
            var model = new StoreViewModel();
            var source = db.Products.Where(x => !x.IsInStore).ToList();

            Random rand = new Random();
            if (Session["ProductSeed"] != null)
            {
                rand = new Random(int.Parse(Session["ProductSeed"].ToString()));
            }
            else
            {
                int seed = rand.Next(1000);
                Session["ProductSeed"] = seed;
                rand = new Random(seed);
            }

            model.Products = source.OrderBy(item => rand.Next()).ToList();
            model.Categories = db.Categories.ToList();           

            return View(model);
        }

        // GET: /Store/Browse?category=Fabrics
        public ActionResult Browse(string category)
        {
            var categoryModel = db.Categories.Include("Products").Single(g => g.Name == category);
            return View(categoryModel);
        }

        // GET: /Store/Details/5
        public ActionResult Details(int id)
        {
            var product = db.Products.Find(id);
            return View(product);
        }

    }
}
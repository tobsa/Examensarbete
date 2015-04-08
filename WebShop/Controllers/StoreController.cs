using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            model.Products = db.Products.ToList();
            model.Categories = db.Categorys.ToList();

            return View(model);
        }

        // GET: /Store/Browse?category=Fabrics
        public ActionResult Browse(string category)
        {
            var categoryModel = db.Categorys.Include("Products").Single(g => g.Name == category);
            return View(categoryModel);
        }

        // GET: /Store/Details/5
        public ActionResult Details(int id)
        {
            var product = db.Products.Find(id);
            return View(product);
        }

        //
        // GET: /Store/GenreMenu
        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var genres = db.Categorys.ToList();

            return PartialView(genres);
        }

    }
}
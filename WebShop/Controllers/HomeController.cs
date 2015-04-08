using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebShop.Models;
using WebShop.ViewModels;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        ProductContext db = new ProductContext();

        public ActionResult Index()
        {
            var model = new StoreViewModel();
            model.Categories = db.Categorys.ToList();
            model.Products = db.Products.ToList();

            return View(model);
        }
    }
}
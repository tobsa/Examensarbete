using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        ProductContext db = new ProductContext();

        public ActionResult Index()
        {
            var products = db.Products.ToList();            
            return View(products);
        }
    }
}
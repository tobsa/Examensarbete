using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebShop.Models;
using WebShop.ViewModels;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            bool isWebStore = Session["StoreType"] == null || (bool)Session["StoreType"] == true;

            return View(isWebStore);
        }

        public ActionResult StoreType(bool type)
        {
            Session["StoreType"] = type;
            return RedirectToAction("Index", "Store", null);
        }
    }
}
using System.Web.Mvc;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            bool isWebStore = Session["StoreType"] == null || (bool)Session["StoreType"];

            return View(isWebStore);
        }

        public ActionResult Instructions(bool type)
        {
            Session["StoreType"] = type;

            return type ? View("WebstoreInstruction") : View("RetailInstruction");
        }

        public ActionResult StoreType()
        {
            return RedirectToAction("Index", "Store", null);
        }
    }
}
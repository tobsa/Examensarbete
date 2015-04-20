using System.Linq;
using System.Web.Mvc;
using WebShop.Models;
using WebShop.ViewModels;

namespace WebShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        ProductContext db = new ProductContext();

        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(HttpContext);

            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddToCartFromIndex(int id)
        {
            var cart = ShoppingCart.GetCart(HttpContext);

            ar addedProduct = db.Products.Single(product => product.ProductId == id);

            bool foundItemInCart = cart.GetCartItems().Exists(x => x.ProductId == id);
            if (foundItemInCart)
                return Json("itemexists");

            cart.AddToCart(addedProduct);

            if (cart.GetCount() >= 5)
                return Json("redirect");

            return Json("reload");
        }

        // GET: /Store/AddToCartFromDetails/5
        public ActionResult AddToCartFromDetails(int id)
        {
            var cart = ShoppingCart.GetCart(HttpContext);

            var addedProduct = db.Products.Single(product => product.ProductId == id);
            bool foundItemInCart = cart.GetCartItems().Exists(x => x.ProductId == id);
            if (!foundItemInCart)
                cart.AddToCart(addedProduct);

            return RedirectToAction("Details", "Store", new { id = id });
        }

        public ActionResult RemoveFromCart(int id)
        {
            var cart = ShoppingCart.GetCart(HttpContext);

            cart.RemoveFromCart(id);

            return RedirectToAction("Index");
        }

        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(HttpContext);

            ViewData["CartCount"] = cart.GetCount();

            return PartialView("CartSummary");
        }
    }
}
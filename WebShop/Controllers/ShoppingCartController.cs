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
        // GET: /Store/AddToCartFromIndex/5
        public ActionResult AddToCartFromIndex(int id)
        {
            AddToCart(id, "", "");

            var cart = ShoppingCart.GetCart(HttpContext);

            if (cart.GetCount() >= 5)
                return Json("redirect");

            return Json("reload");
        }

        // GET: /Store/AddToCartFromDetails/5
        public ActionResult AddToCartFromDetails(int id)
        {
            return AddToCart(id, "Index", "Store");
        }

        private ActionResult AddToCart(int id, string actionName, string controllerName)
        {
            var addedProduct = db.Products.Single(product => product.ProductId == id);

            var cart = ShoppingCart.GetCart(HttpContext);

            bool foundItemInCart = cart.GetCartItems().Exists(x => x.ProductId == id);
            if (!foundItemInCart)
                cart.AddToCart(addedProduct);

            if (cart.GetCount() == 5)
                return RedirectToAction("Index", "ShoppingCart");

            return RedirectToAction(actionName, controllerName);
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
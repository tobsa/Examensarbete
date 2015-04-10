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
            var cart = ShoppingCart.GetCart(this.HttpContext);

            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            return View(viewModel);
        }

        // GET: /Store/AddToCartFromIndex/5
        public ActionResult AddToCartFromIndex(int id)
        {
            return AddToCart(id, "Index", "Store");
        }

        // GET: /Store/AddToCartFromDetails/5
        public ActionResult AddToCartFromDetails(int id)
        {
            return AddToCart(id, "Index", "ShoppingCart");
        }

        private ActionResult AddToCart(int id, string actionName, string controllerName)
        {
            var addedAlbum = db.Products.Single(product => product.ProductId == id);

            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(addedAlbum);

            return RedirectToAction(actionName, controllerName);
        }


        public ActionResult RemoveFromCart(int id)
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.RemoveFromCart(id);

            return RedirectToAction("Index");
        }

        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();

            return PartialView("CartSummary");
        }
    }
}
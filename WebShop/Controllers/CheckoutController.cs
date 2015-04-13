using System;
using System.Linq;
using System.Web.Mvc;
using WebShop.Models;
using WebShop.ViewModels;

namespace WebShop.Controllers
{
    public class CheckoutController : Controller
    {
        private ProductContext db = new ProductContext();

        // GET: /Checkout/AddressAndPayment
        public ActionResult AddressAndPayment()
        {
            var cart = ShoppingCart.GetCart(HttpContext);

            //if (cart.GetCount() < 5)
            //    return RedirectToAction("Index", "ShoppingCart");

            return View();
        }

        public ActionResult ChooseProduct(int recommendedProductId, int orderId, int selectedProductId)
        {
            var result = new RecommendationResult();
            result.OrderId = orderId;
            result.RecommendedProductID = recommendedProductId;
            result.SelectedProductID = selectedProductId;

            if (!db.RecommendationResults.ToList().Exists(x => x.OrderId == orderId))
            {
                db.RecommendationResults.Add(result);
                db.SaveChanges();
            }

            return View("CompleteFinished");
        }

        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);

            try
            {
                var username = values["Username"];
                var cart = ShoppingCart.GetCart(HttpContext);
                
                order.Username = username;
                order.OrderDate = DateTime.Now;
                order.Total = cart.GetTotal();
                order.IpAddress = Request.UserHostAddress;
                order.IsWebOrder = Session["StoreType"] == null || (bool)Session["StoreType"];

                //var users = db.Users.ToList();
                //var orders = db.Orders.ToList();



                //if (!users.Exists(x => x.Username == username) || orders.Exists(x => x.Username == username))
                //    return View(order);

                db.Orders.Add(order);
                db.SaveChanges();

                cart.CreateOrder(order);

                var random = new Random();
                var products = db.Products.ToList();
                var model = new CheckoutCompleteViewModel();

                var inStoreItems = products.Where(x => x.IsInStore).ToList();

                model.Order = order;
                model.RecommendedProduct = inStoreItems[random.Next(inStoreItems.Count)];
                model.Products = inStoreItems;
                model.IsWebOrder = order.IsWebOrder;

                return View("Complete", model);          
            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }
    }
}

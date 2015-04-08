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
            return View();
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

                var cart = ShoppingCart.GetCart(this.HttpContext);
                
                order.Username = username;
                order.OrderDate = DateTime.Now;
                order.Total = cart.GetTotal();

                db.Orders.Add(order);
                db.SaveChanges();

                cart.CreateOrder(order);

                var random = new Random();
                var products = db.Products.ToList();
                var model = new CheckoutCompleteViewModel();
                model.OrderId = order.OrderId;
                model.RecommendedProduct = products[random.Next(products.Count)];

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

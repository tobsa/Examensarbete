using System;
using System.Linq;
using System.Web.Mvc;
using WebShop.Models;

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

                return RedirectToAction("Complete", new { id = order.OrderId });
            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }

        // GET: /Checkout/Complete
        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = db.Orders.Any(o => o.OrderId == id);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}

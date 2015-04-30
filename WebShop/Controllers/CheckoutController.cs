using System;
using System.Linq;
using System.Web.Mvc;
using WebShop.Models;
using WebShop.RecommendationSystem;
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

            if (cart.GetCount() < 5)
                return RedirectToAction("Index", "ShoppingCart");

            SetViewBag(null);
            return View();
        }

        public ActionResult ChooseProduct(int itemRecommendedProductId, int userRecommendedProductId, int orderId, int selectedProductId)
        {
            var result = new RecommendationResult();
            result.OrderId = orderId;
            result.SelectedProductId = selectedProductId;
            result.ItemRecommendedProductId = itemRecommendedProductId;
            result.UserRecommendedProductId = userRecommendedProductId;

            if (!db.RecommendationResults.ToList().Exists(x => x.OrderId == orderId))
            {
                db.RecommendationResults.Add(result);
                db.SaveChanges();
            }

            return View("CompleteFinished", orderId);
        }

        public ActionResult ProcessOrder(int itemRecommendedProductId, int userRecommendedProductId, int orderId)
        {
            var model = new ChooseProductViewModel();
            model.Order = db.Orders.ToList().Single(x => x.OrderId == orderId);
            model.Products = db.Products.Where(x => x.IsInStore).ToList();
            model.ItemRecommendedProduct = db.Products.ToList().Single(x => x.ProductId == itemRecommendedProductId);
            model.UserRecommendedProduct = db.Products.ToList().Single(x => x.ProductId == userRecommendedProductId);

            return View("ChooseProduct", model);
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

                var value = values["Kön"];
                if (!string.IsNullOrEmpty(value))
                    order.Sex = value.Equals("Man");

                //var users = db.Users.ToList();
                //var orders = db.Orders.ToList();

                //if (!users.Exists(x => x.Username == username) || orders.Exists(x => x.Username == username))
                //{
                //    SetViewBag(order);
                //    return View(order);
                //}
                    

                db.Orders.Add(order);
                db.SaveChanges();

                cart.CreateOrder(order);

                var products = db.Products.ToList();
                var model = new CheckoutCompleteViewModel();

                var inStoreItems = products.Where(x => x.IsInStore).ToList();

                RecommendationCalculator calculator = new RecommendationCalculator();
                int itemKNearest = 12;
                int userKNearest = 7;
                var itemRecommendedProduct = calculator.RecommendProductItemBased(order, new CosineSimilarity(), itemKNearest);
                var userRecommendedProduct = calculator.RecommendProductUserBased(order, new CosineSimilarity(),userKNearest);

                // If we can't find a recommended product then choose a random product instead to recommend
                if (itemRecommendedProduct == null)
                    model.ItemRecommendedProduct = null;
                else 
                    model.ItemRecommendedProduct = itemRecommendedProduct;

                model.UserRecommendedProduct = userRecommendedProduct;

                model.Order = order;
                model.Products = inStoreItems;
                model.IsWebOrder = order.IsWebOrder;

                return View("Complete", model);
            }
            catch
            {
                SetViewBag(order);
                //Invalid - redisplay with errors
                return View(order);
            }
        }

        private void SetViewBag(Order order)
        {
            if (order == null)
            {
                ViewBag.SelectedItem1 = false;
                ViewBag.SelectedItem2 = false;
            }
            else
            {
                ViewBag.SelectedItem1 = order.Sex != null && (bool)order.Sex;
                ViewBag.SelectedItem2 = order.Sex != null && !(bool)order.Sex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebShop.Models;
using WebShop.RecommendationSystem;

namespace WebShopTest
{
    [TestClass]
    public class RecommendationSystemTest
    {
        ProductContext db = new ProductContext();

        [TestMethod]
        public void ItemBasedLimitedDataEvaluateKValue()
        {
            var products = db.Products.ToList();
            var orders = db.Orders.ToList();
            var orderDetails = db.OrderDetails.ToList();
            var recommendationResults = db.RecommendationResults.ToList();

            ISimilarityCalculable similarityCalculable = new CosineSimilarity();
            using (StreamWriter w = File.AppendText(@"c:\TestResult.txt"))
            {
                w.WriteLine("Item-based test with limited data" + DateTime.Now);

                for (int kNearest = 1; kNearest < products.Count; kNearest++)
                {
                    int firstHalfCorrect = 0;
                    int secondHalfCorrect = 0;


                    for (int j = 0; j < orders.Count; j++)
                    {
                        Order order = orders[j];

                        List<Order> availableOrders = orders.GetRange(0, j + 1);

                        List<OrderDetail> availableOrderDetails =
                            (from o in availableOrders
                             from od in orderDetails
                             where od.OrderId == o.OrderId
                             select od).ToList();

                        List<RecommendationResult> availableRecommendationResults =
                            (from o in availableOrders
                             from rr in recommendationResults
                             where rr.OrderId == o.OrderId
                             select rr).ToList();

                        availableOrders.Remove(order);
                        availableRecommendationResults.Remove(
                            availableRecommendationResults.Find(rr => rr.OrderId == order.OrderId));

                        RecommendationCalculator calc = new RecommendationCalculator(@"c:\testLog.txt", products,
                            availableOrders, availableOrderDetails, availableRecommendationResults);

                        Product product = calc.RecommendProductItemBased(order, similarityCalculable, kNearest);

                        if (product.ProductId == recommendationResults[j].SelectedProductId)
                        {
                            if (j < orders.Count/2)
                                firstHalfCorrect++;
                            else
                                secondHalfCorrect++;
                        }
                    }
                    w.WriteLine("K: " + kNearest + " \tCorrect: " + (firstHalfCorrect + secondHalfCorrect) + "\tOrders: " + orders.Count + "\tPercentage: " +
                                Math.Round((firstHalfCorrect + secondHalfCorrect) / (double)orders.Count),3);

                    w.Flush();

                }
            }
            Assert.IsTrue(true);
        }

        //[TestMethod]
        //public void ItemBasedFullDataEvaluateKValue()
        //{
        //    var products = db.Products.ToList();
        //    var orders = db.Orders.ToList();
        //    var orderDetails = db.OrderDetails.ToList();
        //    var recommendationResults = db.RecommendationResults.ToList();

        //    ISimilarityCalculable similarityCalculable = new CosineSimilarity();
        //    using (StreamWriter w = File.AppendText(@"c:\TestResult.txt"))
        //    {
        //        w.WriteLine("Item-based test" + DateTime.Now);

        //        for (int kNearest = 1; kNearest < products.Count; kNearest++)
        //        {
        //            int firstHalfCorrect = 0;
        //            int secondHalfCorrect = 0;


        //            for (int j = 0; j < orders.Count; j++)
        //            {
        //                Order order = orders[j];

        //                List<Order> availableOrders = orders.ToList();

        //                List<OrderDetail> availableOrderDetails =
        //                    (from o in availableOrders
        //                     from od in orderDetails
        //                     where od.OrderId == o.OrderId
        //                     select od).ToList();

        //                List<RecommendationResult> availableRecommendationResults =
        //                    (from o in availableOrders
        //                     from rr in recommendationResults
        //                     where rr.OrderId == o.OrderId
        //                     select rr).ToList();

        //                availableOrders.Remove(order);
        //                availableRecommendationResults.Remove(
        //                    availableRecommendationResults.Find(rr => rr.OrderId == order.OrderId));

        //                RecommendationCalculator calc = new RecommendationCalculator(@"c:\testLog.txt", products,
        //                    availableOrders, availableOrderDetails, availableRecommendationResults);

        //                Product product = calc.RecommendProductItemBased(order, similarityCalculable, kNearest);

        //                if (product.ProductId == recommendationResults[j].SelectedProductId)
        //                {
        //                    if (j < orders.Count / 2)
        //                        firstHalfCorrect++;
        //                    else
        //                        secondHalfCorrect++;
        //                }
        //            }
        //            w.WriteLine("K: " + kNearest + " \tFirstHalf: " + firstHalfCorrect + " \tSecondHalf: " +
        //                        secondHalfCorrect + "\tOrders: " + orders.Count + "\tPercentage: " +
        //                        (firstHalfCorrect + secondHalfCorrect) / (double)orders.Count);

        //            w.Flush();

        //        }
        //    }
        //    Assert.IsTrue(true);
        //}

        [TestMethod]
        public void UserBasedLimitedDataEvaluateKValue()
        {
            var products = db.Products.ToList();
            var orders = db.Orders.ToList();
            var orderDetails = db.OrderDetails.ToList();
            var recommendationResults = db.RecommendationResults.ToList();

            ISimilarityCalculable similarityCalculable = new CosineSimilarity();

            using (StreamWriter w = File.AppendText(@"c:\TestResult.txt"))
            {
                w.WriteLine("User-based test with limited data " + DateTime.Now);

                for (int kNearest = 1; kNearest < orders.Count; kNearest++)
                {
                    int firstHalfCorrect = 0;
                    int secondHalfCorrect = 0;

                    for (int j = 0; j < orders.Count; j++)
                    {
                        Order order = orders[j];

                        List<Order> availableOrders = orders.GetRange(0, j + 1);

                        List<OrderDetail> availableOrderDetails =
                            (from o in availableOrders
                             from od in orderDetails
                             where od.OrderId == o.OrderId
                             select od).ToList();

                        List<RecommendationResult> availableRecommendationResults =
                            (from o in availableOrders
                             from rr in recommendationResults
                             where rr.OrderId == o.OrderId
                             select rr).ToList();

                        availableOrders.Remove(order);
                        availableRecommendationResults.Remove(availableRecommendationResults.Find(rr => rr.OrderId == order.OrderId));

                        RecommendationCalculator calc = new RecommendationCalculator(@"c:\testLog.txt", products, availableOrders, availableOrderDetails, availableRecommendationResults);

                        Product product = calc.RecommendProductUserBased(order, similarityCalculable, kNearest);

                        if (product.ProductId == recommendationResults[j].SelectedProductId)
                        {
                            if (j < orders.Count/2)
                                firstHalfCorrect++;
                            else
                                secondHalfCorrect++;
                        }
                    }
                    w.WriteLine("K: " + kNearest + " \tCorrect: " + (firstHalfCorrect + secondHalfCorrect) + "\tOrders: " + orders.Count + "\tPercentage: " + Math.Round((firstHalfCorrect + secondHalfCorrect) / (double)orders.Count),3);

                    w.Flush();
                }
            }
            Assert.IsTrue(true);
        }

        //[TestMethod]
        //public void UserBasedFullEvaluateKValue()
        //{
        //    var products = db.Products.ToList();
        //    var orders = db.Orders.ToList();
        //    var orderDetails = db.OrderDetails.ToList();
        //    var recommendationResults = db.RecommendationResults.ToList();

        //    ISimilarityCalculable similarityCalculable = new CosineSimilarity();

        //    using (StreamWriter w = File.AppendText(@"c:\TestResult.txt"))
        //    {
        //        w.WriteLine("User-based test " + DateTime.Now);

        //        for (int kNearest = 1; kNearest < orders.Count; kNearest++)
        //        {
        //            int firstHalfCorrect = 0;
        //            int secondHalfCorrect = 0;

        //            for (int j = 0; j < orders.Count; j++)
        //            {
        //                Order order = orders[j];

        //                List<Order> availableOrders = orders.ToList();

        //                List<OrderDetail> availableOrderDetails =
        //                    (from o in availableOrders
        //                     from od in orderDetails
        //                     where od.OrderId == o.OrderId
        //                     select od).ToList();

        //                List<RecommendationResult> availableRecommendationResults =
        //                    (from o in availableOrders
        //                     from rr in recommendationResults
        //                     where rr.OrderId == o.OrderId
        //                     select rr).ToList();

        //                availableOrders.Remove(order);
        //                availableRecommendationResults.Remove(availableRecommendationResults.Find(rr => rr.OrderId == order.OrderId));

        //                RecommendationCalculator calc = new RecommendationCalculator(@"c:\testLog.txt", products, availableOrders, availableOrderDetails, availableRecommendationResults);

        //                Product product = calc.RecommendProductUserBased(order, similarityCalculable, kNearest);

        //                if (product.ProductId == recommendationResults[j].SelectedProductId)
        //                {
        //                    if (j < orders.Count / 2)
        //                        firstHalfCorrect++;
        //                    else
        //                        secondHalfCorrect++;
        //                }
        //            }
        //            w.WriteLine("K: " + kNearest + " \tFirstHalf: " + firstHalfCorrect + " \tSecondHalf: " + secondHalfCorrect + "\tOrders: " + orders.Count + "\tPercentage: " + (firstHalfCorrect + secondHalfCorrect) / (double)orders.Count);

        //            w.Flush();
        //        }
        //    }
        //    Assert.IsTrue(true);
        //}
    }
}

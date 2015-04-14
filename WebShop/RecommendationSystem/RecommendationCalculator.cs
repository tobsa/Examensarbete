using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop.Models;

namespace WebShop.RecommendationSystem
{
    public class RecommendationCalculator
    {
        private ProductContext db = new ProductContext();

        public Product RecommendProduct(Order order, ISimilarityCalculable calculable)
        {
            var purchaseData = GetPurchaseData();

            var data1 = ConvertToPurchaseData(order);

            foreach (var data2 in purchaseData)
            {
                if (data1.OrderID != data2.OrderID)
                    data2.Similarity = calculable.CalculateSimilarity(data1.Data, data2.Data);
            }

            var result = FindRecommendationResult(purchaseData);

            if (result == null)
                return null;

            return db.Products.ToList().SingleOrDefault(x => x.ProductId == result.SelectedProductID);
        }

        protected RecommendationResult FindRecommendationResult(List<PurchaseData> purchaseData)
        {
            var bestData = GetDataWithBestSimilarity(purchaseData);
            
            var results = db.RecommendationResults.ToList();
            var foundResult = results.SingleOrDefault(x => x.OrderId == bestData.OrderID);

            return foundResult;
        }

        protected PurchaseData GetDataWithBestSimilarity(List<PurchaseData> purchaseData)
        {
            var bestData = purchaseData.First();

            foreach (var data in purchaseData)
            {
                if (data.Similarity >= bestData.Similarity)
                    bestData = data;
            }

            return bestData;
        }

        protected List<PurchaseData> GetPurchaseData()
        {
            var products = db.Products.ToList();
            var orders = db.Orders.ToList();

            PurchaseData.ProductIDs = new int[products.Count];
            for (int i = 0; i < products.Count; i++)
                PurchaseData.ProductIDs[i] = products[i].ProductId;

            List<PurchaseData> purchaseData = new List<PurchaseData>();
            foreach (var order in orders)
                purchaseData.Add(ConvertToPurchaseData(order));

            return purchaseData;
        }

        protected PurchaseData ConvertToPurchaseData(Order order)
        {
            var products = db.Products.ToList();
            var orderDetails = db.OrderDetails.ToList();

            PurchaseData data = new PurchaseData();
            data.OrderID = order.OrderId;
            data.Data = new int[products.Count];

            for (int i = 0; i < PurchaseData.ProductIDs.Length; i++)
            {
                foreach (var orderDetail in orderDetails)
                {
                    if (order.OrderId == orderDetail.OrderId && orderDetail.ProductId == PurchaseData.ProductIDs[i])
                    {
                        data.Data[i] = 1;
                    }
                }
            }

            return data;
        }

        
    }
}
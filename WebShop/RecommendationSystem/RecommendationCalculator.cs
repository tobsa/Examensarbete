using System.Collections.Generic;
using System.Linq;
using WebShop.Models;

namespace WebShop.RecommendationSystem
{
    public class RecommendationCalculator
    {
        private const int KNearest = 2;
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

            var result = FindRecommendation(purchaseData);

            if (result == -1)
                return null;

            return db.Products.ToList().SingleOrDefault(x => x.ProductId == result);
        }

        private int FindRecommendation(List<PurchaseData> purchaseData)
        {
            List<PurchaseData> sortedList;

            if (purchaseData.Count >= KNearest)
            {
                sortedList = purchaseData.OrderByDescending(purchase => purchase.Similarity).ToList().GetRange(0, KNearest);
            }
            else
            {
                sortedList = purchaseData.OrderByDescending(purchase => purchase.Similarity).ToList();
            }

            double similaritySum = sortedList.Sum(purchase => purchase.Similarity);

            foreach (var purchase in sortedList)
            {
                purchase.Influence = purchase.Similarity / similaritySum;
            }

            var products = new Dictionary<int, double>();
            var tempResult = db.RecommendationResults.ToList();

            foreach (var purchase in sortedList)
            {
                foreach (var recommendationResult in tempResult.Where(r => r.OrderId == purchase.OrderID))
                {
                    if(products.ContainsKey(recommendationResult.SelectedProductID))
                        products[recommendationResult.SelectedProductID] += purchase.Influence;
                    else
                        products.Add(recommendationResult.SelectedProductID, purchase.Influence);
                }
            }

            return products.OrderByDescending(product => product.Value).First().Key;
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

        private List<PurchaseData> GetPurchaseData()
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

        private PurchaseData ConvertToPurchaseData(Order order)
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
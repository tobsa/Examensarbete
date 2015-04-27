using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebShop.Models;

namespace WebShop.RecommendationSystem
{
    public struct ItemData
    {
        public int ProductId;
        public int[] PurchasedByCustomer;
        public List<ItemSimilarity> SimilarityVector;
    }

    public struct ItemSimilarity
    {
        public int ProductId;
        public double Similarity;
    }

    public class RecommendationCalculator
    {
        private const int KNearest = 12;
        private ProductContext db = new ProductContext();

        private List<Product> _products;

        public RecommendationCalculator()
        {
            _products = db.Products.ToList();

            PurchaseData.ProductIDs = new int[_products.Count];
            for (int i = 0; i < _products.Count; i++)
                PurchaseData.ProductIDs[i] = _products[i].ProductId;
        }

        public Product RecommendProductUserBased(Order order, ISimilarityCalculable calculable)
        {
            var purchaseData = GetPurchaseData();

            var data1 = ConvertToPurchaseData(order);

            foreach (var data2 in purchaseData)
            {
                if (data1.OrderID != data2.OrderID)
                    data2.Similarity = calculable.CalculateSimilarity(data1.Data, data2.Data);
            }

            var result = FindRecommendationUserBased(purchaseData, data1);

            if (result == -1)
                return null;

            return _products.ToList().SingleOrDefault(x => x.ProductId == result);
        }

        public Product RecommendProductItemBased(Order order, ISimilarityCalculable calculable)
        {
            var itemData = GetItemData();
            var currentPurchase = ConvertToPurchaseData(order);

            for (int i = 0; i < itemData.Count; i++)
            {
                var data1 = itemData[i];

                for (int j = 0; j < itemData.Count; j++)
                {
                    var similarity = new ItemSimilarity();
                    similarity.ProductId = itemData[j].ProductId;

                    if(j == i) continue;

                    var data2 = itemData[j];
                    similarity.Similarity = calculable.CalculateSimilarity(data1.PurchasedByCustomer, data2.PurchasedByCustomer);
                    data1.SimilarityVector.Add(similarity);
                }
            }

            var result = FindRecommendationItemBased(itemData, currentPurchase);

            if (result == -1)
                return null;

            return _products.ToList().SingleOrDefault(x => x.ProductId == result);
        }

        // TODO: Make this more effecient if needed
        private List<ItemData> GetItemData()
        {
            var purchaseData = GetPurchaseData();

            int numCustomers = db.Orders.Count();

            var chosenInStore = db.RecommendationResults.ToList();

            List<ItemData> itemSimilarity = new List<ItemData>();

            // For all products in the catalog
            for (int i = 0; i < PurchaseData.ProductIDs.Count(); i++)
            {
                ItemData itemData = new ItemData();
                itemData.PurchasedByCustomer = new int[numCustomers];
                itemData.SimilarityVector = new List<ItemSimilarity>();
                itemData.ProductId = PurchaseData.ProductIDs[i];
                
                for (int j = 0; j < purchaseData.Count; j++)
                {
                    itemData.PurchasedByCustomer[j] = purchaseData[j].Data[i];

                    // Add in store products
                    foreach (var product in chosenInStore)
                    {
                        if (purchaseData[j].OrderID == product.OrderId && product.SelectedProductID == itemData.ProductId)
                            itemData.PurchasedByCustomer[j] = 1;
                    }
                }
                itemSimilarity.Add(itemData);
            }
            return itemSimilarity;
        }

        private int FindRecommendationItemBased(List<ItemData> itemData, PurchaseData purchase)
        {
            List<int> purchaseProducts = new List<int>();

            for (int i = 0; i < purchase.Data.Length; i++)
                if (purchase.Data[i] == 1)
                    purchaseProducts.Add(PurchaseData.ProductIDs[i]);

            var recommendations = new Dictionary<int, double>();
            foreach (var product in itemData)
            {
                if (purchaseProducts.Contains(product.ProductId))
                {
                    // Get k-most similar items
                    var productSimilarities = product.SimilarityVector.OrderByDescending(item => item.Similarity).ToList().GetRange(0, KNearest);

                    foreach (var item in productSimilarities)
                    {
                        if (recommendations.ContainsKey(item.ProductId))
                            recommendations[item.ProductId] += item.Similarity;
                        else
                            recommendations.Add(item.ProductId, item.Similarity);
                    }
                }
            }
            var inStore = _products.Where(x => x.IsInStore).Select(product => product.ProductId).ToList();

            var sortedRecommendation = recommendations.OrderByDescending(product => product.Value);
            var filteredRecommendations = sortedRecommendation.Where(product => inStore.Contains(product.Key)).ToList();

            int recommendedProduct = -1; 

            if (filteredRecommendations.Count == 0)
            {
                recommendedProduct = inStore[new Random().Next(inStore.Count)];
                LogResult("\r\nItemBased", purchase.OrderID, recommendedProduct, true, filteredRecommendations);
                return recommendedProduct;
            }
                
            if (filteredRecommendations.First().Value == 0)
            {
                recommendedProduct = inStore[new Random().Next(inStore.Count)];
                LogResult("\r\nItemBased", purchase.OrderID, recommendedProduct, true, filteredRecommendations);
                return recommendedProduct;
            }                

            recommendedProduct = filteredRecommendations.First().Key;
            LogResult("\r\nItemBased", purchase.OrderID, recommendedProduct, false, filteredRecommendations);
            return recommendedProduct;
        }
        private int FindRecommendationUserBased(List<PurchaseData> purchaseData, PurchaseData p)
        {
            List<PurchaseData> purchases;

            // Use k-nearest if possible
            if (purchaseData.Count >= KNearest)
                purchases = purchaseData.OrderByDescending(purchase => purchase.Similarity).ToList().GetRange(0, KNearest);
            // else as many as possible
            else
                purchases = purchaseData.OrderByDescending(purchase => purchase.Similarity).ToList();

            // Calculate similarity
            double similaritySum = purchases.Sum(purchase => purchase.Similarity);
            foreach (var purchase in purchases)
                purchase.Influence = purchase.Similarity / similaritySum;


            // Sum weighted similarity for each product
            var recommendations = new Dictionary<int, double>();
            var chosenInStore = db.RecommendationResults.ToList();
            foreach (PurchaseData purchase in purchases)
            {
                foreach (var recommendationResult in chosenInStore.Where(r => r.OrderId == purchase.OrderID))
                {
                    if(recommendations.ContainsKey(recommendationResult.SelectedProductID))
                        recommendations[recommendationResult.SelectedProductID] += purchase.Influence;
                    else
                        recommendations.Add(recommendationResult.SelectedProductID, purchase.Influence);
                }
            }

            var sortedRecommendations = recommendations.OrderByDescending(product => product.Value).ToList();

            int recommendedProduct = -1;

            // TODO: Make this look if similarity is 0 instead
            if (sortedRecommendations.Count == 0)
            {
                Random random = new Random();
                var instoreProducts = _products.Where(x => x.IsInStore).ToList();

                recommendedProduct = instoreProducts[random.Next(instoreProducts.Count)].ProductId;
                LogResult("UserBased", p.OrderID, recommendedProduct, true, sortedRecommendations);
                return recommendedProduct;
            }

            LogResult("UserBased", p.OrderID, sortedRecommendations[0].Key, false, sortedRecommendations);
            recommendedProduct = sortedRecommendations[0].Key;

            return recommendedProduct;
        }

        private List<PurchaseData> GetPurchaseData()
        {
            var orders = db.Orders.ToList();
            var purchaseData = new List<PurchaseData>();

            foreach (var order in orders)
                purchaseData.Add(ConvertToPurchaseData(order));

            return purchaseData;
        }

        private PurchaseData ConvertToPurchaseData(Order order)
        {
            var orderDetails = db.OrderDetails.Where(o => o.OrderId == order.OrderId).ToList();

            PurchaseData data = new PurchaseData();
            data.OrderID = order.OrderId;
            data.Data = new int[_products.Count];

            for (int i = 0; i < PurchaseData.ProductIDs.Length; i++)
            {
                foreach (var orderDetail in orderDetails)
                {
                    if (orderDetail.ProductId == PurchaseData.ProductIDs[i])
                    {
                        data.Data[i] = 1;
                        break;
                    }
                }
            }

            return data;
        }

        private void LogResult(string message, int orderId, int productId, bool random, List<KeyValuePair<int, double>> recommendations)
        {
            //using (StreamWriter w = File.AppendText("Log.txt"))
            using (StreamWriter w = File.AppendText(@"c:\exjobb-kristoffer-tobias\log.txt"))
            {
                w.WriteLine(message + " ---------------");
                w.WriteLine("K-value: " + KNearest);
                w.WriteLine("Order ID: " + orderId);
                w.WriteLine("Recommended product: " + productId);
                w.WriteLine("Random: " + random);

                foreach (var recommendation in recommendations)
                {
                    w.WriteLine(" ID: " + recommendation.Key + " Similarity: " + Math.Round(recommendation.Value, 5));
                }
                w.Flush();
            }
        }
    }
}
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
        private List<Product> _products;
        private List<Order> _orders;
        private List<OrderDetail> _orderDetails;
        private List<RecommendationResult> _recommendationResults; 

        private string _logPath;
        public RecommendationCalculator()
        {
            ProductContext db = new ProductContext();

            //_logPath = @"c:\exjobb-kristoffer-tobias\log.txt";
            _logPath = @"c:\log.txt";
            _products = db.Products.ToList();
            _orders = db.Orders.ToList();
            _orderDetails = db.OrderDetails.ToList();
            _recommendationResults = db.RecommendationResults.ToList();

            PurchaseData.ProductIDs = new int[_products.Count];
            for (int i = 0; i < _products.Count; i++)
                PurchaseData.ProductIDs[i] = _products[i].ProductId;
        }

        public RecommendationCalculator(string logPath, List<Product> products,List<Order> orders, List<OrderDetail> orderDetails, List<RecommendationResult> recommendationResults)
        {
            _logPath = logPath;
            _products = products;
            _orders = orders;
            _orderDetails = orderDetails;
            _recommendationResults = recommendationResults;

            PurchaseData.ProductIDs = new int[_products.Count];
            for (int i = 0; i < _products.Count; i++)
                PurchaseData.ProductIDs[i] = _products[i].ProductId;
        }

        public Product RecommendProductUserBased(Order order, ISimilarityCalculable calculable, int kNearest)
        {
            var purchaseData = GetPurchaseData();

            var data1 = ConvertToPurchaseData(order);

            foreach (var data2 in purchaseData)
            {
                if (data1.OrderID != data2.OrderID)
                    data2.Similarity = calculable.CalculateSimilarity(data1.Data, data2.Data);
            }

            var result = FindRecommendationUserBased(purchaseData, data1, kNearest);

            if (result == -1)
                return null;

            return _products.ToList().SingleOrDefault(x => x.ProductId == result);
        }

        public Product RecommendProductItemBased(Order order, ISimilarityCalculable calculable, int kNearest)
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

                    var data2 = itemData[j];

                    if (j != i)
                        similarity.Similarity = calculable.CalculateSimilarity(data1.PurchasedByCustomer, data2.PurchasedByCustomer);
                    data1.SimilarityVector.Add(similarity);
                }
            }

            var result = FindRecommendationItemBased(itemData, currentPurchase, kNearest);

            if (result == -1)
                return null;

            return _products.ToList().SingleOrDefault(x => x.ProductId == result);
        }

        // TODO: Make this more effecient if needed
        private List<ItemData> GetItemData()
        {
            var purchaseData = GetPurchaseData();

            int numCustomers = _orders.Count();

            var chosenInStore = _recommendationResults.ToList();

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
                        if (purchaseData[j].OrderID == product.OrderId && product.SelectedProductId == itemData.ProductId)
                            itemData.PurchasedByCustomer[j] = 1;
                    }
                }
                itemSimilarity.Add(itemData);
            }
            return itemSimilarity;
        }

        private int FindRecommendationItemBased(List<ItemData> itemData, PurchaseData purchase, int kNearest)
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
                    var productSimilarities = product.SimilarityVector.OrderByDescending(item => item.Similarity).ToList().GetRange(0, kNearest);

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
                LogResult("ItemBased", kNearest, purchase.OrderID, recommendedProduct, true, filteredRecommendations);
                return recommendedProduct;
            }
                
            if (filteredRecommendations.First().Value == 0)
            {
                recommendedProduct = inStore[new Random().Next(inStore.Count)];
                LogResult("ItemBased", kNearest, purchase.OrderID, recommendedProduct, true, filteredRecommendations);
                return recommendedProduct;
            }                

            recommendedProduct = filteredRecommendations.First().Key;
            LogResult("ItemBased", kNearest, purchase.OrderID, recommendedProduct, false, filteredRecommendations);
            return recommendedProduct;
        }
        private int FindRecommendationUserBased(List<PurchaseData> purchaseData, PurchaseData p, int kNearest)
        {
            List<PurchaseData> purchases;

            // Use k-nearest if possible
            if (purchaseData.Count >= kNearest)
                purchases = purchaseData.OrderByDescending(purchase => purchase.Similarity).ToList().GetRange(0, kNearest);
            // else as many as possible
            else
                purchases = purchaseData.OrderByDescending(purchase => purchase.Similarity).ToList();

            // Calculate similarity
            double similaritySum = purchases.Sum(purchase => purchase.Similarity);
            foreach (var purchase in purchases)
                purchase.Influence = purchase.Similarity / similaritySum;


            // Sum weighted similarity for each product
            var recommendations = new Dictionary<int, double>();
            var chosenInStore = _recommendationResults;
            foreach (PurchaseData purchase in purchases)
            {
                foreach (var recommendationResult in chosenInStore.Where(r => r.OrderId == purchase.OrderID))
                {
                    if(recommendations.ContainsKey(recommendationResult.SelectedProductId))
                        recommendations[recommendationResult.SelectedProductId] += purchase.Influence;
                    else
                        recommendations.Add(recommendationResult.SelectedProductId, purchase.Influence);
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
                LogResult("UserBased", kNearest, p.OrderID, recommendedProduct, true, sortedRecommendations);
                return recommendedProduct;
            }

            LogResult("UserBased", kNearest, p.OrderID, sortedRecommendations[0].Key, false, sortedRecommendations);
            recommendedProduct = sortedRecommendations[0].Key;

            return recommendedProduct;
        }

        private List<PurchaseData> GetPurchaseData()
        {
            var purchaseData = new List<PurchaseData>();

            foreach (var order in _orders)
                purchaseData.Add(ConvertToPurchaseData(order));

            return purchaseData;
        }

        private PurchaseData ConvertToPurchaseData(Order order)
        {
            var orderDetails = _orderDetails.Where(o => o.OrderId == order.OrderId).ToList();

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

        private void LogResult(string message, int kNearest, int orderId, int productId, bool random, List<KeyValuePair<int, double>> recommendations)
        {
            using (StreamWriter w = File.AppendText(_logPath))
            {
                w.WriteLine(message + " K-value: " + kNearest + "\tOrder ID: " + orderId + "\tRandom: " + random + "\tRecommended ID: " + productId);
               
                foreach (var recommendation in recommendations)
                {
                    w.Write("\tID: " + recommendation.Key + " Similarity: " + Math.Round(recommendation.Value, 5));
                }
                w.WriteLine();
                w.WriteLine();
                w.Flush();
            }
        }
    }
}
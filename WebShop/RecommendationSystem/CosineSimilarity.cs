using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.RecommendationSystem
{
    public class CosineSimilarity : ISimilarityCalculable
    {
        public double CalculateSimilarity(int[] data1, int[] data2)
        {
            var dotProduct = DotProduct(data1, data2);
            var magnitude1 = Magnitude(data1);
            var magnitude2 = Magnitude(data2);

            if (magnitude1 == 0 || magnitude2 == 0)
                return 0;
            return dotProduct / (magnitude1 * magnitude2);
        }

        private double DotProduct(int[] data1, int[] data2)
        {
            double dotProduct = 0;
            for (var i = 0; i < data1.Length; i++)
            {
                dotProduct += (data1[i] * data2[i]);
            }

            return dotProduct;
        }

        private double Magnitude(int[] data)
        {
            return Math.Sqrt(DotProduct(data, data));
        }
    }
}
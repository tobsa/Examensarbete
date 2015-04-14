using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.RecommendationSystem
{
    public interface ISimilarityCalculable
    {
        double CalculateSimilarity(int[] data1, int[] data2);
    }
}

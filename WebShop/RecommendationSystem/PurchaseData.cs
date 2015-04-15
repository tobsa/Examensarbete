using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.RecommendationSystem
{
    public class PurchaseData
    {
        public static int[] ProductIDs { get; set; }

        public int OrderID { get; set; }
        public int[] Data { get; set; }
        public double Similarity { get; set; }
        public double Influence { get; set; }
    }
}
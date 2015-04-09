using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShop.Models
{
    public class RecommendationResult
    {
        [Key]
        public int ResultId { get; set; }
        public int OrderId { get; set; }
        public int RecommendedProductID { get; set; }
        public int SelectedProductID { get; set; }
    }
}
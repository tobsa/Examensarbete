using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    public class RecommendationResult
    {
        [Key]
        public int ResultId { get; set; }
        public int OrderId { get; set; }
        public int SelectedProductId { get; set; }
        public int ItemRecommendedProductId { get; set; }
        public int UserRecommendedProductId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    public class Order
    {
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }

        [ScaffoldColumn(true)]
        [Required(ErrorMessage = "Du måste ange ett giltigt användarnamn")]
        [DisplayName("Användarnamn")]
        public string Username { get; set; }

        [ScaffoldColumn(false)]
        public decimal Total { get; set; }

        [ScaffoldColumn(false)]
        public DateTime OrderDate { get; set; }

        [ScaffoldColumn(false)]
        public List<OrderDetail> OrderDetails { get; set; }

        [ScaffoldColumn(false)]
        public bool IsWebOrder { get; set; }

        [ScaffoldColumn(false)]
        public string IpAddress { get; set; }
    }
}

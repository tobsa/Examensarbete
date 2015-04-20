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
        [Required(ErrorMessage = "Du måste ange ett användarnamn")]
        [DisplayName("Användarnamn")]
        [UniqueUsername(ErrorMessage="Du måste ange ett giltigt användarnamn")]
        public string Username { get; set; }

        [ScaffoldColumn(true)]
        [Range(1, 200, ErrorMessage = "Du måste ange ett tal mellan 1 och 200")]
        [Required(ErrorMessage="Du måste ange en ålder")]
        [DisplayName("Ålder")]
        public int Age { get; set; }

        [ScaffoldColumn(true)]
        [DisplayName("Kön")]
        [Required(ErrorMessage="Du måste ange kön")]
        public bool? Sex { get; set; }

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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebShop.Models
{
    public class Order
    {
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }

        [ScaffoldColumn(true)]
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

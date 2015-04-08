using System.Collections.Generic;
using WebShop.Models;

namespace WebShop.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShop.Models
{
    public class UniqueUsername : ValidationAttribute
    {
        private ProductContext db = new ProductContext();

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string username = value.ToString();



            return ValidationResult.Success;
        }
    }
}
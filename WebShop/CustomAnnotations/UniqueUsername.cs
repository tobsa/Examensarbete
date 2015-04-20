using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebShop.Models;

namespace WebShop.CustomAnnotations
{
    public class UniqueUsername : ValidationAttribute
    {
        private ProductContext db = new ProductContext();

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            string username = value.ToString();

            if(db.Users.ToList().Exists(x => x.Username == username))
                return ValidationResult.Success;

            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
    }
}
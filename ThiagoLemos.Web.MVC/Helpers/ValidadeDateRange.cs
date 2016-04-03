using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ThiagoLemos.Web.MVC.Helpers
{
    public class ValidateDateRange : ValidationAttribute
    {
        public DateTime FirstDate { get; set; }
        public DateTime SecondDate { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            FirstDate = Convert.ToDateTime("01/01/1900");
            // your validation logic
            if ((DateTime)value >= FirstDate )
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("A data não é válida.");
            }
        }
    }

    
}
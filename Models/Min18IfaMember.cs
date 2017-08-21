using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Min18IfaMember: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MemberShipTypeId == 1)
                return ValidationResult.Success;
            if (customer.BirthDate == null)
                return new ValidationResult("BirthDate is required");
            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
            if (age > 18)
                return ValidationResult.Success;
            else
                return new ValidationResult("Customer should be atleast 18 years of age");


        }
    }
}
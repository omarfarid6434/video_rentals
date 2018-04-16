using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace video_rentals.Models
{
    public class Min18YearsIfAmember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MemberShipType.Unkown  || customer.MembershipTypeId == MemberShipType.PayASYouGo)
                return ValidationResult.Success;
            if (customer.Birthday == null)
                return new ValidationResult("This field is Required");

            var age = DateTime.Today.Year - customer.Birthday.Value.Year;

            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer should be at least 18 year old");
        }
    }
}
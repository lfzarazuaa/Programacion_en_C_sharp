using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Customer customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown ||
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult(ErrorMessage = "Birthdate is required.");

            int age = CalculateAge(customer.Birthdate.Value);

            bool HasMoreThan18Years = (age >= 18);

            return HasMoreThan18Years
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 years old to go on a membership.");

        }

        private int CalculateAge(DateTime birth)
        {
            DateTime today = DateTime.UtcNow.Date;
            var age = today.Year - birth.Year;

            // Si es mayor en mes o si es mayor en dias pero del mismo mes.
            if (birth.Month > today.Month ||
                (birth.Month == today.Month && birth.Day > today.Day))
            {
                age--;
            }

            return age;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealership.Models
{
    public class ContactForm : IValidatableObject
    {
        // Your task is to:
        //
        // Make all fields required
        // Ensure the Email field contains an '@' symbol
        // Ensure PhoneNumber is in the format: 1-XXX-XXX-XXXX
        // If the Income is less than 10000 and the PurchaseTimeFrameInMonts is greater than 12,
        // generate a model level area that says 'We don't want your business!'

        public string Name { get; set; }
        public int PurchaseTimeFrameInMonths { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal? Income { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (Income == null || Income <= 20000)
            {
                errors.Add(new ValidationResult("Please enter a valid Income", new string[] { "Income" }));
            }

            if (string.IsNullOrEmpty(Name))
            {
                errors.Add(new ValidationResult("Please Enter A Name", new string[] { "Name" }));
            }

            if (string.IsNullOrEmpty(PhoneNumber) || PhoneNumber[3] != '-' || PhoneNumber[7] != '-' || PhoneNumber.Length != 12)
            {
                errors.Add(new ValidationResult("Please enter a number in the correct format xxx-xxxx-xxxx", new string[] { "PhoneNumber" }));
            }

            if (string.IsNullOrEmpty(Email) || !(Email.Contains('@')))
            {
                errors.Add(new ValidationResult("Please enter an email", new string[] { "Email" }));
            }
            return errors;
        }
    }
}
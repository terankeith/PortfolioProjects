using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealership.Models
{
    public class Car : IValidatableObject
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }

       public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
       {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Make))
            {
                errors.Add(new ValidationResult("Please enter a valid Manufacturer", new string[] { "Make" }));
            }

            if (string.IsNullOrEmpty(Model))
            {
                errors.Add(new ValidationResult("Please enter a valid model", new string[] { "Model" }));
            }

            if (string.IsNullOrEmpty(Title))
            {
                errors.Add(new ValidationResult("Please enter a valid title of the car", new string[] { "Title" }));
            }

            if (Price == null || Price >= 1000000)
            {
                errors.Add(new ValidationResult("Please enter an email", new string[] { "Price" }));
            }

            if (Year == null)
            {
                errors.Add(new ValidationResult("The year of the car is required", new string[] { "Year" }));
            }
            else if (Year.Length != 4)
            {
                errors.Add(new ValidationResult("Please enter a valid year: xxxx", new string[] { "Year" }));
            }
            return errors;
        }
    }
}
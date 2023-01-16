using Helsinki_City_Bike_Database_Seeder.Models;
using System.ComponentModel.DataAnnotations;

namespace Helsinki_City_Bike_Database_Seeder.ModelValidations
{
    public class Journey_EnsureDurationAtLeastTenSeconds: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var journey = validationContext.ObjectInstance as Journey;
            if (journey != null && journey.Duration < 10)
            {
                return new ValidationResult("Duration has to be at least 10 seconds!");
            }
            return ValidationResult.Success;
        }
    }
}

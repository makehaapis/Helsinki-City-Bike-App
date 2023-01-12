using Helsinki_City_Bike_App.Models;
using System.ComponentModel.DataAnnotations;

namespace Helsinki_City_Bike_App.ModelValidations
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

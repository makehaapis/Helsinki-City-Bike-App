using Helsinki_City_Bike_App.Models;
using System.ComponentModel.DataAnnotations;

namespace Helsinki_City_Bike_App.ModelValidations
{
    public class Journey_EnsureDepartureDateBeforeReturn: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var journey = validationContext.ObjectInstance as Journey;
            if (journey != null && journey.DepartureTime < journey.ReturnTime) 
            {
                return new ValidationResult("Departure has to be before return!");
            }
            return ValidationResult.Success;
        }
    }
}

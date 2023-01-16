using Helsinki_City_Bike_Database_Seeder.Models;
using System.ComponentModel.DataAnnotations;

namespace Helsinki_City_Bike_Database_Seeder.ModelValidations
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

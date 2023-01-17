
using Helsinki_City_Bike_Database_Seeder.Models;
using System.ComponentModel.DataAnnotations;

namespace Helsinki_City_Bike_Database_Seeder.ModelValidations
{
    public class Journey_EnsureDistanceAtLeast10Meters:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var journey = validationContext.ObjectInstance as Journey;
            if (journey != null && journey.Distance < 10)
            {
                return new ValidationResult("Distance has to be at least 10 meters!");
            }
            return ValidationResult.Success;
        }
    }
}
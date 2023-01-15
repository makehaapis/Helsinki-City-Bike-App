using Helsinki_City_Bike_Database_Seeder.Models;

namespace Helsinki_City_Bike_Database_Seeder.ModelValidations
{
    public class ValidateCsvJourney
    {
        public static bool ValidateJourney(Journey journey)
        {
            if (journey.DepartureTime > journey.ReturnTime || journey.Duration < 10 || journey.Distance < 10)
            { return false; }
            else { return true; }
        }
    }
}
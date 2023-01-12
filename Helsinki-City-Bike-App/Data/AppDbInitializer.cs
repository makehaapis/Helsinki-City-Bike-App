using Helsinki_City_Bike_App.Models;
using Helsinki_City_Bike_App.Pages.Stations;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Helsinki_City_Bike_App.Data
{
    public class AppDbInitializer
    {
        private static List<Journey> journeys;
        public static void Seed(AppDbContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Stations.Any())
            {
                var stations = CsvToStation.Stations();
                foreach (var station in stations)
                {
                    try
                    {
                        context.Add(station);
                        context.SaveChanges();
                    }
                    catch (DbUpdateException)
                    {
                        context.Stations.Remove(station);
                        continue;
                    }
                }
            }

            int i = 0;

            if (!context.Journeys.Any())
            {
                journeys = CsvToJourney.Journeys();
                foreach (var item in journeys)
                {
                    i += 1;
                    try
                    {
                        context.Journeys.Add(item);
                        context.SaveChanges();
                    }
                    catch (DbUpdateException)
                    {
                        context.Journeys.Remove(item);
                        continue;
                    }
                    Console.WriteLine($"Where we at {i} / {journeys.Count()}");
                }
            }
        }
    }
}

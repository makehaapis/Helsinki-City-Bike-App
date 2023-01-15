using Helsinki_City_Bike_Database_Seeder.Models;
using Helsinki_City_Bike_Database_Seeder.ModelValidations;
using Microsoft.EntityFrameworkCore;

namespace Helsinki_City_Bike_Database_Seeder.Data
{
    public class AppDbInitializer
    {
        private static List<Journey> journeys;
        public static async Task Seed(AppDbContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Stations.Any())
            {
                var stations = CsvToStation.Stations();
                foreach (var station in stations)
                {
                    try
                    {
                        await context.AddAsync(station);
                        await context.SaveChangesAsync();
                    }
                    catch (DbUpdateException)
                    {
                        Console.WriteLine(station.Name);
                        context.Stations.Remove(station);
                        continue;
                    }
                }
            }

            if (!context.Journeys.Any())
            {
                context.ChangeTracker.AutoDetectChangesEnabled = false;
                var watch = System.Diagnostics.Stopwatch.StartNew();
                journeys = CsvToJourney.Journeys();
                foreach (var journey in journeys)
                {
                    if (ValidateCsvJourney.ValidateJourney(journey))
                    { 
                        try
                        {
                            await context.Journeys.AddAsync(journey);
                            await context.SaveChangesAsync();
                        }
                        catch (DbUpdateException)
                        {
                            context.Journeys.Remove(journey);
                            continue;
                        }
                    }
                }
                watch.Stop();
                Console.Write("This took: ");
                Console.Write(watch.Elapsed.ToString());
                Console.WriteLine("seconds");
                context.ChangeTracker.AutoDetectChangesEnabled = true;
            }
        }
    }
}
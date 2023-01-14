using Helsinki_City_Bike_App.Models;
using Helsinki_City_Bike_App.Pages.Stations;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace Helsinki_City_Bike_App.Data
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
                foreach (var item in journeys)
                {
                    try
                    {
                        await context.Journeys.AddAsync(item);
                        await context.SaveChangesAsync();
                    }
                    catch (DbUpdateException)
                    {
                        context.Journeys.Remove(item);
                        continue;
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

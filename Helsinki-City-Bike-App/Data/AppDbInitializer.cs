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
                context.Stations.AddRange(new List<Station>()
                {
                    new Station() {
                        StationID = 501,
                        Name = "Hanasaari",
                        Address = "Hanasaarenranta 1",
                        Capacity = 10,
                        Longitude = "24.840319",
                        Latitude = "60.16582"
                    },
                    new Station()
                    {
                        StationID = 503,
                        Name = "Keilalahti",
                        Address = "Keilalahdentie 2",
                        Capacity = 28,
                        Longitude = "24.840319",
                        Latitude = "60.16582"
                    }
                });
                context.SaveChanges();
            }

            if (!context.Journeys.Any())
            {
                journeys = new List<Journey>();
                journeys.AddRange(new List<Journey>()
                {
                    new Journey() {
                        DepartureTime =DateTime.Parse("2021-05-31T23:57:25"),
                        ReturnTime = DateTime.Parse("2021-06-01T00:05:46"),
                        Distance = 12,
                        Duration = 20,
                        ReturnStationID = 501,
                        DepartureStationID = 503
                    },
                    new Journey() {
                        DepartureTime =DateTime.Parse("2021-05-31T23:57:25"),
                        ReturnTime = DateTime.Parse("2021-06-01T00:05:46"),
                        Distance = 12,
                        Duration = 20,
                        ReturnStationID = 501,
                        DepartureStationID = 50
                    },
                    new Journey() {
                        DepartureTime =DateTime.Parse("2023-05-31T23:57:25"),
                        ReturnTime = DateTime.Parse("2023-06-01T00:05:46"),
                        Distance = 12,
                        Duration = 20,
                        ReturnStationID = 501,
                        DepartureStationID = 503
                    },
                    new Journey() {
                        DepartureTime =DateTime.Parse("2022-05-31T23:57:25"),
                        ReturnTime = DateTime.Parse("2022-06-01T00:05:46"),
                        Distance = 12,
                        Duration = 20,
                        ReturnStationID = 501,
                        DepartureStationID = 503
                    }
                });
                foreach (var item in journeys)
                {
                    try
                    {
                        context.Journeys.Add(item);
                        context.SaveChanges();
                    }
                    catch(DbUpdateException) 
                    {
                        context.Journeys.Remove(item);
                        continue;
                    }
                    
                }
            }
        }
    }
}

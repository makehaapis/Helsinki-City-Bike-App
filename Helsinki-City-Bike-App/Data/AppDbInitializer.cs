using Helsinki_City_Bike_App.Models;

namespace Helsinki_City_Bike_App.Data
{
    public class AppDbInitializer
    {
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
        }
    }
}

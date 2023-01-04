using Helsinki_City_Bike_App.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helsinki_City_Bike_App.Models
{
    public class Station
    {
        //Allow us to add primary key from csv.
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StationID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public ICollection<Journey> DepartingJourneys { get; set; }
        public ICollection<Journey> ReturningJourneys { get; set; }
    }
}

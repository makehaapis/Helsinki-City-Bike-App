using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Helsinki_City_Bike_Database_Seeder.Models
{
    public class Station
    {
        //Allow us to add primary key from csv.
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StationID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public string Longitude { get; set; }
        [Required]
        public string Latitude { get; set; }
        public ICollection<Journey> DepartingJourneys { get; set; }
        public ICollection<Journey> ReturningJourneys { get; set; }
    }
}
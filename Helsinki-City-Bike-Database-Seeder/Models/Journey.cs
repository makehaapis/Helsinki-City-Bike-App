using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Helsinki_City_Bike_Database_Seeder.ModelValidations;

namespace Helsinki_City_Bike_Database_Seeder.Models
{
    public class Journey
    {
        [Key]
        public int JourneyID { get; set; }
        [Required]
        public DateTime DepartureTime { get; set; }
        [Required]
        public DateTime ReturnTime { get; set; }
        [Required]
        public int Distance { get; set; }
        [Required]
        public float Duration { get; set; }
        [ForeignKey(nameof(ReturnStationID))]
        public int ReturnStationID { get; set; }
        public Station ReturnStation { get; set; }
        [ForeignKey(nameof(DepartureStationID))]
        public int DepartureStationID { get; set; }
        public Station DepartureStation { get; set; }
    }
}

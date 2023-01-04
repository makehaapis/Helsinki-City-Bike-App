using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Helsinki_City_Bike_App.Models
{
    public class Journey
    {
        [Key]
        public int JourneyID { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ReturnTime { get; set; }
        public int Distance { get; set; }
        public float Duration { get; set; }

        [ForeignKey(nameof(ReturnStationID))]
        public int ReturnStationID { get; set; }
        public Station ReturnStation { get; set; }
        [ForeignKey(nameof(DepartureStationID))]
        public int DepartureStationID { get; set; }
        public Station DepartureStation { get; set; }
    }
}

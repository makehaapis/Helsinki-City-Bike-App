using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Helsinki_City_Bike_App.Data;
using Helsinki_City_Bike_App.Models;

namespace Helsinki_City_Bike_App.Pages.Stations
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;

        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public Station Station { get; set; }
        public List<Journey> DepartingJourneys { get; set; }
        public List<Journey> ReturningJourneys { get; set; }
        public int AverageStartingJourneyDistance { get; set; }
        public int AverageReturnJourneyDistance { get; set; }
        public int TotalStartingJourneyDistance { get; set; }
        public int TotalReturningJourneyDistance { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id, int? JourneyID)
        {
            if (id == null || _context.Stations == null)
            {
                return NotFound();
            }
            Station = await _context.Stations.FirstOrDefaultAsync(m => m.StationID == id);
            DepartingJourneys = _context.Journeys.Where(j => j.DepartureStationID.Equals(id)).ToList();
            ReturningJourneys = _context.Journeys.Where(j => j.ReturnStationID.Equals(id)).ToList();

            if (DepartingJourneys.Count() > 0)
            {
                foreach (var item in DepartingJourneys)
                {
                    TotalStartingJourneyDistance += item.Distance;
                }
                AverageStartingJourneyDistance = TotalStartingJourneyDistance / DepartingJourneys.Count();
            }

            if (ReturningJourneys.Count() > 0)
            {
                foreach (var item in ReturningJourneys)
                {
                    TotalReturningJourneyDistance += item.Distance;
                }
                AverageReturnJourneyDistance = TotalReturningJourneyDistance / ReturningJourneys.Count();
                }
            return Page();
        }
    }
}

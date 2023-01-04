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
        private readonly Helsinki_City_Bike_App.Data.AppDbContext _context;

        public DetailsModel(Helsinki_City_Bike_App.Data.AppDbContext context)
        {
            _context = context;
        }

      public Station Station { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Stations == null)
            {
                return NotFound();
            }

            var station = await _context.Stations.FirstOrDefaultAsync(m => m.StationID == id);
            if (station == null)
            {
                return NotFound();
            }
            else 
            {
                Station = station;
            }
            return Page();
        }
    }
}

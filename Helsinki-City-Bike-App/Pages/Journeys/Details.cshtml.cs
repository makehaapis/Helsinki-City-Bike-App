using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Helsinki_City_Bike_App.Data;
using Helsinki_City_Bike_App.Models;

namespace Helsinki_City_Bike_App.Pages.Journeys
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;

        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public Journey Journey { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Journeys == null)
            {
                return NotFound();
            }

            var journey = await _context.Journeys.Include(j => j.ReturnStation).Include(j => j.DepartureStation).FirstOrDefaultAsync(m => m.JourneyID == id);
            if (journey == null)
            {
                return NotFound();
            }
            else
            {
                Journey = journey;
            }
            return Page();
        }
    }
}

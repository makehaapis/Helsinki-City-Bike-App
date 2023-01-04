using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Helsinki_City_Bike_App.Data;
using Helsinki_City_Bike_App.Models;

namespace Helsinki_City_Bike_App.Pages.Journeys
{
    public class EditModel : PageModel
    {
        private readonly Helsinki_City_Bike_App.Data.AppDbContext _context;

        public EditModel(Helsinki_City_Bike_App.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Journey Journey { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Journeys == null)
            {
                return NotFound();
            }

            var journey =  await _context.Journeys.FirstOrDefaultAsync(m => m.JourneyID == id);
            if (journey == null)
            {
                return NotFound();
            }
            Journey = journey;
           ViewData["DepartureStationID"] = new SelectList(_context.Stations, "StationID", "StationID");
           ViewData["ReturnStationID"] = new SelectList(_context.Stations, "StationID", "StationID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Journey).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JourneyExists(Journey.JourneyID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool JourneyExists(int id)
        {
          return _context.Journeys.Any(e => e.JourneyID == id);
        }
    }
}

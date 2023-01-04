using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Helsinki_City_Bike_App.Data;
using Helsinki_City_Bike_App.Models;

namespace Helsinki_City_Bike_App.Pages.Journeys
{
    public class CreateModel : PageModel
    {
        private readonly Helsinki_City_Bike_App.Data.AppDbContext _context;

        public CreateModel(Helsinki_City_Bike_App.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DepartureStationID"] = new SelectList(_context.Stations, "StationID", "StationID");
        ViewData["ReturnStationID"] = new SelectList(_context.Stations, "StationID", "StationID");
            return Page();
        }

        [BindProperty]
        public Journey Journey { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Journeys.Add(Journey);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Helsinki_City_Bike_App.Data;
using Helsinki_City_Bike_App.Models;

namespace Helsinki_City_Bike_App.Pages.Stations
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
            return Page();
        }

        [BindProperty]
        public Station Station { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Stations.Add(Station);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

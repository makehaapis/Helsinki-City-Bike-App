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
    public class IndexModel : PageModel
    {
        private readonly Helsinki_City_Bike_App.Data.AppDbContext _context;

        public IndexModel(Helsinki_City_Bike_App.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Journey> Journey { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Journeys != null)
            {
                Journey = await _context.Journeys
                .Include(j => j.DepartureStation)
                .Include(j => j.ReturnStation).ToListAsync();
            }
        }
    }
}

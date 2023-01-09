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
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        public IndexModel(AppDbContext context)
        {
            _context = context;
        }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public string NameSort { get; set; }
        public string AddressSort { get; set; }
        public string CapacitySort { get; set; }
        public PaginatedList<Station> Stations { get; set; } = default!;

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = sortOrder == "StationName" ? "station_name_desc" : "StationName";
            AddressSort = sortOrder == "StationAddress" ? "station_address_desc" : "StationAddress";
            CapacitySort = sortOrder == "StationCapacity" ? "station_capacity_desc" : "StationCapacity";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            currentFilter = searchString;
            IQueryable<Station> stationsIQ = from s in _context.Stations
                                             select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                stationsIQ = stationsIQ.Where(s => s.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "StationName":
                    stationsIQ = stationsIQ.OrderBy(s => s.Name);
                    break;
                case "station_name_desc":
                    stationsIQ = stationsIQ.OrderByDescending(s => s.Name);
                    break;
                case "StationAddress":
                    stationsIQ = stationsIQ.OrderBy(j => j.Address);
                    break;
                case "station_address_desc":
                    stationsIQ = stationsIQ.OrderByDescending(j => j.Address);
                    break;
                case "StationCapacity":
                    stationsIQ = stationsIQ.OrderBy(j => j.Capacity);
                    break;
                case "station_capacity_desc":
                    stationsIQ = stationsIQ.OrderByDescending(j => j.Capacity);
                    break;
            }
            var pageSize = 20;
            Stations = await PaginatedList<Station>.CreateAsync(
                stationsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}

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
        private readonly AppDbContext _context;
        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public string DepartureTimeSort { get; set; }
        public string ReturnTimeSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public string DistanceSort { get; set; }
        public string DurationSort { get; set; }
        public string DepartureStationSort { get; set; }
        public string ReturnStationSort { get; set; }
        public PaginatedList<Journey> Journeys { get; set; }


        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            DepartureTimeSort = sortOrder == "DepartureTime" ? "departure_date_desc" : "DepartureTime";
            ReturnTimeSort = sortOrder == "ReturnTime" ? "return_date_desc" : "ReturnTime";
            DistanceSort = sortOrder == "Distance" ? "distance_desc" : "Distance";
            DurationSort = sortOrder == "Duration" ? "duration_desc" : "Duration";
            DepartureStationSort = sortOrder == "DepartureStation" ? "departure_station_desc" : "DepartureStation";
            ReturnStationSort = sortOrder == "ReturnStation" ? "return_station_desc" : "ReturnStation";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Journey> journeysIQ = from j in _context.Journeys
                                             select j;

            if (!String.IsNullOrEmpty(searchString))
            {
                journeysIQ = journeysIQ.Where(j => j.ReturnStation.Name.Contains(searchString) && j.DepartureTime == DateTime.Parse("2021-05-31T22:32:41")
                                       || j.DepartureStation.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "DepartureTime":
                    journeysIQ = journeysIQ.OrderBy(j => j.DepartureTime);
                    break;
                case "departure_date_desc":
                    journeysIQ = journeysIQ.OrderByDescending(j => j.DepartureTime);
                    break;
                case "ReturnTime":
                    journeysIQ = journeysIQ.OrderBy(j => j.ReturnTime);
                    break;
                case "return_date_desc":
                    journeysIQ = journeysIQ.OrderByDescending(j => j.ReturnTime);
                    break;
                case "Distance":
                    journeysIQ = journeysIQ.OrderBy(j => j.Distance);
                    break;
                case "distance_desc":
                    journeysIQ = journeysIQ.OrderByDescending(j => j.Distance);
                    break;
                case "Duration":
                    journeysIQ = journeysIQ.OrderBy(j => j.Duration);
                    break;
                case "duration_desc":
                    journeysIQ = journeysIQ.OrderByDescending(j => j.Duration);
                    break;
                case "DepartureStation":
                    journeysIQ = journeysIQ.OrderBy(j => j.DepartureStation.Name);
                    break;
                case "departure_station_desc":
                    journeysIQ = journeysIQ.OrderByDescending(j => j.DepartureStation.Name);
                    break;
                case "ReturnStation":
                    journeysIQ = journeysIQ.OrderBy(j => j.ReturnStation.Name);
                    break;
                case "return_station_desc":
                    journeysIQ = journeysIQ.OrderByDescending(j => j.ReturnStation.Name);
                    break;
                default:
                    journeysIQ = journeysIQ.OrderBy(j => j.JourneyID);
                    break;
            }
            var pageSize = 20;
            Journeys = await PaginatedList<Journey>.CreateAsync(
                journeysIQ.Include(j => j.DepartureStation).Include(j => j.ReturnStation).AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
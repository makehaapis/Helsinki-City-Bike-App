using Helsinki_City_Bike_Database_Seeder.Models;
using Microsoft.EntityFrameworkCore;

namespace Helsinki_City_Bike_Database_Seeder.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Journey> Journeys { get; set; }
        public DbSet<Station> Stations { get; set; }

        //Entity framework relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Station>().HasMany(s => s.DepartingJourneys).WithOne(j => j.DepartureStation).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Station>().HasMany(s => s.ReturningJourneys).WithOne(j => j.ReturnStation).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
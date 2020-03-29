using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Spaceport.Models;
using System.IO;

namespace Spaceport
{
    public class SpacePortDBContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<ParkingSpot> ParkingSpots { get; set; }
        public DbSet<ParkingSession> ParkingSessions { get; set; }
        public DbSet<SpacePort> SpacePorts { get; set; }
        public DbSet<SpaceShip> SpaceShips { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

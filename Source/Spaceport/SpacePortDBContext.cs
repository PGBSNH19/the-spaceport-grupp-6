using Microsoft.EntityFrameworkCore;
using Spaceport.Models;

namespace Spaceport
{
    class SpacePortDBContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<ParkingSpot> ParkingSpots { get; set; }
        public DbSet<ParkingSession> ParkingSessions { get; set; }
        public DbSet<SpacePort> SpacePorts { get; set; }
        public DbSet<SpaceShip> SpaceShips { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.UseSqlServer(Program.CONNECTION_STRING);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Person>().HasData(
            //    new Person(
            //    )
            //);
                
            base.OnModelCreating(modelBuilder);
        }
    }
}

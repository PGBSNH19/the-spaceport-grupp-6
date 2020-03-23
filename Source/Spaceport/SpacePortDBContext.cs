using Microsoft.EntityFrameworkCore;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Spaceport
{
    class SpacePortDBContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<ParkingSpot> ParkingSpots { get; set; }
        public DbSet<ParkingSession> ParkingSessions { get; set; }
        public DbSet<SpacePort> SpacePorts { get; set; }
        public DbSet<SpaceShip> SpaceShip { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.UseSqlServer(Program.CONNECTION_STRING);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Data here
        }
    }
}

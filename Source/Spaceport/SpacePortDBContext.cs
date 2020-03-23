using Microsoft.EntityFrameworkCore;

namespace Spaceport
{
    class SpacePortDBContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<ParkingSpot> ParkingSpot { get; set; }
        public DbSet<ParkingSession> ParkingSession { get; set; }
        public DbSet<SpacePort> SpacePort { get; set; }
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

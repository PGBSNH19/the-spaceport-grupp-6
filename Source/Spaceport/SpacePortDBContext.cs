using Microsoft.EntityFrameworkCore;

namespace Spaceport
{
    class SpacePortDBContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<ParkingSpot> ParkingSpots { get; set; }
        public DbSet<ParkingSession> ParkingSessions { get; set; }
        public DbSet<SpacePort> SpacePorts { get; set; }
        public DbSet<SpaceShip> SpaceShips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.UseSqlServer(Program.CONNECTION_STRING);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spaceport
{
    class StarwarsDBContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<ParkingSpot> ParkingSpots { get; set; }
        public DbSet<ParkingSession> ParkingSessions { get; set; }
        public DbSet<SpacePort> Spaceports { get; set; }
        public DbSet<ISpaceShip> SpaceShips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Data Source(localdb)\ProjectsV13;Initial Catalog=StoreDB;");
        }
    }
}

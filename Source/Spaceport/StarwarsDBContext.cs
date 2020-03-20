using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Spaceport
{
    class StarwarsDBContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<ParkingSpot> ParkingSpots { get; set; }
        public DbSet<ParkingSession> ParkingSessions { get; set; }
        public DbSet<SpacePort> Spaceports { get; set; }
        public DbSet<StarShip> StarShip { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Server=den1.mssql7.gear.host;Database=spaceport;Uid=spaceport;Pwd=Zm0~!8U6r493;");
        }
    }
}

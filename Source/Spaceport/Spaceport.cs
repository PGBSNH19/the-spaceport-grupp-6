using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spaceport
{
    public class SpacePort
    {
        public int SpacePortID { get; set; }
        public string Name { get; set; }
        public List<ParkingSpot> ParkingSpots { get; set; }

        private static int _amountSpaceSports = 0;

        public SpacePort(string name)
        {
            // Tillfällig
            ParkingSpots = new List<ParkingSpot>
            {
                new ParkingSpot() {MaxLength = 20, ParkingSpotID = 1},
                new ParkingSpot() {MaxLength = 30, ParkingSpotID = 2},
                new ParkingSpot() {MaxLength = 40, ParkingSpotID = 3},
                new ParkingSpot() {MaxLength = 50, ParkingSpotID = 4},
                new ParkingSpot() {MaxLength = 60, ParkingSpotID = 5}
            };

            _amountSpaceSports++;
            SpacePortID = _amountSpaceSports;
            Name = name;
        }

        public ParkingSpot FreeParkingSpot(int shipLength)
        {
            var freeSpot = ParkingSpots.
                FirstOrDefault(s => s.MaxLength >= shipLength);
            freeSpot = (freeSpot == null) ? throw new Exception("No available spots") : freeSpot;
            return freeSpot;
        }
    }
}

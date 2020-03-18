using System;
using System.Collections.Generic;
using System.Text;

namespace Spaceport
{
    public class SpacePort
    {
        public int SpacePortID { get; set; }
        public string Name { get; set; }
        public List<ParkingSpot> ParkingSpots { get; set; }
    }
}

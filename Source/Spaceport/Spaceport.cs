using System;
using System.Collections.Generic;
using System.Text;

namespace Spaceport
{
    public class Spaceport
    {
        public int SpaceportId { get; set; }
        public string Name { get; set; }
        public List<Parkingspot> Parkingspots { get; set; }
    }
}

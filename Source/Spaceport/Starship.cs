using System;
using System.Collections.Generic;
using System.Text;

namespace Spaceport
{
    public class Starship : ISpaceship
    {
        public int SpaceshipId { get; set; }
        public int Name { get; set; }
        public Person Person { get; set; }
        public int Length { get; set; }
    }
}

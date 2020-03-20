using System;
using System.Collections.Generic;
using System.Text;

namespace Spaceport
{
    public class StarShip : ISpaceShip
    {
        public int StarShipID { get; set; }
        public int Name { get; set; }
        public Person Driver { get; set; }
        public int Length { get; set; }
    }
}

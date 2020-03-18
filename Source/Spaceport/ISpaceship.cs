using System;
using System.Collections.Generic;
using System.Text;

namespace Spaceport
{
    public interface ISpaceShip
    {
        public int SpaceShipID { get; set; }
        public int Name { get; set; }
        public Person Driver { get; set; }
        public int Length { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Spaceport
{
    public class ParkingSession
    {
        public int ParkingSessionID { get; set; }
        public ParkingSpot ParkingSpot { get; set; }
        public ISpaceShip SpaceShip { get; set; }
        public SpacePort SpacePort { get; set; }
        public bool Token { get; set; }
        public DateTime RegistrationTime { get; set; }
        public DateTime ValidUntil { get; set; }

        public ParkingSession SetForShip(ISpaceShip ship)
        {
            SpaceShip = ship;
            return this;
        }

        public ParkingSession AtSpacePort(SpacePort port)
        {
            SpacePort = port;
            return this;
        }

        public ParkingSession FindFreeSpot()
        {

        }

        public bool SessionIsValid(DateTime currentTime)
        {
            return currentTime > ValidUntil;
        }
    }
}

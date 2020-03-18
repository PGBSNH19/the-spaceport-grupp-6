using System;

namespace Spaceport
{
    class Program
    {
        static void Main(string[] args)
        {
            var spacePort = new SpacePort();
            var ship = new StarShip();
            var parkingSession = new ParkingSession()
                .SetForShip(ship)
                .AtSpacePort(port)
                .FindFreeSpot()
        }
    }
}
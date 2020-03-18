using System;

namespace Spaceport
{
    class Program
    {
        static void Main(string[] args)
        {
            var coruscantSpacePort = new SpacePort("Coruscant");
            var bigShip = new StarShip() { Length = 50 };
            var parkingSession = new ParkingSession()
                .SetForShip(bigShip)
                .AtSpacePort(coruscantSpacePort)
                .FindFreeSpot();

            Console.WriteLine(parkingSession.SpacePort.Name);
            Console.WriteLine(parkingSession.ParkingSpot.ParkingSpotID);

            Console.ReadLine();
        }
    }
}
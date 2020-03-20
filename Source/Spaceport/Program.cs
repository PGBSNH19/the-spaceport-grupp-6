using System;

namespace Spaceport
{
    class Program
    {
        static void Main(string[] args)
        {
            var coruscantSpacePort = new SpacePort("Coruscant");
            var bigShipDriver = new Person() { Name = "Luke Skywalker"  };
            var bigShip = new StarShip() { Length = 50 , Driver=bigShipDriver};
            var parkingSession = new ParkingSession()
                .SetForShip(bigShip)
                .AtSpacePort(coruscantSpacePort)
                .FindFreeSpot()
                .ValidateParkingRight() ;

            Console.WriteLine(parkingSession.SpacePort.Name);
            Console.WriteLine(parkingSession.ParkingSpot.ParkingSpotID);

            Console.ReadLine();
        }
    }
}
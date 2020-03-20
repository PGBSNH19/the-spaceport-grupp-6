using System;

namespace Spaceport
{
    class Program
    {
        public const string CONNECTION_STRING = @"Server=den1.mssql7.gear.host;Database=spaceport;Uid=spaceport;Pwd=Zm0~!8U6r493;";
        static void Main(string[] args)
        {
            var coruscantSpacePort = new SpacePort("Coruscant");
            var bigShipDriver = new Person() { Name = "Luke Skywalker"  };
            var bigShip = new StarShip() { Length = 50 , Driver=bigShipDriver};
            var parkingSession = new ParkingSession()
                .SetForShip(bigShip)
                .AtSpacePort(coruscantSpacePort)
                .FindFreeSpot()
                .ValidateParkingRight()
                .StartParkingSession();

            Console.ReadLine();
        }
    }
}
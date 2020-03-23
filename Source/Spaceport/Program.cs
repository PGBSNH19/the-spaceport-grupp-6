using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Spaceport
{
    class Program
    {
        //public readonly string CONNECTION_STRING = Environment.GetEnvironmentVariable("project3_spaceport");
        public const string CONNECTION_STRING = @"Server=den1.mssql8.gear.host;Database=spaceport6;Uid=spaceport6;Pwd=Xb7I3!HZ12_g;";
        //public const string CONNECTION_STRING = @"Server=.\SQLExpress;Database=spaceport6;Integrated Security=SSPI;";
        static void Main(string[] args)
        {
            //Console.ReadLine();
            //Modules.WelcomeToSpacePark();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

            var context = new SpacePortDBContext();

            Console.WriteLine("Fetching ParkingSpots from Database...");
            var parkingSpots = GetParkingSpots();
            Console.WriteLine("Done.");

            Console.WriteLine("Fetching SpacePorts from Database...");
            var spacePorts = GetSpacePorts();
            Console.WriteLine("Done.");

            Console.WriteLine("Fetching People from Database...");
            var people = GetPeople();
            Console.WriteLine("Done.");


            // Ships cannot get their Person object - why?
            Console.WriteLine("Fetching SpaceShips from Database...");
            var ships = GetShips();
            Console.WriteLine("Done");

            foreach(var ship in ships)
            {
                Console.ReadLine();
            }

            var luke = new Person() { Name = "Luke Skywalker", PersonID = 1 };

            var coruscantSpacePort = new SpacePort() { SpacePortID = 1, Name = "Coruscant" };

            //SpaceShip bigShip = new StarShip() { SpaceShipID = 1, Length = 40, Driver = luke };

            //var parkingSession = new ParkingSession()
            //    .AtSpacePort(coruscantSpacePort)
            //    .SetForShip(bigShip)
            //    .ValidateParkingRight()
            //    .FindFreeSpot()
            //    .StartParkingSession();

            Console.ReadLine();
        }

        public static List<ParkingSpot> GetParkingSpots()
        {
            using var context = new SpacePortDBContext();
            return context.ParkingSpots.ToList();
        }

        public static List<SpacePort> GetSpacePorts()
        {
            using var context = new SpacePortDBContext();
            return context.SpacePorts.ToList();
        }

        public static List<Person> GetPeople()
        {
            using var context = new SpacePortDBContext();
            return context.Persons.ToList();
        }

        public static List<SpaceShip> GetShips()
        {
            using var context = new SpacePortDBContext();
            return context.SpaceShips.Include(x => x.Driver).ToList();
        }
    }
}
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
        public static readonly string CONNECTION_STRING = Environment.GetEnvironmentVariable("project3_spaceport");

        static void Main(string[] args)
        {
            Console.ReadLine();
            Modules.WelcomeToSpacePark();


            // Database async fetch
            Modules.InfoPrint("Fetching SpacePorts from Database...");
            var spacePorts = GetSpacePortsAsync();

            Modules.InfoPrint("Fetching SpaceShips from Database...");
            var spaceShips = GetShipsAsync();

            Task.WaitAll(new Task[] { spaceShips, spacePorts });
            Modules.InfoPrint("Done");

            var parkingSession = new ParkingSession()
                .AtSpacePort(spacePorts.Result.Where(n => n.Name == "Coruscant").First())
                .SetForShip(spaceShips.Result.Where(s => s.Driver.Name == "Luke Skywalker").First())
                .ValidateParkingRight()
                .FindFreeSpot()
                .StartParkingSession();

            Console.ReadLine();
        }

        public static async Task<List<ParkingSpot>> GetParkingSpotsAsync()
        {
            using var context = new SpacePortDBContext();
            return await context.ParkingSpots.ToListAsync();
        }

        public static async Task<List<SpacePort>> GetSpacePortsAsync()
        {
            using var context = new SpacePortDBContext();
            return await context.SpacePorts.ToListAsync();
        }

        public static async Task<List<Person>> GetPeopleAsync()
        {
            using var context = new SpacePortDBContext();
            return await context.Persons.ToListAsync();
        }

        public static async Task<List<SpaceShip>> GetShipsAsync()
        {
            using var context = new SpacePortDBContext();
            return await context.SpaceShips.Include(x => x.Driver).ToListAsync();
        }
    }
}
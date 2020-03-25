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
        public static readonly string CONNECTION_STRING = "Server=den1.mssql8.gear.host;Database=spaceport6;Uid=spaceport6;Pwd=Xb7I3!HZ12_g;";

        static void Main(string[] args)
        {
            Console.ReadLine();
            Styling.WelcomeToSpacePark();

            Styling.InfoPrint("Fetching SpacePorts from Database");
            var spacePorts = GetSpacePortsAsync();
            Styling.InfoPrint("Fetching SpaceShips from Database");
            var spaceShips = GetShipsAsync();

            new VisualProgress().AwaitAndShow(new Task[] { spaceShips, spacePorts });

            Styling.InfoPrint("\nDone");

            var parkingSession = new ParkingSession()
                .AtSpacePort(spacePorts.Result.Where(n => n.Name == "Coruscant").First())
                .SetForShip(spaceShips.Result.Where(s => s.Driver.Name == "Luke Skywalker").First())
                .ValidateParkingRight()
                .FindFreeSpot()
                .CreateInvoice()
                .PayInvoice()
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
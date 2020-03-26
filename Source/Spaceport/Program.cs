using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Spaceport
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            //Styling.PrintSpaceParkASCIILogo();

            Styling.InfoPrint("Fetching SpacePorts from Database");
            Task<List<SpacePort>> spacePorts; 
            Styling.InfoPrint("Fetching SpaceShips from Database");
            Task<List<SpaceShip>> spaceShips;

            new VisualProgressBar().AwaitAndShow(new Task[] { spacePorts = GetSpacePortsAsync(), spaceShips = GetSpaceShipsAsync() }).Wait();

            Styling.InfoPrint("\nDone", 2000);
            Styling.ConsolePrint("\nWelcome to SpacePark!\nWhich of our stations would do like to park at?");

            var parkingSession = new ParkingSession()
                .AtSpacePort(spacePorts.Result.Where(n => n.Name == "Coruscant").First())
                .SetForShip(spaceShips.Result.Where(s => s.Driver.Name == "Donald Trump").First())
                .ValidateParkingRight()
                .FindFreeSpot()
                .CreateInvoice()
                .PayInvoice()
                .StartParkingSession();

            Console.ReadLine();
        }

        public async static Task<List<SpacePort>> GetSpacePortsAsync()
        {
            using var context = new SpacePortDBContext();
            var result = await context.SpacePorts.ToListAsync();
            return result;
        }

        public async static Task<List<SpaceShip>> GetSpaceShipsAsync()
        {
                using var context = new SpacePortDBContext();
                var result = await context.SpaceShips.Include(x => x.Driver).ToListAsync();
                return result;
        }

        [Obsolete("Method not in use")]
        public static Task<List<ParkingSpot>> GetParkingSpotsAsync()
        {
            return Task.Run(() => {
                using var context = new SpacePortDBContext();
                return context.ParkingSpots.ToListAsync();
            });
        }

        [Obsolete("Method not in use")]
        public static Task<List<Person>> GetPeopleAsync()
        {
            return Task.Run(() => {
                using var context = new SpacePortDBContext();
                return context.Persons.ToListAsync();
            });
        }

    }
}
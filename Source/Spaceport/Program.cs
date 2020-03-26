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
            //Styling.PrintSpaceParkASCIILogo();

            Styling.InfoPrint("Fetching SpacePorts from Database");
            var spacePorts = GetSpacePortsAsync();
            Styling.InfoPrint("Fetching SpaceShips from Database");
            var spaceShips = GetSpaceShipsAsync();

            new VisualProgressBar().AwaitAndShow(new Task[] { spaceShips, spacePorts });

            Styling.InfoPrint("\nDone", 2000);
            Styling.ConsolePrint("\nWelcome to SpacePark!\nWhich of our stations would do like to park at?");

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

        public static Task<List<SpacePort>> GetSpacePortsAsync()
        {
            return Task.Run(() => {
                using var context = new SpacePortDBContext();
                return context.SpacePorts.ToListAsync();
            });
        }

        public static Task<List<SpaceShip>> GetSpaceShipsAsync()
        {
            return Task.Run(() => {
                using var context = new SpacePortDBContext();
                return context.SpaceShips.Include(x => x.Driver).ToListAsync();
            });
        }

        public static Task<List<ParkingSpot>> GetParkingSpotsAsync()
        {
            return Task.Run(() => {
                using var context = new SpacePortDBContext();
                return context.ParkingSpots.ToListAsync();
            });
        }

        public static Task<List<Person>> GetPeopleAsync()
        {
            return Task.Run(() => {
                using var context = new SpacePortDBContext();
                return context.Persons.ToListAsync();
            });
        }

    }
}
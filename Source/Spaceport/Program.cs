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

            Styling.InfoPrint("\nDone");
            Styling.ConsolePrint("\nWelcome to SpacePark!");

            var stationChoice = GetSpacePortChoice();
            

            var parkingSession = new ParkingSession().AtSpacePort(stationChoice);


                //parkingSession.SetForShip(spaceShips.Result.Where(s => s.Driver.Name == "Donald Trump").First())
                //.ValidateParkingRight()
                //.FindFreeSpot()
                //.CreateInvoice()
                //.PayInvoice()
                //.StartParkingSession();

            Console.ReadLine();
        }

        public static SpacePort GetSpacePortChoice()
        {
            Styling.ConsolePrint("\nWhich of our stations would do like to park at?");
            var choice = SpacePortExists(Console.ReadLine());
            while (choice == null)
            {
                Styling.ConsolePrint("Sorry that spacePort doesn't exist.");
                Styling.ConsolePrint("\nWhich of our stations would do like to park at?");
                choice = SpacePortExists(Console.ReadLine());
            }
            if (SpacePortIsFull(choice))
            {

            }
            return choice;
        }

        private static bool SpacePortIsFull(SpacePort choice)
        {
            using var context = new SpacePortDBContext();
            var parkingSpots = context.ParkingSpots.Where(x => x.SpacePortID == choice.SpacePortID).ToList();
            var availableSpots = context.ParkingSessions.Where(x => x.SpacePortID == choice.SpacePortID).ForEachAsync(x => x.);
            //result.ForEach(r => Console.WriteLine(choice.Name + " holds following parkingspots: " + r.ParkingSpotID));
            return true;
        }

        internal static SpacePort SpacePortExists(string choice)
        {
            using var context = new SpacePortDBContext();
            var result = context.SpacePorts.Where(x => x.Name == choice);
            return (result.Count() == 0) ? null : result.First();
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
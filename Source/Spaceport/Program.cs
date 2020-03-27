using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Spaceport.Models;

namespace Spaceport
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            while(true)
            {
                Console.Clear();
                Styling.PrintSpaceParkASCIILogo();

                Styling.ConsolePrint("\nWelcome to SpacePark!");

                var userInput = new UserInput().GetPersonChoice().GetSpaceShipChoice().GetSpacePortChoice();

                //var personChoice = GetPersonChoice();
                //CheckForUnpaidInvoice(personChoice);
                //var spaceShipChoice = GetSpaceShipChoice(personChoice);
                //var stationChoice = GetSpacePortChoice();

                var parkingSession = new ParkingSession()
                .AtSpacePort(userInput.SpacePort)
                .SetForShip(userInput.SpaceShip)
                .ValidateParkingRight(userInput.Person)
                .FindFreeSpot()
                .CreateInvoice()
                .StartParkingSession();

                Console.ReadLine();
            }
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
                var result = await context.SpaceShips.ToListAsync();
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
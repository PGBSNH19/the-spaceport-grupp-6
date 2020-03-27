﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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

            var personChoice = GetPersonChoice();
            Styling.ConsolePrint(personChoice.Name);

            var spaceShipChoice = GetSpaceShipChoice(personChoice);
            Styling.ConsolePrint($"SpaceShipID: {spaceShipChoice.SpaceShipID} is of length {spaceShipChoice.Length} spacemeteres and registered under {personChoice.Name}");

            var stationChoice = GetSpacePortChoice();
            

            var parkingSession = new ParkingSession().AtSpacePort(stationChoice);


            parkingSession.SetForShip(spaceShips.Result.Where(s => s.Driver.Name == "Luke Skywalker").First())
            .ValidateParkingRight()
            .FindFreeSpot()
            .CreateInvoice()
            .PayInvoice()
            .StartParkingSession();

            Console.ReadLine();
        }

        private static SpaceShip GetSpaceShipChoice(Person driver)
        {
            if (SpaceShip.EntityExistsInDatabase(driver))
            {
                Styling.ConsolePrint("\nFound a ship registered with your name.");
            }
            else
            {

                Styling.ConsolePrint("\nNo ships matching under your name.");
                string length = String.Empty;
                while (int.TryParse(length, out int result) == false)
                {
                    Styling.ConsolePrint("What's the length of your ship? (In spacemeters)");
                    length = Console.ReadLine();
                }

                SpaceShip.AddEntityToDatabase(driver, int.Parse(length));
            }

            return SpaceShip.GetEntityFromDatabase(driver);
        }

        public static Person GetPersonChoice()
        {
            Styling.ConsolePrint("\nWhat's your SSN? ");
            var ssn = Console.ReadLine();
            if (!Person.EntityExistsInDatabase(ssn))
            {
                Styling.ConsolePrint("\nEnter your full name: ");
                var name = Console.ReadLine();
                Person.AddEntityToDatabase(ssn, name);
            }
            return Person.GetEntityFromDatabase(ssn);
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
            if (SpacePort.SpacePortIsFull(choice))
            {
                // Do something here?
            }
            return choice;
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
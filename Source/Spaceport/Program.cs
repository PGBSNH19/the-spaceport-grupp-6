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

            CheckForUnpaidInvoice(personChoice);

            var spaceShipChoice = GetSpaceShipChoice(personChoice);
            Styling.ConsolePrint($"SpaceShipID: {spaceShipChoice.SpaceShipID} is of length {spaceShipChoice.Length} spacemeteres and registered under {personChoice.Name}");

            DisplaySpacePorts();
            var stationChoice = GetSpacePortChoice();

            var parkingSession = new ParkingSession().AtSpacePort(stationChoice);

            parkingSession.SetForShip(spaceShipChoice)
            .ValidateParkingRight(personChoice)
            .FindFreeSpot()
            .CreateInvoice()
            .PayInvoice()
            .StartParkingSession();

            Console.ReadLine();
        }

        private static void CheckForUnpaidInvoice(Person person)
        {
            Invoice invoice = Invoice.UnpaidInvoiceFromPerson(person);
            while (invoice != null)
            {
                Styling.ConsolePrint("\nUnpaid invoice detected!");
                Styling.ConsolePrint("\nWould you like to pay? [Y/N]");
                
                var userInput = Console.ReadLine();

                if (userInput.ToLower() == "n")
                {
                    CheckForUnpaidInvoice(person);
                }
                else if (userInput.ToLower() == "y")
                {
                    invoice.Pay();
                    return;
                }
            }
        }

        private static void DisplaySpacePorts()
        {
            Styling.ConsolePrint("\nExisting spaceports:");

            using var context = new SpacePortDBContext();
            var spaceports = context.SpacePorts;

            foreach (SpacePort spaceport in spaceports)
            {
                Styling.ConsolePrint("\nID: " + spaceport.SpacePortID + " Name: " + spaceport.Name
                    + " Has available parking spots: " + (spaceport.HasAvailableParkingspots() ? "Yes" : "No"));
            }

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
            Styling.ConsolePrint("\nEnter Id of the station you would do like to park at: ");
            var choice = SpacePortExists(int.Parse(Console.ReadLine()));
            while (choice == null)
            {
                Styling.ConsolePrint("Sorry that spacePort doesn't exist.");
                Styling.ConsolePrint("\nWhich of our stations would do like to park at?");
                choice = SpacePortExists(int.Parse(Console.ReadLine()));
            }
            if (choice.HasAvailableParkingspots())
            {
                // Do something here?
            }
            return choice;
        }

        internal static SpacePort SpacePortExists(int choice)
        {
            using var context = new SpacePortDBContext();
            var result = context.SpacePorts.Where(x => x.SpacePortID == choice);
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
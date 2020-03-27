using Spaceport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spaceport
{
    class UserInput
    {
        public Person Person { get; set; }
        public SpaceShip SpaceShip { get; set; }
        public SpacePort SpacePort { get; set; }

        public UserInput GetPersonChoice()
        {
            Styling.ConsolePrint("Enter your SSN:");
            var ssn = Console.ReadLine();
            if (!Person.EntityExistsInDatabase(ssn))
            {
                Styling.ConsolePrint("Enter your full name: ");
                var name = Console.ReadLine();
                Person.AddEntityToDatabase(ssn, name);
            }
            Person = Person.GetEntityFromDatabase(ssn);
            Styling.ConsolePrint("Well met, " + Person.Name + ".");
            CheckForUnpaidInvoice();
            return this;
        }

        public UserInput GetSpaceShipChoice()
        {
            if (SpaceShip.EntityExistsInDatabase(Person))
            {
                SpaceShip = SpaceShip.GetEntityFromDatabase(Person);
                Styling.ConsolePrint($"\nGood news! A SpaceShip of {SpaceShip.Length} spacemeters is already registered in your name.");
            }
            else
            {
                Styling.ConsolePrint("\nNo ships registered under your name.");
                string length = String.Empty;
                while (int.TryParse(length, out int result) == false)
                {
                    Styling.ConsolePrint("What's the length of your ship? (In spacemeters please)");
                    length = Console.ReadLine();
                }

                SpaceShip.AddEntityToDatabase(Person, int.Parse(length));
                SpaceShip = SpaceShip.GetEntityFromDatabase(Person);
            }
            return this;
        }

        public UserInput GetSpacePortChoice()
        {
            DisplaySpacePorts();
            Styling.ConsolePrint("\nEnter ID of the SpacePort you would do like to park at: ");
            var choice = SpacePortExists(int.Parse(Console.ReadLine()));

            while (choice == null || !choice.HasAvailableParkingspots())
            {
                if(choice == null)
                {
                    Styling.ConsolePrint("Sorry that SpacePort doesn't exist.");
                }
                else
                {
                    Styling.ConsolePrint("Sorry that SpacePort is closed due to no available spots.");
                }
                Styling.ConsolePrint("\nWhich of our SpacePorts would do like to park at?");
                choice = SpacePortExists(int.Parse(Console.ReadLine()));
            }
            SpacePort = choice;
            return this;
        }

        public SpacePort SpacePortExists(int choice)
        {
            using var context = new SpacePortDBContext();
            var result = context.SpacePorts.Where(x => x.SpacePortID == choice);
            return (result.Count() == 0) ? null : result.First();
        }

        private void CheckForUnpaidInvoice()
        {
            Invoice invoice = Invoice.UnpaidInvoiceFromPerson(Person);
            while (invoice != null)
            {
                Styling.ConsolePrint("\nUnpaid invoice detected!");
                Styling.ConsolePrint("Would you like to pay? [Y/N]");

                var userInput = Console.ReadLine();

                if (userInput.ToLower() == "n")
                {
                    CheckForUnpaidInvoice();
                }
                else if (userInput.ToLower() == "y")
                {
                    ParkingSpot.FreeSpotByID(invoice.ParkingSpotID);
                    invoice.Pay();
                    return;
                }
            }
        }

        private void DisplaySpacePorts()
        {
            Styling.ConsolePrint("\nExisting spaceports:");

            using var context = new SpacePortDBContext();
            var spaceports = context.SpacePorts;

            foreach (SpacePort spaceport in spaceports)
            {
                Styling.ConsolePrint($"ID: {spaceport.SpacePortID} " +
                    $"\tName:  {spaceport.Name.PadRight(14,' ')} " +
                    $"\tStatus:  {(spaceport.HasAvailableParkingspots() ? "Available Parkingspots" : "Closed")}",0);
            }
        }
        
    }
}

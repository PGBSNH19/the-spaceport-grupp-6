using Spaceport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var personExistsTask = Task.Run(() => Person.EntityExistsInDatabase(ssn));
            new VisualProgressBar().
                AwaitAndShow(new Task[] { personExistsTask })
                .Wait();
            if (!personExistsTask.Result)
            {
                Styling.ConsolePrint("\nEnter your full name: ");
                var name = Console.ReadLine();
                Person.AddEntityToDatabase(ssn, name);
            }
            var personFetchTask = Task.Run(() => Person.GetEntityFromDatabase(ssn));
            new VisualProgressBar().
                AwaitAndShow(new Task[] { personFetchTask })
                .Wait();
            Person = personFetchTask.Result;
            Styling.ConsolePrint("\nWell met, " + Person.Name + ".");
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
            var spacePort = SpacePortExists(int.Parse(Console.ReadLine()));

            while (spacePort == null || !spacePort.HasAvailableParkingspots() || spacePort.FindFreeParkingSpot(SpaceShip).Count() == 0)
            {
                if(spacePort == null)
                {
                    Styling.ConsolePrint("Sorry that SpacePort doesn't exist.");
                }
                else if (spacePort.FindFreeParkingSpot(SpaceShip).Count() == 0)
                {
                    Styling.ConsolePrint($"{"\nNo suitable parking spot found to support ship length."}");
                }
                else
                {
                    Styling.ConsolePrint("Sorry that SpacePort is closed due to no available spots.");
                }
                Styling.ConsolePrint("\nWhich of our SpacePorts would do like to park at?");
                spacePort = SpacePortExists(int.Parse(Console.ReadLine()));
            }
            SpacePort = spacePort;
            return this;
        }

        public SpacePort SpacePortExists(int spacePortID)
        {
            using var context = new SpacePortDBContext();
            var result = context.SpacePorts.Where(x => x.SpacePortID == spacePortID);
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
                    invoice.Pay(DateTime.Now);
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

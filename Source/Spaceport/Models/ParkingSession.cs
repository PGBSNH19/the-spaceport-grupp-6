using Spaceport.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spaceport
{
    [Table("ParkingSessions")]
    public class ParkingSession
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParkingSessionID { get; set; }
        public ParkingSpot ParkingSpot { get; set; }
        public int ParkingSpotID { get; set; }
        public virtual SpaceShip SpaceShip { get; set; }
        public int SpaceShipID { get; set; }
        public bool ParkingToken { get; set; }
        public DateTime RegistrationTime { get; set; }
        [NotMapped]
        public SpacePort SpacePort { get; set; }
        public int SpacePortID { get; set; }
        public Invoice Invoice { get; set; }
        public int InvoiceID { get; set; }

        public ParkingSession AtSpacePort(SpacePort port)
        {
            SpacePort = port;
            Styling.ConsolePrint($"\nThank you for choosing SpacePort {SpacePort.Name}.");
            Styling.ConsolePrint("We need some information about your ship.");
            return this;
        }

        public ParkingSession CreateInvoice()
        {
            Invoice = new Invoice()
            {
                Paid = false
            };

            Invoice.AddEntityToDatabase();
            return this;
        }

        public ParkingSession PayInvoice()
        {
            Invoice.Pay(RegistrationTime);
            return this;
        }

        public ParkingSession SetForShip(SpaceShip ship)
        {
            SpaceShip = ship;
            Styling.ConsolePrint($"\nYour ship has been registered with a length of {SpaceShip.Length} spacemeters.");
            return this;
        }

        public ParkingSession ValidateParkingRight(Person driver)
        {
            SpaceShip.Driver = driver;
            Styling.ConsolePrint("\nSpacePark is an exclusive SpacePort.\nWe need to run a background check on you.");
            ParkingToken = this.SpaceShip.Driver.IsPartOfStarwars();
            if (ParkingToken)
            {
                Styling.ConsolePrint($"\n{SpaceShip.Driver.Name}, what a pleasure!\nYou have been given an access token to park.");
            }
            else
            {
                Styling.ConsolePrint($"\n{SpaceShip.Driver.Name} sorry SpacePark cannot let you park.");
                Console.ReadLine();
                Environment.Exit(0);
            }
            return this;
        }

        public ParkingSession FindFreeSpot()
        {
            ParkingSpot = SpacePort.FindFreeParkingSpot(SpaceShip);
            if (ParkingSpot == null)
            {
                Styling.ConsolePrint($"{"\nNo suitable parking spot found."}");
                Console.ReadLine();
                Environment.Exit(0);
            }
            return this;
        }

        public ParkingSession StartParkingSession()
        {
            RegistrationTime = DateTime.Now;
            AddEntityToDatabase();
            Console.WriteLine("\nParking session started");
            return this;
        }

        internal void AddEntityToDatabase()
        {
            using (var context = new SpacePortDBContext())
            {
                var session = new ParkingSession()
                {
                    ParkingToken = this.ParkingToken,
                    ParkingSpotID = ParkingSpot.ParkingSpotID,
                    SpaceShipID = SpaceShip.SpaceShipID,
                    RegistrationTime = RegistrationTime,
                    SpacePortID = this.SpacePort.SpacePortID,
                    InvoiceID = this.Invoice.InvoiceID
                };
                context.ParkingSessions.Add(session);
                context.SaveChanges();
            }
        }
    }
}

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
        [Required]
        [ForeignKey("ParkingSpotID")]
        public ParkingSpot ParkingSpot { get; set; }
        [Required]
        public virtual SpaceShip SpaceShip { get; set; }
        [Required]
        public bool ParkingToken { get; set; }
        [Required]
        public DateTime RegistrationTime { get; set; }
        [NotMapped]
        public SpacePort SpacePort { get; set; }
        [ForeignKey("InvoiceID")]
        [Required]
        public Invoice Invoice { get; set; }

        public ParkingSession()
        {
            Styling.ConsolePrint("\nWelcome to SpacePark!\nWhich of our stations would do like to park at?");
        }

        public ParkingSession AtSpacePort(SpacePort port)
        {
            SpacePort = port;
            Styling.ConsolePrint($"\nThank you for choosing SpacePort {SpacePort.Name}.\nWe need some information about your ship.");
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
            Styling.ConsolePrint("\nYour ship has been registered.");
            return this;
        }

        public ParkingSession ValidateParkingRight()
        {
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
            ParkingSpot = SpacePort.FindFreeParkingSpot(SpacePort, SpaceShip);
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
            using (var context = new SpacePortDBContext())
            {
                var parkingSessionContext = context.Set<ParkingSession>();
                parkingSessionContext.Add(this);
                context.SaveChanges();
            }

            Console.WriteLine("\nParking session started");
            return this;
        }
    }
}

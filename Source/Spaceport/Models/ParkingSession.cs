using Microsoft.Data.SqlClient;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Threading;

namespace Spaceport
{
    [Table("ParkingSessions")]
    public class ParkingSession
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParkingSessionID { get; set; }
        [Required]
        public ParkingSpot ParkingSpot { get; set; }
        [Required]
        public virtual SpaceShip SpaceShip { get; set; }
        [Required]
        public bool ParkingToken { get; set; }
        [Required]
        public DateTime RegistrationTime { get; set; }
        [NotMapped]
        public SpacePort SpacePort { get; set; }

        public ParkingSession()
        {
            Styling.ComputerPrint("\nWelcome to SpacePark!\nWhich of our stations would do like to park at?");
        }

        public ParkingSession AtSpacePort(SpacePort port)
        {
            SpacePort = port;
            Styling.ComputerPrint($"\nThank you for choosing SpacePort {SpacePort.Name}.\nWe need some information about your ship.");
            return this;
        }

        public ParkingSession SetForShip(SpaceShip ship)
        {
            SpaceShip = ship;
            Styling.ComputerPrint("\nYour ship has been registered.");
            return this;
        }

        public ParkingSession ValidateParkingRight()
        {
            Styling.ComputerPrint("\nSpacePark is an exclusive SpacePort.\nWe need to run a background check on you.");
            ParkingToken = this.SpaceShip.Driver.IsPartOfStarwars();
            if (ParkingToken)
            {
                Styling.ComputerPrint($"\n{SpaceShip.Driver.Name}, what a pleasure!\nYou have been given an access token to park.");
            }
            else
            {
                Styling.ComputerPrint($"\n{SpaceShip.Driver.Name} sorry SpacePark cannot let you park.");
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
                Styling.ComputerPrint($"{"\nNo suitable parking spot found."}");
                Console.ReadLine();
                Environment.Exit(0);

            }
            return this;
        }

        public ParkingSession StartParkingSession()
        {
            Console.WriteLine("\nParking session started");
            return this;
        }
    }
}

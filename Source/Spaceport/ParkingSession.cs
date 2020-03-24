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
            var left = Console.CursorLeft;
            Modules.ComputerPrint("\nWelcome to SpacePark!\nWhich of our stations would do like to park at?");
        }

        public ParkingSession AtSpacePort(SpacePort port)
        {
            SpacePort = port;
            Modules.ComputerPrint($"\nThank you for choosing SpacePort {SpacePort.Name}.\nWe need some information about your ship.");
            return this;
        }


        public ParkingSession SetForShip(SpaceShip ship)
        {
            SpaceShip = ship;
            Modules.ComputerPrint("\nYour ship has been registered.");
            return this;
        }

        public ParkingSession ValidateParkingRight()
        {
            Modules.ComputerPrint("\nSpacePark is an exclusive SpacePort.\nWe need to run a background check on you.");
            ParkingToken = this.SpaceShip.Driver.IsPartOfStarwars();
            if (ParkingToken)
            {
                Modules.ComputerPrint($"\n{SpaceShip.Driver.Name}, what a pleasure!\nYou have been given an access token to park.");
            }
            else
            {
                Modules.ComputerPrint($"\n{SpaceShip.Driver.Name} sorry SpacePark cannot let you park.");
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
                Modules.ComputerPrint($"{"\nNo suitable parking spot found."}");
                Console.ReadLine();
                Environment.Exit(0);

            }
            return this;
        }

        public ParkingSession StartParkingSession()
        {
            Console.WriteLine("\nParking session started");
            return this;
            //    RegistrationTime = DateTime.Now;
            //    using SqlConnection conn = new SqlConnection(Program.CONNECTION_STRING);

            //    Console.WriteLine("INSERT INTO ParkingSessions " +
            //        "(ParkingSpotID, " +
            //        "SpaceShipID, " +
            //        "SpacePortID, " +
            //        "ParkingToken, " +
            //        "RegistrationTime) " +
            //        "VALUES " +
            //        $"({ParkingSpot.ParkingSpotID}, " +
            //        $"{SpaceShip.SpaceShipID}, " +
            //        $"{SpacePort.SpacePortID}, " +
            //        $"{ParkingToken}, " +
            //        $"{RegistrationTime.ToString("yyyy/MM/dd hh:mm:ss.fffffff")})");

            //    Console.WriteLine("Press any key to update database...");
            //    Console.ReadLine();

            //    conn.Open();
            //    SqlCommand cmd = new SqlCommand(
            //        "INSERT INTO ParkingSessions " +
            //        "(ParkingSpotID, " +
            //        "SpaceShipID, " +
            //        "SpacePortID, " +
            //        "ParkingToken, " +
            //        "RegistrationTime) " +
            //        "VALUES " +
            //        $"({ParkingSpot.ParkingSpotID}, " +
            //        $"{SpaceShip.SpaceShipID}, " +
            //        $"{SpacePort.SpacePortID}, " +
            //        $"@t, " +
            //        $"@d)"
            //        , conn); 

            //    var ParamRegistrationTime = new SqlParameter("@d", SqlDbType.DateTime2);
            //    ParamRegistrationTime.Value = RegistrationTime;
            //    cmd.Parameters.Add(ParamRegistrationTime);

            //    var ParamToken = new SqlParameter("@t", SqlDbType.Bit);
            //    ParamToken.Value = ParkingToken;
            //    cmd.Parameters.Add(ParamToken);

            //    try
            //    {
            //        cmd.ExecuteNonQuery();
            //        Console.WriteLine("Your parking has been granted and ParkingSession verified!");
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine("Exception adding ParkingSession to DB: " + e.ToString());
            //    }
        }
    }
}

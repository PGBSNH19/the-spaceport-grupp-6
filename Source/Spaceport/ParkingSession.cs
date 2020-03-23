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

        public ParkingSession()
        {
            var left = Console.CursorLeft;
            ComputerPrint("Welcome to SpacePark!");
            ComputerPrint("Which of our stations woulld do like to park at?", 1000);
        }

        internal void ComputerPrint(string s, int milliSeconds = 500)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < s.Length; i++)
            {
                Console.Write(s[i]);
                Thread.Sleep(20);
            }
            Console.Write("\n");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(milliSeconds);
        }

        //public ParkingSession AtSpacePort(SpacePort port)
        //{
        //    SpacePort = port;
        //    ComputerPrint($"Thank you for choosing SpacePort {SpacePort.Name}.");
        //    ComputerPrint($"We need some information about your ship.", 1000);
        //    return this;
        //}


        public ParkingSession SetForShip(SpaceShip ship)
        {
            SpaceShip = ship;
            ComputerPrint("Your ship has been registered.", 1000);
            ComputerPrint("SpacePark is an exclusive SpacePort.");
            ComputerPrint("We need to run a background check on you.");
            return this;
        }

        public ParkingSession ValidateParkingRight()
        {
            ParkingToken = this.SpaceShip.Driver.IsPartOfStarwars();
            if (ParkingToken)
            {
                ComputerPrint($"{SpaceShip.Driver.Name}, what a pleasure!", 1000);
                ComputerPrint("You have been given an access token to park.");
            }
            else
            {
                ComputerPrint($"{SpaceShip.Driver.Name}, I'm sorry.", 1000);
                ComputerPrint($"SpacePark cannot let you park.", 1000);
                Console.ReadLine();
                Environment.Exit(0);
            }
            return this;
        }

        //public ParkingSession FindFreeSpot()
        //{
        //    ParkingSpot = SpacePort.FindFreeParkingSpot(SpacePort, SpaceShip.Length);
        //    if (ParkingSpot == null)
        //        throw new Exception("No suitable ParkingSpots available");
        //    return this;
        //}

        //public ParkingSession StartParkingSession()
        //{
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
            
        //    return this;
        //}
    }
}

using Microsoft.Data.SqlClient;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spaceport
{
    public class ParkingSession
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParkingSessionID { get; set; }
        public ParkingSpot ParkingSpot { get; set; }
        public ISpaceShip SpaceShip { get; set; }
        public SpacePort SpacePort { get; set; }
        public bool ParkingToken { get; set; }
        public DateTime RegistrationTime { get; set; }

        public ParkingSession SetForShip(ISpaceShip ship)
        {
            SpaceShip = ship;
            return this;
        }

        public ParkingSession  ValidateParkingRight()
        {
            ParkingToken = this.SpaceShip.Driver.IsPartOfStarwars();
            return this;
        }

        public ParkingSession AtSpacePort(SpacePort port)
        {
            SpacePort = port;
            return this;
        }

        public ParkingSession FindFreeSpot()
        {
            ParkingSpot = SpacePort.FreeParkingSpot(SpaceShip.Length);
            return this;
        }

        public ParkingSession StartParkingSession()
        {
            RegistrationTime = DateTime.Now;
            using (SqlConnection conn = new SqlConnection(Program.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into ParkingSessions(ParkingSpotID, SpaceShipID, SpacePortID, ParkingToken, RegistrationTime) values (@ParkingSpotID, @SpaceShipID, @SpacePortID, @ParkingToken, @RegistrationTime)", conn);
                SqlParameter paramParkingSpotID = new SqlParameter
                {
                    ParameterName = "@ParkingSpotID",
                    Value = this.ParkingSpot.ParkingSpotID
                };
                cmd.Parameters.Add(paramParkingSpotID);
                SqlParameter paramSpaceShipID = new SqlParameter
                {
                    ParameterName = "@SpaceShipID",
                    Value = this.SpaceShip.SpaceShipID
                };
                cmd.Parameters.Add(paramSpaceShipID);
                SqlParameter paramSpacePortID = new SqlParameter
                {
                    ParameterName = "@SpacePortID",
                    Value = this.SpacePort.SpacePortID
                };
                cmd.Parameters.Add(paramSpacePortID);
                SqlParameter paramParkingToken = new SqlParameter
                {
                    ParameterName = "@ParkingToken",
                    Value = this.ParkingToken
                };
                cmd.Parameters.Add(paramParkingToken);
                SqlParameter paramRegistrationTime = new SqlParameter
                {
                    ParameterName = "@RegistrationTime",
                    Value = this.RegistrationTime
                };
                cmd.Parameters.Add(paramRegistrationTime);
                try
                {
                    cmd.ExecuteScalar();
                    Console.WriteLine("ParkingSession added!");
                }
                catch(Exception e)
                {
                    Console.WriteLine("Unable to add ParkingSession");
                }
            }
            return this;
        }
    }
}

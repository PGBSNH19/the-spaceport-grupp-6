using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaceport
{
    public class SpacePort
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpacePortID { get; set; }
        public string Name { get; set; }

        public SpacePort()
        {

        }

        public ParkingSpot FindFreeParkingSpot(SpacePort spacePort, int shipLength)
        {
            return new ParkingSpot() { SpacePort = spacePort };
            //using SqlConnection conn = new SqlConnection(Program.CONNECTION_STRING);
            //conn.Open();
            //string sql =
            //    $"SELECT * " +
            //    $"FROM ParkingSpots " +
            //    $"WHERE SpacePortID = {spacePort.SpacePortID} " +
            //    $"AND Occupied = 0 " +
            //    $"AND MaxLength >= {shipLength}";
            //SqlCommand cmd = new SqlCommand(sql, conn);
            //using SqlDataReader rdr = cmd.ExecuteReader();
            //Console.WriteLine($"Searching for suitable ParkingSpot at {spacePort.Name} SpacePort.");
            //if (rdr.Read())
            //{
            //    Console.WriteLine($"Unoccupied ParkingSpot found supporting your Ship's length of {shipLength}.");
            //    return new ParkingSpot()
            //    {
            //        ParkingSpotID = Int32.Parse(rdr["ParkingSpotID"].ToString()),
            //        MaxLength = Int32.Parse(rdr["MaxLength"].ToString()),
            //        SpacePortID = Int32.Parse(rdr["SpacePortID"].ToString()),
            //        Occupied = bool.Parse(rdr["Occupied"].ToString())
            //    };
            //}
            //else
            //{
            //    Console.WriteLine("No suitable ParkingSpots at " + spacePort.Name + " SpacePort");
            //    //throw new Exception("No suitable ParkingSpots at " + spacePort.Name + " SpacePort");
            //    return null;
            //}
        }
    }
}

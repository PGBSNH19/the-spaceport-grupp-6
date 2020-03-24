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
    [Table("SpacePorts")]
    public class SpacePort
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpacePortID { get; set; }
        [Required]
        public string Name { get; set; }

        public SpacePort()
        {

        }

        public ParkingSpot FindFreeParkingSpot(SpacePort spacePort, SpaceShip spaceShip)
        {
            using SpacePortDBContext context = new SpacePortDBContext();
            var result = context.ParkingSpots.
                Where(x => x.SpacePort == spacePort
                && x.Occupied == false
                && x.MaxLength >= spaceShip.Length);

            return (result.Count() == 0) ? null : result.First();
        }
    }
}

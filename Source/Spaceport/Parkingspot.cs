using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Spaceport
{
    public class ParkingSpot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParkingSpotID { get; set; }
        public int MaxLength { get; set; }
        public int SpacePortID { get; set; }
        public bool Occupied { get; set; }
    }
}

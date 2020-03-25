using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Spaceport
{
    [Table("ParkingSpots")]
    public class ParkingSpot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParkingSpotID { get; set; }
        [Required]
        public int MaxLength { get; set; }
        public SpacePort? SpacePort { get; set; }
        public bool Occupied { get; set; }
    }
}

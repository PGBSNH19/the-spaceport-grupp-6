﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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

        public ParkingSpot FindFreeParkingSpot(SpaceShip spaceShip)
        {
            using SpacePortDBContext context = new SpacePortDBContext();
            var result = context.ParkingSpots.Where(x => x.SpacePortID == SpacePortID
                && x.Occupied == false
                && x.MaxLength >= spaceShip.Length);

            return (result.Count() == 0) ? null : result.First();
        }

        public static bool SpacePortIsFull(SpacePort choice)
        {
            using var context = new SpacePortDBContext();
            var occupiedSpots = context.ParkingSessions.Where(x => !x.Invoice.Paid && x.ParkingSpot.SpacePortID == choice.SpacePortID).Select(x => x.ParkingSpot).ToList();
            var parkingSpots = context.ParkingSpots.Where(x => x.SpacePortID == choice.SpacePortID).ToList();

            foreach (ParkingSpot occupiedSpot in occupiedSpots)
            {
                parkingSpots.RemoveAll(x => x.ParkingSpotID == occupiedSpot.ParkingSpotID);
            }

            return parkingSpots.Count() > 0;
        }
    }
}

﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
        public SpacePort SpacePort { get; set; }
        public int SpacePortID { get; set; }
        public bool Occupied { get; set; }
        
        internal void UpdateEntityInDatabase()
        {
            using var context = new SpacePortDBContext();
            var invoiceContext = context.Set<ParkingSpot>();
            invoiceContext.Update(this);
            context.SaveChanges();
        }

        public static void FreeSpotByID(int parkingSpotID)
        {
            using var context = new SpacePortDBContext();
            var res = context.ParkingSpots.Where(x => x.ParkingSpotID == parkingSpotID).FirstOrDefault();
            if(res != null)
            {
                res.Occupied = false;
                context.Set<ParkingSpot>().Update(res);
                context.SaveChanges();
            }
        }
    }
}

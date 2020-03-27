using System.ComponentModel.DataAnnotations;
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
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spaceport
{
    public interface ISpaceShip
    {
        public int SpaceShipID { get; set; }
        public Person Driver { get; set; }
        public int Length { get; set; }
    }

    public class SpaceShip : ISpaceShip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpaceShipID { get; set; }
        public Person Driver { get; set; }
        public int Length { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Spaceport
{
    public class StarShip : ISpaceShip
    {
        [Key]
        public int SpaceShipID { get; set; }
        public int Name { get; set; }
        public Person Driver { get; set; }
        public int Length { get; set; }
    }
}

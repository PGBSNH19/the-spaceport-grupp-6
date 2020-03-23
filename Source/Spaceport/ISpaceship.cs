using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spaceport
{
    public interface ISpaceShip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpaceShipID { get; set; }
        [Required]
        public Person Person { get; set; }
        public int Length { get; set; }
    }

    public class SpaceShip : ISpaceShip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpaceShipID { get; set; }
        [Required]
        public Person Person { get; set; }
        public int Length { get; set; }
    }
}

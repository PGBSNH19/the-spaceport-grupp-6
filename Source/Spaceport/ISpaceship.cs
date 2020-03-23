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
        [Column("DriverPersonID")]
        public Person Driver { get; set; }
        public int Length { get; set; }
    }

    [Table("SpaceShips")]
    public class SpaceShip : ISpaceShip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpaceShipID { get; set; }
        [Required]
        public Person Driver { get; set; }
        public int Length { get; set; }
    }
}

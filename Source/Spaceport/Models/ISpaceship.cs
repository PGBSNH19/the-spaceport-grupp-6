using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Spaceport
{
    public interface ISpaceShip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpaceShipID { get; set; }
        public int DriverPersonID { get; set; }
        public int Length { get; set; }
    }

    [Table("SpaceShips")]
    public class SpaceShip : ISpaceShip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpaceShipID { get; set; }
        [Column("DriverPersonID")]
        public int DriverPersonID { get; set; }
        [NotMapped]
        public Person Driver { get; set; }
        public int Length { get; set; }

        public static bool EntityExistsInDatabase(Person driver)
        {
            var context = new SpacePortDBContext();
            return context.SpaceShips.Any(x => x.DriverPersonID == driver.PersonID);
        }

        public static void AddEntityToDatabase(Person driver, int length)
        {
            var ship = new SpaceShip()
            {
                DriverPersonID = driver.PersonID,
                Length = length
            };
            using var context = new SpacePortDBContext();
            context.Set<SpaceShip>().Add(ship);
            context.SaveChanges();
            Console.WriteLine("Ship Added");
        }

        internal static SpaceShip GetEntityFromDatabase(Person driver)
        {
            using var context = new SpacePortDBContext();
            return context.SpaceShips.Where(x => x.DriverPersonID == driver.PersonID).First();
        }
    }
}

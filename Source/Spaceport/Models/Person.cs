using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Spaceport
{
    [Table("Persons")]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonID { get; set; }
        // Note: 
        // Specify more of these to avoid varchar(max)
        [Required]
        [MaxLength(50)] 
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string SSN { get; set; }

        public bool IsPartOfStarwars()
        {
            return APIConsumer.SearchCharacterAsync(Name).Results.Any();
        }

        internal static bool EntityExistsInDatabase(string ssn)
        {
            using var context = new SpacePortDBContext();
            return context.Persons.Any(x => x.SSN == ssn);
        }

        internal static void AddEntityToDatabase(string ssn, string name)
        {
            var myperson = new Person
            {
                Name = name,
                SSN = ssn
            };

            using var context = new SpacePortDBContext();
            context.Set<Person>().Add(myperson);
            context.SaveChanges();
        }

        internal static Person GetEntityFromDatabase(string ssn)
        {
            using SpacePortDBContext context = new SpacePortDBContext();
            var person = context.Persons.Where(x => x.SSN == ssn).First();
            return person;
        }
    }
}

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

        public bool IsPartOfStarwars()
        {
            return APIConsumer.SearchCharacterAsync(Name).Results.Any();
        }
    }
}

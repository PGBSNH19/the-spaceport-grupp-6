using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spaceport
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonID { get; set; }
        // Note: 
        // Specify more of these to avoid varchar(max)
        [MaxLength(50)] 
        public string Name { get; set; }

        public bool IsPartOfStarwars()
        {
            var test = APIConsumer.GetCharacterAsync(Name);
            return test;
        }
    }
}

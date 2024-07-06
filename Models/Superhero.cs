using System.ComponentModel.DataAnnotations;

namespace Suberheroes.Models
{
    public class Superhero
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Palce { get; set; }



    }
}

using System.ComponentModel.DataAnnotations;

namespace CarsPlatform.Core.Entities
{
    public class Colour
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ColourName { get; set; } = null!;

        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}

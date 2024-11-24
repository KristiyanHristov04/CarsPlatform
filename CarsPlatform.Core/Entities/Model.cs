using System.ComponentModel.DataAnnotations;

namespace CarsPlatform.Core.Entities
{
    public class Model
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ModelName { get; set; } = null!;

        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}

using System.ComponentModel.DataAnnotations;

namespace CarsPlatform.Core.Entities
{
    public class FuelType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FuelTypeName { get; set; } = null!;

        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}

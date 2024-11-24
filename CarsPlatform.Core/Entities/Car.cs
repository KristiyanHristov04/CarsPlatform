using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsPlatform.Core.Entities
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Make))]
        public int MakeId { get; set; }
        public Make Make { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Model))]
        public int ModelId { get; set; }
        public Model Model { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Colour))]
        public int ColourId { get; set; }
        public Colour Colour { get; set; } = null!;

        [Required]
        public int ReleaseYear { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        [ForeignKey(nameof(FuelType))]
        public int FuelTypeId { get; set; }
        public FuelType FuelType { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Transmission))]
        public int TransmissionId { get; set; }
        public Transmission Transmission { get; set; } = null!;
    }
}

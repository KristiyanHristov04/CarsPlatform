using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsPlatform.Application.Models.FormModels
{
    public class CreateCarFormModel
    {
        public List<string> Makes { get; set; } = new List<string>();

        [Required]
        public string Make { get; set; } = null!;

        [Required]
        public string Model { get; set; } = null!;
        public List<string> Colours { get; set; } = new List<string>();

        [Required]
        public string Colour { get; set; } = null!;

        [Required]
        [Range(1890, 2025)]
        public int Year { get; set; }

        [Required]
        [Range(0, 10000000)]
        public int Price { get; set; }
        public List<string> FuelTypes { get; set; } = new List<string>();

        [Required]
        public string Fuel { get; set; } = null!;
        public List<string> TransmissionTypes { get; set; } = new List<string>();

        [Required]
        public string Transmission { get; set; } = null!;
    }
}

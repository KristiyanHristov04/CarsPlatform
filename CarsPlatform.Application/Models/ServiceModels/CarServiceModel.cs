using CsvHelper.Configuration.Attributes;

namespace CarsPlatform.Application.Models.ServiceModels
{
    public class CarServiceModel
    {
        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string Colour { get; set; } = null!;

        public int Year { get; set; }

        public int Price { get; set; }

        [Name("Fuel Type")]
        public string Fuel { get; set; } = null!;

        public string Transmission { get; set; } = null!;
    }
}

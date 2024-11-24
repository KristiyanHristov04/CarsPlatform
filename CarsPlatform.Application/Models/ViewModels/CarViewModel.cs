namespace CarsPlatform.Application.Models.ViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string Colour { get; set; } = null!;

        public int Year { get; set; }

        public int Price { get; set; }

        public string Fuel { get; set; } = null!;

        public string Transmission { get; set; } = null!;
    }
}

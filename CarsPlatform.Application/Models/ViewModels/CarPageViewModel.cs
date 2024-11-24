namespace CarsPlatform.Application.Models.ViewModels
{
    public class CarPageViewModel
    {
        public int? SearchByYear { get; set; }
        public string? Price { get; set; }
        public List<string> Makes { get; set; } = new List<string>();
        public string? Make { get; set; }
        public string? Model { get; set; }
        public List<string> Colours { get; set; } = new List<string>();
        public string? Colour { get; set; }
        public List<string> FuelTypes { get; set; } = new List<string>();
        public string? FuelType { get; set; }
        public List<string> Transmissions { get; set; } = new List<string>();
        public string? Transmission { get; set; }
        public int CarsPerPage { get; } = 10;
        public int TotalCars { get; set; }
        public int CurrentPage { get; set; } = 1;
        public List<CarViewModel> Cars { get; set; } = new List<CarViewModel>();
    }
}

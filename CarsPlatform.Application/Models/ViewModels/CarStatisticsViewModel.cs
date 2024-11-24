namespace CarsPlatform.Application.Models.ViewModels
{
    public class CarStatisticsViewModel
    {
        public Dictionary<string, int> Makes { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> Models { get; set; } = new Dictionary<string, int>();

        public int TotalCarsCount { get; set; }
    }
}

namespace CarsPlatform.Application.Contracts
{
    public interface ICarStatisticsService
    {
        public Dictionary<string, int> GetMakeStatistics();
        public Dictionary<string, int> GetMakeModelsCount();
        public int GetTotalCarsCount();
    }
}

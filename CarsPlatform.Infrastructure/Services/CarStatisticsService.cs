using CarsPlatform.Application.Contracts;
using CarsPlatform.Infrastructure.Data;

namespace CarsPlatform.Infrastructure.Services
{
    public class CarStatisticsService : ICarStatisticsService
    {
        private readonly CarsPlatformDbContext context;
        public CarStatisticsService(CarsPlatformDbContext context)
        {
            this.context = context;
        }

        public Dictionary<string, int> GetMakeStatistics()
        {
            //Nissan -> 50 BMW -> 150 ...
            Dictionary<string, int> makes = this.context.Makes
                .Select(m => new
                {
                    m.MakeName,
                    m.Cars.Count
                }).ToDictionary(k => k.MakeName, v => v.Count);

            return makes;
        }

        public Dictionary<string, int> GetMakeModelsCount()
        {
            Dictionary<string, int> makesModels = this.context.Makes
                .Select(m => new
                {
                    m.MakeName,
                    makeModelsCount = m.Cars
                    .Where(c => c.MakeId == m.Id)
                    .Select(c => c.ModelId)
                    .Distinct()
                    .Count()
                }).ToDictionary(k => k.MakeName, v => v.makeModelsCount);

            return makesModels;
        }

        public int GetTotalCarsCount()
        {
            return this.context.Cars.Count();
        }
    }
}

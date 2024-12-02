using CarsPlatform.Application.Contracts;
using CarsPlatform.Infrastructure.Data;

namespace CarsPlatform.Infrastructure.Services
{
    public class APICarService : IAPICarService
    {
        private readonly CarsPlatformDbContext context;
        public APICarService(CarsPlatformDbContext context)
        {
            this.context = context;
        }

        public List<string> GetModels(string make)
        {
            List<int> validModelIds = this.context.Cars
                .Where(c => c.Make.MakeName == make)
                .Select(c => c.ModelId)
                .Distinct()
                .ToList();

            return this.context.Models
                .Where(m => validModelIds.Contains(m.Id))
                .Select(m => m.ModelName)
                .ToList();
        }

        public Dictionary<string, int> GetMakes()
        {
            Dictionary<string, int> makes = this.context.Makes
                .OrderByDescending(m => m.Cars.Count)
                .Select(m => new
                {
                    m.MakeName,
                    m.Cars.Count
                })
                .Take(6)
                .ToDictionary(k => k.MakeName, v => v.Count);

            return makes;
        }
    }
}

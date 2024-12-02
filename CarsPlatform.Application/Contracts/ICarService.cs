using CarsPlatform.Application.Models.FormModels;
using CarsPlatform.Application.Models.ViewModels;

namespace CarsPlatform.Application.Contracts
{
    public interface ICarService
    {
        public List<CarViewModel> GetCars(string? make, string? model, string? colour, int? year, string? price, string? fuelType, string? transmission, int page, int carsPerPage);
        public int TotalCars(string? make, string? model, string? colour, int? year, string? fuelType, string? transmission);
        public List<string> GetAllMakes();
        public List<string> GetAllColours();
        public List<string> GetAllFuelTypes();
        public List<string> GetAllTransmissions();
        public CarViewModel? GetCarById(int id);
        public void DeleteCarById(int id);
        public void CreateCar(CreateCarFormModel createCarFormModel);
    }
}

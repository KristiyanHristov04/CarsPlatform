using CarsPlatform.Application.Contracts;
using CarsPlatform.Core.Entities;
using CarsPlatform.Application.Models.ViewModels;
using CarsPlatform.Infrastructure.Data;

namespace CarsPlatform.Infrastructure.Services
{
    public class CarService : ICarService
    {
        public readonly CarsPlatformDbContext context;

        public CarService(CarsPlatformDbContext ctx)
        {
            this.context = ctx;
        }

        public List<CarViewModel> GetCars(string? make, string? model, string? colour, int? year, string? price, string? fuelType, string? transmission, int page, int carsPerPage)
        {
            IQueryable<Car> cars = this.context.Cars;


            if (make != null)
            {
                cars = cars.Where(c => c.Make.MakeName == make);
            }

            if (model != null)
            {
                cars = cars.Where(c => c.Model.ModelName == model);
            }

            if (colour != null)
            {
                cars = cars.Where(c => c.Colour.ColourName == colour);
            }

            if (year != null)
            {
                cars = cars.Where(c => c.ReleaseYear == year);
            }


            if (price == "Ascending")
            {
                cars = cars.OrderBy(c => c.Price);
            }
            else if (price == "Descending")
            {
                cars = cars.OrderByDescending(c => c.Price);
            }

            if (fuelType != null)
            {
                cars = cars.Where(c => c.FuelType.FuelTypeName == fuelType);
            }

            if (transmission != null)
            {
                cars = cars.Where(c => c.Transmission.TransmissionType == transmission);
            }

            List<CarViewModel> carsViewModel = cars.Select(c => new CarViewModel()
            {
                Id = c.Id,
                Make = c.Make.MakeName,
                Model = c.Model.ModelName,
                Colour = c.Colour.ColourName,
                Year = c.ReleaseYear,
                Price = c.Price,
                Fuel = c.FuelType.FuelTypeName,
                Transmission = c.Transmission.TransmissionType
            }).Skip((page - 1) * carsPerPage).Take(carsPerPage).ToList();

            return carsViewModel;
        }

        public int TotalCars(string? make, string? model, string? colour, int? year, string? fuelType, string? transmission)
        {
            IQueryable<Car> cars = this.context.Cars;

            if (make != null)
            {
                cars = cars.Where(c => c.Make.MakeName == make);
            }

            if (model != null)
            {
                cars = cars.Where(c => c.Model.ModelName == model);
            }

            if (colour != null)
            {
                cars = cars.Where(c => c.Colour.ColourName == colour);
            }

            if (year != null)
            {
                cars = cars.Where(c => c.ReleaseYear == year);
            }

            if (fuelType != null)
            {
                cars = cars.Where(c => c.FuelType.FuelTypeName == fuelType);
            }

            if (transmission != null)
            {
                cars = cars.Where(c => c.Transmission.TransmissionType == transmission);
            }

            int carsCount = cars.Count();

            return carsCount;
        }

        public List<string> GetAllMakes()
        {
            return this.context.Makes.Select(m => m.MakeName).ToList();
        }

        public List<string> GetAllColours()
        {
            return this.context.Colours.Select(c => c.ColourName).ToList();
        }

        public List<string> GetAllFuelTypes()
        {
            return this.context.FuelTypes.Select(c => c.FuelTypeName).ToList();
        }

        public List<string> GetAllTransmissions()
        {
            return this.context.Transmissions.Select(c => c.TransmissionType).ToList();
        }

        public CarViewModel? GetCarById(int id)
        {
            CarViewModel? carViewModel = this.context.Cars.Select(c => new CarViewModel()
            {
                Id = c.Id,
                Make = c.Make.MakeName,
                Model = c.Model.ModelName,
                Colour = c.Colour.ColourName,
                Year = c.ReleaseYear,
                Price = c.Price,
                Fuel = c.FuelType.FuelTypeName,
                Transmission = c.Transmission.TransmissionType
            }).FirstOrDefault(c => c.Id == id);

            return carViewModel;
        }

        public void DeleteCarById(int id)
        {
            Car carToRemove = this.context.Cars.Find(id)!;
            this.context.Cars.Remove(carToRemove);
            this.context.SaveChanges();
        }
    }
}

using CarsPlatform.Application.Contracts;
using CarsPlatform.Application.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarsPlatform.Web.Controllers
{
    public class CarsController : Controller
    {
        public readonly ICarService carService;
        public CarsController(ICarService carService)
        {
            this.carService = carService;
        }

        [Authorize]
        public IActionResult Index(CarPageViewModel carPageViewModel)
        {
            carPageViewModel.Cars = this.carService.GetCars(carPageViewModel.Make, carPageViewModel.Model, carPageViewModel.Colour, carPageViewModel.SearchByYear, carPageViewModel.Price, carPageViewModel.FuelType, carPageViewModel.Transmission, carPageViewModel.CurrentPage, carPageViewModel.CarsPerPage);
            carPageViewModel.TotalCars = this.carService.TotalCars(carPageViewModel.Make, carPageViewModel.Model, carPageViewModel.Colour, carPageViewModel.SearchByYear, carPageViewModel.FuelType, carPageViewModel.Transmission);
            carPageViewModel.Makes = this.carService.GetAllMakes();
            carPageViewModel.Colours = this.carService.GetAllColours();
            carPageViewModel.FuelTypes = this.carService.GetAllFuelTypes();
            carPageViewModel.Transmissions = this.carService.GetAllTransmissions();
            return View(carPageViewModel);
        }
    }
}

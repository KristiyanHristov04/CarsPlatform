using CarsPlatform.Application.Contracts;
using CarsPlatform.Application.Models.FormModels;
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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            CarViewModel? car = this.carService.GetCarById(id);

            if (car == null)
            {
                return NotFound();
            }

            EditCarFormModel editCarFormModel = new EditCarFormModel();
            editCarFormModel.Makes = this.carService.GetAllMakes();
            editCarFormModel.Colours = this.carService.GetAllColours();
            editCarFormModel.FuelTypes = this.carService.GetAllFuelTypes();
            editCarFormModel.TransmissionTypes = this.carService.GetAllTransmissions();
            editCarFormModel.Make = car.Make;
            editCarFormModel.Model = car.Model;
            editCarFormModel.Colour = car.Colour;
            editCarFormModel.Year = car.Year;
            editCarFormModel.Price = car.Price;
            editCarFormModel.Fuel = car.Fuel;
            editCarFormModel.Transmission = car.Transmission;

            return View(editCarFormModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, EditCarFormModel editCarFormModel)
        {
            if (!ModelState.IsValid)
            {
                return Edit(id);
            }

            this.carService.EditCar(id, editCarFormModel);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateCarFormModel createCarFormModel = new CreateCarFormModel();
            createCarFormModel.Makes = this.carService.GetAllMakes();
            createCarFormModel.Colours = this.carService.GetAllColours();
            createCarFormModel.FuelTypes = this.carService.GetAllFuelTypes();
            createCarFormModel.TransmissionTypes = this.carService.GetAllTransmissions();
            return View(createCarFormModel);
        }

        [HttpPost]
        public IActionResult Create(CreateCarFormModel createCarFormModel)
        {
            if (!ModelState.IsValid)
            {
                return Create();
            }

            this.carService.CreateCar(createCarFormModel);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            CarViewModel? car = this.carService.GetCarById(id);

            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        [HttpPost]
        public IActionResult Delete(CarViewModel carViewModel)
        {
            this.carService.DeleteCarById(carViewModel.Id);

            return RedirectToAction(nameof(Index));
        }
    }
}

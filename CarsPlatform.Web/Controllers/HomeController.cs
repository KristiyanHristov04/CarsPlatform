using CarsPlatform.Application.Contracts;
using CarsPlatform.Application.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarsPlatform.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarStatisticsService carStatisticsService;
      
        public HomeController(ILogger<HomeController> logger, ICarStatisticsService carStatisticsService)
        {
            _logger = logger;
            this.carStatisticsService = carStatisticsService;
        }

        public IActionResult Index()
        {   
            CarStatisticsViewModel carStatisticsViewModel = new CarStatisticsViewModel();
            carStatisticsViewModel.Makes = this.carStatisticsService.GetMakeStatistics();
            carStatisticsViewModel.Models = this.carStatisticsService.GetMakeModelsCount();
            carStatisticsViewModel.TotalCarsCount = this.carStatisticsService.GetTotalCarsCount();

            return View(carStatisticsViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

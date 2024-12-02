using CarsPlatform.Application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarsPlatform.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IAPICarService apiCarService;
        public CarsController(IAPICarService apiCarService)
        {
            this.apiCarService = apiCarService;
        }

        [HttpGet]
        public List<string> GetModels(string make)
        {
            return this.apiCarService.GetModels(make);
        }

        [HttpGet("GetMakes")]
        public Dictionary<string, int> GetMakes()
        {
            return this.apiCarService.GetMakes();
        }
    }
}

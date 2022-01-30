using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarehouseApi.Models;
using WarehouseApi.Services;

namespace WarehouseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task <ActionResult<List<CarBasicModel>>> Get()
        {
            var cars = await _carService.GetAllBasic();
            return Ok(cars);
        }

        [HttpGet("getDetails")]
        public async Task <ActionResult<CarDetailedModel>> GetDetails(int id)
        {
            var car = await _carService.GetDetails(id);
            return Ok(car);
        }
    }
}

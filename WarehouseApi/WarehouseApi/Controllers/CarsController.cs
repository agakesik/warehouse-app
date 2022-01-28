using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarehouseApi.Models;

namespace WarehouseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Car>> Get()
        {
            var car1 = new Car { Id = 1, DateAdded = "2017-11-14", Make = "Maserati", Model = "Coupe", YearModel = 2005, Price = 199572.71M, Licensed = false };
            var car2 = new Car { Id = 2, DateAdded = "2017-12-03", Make = "Isuzu", Model = "Rodeo", YearModel = 1998, Price = 6303.99M, Licensed = false };
            var cars = new List<Car> { car1, car2 };
            return Ok(cars);
        }
    }
}

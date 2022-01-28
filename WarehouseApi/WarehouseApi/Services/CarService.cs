using WarehouseApi.Models;

namespace WarehouseApi.Services
{
    public class CarService : ICarService
    {

        private List<Car> _cars = new List<Car>
        {
            new Car { Id = 1, DateAdded = "2017-11-14", Make = "Maserati", Model = "Coupe", YearModel = 2005, Price = 199572.71M, Licensed = false },
            new Car { Id = 2, DateAdded = "2017-12-03", Make = "Isuzu", Model = "Rodeo", YearModel = 1998, Price = 6303.99M, Licensed = false }
        };


        public async Task<IEnumerable<Car>> GetAll()
        {

            // wrapped in "await Task.Run" to mimic fetching users from a db
            return await Task.Run(() => _cars);
        }
    }
}

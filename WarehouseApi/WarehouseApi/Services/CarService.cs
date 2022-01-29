using WarehouseApi.Data;
using WarehouseApi.Models;

namespace WarehouseApi.Services
{
    public class CarService : ICarService
    {
        private readonly DataContext _dataContext;

        public CarService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _dataContext.Cars.OrderBy(x => x.DateAdded).ToListAsync();
        }
    }
}

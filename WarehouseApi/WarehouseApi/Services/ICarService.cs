using WarehouseApi.Models;

namespace WarehouseApi.Services
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetAll();
    }
}
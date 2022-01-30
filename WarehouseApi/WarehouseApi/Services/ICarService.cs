using WarehouseApi.Models;

namespace WarehouseApi.Services
{
    public interface ICarService
    {
        Task<IEnumerable<CarBasicModel>> GetAllBasic();
    }
}
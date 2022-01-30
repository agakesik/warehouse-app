using WarehouseApi.Models;

namespace WarehouseApi.Services
{
    public interface ICarService
    {
        Task<IEnumerable<CarBasicModel>> GetAllBasic();
        Task<CarDetailedModel> GetDetails(int id);
    }
}
using WarehouseApi.Models;

namespace WarehouseApi.Services
{
    public interface IWarehouseService
    {
        Task<Warehouse> GetById(int id);
    }
}
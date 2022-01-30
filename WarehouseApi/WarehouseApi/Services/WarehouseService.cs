using WarehouseApi.Data;
using WarehouseApi.Models;

namespace WarehouseApi.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly DataContext _dataContext;

        public WarehouseService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Warehouse> GetById(int id)
        {
            return await _dataContext.Warehouses.FindAsync(id);
        }
    }
}

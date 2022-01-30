using AutoMapper;
using WarehouseApi.Data;
using WarehouseApi.Models;

namespace WarehouseApi.Services
{
    public class CarService : ICarService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IWarehouseService _warehouseService;

        public CarService(DataContext dataContext, IMapper mapper, IWarehouseService warehouseService)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _warehouseService = warehouseService;
        }

        public async Task<IEnumerable<CarBasicModel>> GetAllBasic()
        {
            var cars = await _dataContext.Cars.OrderBy(x => x.DateAdded).ToListAsync();
            return _mapper.Map<IEnumerable<CarBasicModel>>(cars);
        }

        public async Task<CarDetailedModel> GetDetails(int id)
        {
            var lookedUpCar = await _dataContext.Cars.FindAsync(id);
            var detailedCar = _mapper.Map<CarDetailedModel>(lookedUpCar);
            var warehouse = await _warehouseService.GetById(lookedUpCar.WarehouseId);
            detailedCar.WarehouseName = warehouse.Name;
            detailedCar.WarehouseLatitude = warehouse.Latitude;
            detailedCar.WarehouseLongitude = warehouse.Longitude;
            return detailedCar;
        }
    }
}

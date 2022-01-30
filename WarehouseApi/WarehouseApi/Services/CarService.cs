using AutoMapper;
using WarehouseApi.Data;
using WarehouseApi.Models;

namespace WarehouseApi.Services
{
    public class CarService : ICarService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public CarService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CarBasicModel>> GetAllBasic()
        {
            var cars = await _dataContext.Cars.OrderBy(x => x.DateAdded).ToListAsync();
            return _mapper.Map<IEnumerable<CarBasicModel>>(cars);
        }
    }
}
